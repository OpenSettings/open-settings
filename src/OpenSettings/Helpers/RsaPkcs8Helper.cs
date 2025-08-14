#if NETSTANDARD2_0

using System;
using System.IO;
using System.Security.Cryptography;

namespace OpenSettings.Helpers
{
    public static class RsaPkcs8Helper
    {
        private static readonly byte[] RsaOid = new byte[] { 0x2a, 0x86, 0x48, 0x86, 0xf7, 0x0d, 0x01, 0x01, 0x01 }; // 1.2.840.113549.1.1.1

        public static void ImportPkcs8PrivateKey(this RSA rsa, byte[] pkcs8Der, out int bytesRead)
        {
            using (var reader = new BinaryReader(new MemoryStream(pkcs8Der, false)))
            {
                using (var pkcs8Seq = ReadSequence(reader))               // PrivateKeyInfo ::= SEQUENCE { ... }
                {
                    var startPos = reader.BaseStream.Position;

                    // version INTEGER (0)
                    var version = ReadInteger(pkcs8Seq);

                    if (version.Length != 1 || version[0] != 0x00)
                    {
                        throw new CryptographicException("Invalid PKCS#8 version.");
                    }

                    // AlgorithmIdentifier ::= SEQUENCE { algorithm OID, parameters NULL }
                    using (var algId = ReadSequence(pkcs8Seq))
                    {
                        var oid = ReadOid(algId);

                        if (!BytesEqual(oid, RsaOid))
                        {
                            throw new CryptographicException("Not an RSA PKCS#8 key.");
                        }

                        TryReadNull(algId); // parameters (usually NULL). If absent, that's fine.
                        EnsureEof(algId);
                    }

                    // PrivateKey OCTET STRING -> contains RSAPrivateKey (PKCS#1)
                    var innerPkcs1 = ReadOctetString(pkcs8Seq);
                    EnsureEof(pkcs8Seq);

                    // Decode PKCS#1
                    var rsaParameters = DecodePkcs1(innerPkcs1);
                    rsa.ImportParameters(rsaParameters);

                    bytesRead = (int)(reader.BaseStream.Position - startPos);
                }

                bytesRead = (int)reader.BaseStream.Position;
            }
        }

        // ---------- PKCS#1 decode ----------
        private static RSAParameters DecodePkcs1(byte[] pkcs1Der)
        {
            using (var reader = new BinaryReader(new MemoryStream(pkcs1Der, false)))
            {
                using (var seq = ReadSequence(reader))   // RSAPrivateKey ::= SEQUENCE
                {
                    var ver = ReadInteger(seq); // 0 or 1
                    var n = ReadInteger(seq);
                    var e = ReadInteger(seq);
                    var d = ReadInteger(seq);
                    var p = ReadInteger(seq);
                    var q = ReadInteger(seq);
                    var dp = ReadInteger(seq);
                    var dq = ReadInteger(seq);
                    var iq = ReadInteger(seq);
                    EnsureEof(seq);

                    return new RSAParameters
                    {
                        Modulus = n,
                        Exponent = e,
                        D = d,
                        P = p,
                        Q = q,
                        DP = dp,
                        DQ = dq,
                        InverseQ = iq
                    };
                }
            }
        }

        // ---------- Minimal DER helpers ----------
        private static BinaryReader ReadSequence(BinaryReader br)
        {
            ExpectTag(br, 0x30); // SEQUENCE
            var length = ReadLength(br);
            var content = br.ReadBytes(length);
            return new BinaryReader(new MemoryStream(content, false));
        }

        private static byte[] ReadInteger(BinaryReader br)
        {
            ExpectTag(br, 0x02); // INTEGER
            var length = ReadLength(br);
            var bytes = br.ReadBytes(length);

            // strip optional leading 0x00 (sign byte)
            if (bytes.Length > 1 && bytes[0] == 0x00)
            {
                var tmp = new byte[bytes.Length - 1];
                Buffer.BlockCopy(bytes, 1, tmp, 0, tmp.Length);
                bytes = tmp;
            }

            return bytes;
        }

        private static byte[] ReadOctetString(BinaryReader br)
        {
            ExpectTag(br, 0x04); // OCTET STRING
            var length = ReadLength(br);
            return br.ReadBytes(length);
        }

        private static byte[] ReadOid(BinaryReader br)
        {
            ExpectTag(br, 0x06); // OBJECT IDENTIFIER
            var length = ReadLength(br);
            return br.ReadBytes(length); // content only
        }

        private static void TryReadNull(BinaryReader br)
        {
            if (!HasData(br))
            {
                return;
            }

            var b = br.PeekChar(); // safe here; content bytes are < 0x80

            if (b != 0x05)
            {
                return; // not NULL
            }

            br.ReadByte(); // tag

            var length = ReadLength(br);

            if (length != 0)
            {
                throw new CryptographicException("Invalid NULL parameters.");
            }
        }

        private static bool HasData(BinaryReader br)
        {
            return br.BaseStream.Position < br.BaseStream.Length;
        }

        private static void EnsureEof(BinaryReader br)
        {
            if (HasData(br))
            {
                throw new CryptographicException("Extra data at end of ASN.1 structure.");
            }
        }

