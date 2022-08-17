using System;
using Microsoft.AspNetCore.SignalR.Client;

namespace Client.WPF.Windows.Main;

public partial class MainWindowContext
{
    #region ConnectBtnText

    private const string? ConnectState = "Disconnect";
    private const string? DisconnectState = "Connect";

    private string? _connectBtnText;
    public string? ConnectBtnText
    {
        get => _connectBtnText;
        set => Set(ref _connectBtnText, value);
    }

    private void UpdateConnectBtnText()
    {
        ConnectBtnText = _connection?.Hub.State switch
        {
            HubConnectionState.Disconnected => DisconnectState,
            HubConnectionState.Connected => ConnectState,
            HubConnectionState.Connecting => HubConnectionState.Connecting.ToString(),
            HubConnectionState.Reconnecting => HubConnectionState.Reconnecting.ToString(),
            _ => throw new ArgumentOutOfRangeException()
        } ?? DisconnectState;
    }

    #endregion ConnectBtnText

    #region Name

    private string? _name;

    public string? Name
    {
        get => _name;
        set => Set(ref _name, value);
    }

    #endregion Name

    #region Message

    private string? _message;

    public string? Message
    {
        get => _message;
        set => Set(ref _message, value);
    }

    #endregion Message


}