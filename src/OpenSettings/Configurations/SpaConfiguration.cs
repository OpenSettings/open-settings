using System;
using System.IO;

namespace OpenSettings.Configurations
{
    /// <summary>
    /// Represents the configuration options for the open settings Spa page.
    /// <para>This class allows customization of various settings related to the page behavior and appearance.</para>
    /// <para>It includes properties for managing the index stream and document title, among other settings.</para>
    /// </summary>
    public class SpaConfiguration
    {
        private string _routePrefix = OpenSettingsDefaults.Spa.DefaultRoutePrefix;

        /// <summary>
        /// Specifies the prefix used to access the open settings Spa page.  
        /// <para>With this prefix, the open settings Spa page can be accessed through the defined route.</para>
        /// </summary>
        /// <remarks>
        /// The default value is '<c>settings</c>'.
        /// </remarks>
        /// <exception cref="Exception">Throws an exception when assigned null or whitespace.</exception>
        public string RoutePrefix
        {
            get => _routePrefix;
            set
            {
                if (value == null || value == " ")
                {
                    throw new Exception("RoutePrefix can not be null or whitespace!");
                }

                if (value != string.Empty)
                {
                    value = value.TrimStart(OpenSettingsDefaults.Format.SlashChar).TrimEnd(OpenSettingsDefaults.Format.SlashChar);
                }

                _routePrefix = value;
            }
        }

        /// <summary>
        /// Gets or sets a function that returns a <see cref="Stream"/> representing the index HTML file for the open settings spa.  
        /// <para>This function retrieves the embedded resource stream for the specified HTML file.</para>
        /// <para>The default implementation uses the <c>OpenSettings.AspNetCore.Spa</c> type's assembly to access the embedded resource.</para>
        /// </summary>
        public Func<Stream> IndexStream { get; set; }

        /// <summary>
        /// Gets or sets the title of the document for the open settings page.  
        /// <para>This title is used in the HTML document's title element and will be displayed in the browser's title bar.</para>
        /// </summary>
        /// <remarks>
        /// The default value is '<c><see cref="OpenSettingsDefaults.Spa.DefaultDocumentTitle"/></c>'.
        /// </remarks>
        public string DocumentTitle { get; set; } = OpenSettingsDefaults.Spa.DefaultDocumentTitle;

        /// <summary>
        /// Gets or sets a value indicating whether the open settings Spa (Single Page Application) is active.
        /// The default value is <c>true</c>.
        /// </summary>
        /// <remarks>
        /// Setting this property to <c>true</c> does not guarantee that the Spa will be accessible.
        /// Make sure to register <c>AddOpenSettingsController(...)</c> and <c>app.UseOpenSettings(...)</c> after <c>UseRouting()</c> and before <c>UseEndpoints()</c>.
        /// </remarks>
        public bool IsActive { get; set; } = true;
    }
}