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
    public partial class Login : ContentPage
    {
        //prepare a UserDb for login validation
        UserDB userData;        

        //instanciate everything and fetch the latest updated data from the remote db.
        public Login()
        {
            InitializeComponent();            
            WebApi.FetchHouseData();
            WebApi.FetchRoomData();
            WebApi.FetchAvailableTimesData();
            
            userData = new UserDB();
            txtUserName.ReturnCommand = new Command(() => txtPassword.Focus());
        }

        //catch the click and validate entered information
        private async void Login_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new Master(), this);
            if (txtUserName.Text != null && txtPassword.Text != null) {

                var validData = userData.LoginValidate(txtUserName.Text, txtPassword.Text);

                if (validData) {                    
                    await Navigation.PopAsync();
                    Application.Current.MainPage = new Master();

                } else {

                    await DisplayAlert("Login Failed", "Username or Password Incorrect", "OK");

                }

            } else {

                await DisplayAlert("He He", "Enter User Name and Password Please", "OK");

            }
            
        }

        private async void Register_Button_Clicked(object sender, EventArgs e) {

            await Navigation.PushAsync(new Register());
        }

    }
}