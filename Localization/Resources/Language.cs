namespace BAS24.Libs.Localization.Resources;

[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
[global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
public class Language
{
    private static global::System.Resources.ResourceManager resourceMan;
    private static global::System.Globalization.CultureInfo resourceCulture;

    [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
    Language()
    {
    }

    [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
    internal static global::System.Resources.ResourceManager ResourceManager
    {
        get
        {
            if (object.ReferenceEquals(resourceMan, null))
            {
                global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("UNTSD.Lib.Localization.Resources.Language", typeof(Language).Assembly);
                resourceMan = temp;
            }
            return resourceMan;
        }
    }

    /// <summary>
    ///   Overrides the current thread's CurrentUICulture property for all
    ///   resource lookups using this strongly typed resource class.
    /// </summary>
    [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
    internal static global::System.Globalization.CultureInfo Culture
    {
        get
        {
            return resourceCulture;
        }
        set
        {
            resourceCulture = value;
        }
    }
}
