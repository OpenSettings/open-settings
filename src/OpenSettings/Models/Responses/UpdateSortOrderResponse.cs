using System;

namespace OpenSettings.Models.Responses
{
    public class UpdateSortOrderResponse
    {
        public UpdateSortOrderResponseSource Source { get; set; }

        public UpdateSortOrderResponseNeighbour Neighbour { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}