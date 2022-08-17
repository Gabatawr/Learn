using System;
using System.Collections.ObjectModel;
using System.Windows.Markup;
using Client.WPF.Common;
using Client.WPF.Components;

namespace Client.WPF.Windows.Main;

[MarkupExtensionReturnType(typeof(MainWindowContext))]
public partial class MainWindowContext : BaseContext
{
    public ObservableCollection<MessageView>? MessageCollection { get; set; }
    
    public MainWindowContext()
    {
        MessageCollection = new();
        MessageCollection.Add(new MessageView()
        {
            IsMy = true,
            Name = "Owner",
            Text = "Message",
            DateTime = DateTime.Now
        });
        MessageCollection.Add(new MessageView()
        {
            IsMy = false,
            Name = "Target",
            Text = "Message Message Message Message Message Message Message Message Message Message",
            DateTime = DateTime.Now
        });

        State = "Disconnect";
    }
}