using System;

namespace OpenSettings.Models.Inputs
{
    public class CreateSettingInput
    {
        public string AppId { get; set; }

        public string IdentifierId { get; set; }

        public Guid ComputedIdentifier { get; set; }

        public string ClassNamespace { get; set; }

        public string ClassName { get; set; }

        public string ClassFullName { get; set; }

        public string Data { get; set; }

        public Guid? CreatedById { get; set; }

        public bool StoreInSeparateFile { get; set; }

        public bool? IgnoreOnFileChange { get; set; }

        public RegistrationMode RegistrationMode { get; set; }
    }
}