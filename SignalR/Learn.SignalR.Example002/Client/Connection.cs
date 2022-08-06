using Library;
using Microsoft.AspNetCore.SignalR.Client;

namespace Client;

public class Connection : INotificationContract
{
    private readonly HubConnection _hub;

    public Connection(string url, Action<Message> messageHandler)
    {
        _hub = new HubConnectionBuilder()
            .WithUrl($"{url}/notification")
            .Build();

        _hub.On("Send", messageHandler);
    }

    public Task StartAsync() => _hub.StartAsync();

    public Task SendMessage(Message message) =>
        _hub.SendAsync(nameof(SendMessage), message);

    public Task SetName(string name) =>
        _hub.SendAsync(nameof(SetName), name);
}