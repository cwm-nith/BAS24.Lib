namespace BAS24.Libs.CQRS.Messages;

[AttributeUsage(AttributeTargets.Class)]
public class MessageNamespaceAttribute:Attribute
{
    public string Namespace { get; }

    public MessageNamespaceAttribute(string @namespace)
    {
        Namespace = @namespace?.ToLowerInvariant() ?? string.Empty;
    }
}