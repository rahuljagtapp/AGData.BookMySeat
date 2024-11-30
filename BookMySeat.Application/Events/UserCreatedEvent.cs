using MediatR;

namespace AGData.BookMySeat.Application.Events
{
    public record UserCreatedEvent(Guid UserId) : INotification;

}
