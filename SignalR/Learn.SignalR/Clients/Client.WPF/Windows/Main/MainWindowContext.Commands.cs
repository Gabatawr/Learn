using Client.WPF.Common;

namespace Client.WPF.Windows.Main;

public partial class MainWindowContext
{
    #region ConnectClickCommand

    private RelayCommand? _connectClickCommand;
    public RelayCommand ConnectClickCommand =>
        _connectClickCommand ??= new RelayCommand(_ =>
        {

        });

    #endregion ConnectClickCommand

    #region SetNameCommand

    private RelayCommand? _setNameCommand;
    public RelayCommand SetNameCommand =>
        _setNameCommand ??= new RelayCommand(_ =>
        {

        });

    #endregion SetNameCommand

    #region GetNameCommand

    private RelayCommand? _getNameCommand;
    public RelayCommand GetNameCommand =>
        _getNameCommand ??= new RelayCommand(_ =>
        {

        });

    #endregion GetNameCommand

    #region SendMessageCommand

    private RelayCommand? _sendMessageCommand;
    public RelayCommand SendMessageCommand =>
        _sendMessageCommand ??= new RelayCommand(_ =>
        {

        });

    #endregion SendMessageCommand
}