using Microsoft.AspNetCore.SignalR.Client;

namespace Library.Messages;

public class MessageHubConnection : IMessageContract
{
    public readonly HubConnection Hub;

    public MessageHubConnection(string url, Action<Message> messageHandler)
    {
        Hub = new HubConnectionBuilder()
            .WithUrl($"{url}/messages")
            .WithAutomaticReconnect()
            .Build();

        Hub.On("Send", messageHandler);
    }

    public Task SendMessage(Message message) =>
        Hub.SendAsync(nameof(SendMessage), message);

    public Task SetName(string name) =>
        Hub.SendAsync(nameof(SetName), name);

    public Task<string> GetName() =>
        Hub.InvokeAsync<string>(nameof(GetName));
}