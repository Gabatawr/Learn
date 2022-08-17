namespace Client.WPF.Windows.Main;

public partial class MainWindowContext
{
    #region State

    private string? _state;

    public string? State
    {
        get => _state;
        set => Set(ref _state, value);
    }

    #endregion State

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