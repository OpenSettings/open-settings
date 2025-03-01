using System;
using System.IO;
using System.Reflection;

namespace OpenSettings.AspNetCore.Spa
{
    /// <summary>
    /// Represents the configuration options for the OpenSettings page.
    /// <para>This class allows customization of various settings related to the page behavior and appearance.</para>
    /// <para>It includes properties for managing the index stream and document title, among other settings.</para>
    /// </summary>
    public class SettingsSpaOptions
    {
        private string _routePrefix = Constants.DefaultSpaRoutePrefix;

        /// <summary>
        /// Specifies the prefix used to access the OpenSettings page.  
        /// <para>The default value is '<c>settings</c>'.</para>
        /// <para>With this prefix, the OpenSettings page can be accessed through the defined route.</para>
        /// </summary>
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
                    value = value.TrimStart('/').TrimEnd('/');
                }

                _routePrefix = value;
            }
        }

        /// <summary>
        /// Gets or sets a function that returns a <see cref="Stream"/> representing the index HTML file for the open settings spa.  
        /// <para>This function retrieves the embedded resource stream for the specified HTML file.</para>
        /// <para>The default implementation uses the <see cref="SettingsSpaOptions"/> type's assembly to access the embedded resource.</para>
        /// </summary>
        public Func<Stream> IndexStream { get; set; } = () => typeof(SettingsSpaOptions).GetTypeInfo().Assembly.GetManifestResourceStream(Constants.EmbeddedIndexHtmlFileNamespace);

        /// <summary>
        /// Gets or sets the title of the document for the settings page.  
        /// <para>The default value is '<c>OpenSettings Spa</c>'.</para>
        /// <para>This title is used in the HTML document's title element and will be displayed in the browser's title bar.</para>
        /// </summary>
        public string DocumentTitle { get; set; } = Constants.DefaultDocumentTitle;
    }
}