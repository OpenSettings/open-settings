using OpenSettings.Models;
using System;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class DragItemSortOrderRequestBody
    {
        public MoveDirection Direction { get; set; }

        public byte[] SourceRowVersion { get; set; } = Array.Empty<byte>();
    }
}