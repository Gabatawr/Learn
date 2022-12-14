using Library;
using Library.Messages;

namespace Client.CLI;

internal class Program
{
    private static MessageHubConnection? _connection;

    private static async Task Main(string[] args)
    {
        Console.Title = "Client.CLI";

        await InitConnection(5127);
        
        var isExit = false;
        while (isExit == false)
        {
            Console.WriteLine("Enter your message or command:");

            var userInput = Console.ReadLine();

            switch (userInput)
            {
                case "!exit":
                {
                    isExit = true;
                    break;
                }
                case "!setname":
                {
                    Console.WriteLine("Enter your name:");

                    var name = Console.ReadLine();
                    if (string.IsNullOrEmpty(name)) continue;

                    await _connection!.SetName(name);

                    Console.WriteLine("Name saved\n");
                    break;
                }
                default:
                {
                    var message = new Message
                    {
                        Info = "Console client",
                        Body = userInput
                    };

                    await _connection!.SendMessage(message);

                    Console.WriteLine("Message sent\n");
                    break;
                }
            }
        }

        Console.ReadKey();
    }

    private static Task InitConnection(int port)
    {
        _connection = new($"http://localhost:{port}", message =>
        {
            Console.WriteLine($"\n{DateTime.Now:T} New message from {message.Sender}");
            Console.WriteLine($"Info   : {message.Info}");
            Console.WriteLine($"Body   : {message.Body}");

            Console.WriteLine("\nEnter your message or command:");
        });

        return _connection.Hub.StartAsync();
    }
}