using System;

namespace OpenSettings.Attributes
{
    /// <summary>
    /// Specifies that the decorated property should not be exposed or displayed in the spa page.
    /// This attribute can be used to hide sensitive or internal data from UI bindings or editors.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class SecretTextAttribute : Attribute
    {
    }
}