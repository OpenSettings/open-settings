namespace OpenSettings.AspNetCore.Services.Interfaces
{
    /// <summary>
    /// Provides functionality to resolve the Urls for the current instance of the application.
    /// This interface defines a contract for services that can determine the Urls
    /// where the application is accessible.
    /// </summary>
    public interface IInstanceUrlResolverService
    {
        /// <summary>
        /// Resolves the Urls for the current instance of the application.
        /// This method retrieves a collection of Urls that the application is 
        /// accessible through, such as base addresses or endpoints.
        /// </summary>
        /// <returns>
        /// An array of strings representing the Urls of the current instance.
        /// Each string in the array is a full Url (e.g., "http://ipaddress:5000").
        /// </returns>
        string[] ResolveUrls();
    }
}