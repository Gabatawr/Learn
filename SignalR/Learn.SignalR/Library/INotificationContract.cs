namespace Library;

public interface INotificationContract
{
    public Task SendMessage(Message message);

    public Task SetName(string name);
}