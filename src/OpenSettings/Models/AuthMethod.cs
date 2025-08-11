using System.Runtime.Serialization;

namespace OpenSettings.Models
{
    public enum AuthMethod
    {
        Unset = 0,

        Basic = 1,

        Jwt = 2,

        Cookie = 3,
    }
}