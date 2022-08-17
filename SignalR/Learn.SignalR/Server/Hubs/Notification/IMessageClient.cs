
using Library;

namespace Server.Hubs.Notification;

public interface IMessageClient
{
    Task Send(Message message);
}