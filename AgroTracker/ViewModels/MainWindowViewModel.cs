using Avalonia.Media.Imaging;
using Avalonia.Media;
using Avalonia.Platform;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using AgroTracker.Views;

namespace AgroTracker.ViewModels
{
    public class MenuItem : ReactiveObject
    {
        public string Name { get; set; }
        public IImage Image { get; set; }
        public List<MenuItem> Items { get; set; } = new();

        private bool _isExpanded;
        public bool IsExpanded
        {
            get => _isExpanded;
            set => this.RaiseAndSetIfChanged(ref _isExpanded, value);
        }

        public ReactiveCommand<Unit, Unit> ToggleExpandCommand { get; }
        public ReactiveCommand<Unit, Unit> NavigateCommand { get; }

        public MenuItem(string name, string imagePath, Action<MenuItem>? onNavigate = null)
        {
            Name = name;
            Image = new Bitmap(AssetLoader.Open(new Uri(imagePath)));

            ToggleExpandCommand = ReactiveCommand.Create(() =>
            {
                IsExpanded = !IsExpanded;
            });

            NavigateCommand = ReactiveCommand.Create(() =>
            {
                onNavigate?.Invoke(this);
            });
        }
    }


    public class MainWindowViewModel : ViewModelBase
    {
        private object? _currentPage;
        public List<MenuItem> MenuItems { get; }


        public object? CurrentPage
        {
            get => _currentPage;
            set => this.RaiseAndSetIfChanged(ref _currentPage, value);
        }

        #region Footer

        private string _footerCurrent = "";
        private string _footerUnits = "Meters Centimeters";
        private string _footerWidth = "400cm";
        public string FooterCurrent { get => _footerCurrent; set => this.RaiseAndSetIfChanged(ref _footerCurrent, value); }
        public string FooterUnits { get => _footerUnits; set => this.RaiseAndSetIfChanged(ref _footerUnits, value); }
        public string FooterWidth { get => _footerWidth; set => this.RaiseAndSetIfChanged(ref _footerWidth, value); }

        #endregion

        public MainWindowViewModel()
        {
            #region MenuItems

            MenuItems = new()
            {
                new MenuItem("VehicleMenu", "avares://AgroTracker/Assets/img/Con_VehicleMenu.png", null)
                {
                    Items = new()
                    {
                        new MenuItem("VehicleMenu_Config", "avares://AgroTracker/Assets/img/ConS_ImplementConfig.png", NavigateToPage),
                        new MenuItem("VehicleMenu_Hitch", "avares://AgroTracker/Assets/img/ConS_ImplementHitch.png", NavigateToPage),
                        new MenuItem("VehicleMenu_Antenna", "avares://AgroTracker/Assets/img/ConS_ImplementAntenna.png", NavigateToPage),
                    }
                },
                new MenuItem("ImplementMenu", "avares://AgroTracker/Assets/img/Con_ImplementMenu.png", null)
                {
                    Items = new()
                    {
                        new MenuItem("ImplementMenu_Config", "avares://AgroTracker/Assets/img/ConS_ImplementConfig.png", NavigateToPage),
                        new MenuItem("ImplementMenu_Hitch", "avares://AgroTracker/Assets/img/ConS_ImplementHitch.png", NavigateToPage),
                        new MenuItem("ImplementMenu_Pivot", "avares://AgroTracker/Assets/img/ConS_ImplementPivot.png", NavigateToPage),
                        new MenuItem("ImplementMenu_Offset", "avares://AgroTracker/Assets/img/ConS_ImplementOffset.png", NavigateToPage),
                        new MenuItem("ImplementMenu_Section", "avares://AgroTracker/Assets/img/ConS_ImplementSection.png", NavigateToPage),
                        new MenuItem("ImplementMenu_Settings", "avares://AgroTracker/Assets/img/ConS_ImplementSettings.png", NavigateToPage),
                        new MenuItem("ImplementMenu_Switch", "avares://AgroTracker/Assets/img/ConS_ImplementSwitch.png", NavigateToPage),
                    }
                },
                new MenuItem("SourcesMenu", "avares://AgroTracker/Assets/img/Con_SourcesMenu.png", null)
                {
                    Items = new()
                    {
                        new MenuItem("SourcesMenu_Heading", "avares://AgroTracker/Assets/img/ConS_SourcesHeading.png", NavigateToPage),
                        new MenuItem("SourcesMenu_Roll", "avares://AgroTracker/Assets/img/ConS_SourcesRoll.png", NavigateToPage)
                    }
                },
                new MenuItem("UTurnMenu", "avares://AgroTracker/Assets/img/Con_UTurnMenu.png", null)
                {

                },
                new MenuItem("ModulesMenu", "avares://AgroTracker/Assets/img/Con_ModulesMenu.png", null)
                {
                    Items = new()
                    {
                        new MenuItem("ModulesMenu_ModulesMachine", "avares://AgroTracker/Assets/img/ConS_ModulesMachine.png", NavigateToPage),
                        new MenuItem("ModulesMenu_Pins", "avares://AgroTracker/Assets/img/ConS_Pins.png", NavigateToPage)
                    }
                },
                new MenuItem("TramMenu", "avares://AgroTracker/Assets/img/Con_TramMenu.png", null)
                {

                },
                new MenuItem("Display", "avares://AgroTracker/Assets/img/Con_Display.png", null)
                {

                },
                new MenuItem("FeatureMenu", "avares://AgroTracker/Assets/img/Con_FeatureMenu.png", null)
                {

                },
            };

            #endregion
        }

        private void NavigateToPage(MenuItem item)
        {
            switch (item.Name)
            {
                case "VehicleMenu_Config":
                    CurrentPage = new VehicleConfig();
                    break;
                case "VehicleMenu_Hitch":
                    CurrentPage = new MainView();
                    break;
                case "VehicleMenu_Antenna":
                    CurrentPage = new MainView();
                    break;
                default:
                    CurrentPage = null;
                    break;
            }
        }
    }
}
