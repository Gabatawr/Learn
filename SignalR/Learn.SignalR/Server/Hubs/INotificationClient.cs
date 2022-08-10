
using Library;

namespace Server.Hubs;

public interface INotificationClient
{
    Task Send(Message message);
}