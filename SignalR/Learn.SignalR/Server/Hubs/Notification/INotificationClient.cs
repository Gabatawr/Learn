
using Library;

namespace Server.Hubs.Notification;

public interface INotificationClient
{
    Task Send(Message message);
}