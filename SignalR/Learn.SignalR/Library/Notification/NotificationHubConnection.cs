using Microsoft.AspNetCore.SignalR.Client;

namespace Library.Notification;

public class NotificationHubConnection : INotificationContract
{
    private readonly HubConnection _hub;

    public NotificationHubConnection(string url, Action<Message> messageHandler)
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