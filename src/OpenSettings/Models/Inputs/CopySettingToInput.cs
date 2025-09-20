using System;

namespace OpenSettings.Models.Inputs
{
    public class CopySettingToInput
    {
        public Guid AppSettingId { get; set; }

        public Guid TargetAppId { get; set; }

        /// <summary>
        /// IdentifierId can be null, then IdentifierName will be created
        /// </summary>
        public Guid? IdentifierId { get; set; }

        /// <summary>
        /// If IdentifierName and IdentifierId is empty then return an error
        /// </summary>
        public string IdentifierName { get; set; }

        public Guid? UserId { get; set; }
    }
}