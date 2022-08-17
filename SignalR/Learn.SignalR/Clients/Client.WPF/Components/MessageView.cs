using System;
using Library;

namespace Client.WPF.Components;

public class MessageView : Message
{
    public bool IsOwnMessage { get; set; }
    public DateTime DateTime { get; set; }

    public MessageView() => DateTime = DateTime.Now;

    public MessageView(Message message)
    : this()
    {
        Sender = message.Sender;
        Info = message.Info;
        Body = message.Body;
    }
}