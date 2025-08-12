using System;
using System.IO;
using System.Security.Cryptography;

namespace OpenSettings.Helpers
{
#if NETSTANDARD2_0
    public static class RsaPkcs8Helper
    {
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
            writer.Write((byte)0x02);

            if (value[0] >= 0x80)
            {
                // Prepend 0x00 if highest bit is set
                writer.Write((byte)(value.Length + 1));
                writer.Write((byte)0x00);
            }
            else
            {
                writer.Write((byte)value.Length);
            }

            writer.Write(value);
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
            }
            else
            {
                var bytes = BitConverter.GetBytes(length);
                Array.Reverse(bytes);
                var nonZeroBytes = Array.FindAll(bytes, b => b != 0);
                writer.Write((byte)(0x80 | nonZeroBytes.Length));
                writer.Write(nonZeroBytes);
            }
        }
    }
#endif
}