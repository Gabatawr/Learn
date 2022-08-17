using System.Diagnostics;
using Library;
using Library.Notification;
using Microsoft.AspNetCore.SignalR;

namespace Server.Hubs.Notification;

public class NotificationHub : Hub<INotificationClient>, INotificationContract
{
    private enum Keys
    {
        UserName
    }

    public Task SendMessage(Message message)
    {
        Debug.WriteLine(Context.ConnectionId);

        if (Context.Items.ContainsKey(Keys.UserName))
            message.Title = $"Message from user: {Context.Items[Keys.UserName] as string}";

        return Clients.Others.Send(message);
    }

    public Task SetName(string name)
    {
        Context.Items.TryAdd(Keys.UserName, name);
        return Task.CompletedTask;
    }

    public override Task OnConnectedAsync()
    {
        Clients.Others.Send(new Message
        {
            Title = $"New client connected {Context.ConnectionId}",
            Body = string.Empty
        });

        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        Clients.Others.Send(new Message
        {
            Title = $"Client disconnected {Context.ConnectionId}",
            Body = string.Empty
        });

        return base.OnDisconnectedAsync(exception);
    }

    protected override void Dispose(bool disposing)
    {
        Debug.WriteLine("Hub disposed");
        base.Dispose(disposing);
    }
}