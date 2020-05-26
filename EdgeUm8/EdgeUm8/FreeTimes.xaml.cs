using EdgeUm8.ViewModel;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EdgeUm8.Models;
using EdgeUm8.Api;
using EdgeUm8.Data;

namespace EdgeUm8 {
    //super-necessary compiler, that makes sure this xaml will compile at build or runtime.
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FreeTimes : ContentPage {
        //always keep track of which house the user is currently browsing.
        private int selectedHouseId { get; set; }
        //always keep track of what times are free in the currently browsed house.
        private List<AvailableTimes> updatedTimes { get; set; }
        //prepare for calling dibs on a free time.
        DibsDb dibs;

        public FreeTimes() {
            InitializeComponent();
            dibs = new DibsDb();
            //create binding to corresponding ViewModel.
            BindingContext = new FreeTimesViewModel();            
        }       

        //declare variable to hold data from which we can extract an object.
        ViewCell lastCell;
        private void ViewCell_Tapped(object sender, System.EventArgs e) {
            //get the view cell from sender so we can cast an object from it...
            var timeCell = (ViewCell)sender;

            //cast bound object as the object we want (that we've already assigned as a source for the viewcell).
            var time = (AvailableTimes)timeCell.BindingContext;

            //use the newly cast object to get correct db time id, and put it in a new object that we'll send to the dibsDb.
            Dibs dib = new Dibs { AvailabilityId = time.Id, UserId = UserDB.currentUserId };
            //send the new dib to the dibsDb and collect the resulting bool in a variable...
            var dibValid = dibs.AddDib(dib);

            //use the collected bool to determine if the new entry has made it all the way to the dibsDb
            //and report the result to the user.
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

        //slight deviation from MVVM here, but at least it works ;P
        //essentially this updates the listview with the selected house's available times...
        private void OnPickerSelectedIndexChanged(object sender, EventArgs e) {
            Picker picker = sender as Picker;
            var selectedHouse = picker.SelectedItem.ToString();
            selectedHouseId = WebApi.FetchHouseIdByHouseName(selectedHouse);
            CheckTimeDataForDibs();
            FreeTimesViewModel.SetTimesForSelectedHouse(updatedTimes);
            TimesListView.ItemsSource = FreeTimesViewModel.freeTimesForSelection;
        }

        //TODO: refactor and move resulting methods to their own classes.
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
