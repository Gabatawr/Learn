namespace Library.Notification;

public interface INotificationContract
{
    public Task SendMessage(Message message);

    public Task SetName(string name);
}