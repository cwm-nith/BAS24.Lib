using BAS24.Libs.CQRS.Events;

namespace BAS24.Libs.CQRS.Messages;

public interface IRejectedEvent:IEvent
{
    string Reason { get; }
    string Code { get; }
}