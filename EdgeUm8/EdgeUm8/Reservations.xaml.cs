using EdgeUm8.Api;
using EdgeUm8.Data;
using EdgeUm8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EdgeUm8
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Reservations : ContentPage
    {
        private List<AvailableTimes> timesForUser { get; set; }
        private DibsDb dibs;
        public Reservations()
        {
            InitializeComponent();
            dibs = new DibsDb();
            UpdateListView();

        }

        public void UpdateListView() {
            timesForUser = WebApi.GetTimesForUserDibs(dibs.GetDibsForUser(UserDB.currentUserId));
            DibsListView.ItemsSource = timesForUser;
        }

        /*När man trycker på en rad i listview så är den raden färgad annorlunda. Kan använda denna för att navigera till rum-sida.*/
        ViewCell lastCell;
        private void ViewCell_Tapped(object sender, System.EventArgs e)
        {
            var timeCell = (ViewCell)sender;
            var time = (AvailableTimes)timeCell.BindingContext;
            Dibs dib = new Dibs { AvailabilityId = time.Id, UserId = UserDB.currentUserId };
            var dibValid = dibs.EraseDib(dib);
            if (dibValid) { DisplayAlert("Tingning", "Du har raderat din tingning för tiden " + time.From.ToString() + " till " + time.To.ToString() + " i sal " + time.RoomId, "OK"); } else { DisplayAlert("Tingning", "Du kan inte radera den tingade tiden " + time.From.ToString() + " till " + time.To.ToString() + " i sal " + time.RoomId + "för nåt har gått snett, serrö!", "OK"); }
            UpdateListView();

            if (lastCell != null)
                lastCell.View.BackgroundColor = Color.Transparent;
            var viewCell = (ViewCell)sender;
            if (viewCell.View != null)
            {
                viewCell.View.BackgroundColor = Color.BlueViolet;
                lastCell = viewCell;
            }
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new Profile());

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Profile());

        }
    }
}