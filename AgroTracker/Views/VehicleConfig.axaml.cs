using AgroTracker.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AgroTracker.Views;

public partial class VehicleConfig : UserControl
{
    public VehicleConfig()
    {
        InitializeComponent();
        DataContext = new VehicleConfigViewModel();
    }
}