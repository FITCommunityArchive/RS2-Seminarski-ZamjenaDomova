using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZamjenaDomova.Controls;
using ZamjenaDomova.Model;

namespace ZamjenaDomova.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilterPage : ContentPage
    {
        public SelectableObservableCollection<SelectableItem<Model.AmenityModel>> AmenitiesItems { get; set; }
        public ObservableCollection<Model.Territory> TerritoriesCollection = new ObservableCollection<Territory>();
        
        private double StepValue = 1.0;
        public FilterPage()
        {
            InitializeComponent();
            GetAmenities();
            GetTerritories();
        }
        private async void BtnFilter_Clicked(object sender, EventArgs e)
        {
        }

        private void sPersons_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var newStep = Math.Round(e.NewValue / StepValue);

            sPersons.Value = newStep * StepValue;
            lblPersons.Text = sPersons.Value.ToString();
        }

        private void sBeds_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var newStep = Math.Round(e.NewValue / StepValue);

            sBeds.Value = newStep * StepValue;
            lblBeds.Text = sBeds.Value.ToString();
        }

        private void sBathrooms_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var newStep = Math.Round(e.NewValue / StepValue);

            sBathrooms.Value = newStep * StepValue;
            lblBathrooms.Text = sBathrooms.Value.ToString();
        }
        private async void GetAmenities()
        {
            var amenities = await APIService.GetAmenities();
            List<AmenityModel> amenitiesModels = amenities
                .Select(x => new AmenityModel
                {
                    AmenityId = x.AmenityId,
                    Name = x.Name
                }).ToList();
            var amenitiesItems = amenitiesModels
                .Select(x => new SelectableItem<AmenityModel>(x))
                .ToList();
            AmenitiesItems = new SelectableObservableCollection<SelectableItem<AmenityModel>>(amenitiesItems);
            lvAmenities.ItemsSource = AmenitiesItems;
        }
        private async void GetTerritories()
        {
            var territories = await APIService.GetTerritories();
            territories = territories.OrderBy(x => x.Name).ToList();
            foreach (var item in territories)
            {
                TerritoriesCollection.Add(item);
            }
            PickerTerritory.ItemsSource = TerritoriesCollection;
        }

        private void TapReset_Tapped(object sender, EventArgs e)
        {

        }

        private void PickerTerritory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}