        private static void ExpectTag(BinaryReader br, byte expected)
        {
            int actual = br.ReadByte();

            if (actual != expected)
            {
                throw new CryptographicException($"ASN.1: expected tag 0x{expected:X2}, got 0x{actual:X2}.");
            }
        }

        private static int ReadLength(BinaryReader br)
        {
            int b = br.ReadByte();

            if (b < 0x80)
            {
                return b;
            }

            var count = b & 0x7F;

            if (count == 0 || count > 4)
            {
                throw new CryptographicException("Invalid DER length.");
            }

            var length = 0;

            for (var i = 0; i < count; i++)
            {
                length = (length << 8) | br.ReadByte();
            }

            return length;
        }

        private static bool BytesEqual(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
            {
                return false;
            }

            for (var i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static byte[] ExportPkcs8PrivateKey(this RSA rsa)
        {
            var rsaParams = rsa.ExportParameters(true);
            var pkcs1 = EncodePkcs1PrivateKey(rsaParams);
            return EncodePkcs8PrivateKey(pkcs1);
        }

        private static byte[] EncodePkcs1PrivateKey(RSAParameters parameters)
        {
            using (var ms = new MemoryStream())
            {
                using (var writer = new BinaryWriter(ms))
                {
                    WriteAsn1Sequence(writer, w =>
                    {
                        WriteAsn1Integer(w, new byte[] { 0x00 }); // Version
                        WriteAsn1Integer(w, parameters.Modulus);
                        WriteAsn1Integer(w, parameters.Exponent);
                        WriteAsn1Integer(w, parameters.D);
                        WriteAsn1Integer(w, parameters.P);
                        WriteAsn1Integer(w, parameters.Q);
                        WriteAsn1Integer(w, parameters.DP);
                        WriteAsn1Integer(w, parameters.DQ);
                        WriteAsn1Integer(w, parameters.InverseQ);
                    });

                    return ms.ToArray();
                }
            }
        }

        private static byte[] EncodePkcs8PrivateKey(byte[] pkcs1PrivateKey)
        {
            using (var ms = new MemoryStream())
            using (var writer = new BinaryWriter(ms))
            {
                WriteAsn1Sequence(writer, w =>
                {
                    WriteAsn1Integer(w, new byte[] { 0x00 }); // Version

                    // AlgorithmIdentifier sequence
                    WriteAsn1Sequence(w, w2 =>
                    {
                        WriteAsn1ObjectIdentifier(w2, new byte[] { 0x2a, 0x86, 0x48, 0x86, 0xf7, 0x0d, 0x01, 0x01, 0x01 }); // rsaEncryption OID
                        WriteAsn1Null(w2);
                    });

                    // PrivateKey OCTET STRING
                    WriteAsn1OctetString(w, pkcs1PrivateKey);
                });

                return ms.ToArray();
            }
        }

        // Basic ASN.1 writers
        private static void WriteAsn1Sequence(BinaryWriter writer, Action<BinaryWriter> writeContent)
        {
            using (var contentStream = new MemoryStream())
            {
                using (var contentWriter = new BinaryWriter(contentStream))
                {
                    writeContent(contentWriter);
                    var content = contentStream.ToArray();
                    writer.Write((byte)0x30);
                    WriteLength(writer, content.Length);
                    writer.Write(content);
                }
            }
        }

        private static void WriteAsn1Integer(BinaryWriter writer, byte[] value)
        {
            writer.Write((byte)0x02); // INTEGER

            // Strip leading 0x00 padding
            var offset = 0;

            while (offset < value.Length - 1 && value[offset] == 0x00)
            {
                offset++;
            }

            var contentLength = value.Length - offset;

            // If the high bit of the first content byte is set, prepend 0x00
            var prependZero = (contentLength > 0 && (value[offset] & 0x80) != 0);
            var totalLength = contentLength + (prependZero ? 1 : 0);

            WriteLength(writer, totalLength);

            if (prependZero)
            {
                writer.Write((byte)0x00);
            }

            writer.Write(value, offset, contentLength);
        }

        private static void WriteAsn1OctetString(BinaryWriter writer, byte[] value)
        {
            writer.Write((byte)0x04); // OCTET STRING
            WriteLength(writer, value.Length);
            writer.Write(value);
        }

        private static void WriteAsn1Null(BinaryWriter writer)
        {
            writer.Write((byte)0x05); // NULL
            writer.Write((byte)0x00);
        }

        private static void WriteAsn1ObjectIdentifier(BinaryWriter writer, byte[] oid)
        {
            writer.Write((byte)0x06); // OBJECT IDENTIFIER
            WriteLength(writer, oid.Length);
            writer.Write(oid);
        }

        private static void WriteLength(BinaryWriter writer, int length)
        {
            if (length < 128)
            {
                writer.Write((byte)length);
                return;
            }

            // Encode in big-endian minimal bytes
            var tmp = new byte[4];
            var count = 0;
            for (var i = 3; i >= 0; i--)
            {
                var b = (byte)(length >> (i * 8));

                if (count == 0 && b == 0)
                {
                    continue; // skip leading zeros
                }

                tmp[count++] = b;
            }

            writer.Write((byte)(0x80 | count));
            writer.Write(tmp, 0, count);
        }
    }
}
#endif