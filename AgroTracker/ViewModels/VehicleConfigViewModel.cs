using Avalonia.Media.Imaging;
using Avalonia.Media;
using Avalonia.Platform;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace AgroTracker.ViewModels
{
    public class BrandModel(string imageSource, string vehicleImageSource)
    {
        public IImage ImageSource { get; set; } = new Bitmap(AssetLoader.Open(new Uri(imageSource)));
        public IImage VehicleImageSource { get; set; } = new Bitmap(AssetLoader.Open(new Uri(vehicleImageSource)));
    }

    public class VehicleTabModel(string imageSource) : ViewModelBase
    {
        public IImage HeaderImage { get; set; } = new Bitmap(AssetLoader.Open(new Uri(imageSource)));
        public int Columns { get; set; }

        private BrandModel? _selectedBrand;
        public BrandModel? SelectedBrand
        {
            get => _selectedBrand;
            set => this.RaiseAndSetIfChanged(ref _selectedBrand, value);
        }

        private bool _isBrandsVisible = true;
        public bool IsBrandsVisible
        {
            get => _isBrandsVisible;
            set => this.RaiseAndSetIfChanged(ref _isBrandsVisible, value);
        }

        public ObservableCollection<BrandModel> Brands { get; set; } = new ObservableCollection<BrandModel>();
    }


    public class VehicleConfigViewModel : ViewModelBase
    {
        private IImage _canvasBackground = new Bitmap(AssetLoader.Open(new Uri("avares://AgroTracker/Assets/img/VehicleOpacity.png")));

        public IImage CanvasBackground
        {
            get => _canvasBackground;
            set => this.RaiseAndSetIfChanged(ref _canvasBackground, value);
        }

        private IImage? _vehicleImage;
        public IImage? VehicleImage
        {
            get => _vehicleImage;
            set => this.RaiseAndSetIfChanged(ref _vehicleImage, value);

        }

        private double _opacity = 1.0;
        public double Opacity
        {
            get => _opacity;
            set => this.RaiseAndSetIfChanged(ref _opacity, Math.Clamp(value, 0.0, 1.0));
        }

        private IImage? _selectedVehicleImage;
        public IImage? SelectedVehicleImage
        {
            get => _selectedVehicleImage;
            set => this.RaiseAndSetIfChanged(ref _selectedVehicleImage, value);
        }

        private VehicleTabModel? _selectedTab;
        public VehicleTabModel? SelectedTab
        {
            get => _selectedTab;
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedTab, value);

                if (value != null)
                {
                    SelectedVehicleImage = value.SelectedBrand?.VehicleImageSource;
                }
            }
        }

        public ReactiveCommand<Unit, Unit> IncreaseOpacityCommand { get; }
        public ReactiveCommand<Unit, Unit> DecreaseOpacityCommand { get; }
        public ReactiveCommand<Unit, Unit> ClearSelectedBrandCommand { get; }


        public ObservableCollection<VehicleTabModel> Tabs { get; set; }

        public VehicleConfigViewModel()
        {

            var HarvesterTab = new VehicleTabModel("avares://AgroTracker/Assets/img/vehiclePageHarvester.png")
            {
                Columns = 1,
                Brands = new ObservableCollection<BrandModel>
                {
                    new BrandModel("avares://AgroTracker/Assets/img/Brand/BrandAoG.png", "avares://AgroTracker/Assets/img/Harvester/HarvesterAoG.png"),
                    new BrandModel("avares://AgroTracker/Assets/img/Brand/BrandCase.png", "avares://AgroTracker/Assets/img/Harvester/HarvesterCase.png"),
                    new BrandModel("avares://AgroTracker/Assets/img/Brand/BrandClaas.png", "avares://AgroTracker/Assets/img/Harvester/HarvesterClaas.png"),
                    new BrandModel("avares://AgroTracker/Assets/img/Brand/BrandJohnDeere.png", "avares://AgroTracker/Assets/img/Harvester/HarvesterJohnDeere.png"),
                    new BrandModel("avares://AgroTracker/Assets/img/Brand/BrandNewHolland.png", "avares://AgroTracker/Assets/img/Harvester/HarvesterNewHolland.png")
                }
            };

            Tabs = new ObservableCollection<VehicleTabModel>
            {
                HarvesterTab,
                new VehicleTabModel("avares://AgroTracker/Assets/img/vehiclePageTractor.png")
                {
                    Columns = 1,
                    Brands = new ObservableCollection<BrandModel>
                    {
                        new BrandModel("avares://AgroTracker/Assets/img/Brand/BrandJCB.png", "avares://AgroTracker/Assets/img/Tractor/TractorJCB.png"),
                        new BrandModel("avares://AgroTracker/Assets/img/Brand/BrandCase.png", "avares://AgroTracker/Assets/img/Tractor/TractorCase.png"),
                        new BrandModel("avares://AgroTracker/Assets/img/Brand/BrandMassey.png", "avares://AgroTracker/Assets/img/Tractor/TractorMassey.png"),
                        new BrandModel("avares://AgroTracker/Assets/img/Brand/BrandUrsus.png", "avares://AgroTracker/Assets/img/Tractor/TractorUrsus.png"),
                        new BrandModel("avares://AgroTracker/Assets/img/Brand/BrandFendt.png", "avares://AgroTracker/Assets/img/Tractor/TractorFendt.png"),
                        new BrandModel("avares://AgroTracker/Assets/img/Brand/BrandAoG.png", "avares://AgroTracker/Assets/img/Tractor/TractorAoG.png"),
                        new BrandModel("avares://AgroTracker/Assets/img/Brand/BrandClaas.png", "avares://AgroTracker/Assets/img/Tractor/TractorClaas.png"),
                        new BrandModel("avares://AgroTracker/Assets/img/Brand/BrandNewHolland.png", "avares://AgroTracker/Assets/img/Tractor/TractorNewHolland.png"),
                        new BrandModel("avares://AgroTracker/Assets/img/Brand/BrandValtra.png", "avares://AgroTracker/Assets/img/Tractor/TractorValtra.png"),
                        new BrandModel("avares://AgroTracker/Assets/img/Brand/BrandSteyr.png", "avares://AgroTracker/Assets/img/Tractor/TractorSteyr.png"),
                        new BrandModel("avares://AgroTracker/Assets/img/Brand/BrandDeutz.png", "avares://AgroTracker/Assets/img/Tractor/TractorDeutz.png"),
                        new BrandModel("avares://AgroTracker/Assets/img/Brand/BrandSame.png", "avares://AgroTracker/Assets/img/Tractor/TractorSame.png"),
                        new BrandModel("avares://AgroTracker/Assets/img/Brand/BrandJohnDeere.png", "avares://AgroTracker/Assets/img/Tractor/TractorJohnDeere.png"),
                        new BrandModel("avares://AgroTracker/Assets/img/Brand/BrandKubota.png", "avares://AgroTracker/Assets/img/Tractor/TractorKubota.png")
                    }
                },
                new VehicleTabModel("avares://AgroTracker/Assets/img/vehiclePageArticulated.png")
                {
                    Columns = 1,
                    Brands = new ObservableCollection<BrandModel>
                    {
                        new BrandModel("avares://AgroTracker/Assets/img/Brand/BrandAoG.png", "avares://AgroTracker/Assets/img/Articulated/ArticulatedFrontAoG.png"),
                        new BrandModel("avares://AgroTracker/Assets/img/Brand/BrandChallenger.png", "avares://AgroTracker/Assets/img/Articulated/ArticulatedFrontChallenger.png"),
                        new BrandModel("avares://AgroTracker/Assets/img/Brand/BrandCase.png", "avares://AgroTracker/Assets/img/Articulated/ArticulatedFrontCase.png"),
                        new BrandModel("avares://AgroTracker/Assets/img/Brand/BrandJohnDeere.png", "avares://AgroTracker/Assets/img/Articulated/ArticulatedFrontJohnDeere.png"),
                        new BrandModel("avares://AgroTracker/Assets/img/Brand/BrandNewHolland.png", "avares://AgroTracker/Assets/img/Articulated/ArticulatedFrontNewHolland.png"),
                        new BrandModel("avares://AgroTracker/Assets/img/Brand/BrandHolder.png", "avares://AgroTracker/Assets/img/Articulated/ArticulatedFrontHolder.png")
                    }
                },
            };

            foreach (var tab in Tabs)
            {
                tab.WhenAnyValue(x => x.SelectedBrand)
                   .Subscribe(brand =>
                   {
                       if (tab == SelectedTab)
                       {
                           SelectedVehicleImage = brand?.VehicleImageSource;
                       }
                   });
            }


            IncreaseOpacityCommand = ReactiveCommand.Create(() =>
            {
                Opacity += 0.1;
            });

            DecreaseOpacityCommand = ReactiveCommand.Create(() =>
            {
                Opacity -= 0.1;
            });

            ClearSelectedBrandCommand = ReactiveCommand.Create(() =>
            {
                if (SelectedTab != null)
                {
                    if (SelectedTab.IsBrandsVisible)
                    {
                        SelectedTab.IsBrandsVisible = false;
                        SelectedVehicleImage = new Bitmap(AssetLoader.Open(new Uri("avares://AgroTracker/Assets/img/Brand/BrandTriangleVehicle.png")));
                    }
                    else
                    {
                        SelectedTab.IsBrandsVisible = true;
                        SelectedVehicleImage = SelectedTab.SelectedBrand?.VehicleImageSource;
                    }
                }
            });
        }
    }
}
