using System;
using System.Windows;
using Client.WPF.Common;
using Client.WPF.Components;
using Library;
using Microsoft.AspNetCore.SignalR.Client;

namespace Client.WPF.Windows.Main;

public partial class MainWindowContext
{
    #region ConnectClickCommand

    private RelayCommand? _connectClickCommand;
    public RelayCommand ConnectClickCommand =>
        _connectClickCommand ??= new RelayCommand(async _ =>
        {
            if (_connection == null) 
                return;

            switch (_connection.Hub.State)
            {
                case HubConnectionState.Disconnected:
                {
                    try
                    { await _connection.Hub.StartAsync(); }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message); }
                    break;
                }
                case HubConnectionState.Connected:
                {
                    await _connection.Hub.StopAsync();
                    break;
                }
            }

            UpdateConnectBtnText();
        });

    #endregion ConnectClickCommand

    #region SetNameCommand

    private RelayCommand? _setNameCommand;
    public RelayCommand SetNameCommand =>
        _setNameCommand ??= new RelayCommand(async _ =>
        {
            if (_connection == null || _connection.Hub.State != HubConnectionState.Connected)
                return;

            if (string.IsNullOrWhiteSpace(Name))
                return;

            try { await _connection.SetName(Name); }
            catch (Exception ex) 
            { MessageBox.Show(ex.Message); }
        });

    #endregion SetNameCommand

    #region GetNameCommand

    private RelayCommand? _getNameCommand;
    public RelayCommand GetNameCommand =>
        _getNameCommand ??= new RelayCommand(async _ =>
        {
            if (_connection == null || _connection.Hub.State != HubConnectionState.Connected)
                return;

            try { Name = await _connection.GetName(); }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        });

    #endregion GetNameCommand

    #region SendMessageCommand

    private RelayCommand? _sendMessageCommand;
    public RelayCommand SendMessageCommand =>
        _sendMessageCommand ??= new RelayCommand(async _ =>
        {
            if (_connection == null || _connection.Hub.State != HubConnectionState.Connected)
                return;

            try
            {
                await _connection.SendMessage(new Message(Message));
                MessageCollection.Add(new MessageView
                {
                    IsOwnMessage = true,
                    Sender = Name,
                    Body = Message
                });
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            finally { Message = string.Empty; }
        });

    #endregion SendMessageCommand
}