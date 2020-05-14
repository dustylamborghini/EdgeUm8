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
    public partial class AdvFreeTimes : ContentPage
    {
        public AdvFreeTimes()
        {
            InitializeComponent();
        }

        /*När man trycker på en rad i listview så är den raden färgad annorlunda. Kan använda denna för att navigera till rum-sida.*/
        ViewCell lastCell;
        private void ViewCell_Tapped(object sender, System.EventArgs e)
        {
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