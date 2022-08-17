using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using Client.WPF.Common;
using Client.WPF.Components;
using Library.Messages;

namespace Client.WPF.Windows.Main;

[MarkupExtensionReturnType(typeof(MainWindowContext))]
public partial class MainWindowContext : BaseContext
{
    public ObservableCollection<MessageView> MessageCollection { get; set; }
    
    private MessageHubConnection? _connection;
    public MainWindowContext()
    {
        MessageCollection = new ObservableCollection<MessageView>();
        InitConnection(5127);
    }

    private void InitConnection(int port)
    {
        _connection = new($"http://localhost:{port}", message =>
            MessageCollection.Add(new MessageView(message)));

        _connection.Hub.Closed += ex =>
        {
            UpdateConnectBtnText();
            MessageBox.Show($"Connection closed. {ex?.Message}");
            return Task.CompletedTask;
        };

        _connection.Hub.Reconnected += id =>
        {
            UpdateConnectBtnText();
            MessageBox.Show($"Connection reconnected with id: {id}");
            return Task.CompletedTask;
        };

        _connection.Hub.Reconnecting += ex =>
        {
            UpdateConnectBtnText();
            MessageBox.Show($"Connection reconnecting. {ex?.Message}");
            return Task.CompletedTask;
        };

        UpdateConnectBtnText();
    }
}