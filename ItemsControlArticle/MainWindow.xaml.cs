using ReactiveUI;
using Splat;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ItemsControlArticle
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            this.DataContext = new List<PlaceViewModel>
            {
                new CityViewModel("London", 8.308f, -0.1275, 51.5072),
                new CountryViewModel("Netherlands", 16.8f, BitmapLoader.Current.LoadFromResource("pack://application:,,,/ItemsControlArticle;component/Images/nl.png", null, null), 5.5, 53.3541576),
                new CountryViewModel("Australia", 23.13f, BitmapLoader.Current.LoadFromResource("pack://application:,,,/ItemsControlArticle;component/Images/au.png", null, null), 136.1055972, -26.5935356),
                new CityViewModel("Adelaide", 1.203f, 138.6010, -34.9290),
                new CityViewModel("Amsterdam", 0.779808f, 4.9, 52.3667),
                new CountryViewModel("United Kingdom", 64.1f, BitmapLoader.Current.LoadFromResource("pack://application:,,,/ItemsControlArticle;component/Images/gb.png", null, null), -3.4433238, 53),
            };
        }
    }

    public abstract class PlaceViewModel : ReactiveObject
    {
        private readonly string name;
        private readonly float population;
        private readonly double longitude;
        private readonly double latitude;

        protected PlaceViewModel(string name, float population, double longitude, double latitude)
        {
            this.name = name;
            this.population = population;
            this.longitude = longitude;
            this.latitude = latitude;
        }

        public string Name => this.name;

        public float Population => this.population;

        public double Longitude => this.longitude;

        public double Latitude => this.latitude;
    }

    public sealed class CountryViewModel : PlaceViewModel
    {
        private readonly ObservableAsPropertyHelper<IBitmap> countryFlag;

        public CountryViewModel(string name, float population, Task<IBitmap> countryFlag, double longitude, double latitude)
            : base(name, population, longitude, latitude)
        {
            this.countryFlag = countryFlag
                .ToObservable()
                .ToProperty(this, x => x.CountryFlag);
        }

        public IBitmap CountryFlag => this.countryFlag.Value;
    }

    public sealed class CityViewModel : PlaceViewModel
    {
        public CityViewModel(string name, float population, double longitude, double latitude)
            : base(name, population, longitude, latitude)
        {
        }
    }

    public sealed class CustomItemsControl : ItemsControl
    {
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new ContentControl();
        }
    }

    public sealed class PlaceTypeGroupDescription : GroupDescription
    {
        public override object GroupNameFromItem(object item, int level, CultureInfo culture)
        {
            return item is CityViewModel ? "Cities" : "Countries";
        }
    }
}