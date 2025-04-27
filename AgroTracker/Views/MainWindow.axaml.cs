using AgroTracker.ViewModels;
using Avalonia.Controls;

namespace AgroTracker.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }
}
