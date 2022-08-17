using System.Windows;
using Client.WPF.Common;

namespace Client.WPF.Windows.Main;

public partial class MainWindow : Window
{
    public MainWindowContext? Context => DataContext as MainWindowContext;

    public MainWindow() => InitializeComponent();
}