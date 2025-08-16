using System;

namespace OpenSettings.Models.Inputs
{
    [Flags]
    public enum GetMeInputIncludes
    {
        None = 0,

        Claims = 1 << 0
    }
}