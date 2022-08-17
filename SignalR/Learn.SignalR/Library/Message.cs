namespace Library;

public class Message
{
    public const string DefaultSender = "Anonymous";

    public string? Sender { get; set; }
    public string? Info { get; set; }
    public string? Body { get; set; }

    public Message() => Sender = DefaultSender;

    public Message(string? body)
    : this()
    {
        if (string.IsNullOrWhiteSpace(body) is false)
            Body = body;
    }
}