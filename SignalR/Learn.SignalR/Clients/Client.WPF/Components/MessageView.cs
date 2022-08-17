using System;
using System.Windows;

namespace Client.WPF.Components;

public class MessageView
{
    public bool IsMy { get; set; }

    public string? Name { get; set; }
    public string? Text { get; set; }

    public DateTime DateTime { get; set; }
}