using System;

namespace OpenSettings.Models.Inputs
{
    public class CreateAppInputClient
    {
        public string Name { get; set; }

        public Guid Id { get; set; }

        public Guid Secret { get; set; }
    }
}