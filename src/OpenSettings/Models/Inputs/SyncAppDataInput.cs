using System;
using System.Collections.Generic;

namespace OpenSettings.Models.Inputs
{
    public class SyncAppDataInput
    {
        public SyncAppDataInputClient Client { get; set; }

        public AppType AppType { get; set; }

        private string _identifierName = Constants.DefaultIdentifierName;

        public string IdentifierName
        {
            get => _identifierName;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _identifierName = value;
                }
            }
        }

        public SyncAppDataInputConfiguration Configuration { get; set; }

        public ICollection<SyncAppDataInputSetting> Settings { get; set; } = Array.Empty<SyncAppDataInputSetting>();

        public SyncAppDataInputInstance Instance { get; set; }

        public Guid? UserId { get; set; }
    }
}