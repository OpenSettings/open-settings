namespace OpenSettings.Services.Interfaces
{
    /// <summary>
    /// Marker interface used by the OpenSettings library to identify class as part of the settings
    /// <para>The <see cref="ISettings"/> interface is a core part of the OpenSettings system. Only classes that implement this interface are treated as settings and are recognized by the library as requiring centralized management.</para>
    /// <para>If a class does not implement this interface, it will not be treated as a setting, and the library will not perform.</para>
    /// <para>This interface is essential for identifying classes that require configuration management, ensuring that the OpenSettings library can handle them appropriately and manage their state within the system.</para>
    /// </summary>
    public interface ISettings { }
}