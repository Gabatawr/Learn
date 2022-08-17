namespace Library.Messages;

public interface IMessageContract
{
    public Task SendMessage(Message message);

    public Task SetName(string name);
    public Task<string> GetName();
}