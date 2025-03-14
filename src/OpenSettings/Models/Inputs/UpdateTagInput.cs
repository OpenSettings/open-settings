﻿using System;

namespace OpenSettings.Models.Inputs
{
    public class UpdateTagInput
    {
        public string TagId { get; set; }

        public string Name { get; set; }

        public int SortOrder { get; set; }

        public SetSortOrderPosition? SetSortOrderPosition { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();

        public Guid? UpdatedById { get; set; }
    }
}