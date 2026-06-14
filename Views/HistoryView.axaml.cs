using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ScreenBreak.Models;
using ScreenBreak.Services;
using System.Collections.Generic;

namespace ScreenBreak.Views;

public partial class HistoryView : UserControl
{
    public HistoryView()
    {
        InitializeComponent();
        LoadHistory();
    }

    public void LoadHistory()
    {
        HistoryService historyService = new HistoryService();
        List<SessionRecord> records = historyService.LoadHistory();
        HistoryItemsControl.ItemsSource = records;
    }
}