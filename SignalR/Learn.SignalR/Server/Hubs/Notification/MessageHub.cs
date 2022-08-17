using System.Diagnostics;
using Library;
using Library.Messages;
using Microsoft.AspNetCore.SignalR;

namespace Server.Hubs.Notification;

public class MessageHub : Hub<IMessageClient>, IMessageContract
{
    private enum Keys
    {
        UserName
    }

    public Task SendMessage(Message message)
    {
        Debug.WriteLine(Context.ConnectionId);

        if (Context.Items.ContainsKey(Keys.UserName))
            message.Sender = Context.Items[Keys.UserName] as string;

        return Clients.Others.Send(message);
    }

    public Task SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Task.CompletedTask;

        Context.Items.TryAdd(Keys.UserName, name);
        return Task.CompletedTask;
    }

    public Task<string> GetName() =>
        Context.Items.ContainsKey(Keys.UserName) 
            ? Task.FromResult(Context.Items[Keys.UserName] as string)!
            : Task.FromResult(Message.DefaultSender);

    public override Task OnConnectedAsync()
    {
        Clients.Others.Send(new Message
        {
            Sender = "Server",
            Info = $"New client connected {Context.ConnectionId}",
        });

        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        Clients.Others.Send(new Message
        {
            Sender = "Server",
            Info = $"Client disconnected {Context.ConnectionId}",
        });

        return base.OnDisconnectedAsync(exception);
    }

    protected override void Dispose(bool disposing)
    {
        Debug.WriteLine("Hub disposed");
        base.Dispose(disposing);
    }
}