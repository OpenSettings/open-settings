using OpenSettings.Models;
using System;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class UpdateSortOrderRequestBody
    {
        public MoveDirection Direction { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}