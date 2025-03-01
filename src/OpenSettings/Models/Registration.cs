using Microsoft.Extensions.Options;
using System;

namespace OpenSettings.Models
{
    /// <summary>
    /// Specifies how single settings file ( separate setting files should be configured its own setting or setting class ) can be registered and resolved within the service.
    /// Supports resolving via configuration options or as a singleton service.
    /// </summary>
    [Flags]
    public enum RegistrationMode
    {
        /// <summary>
        /// Settings can be resolved through configuration options interfaces,
        /// such as <see cref="IOptions{TOptions}"/>, <see cref="IOptionsSnapshot{TOptions}"/> or <see cref="IOptionsMonitor{TOptions}"/>.
        /// </summary>
        Configure = 0x01,

        /// <summary>
        /// Settings can be resolved directly through its own class as a singleton instance.
        /// </summary>
        Singleton = 0x02,

        /// <summary>
        /// Settings can be resolved both through singleton instances and through
        /// configuration options interfaces
        /// such as <see cref="IOptions{TOptions}"/>, <see cref="IOptionsSnapshot{TOptions}"/> or <see cref="IOptionsMonitor{TOptions}"/>.
        /// </summary>
        Both = Singleton | Configure 
    }
}