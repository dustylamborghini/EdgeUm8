using EdgeUm8.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using Newtonsoft.Json;
using EdgeUm8.Models;
using EdgeUm8.Api;
using EdgeUm8.Data;

namespace EdgeUm8
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FreeTimes : ContentPage 
    {
        private int selectedHouseId { get; set; }
        private List<AvailableTimes> updatedTimes { get; set; }
        DibsDb dibs;

        public FreeTimes()
        {
            InitializeComponent();
            dibs = new DibsDb();

            BindingContext = new FreeTimesViewModel();            
        }       

        /*När man trycker på en rad i listview så är den raden färgad annorlunda. Kan använda denna för att navigera till rum-sida.*/
        ViewCell lastCell;
        private void ViewCell_Tapped(object sender, System.EventArgs e)
        {
            var timeCell = (ViewCell)sender;
            var time = (AvailableTimes)timeCell.BindingContext;
            Dibs dib = new Dibs { AvailabilityId = time.Id, UserId = UserDB.currentUserId };
            var dibValid = dibs.AddDib(dib);
            if (dibValid) { DisplayAlert("Tingning", "Du har tingat tiden " + time.From.ToString() + " till " + time.To.ToString() + " i sal " + time.RoomId, "OK"); }
            else { DisplayAlert("Tingning", "Du kan inte tinga tiden " + time.From.ToString() + " till " + time.To.ToString() + " i sal " + time.RoomId + "för den är redan tingad, serrö!", "OK"); }
            if (lastCell != null)
                lastCell.View.BackgroundColor = Color.Transparent;
            var viewCell = (ViewCell)sender;
            if (viewCell.View != null)
            {
                viewCell.View.BackgroundColor = Color.BlueViolet;
                lastCell = viewCell;
            }
        }

        private void OnPickerSelectedIndexChanged(object sender, EventArgs e) {
            Picker picker = sender as Picker;
            var selectedHouse = picker.SelectedItem.ToString();
            selectedHouseId = WebApi.FetchHouseIdByHouseName(selectedHouse);
            CheckTimeDataForDibs();
            FreeTimesViewModel.SetTimesForSelectedHouse(updatedTimes);
            TimesListView.ItemsSource = FreeTimesViewModel.freeTimesForSelection;
        }

        public void CheckTimeDataForDibs() {
            IEnumerable<AvailableTimes> times = WebApi.FetchTimeDataByHouseId(selectedHouseId);
            IEnumerable<Dibs> allDbDibs = dibs.GetDibs();
            List<AvailableTimes> revisedTimes = new List<AvailableTimes>();
            foreach (AvailableTimes time in times) {
                bool matchFound = false; //life saver!
                foreach (Dibs dib in allDbDibs) {
                    if (dib.AvailabilityId.Equals(time.Id)) {
                        matchFound = true;
                    }
                }
                if (!matchFound) {
                    revisedTimes.Add(time);
                }
            }
            updatedTimes = revisedTimes;
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new Profile());

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Profile());

        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdvFreeTimes());
        }
    }
}
