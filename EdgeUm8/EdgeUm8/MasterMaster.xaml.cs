using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EdgeUm8
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterMaster : ContentPage
    {
        public ListView ListView;

        public MasterMaster()
        {
            InitializeComponent();

            BindingContext = new MasterMasterViewModel();
            ListView = MenuItemsListView;


           
        }

        class MasterMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterMasterMenuItem> MenuItems { get; set; }

            public MasterMasterViewModel()
            {
                MenuItems = new ObservableCollection<MasterMasterMenuItem>(new[]
                {
                    new MasterMasterMenuItem { Id = 0, Title = "Startsida", TargetType=typeof(MainPage)},
                    new MasterMasterMenuItem { Id = 1, Title = "Profilsida", TargetType=typeof(Profile)},
                    new MasterMasterMenuItem { Id = 2, Title = "Mina bokningar", TargetType=typeof(Reservations)},
                    new MasterMasterMenuItem { Id = 3, Title = "Favoriter", TargetType=typeof(Favorites)},
                    new MasterMasterMenuItem { Id = 4, Title = "Lediga nu", TargetType=typeof(FreeTimes)},
                    new MasterMasterMenuItem { Id = 5, Title = "Avancerad sökning", TargetType=typeof(AdvFreeTimes)},
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }

        private async void Button_Clicked(object sender, EventArgs e) {
            Application.Current.MainPage = new NavigationPage(new Login());
            await Navigation.PushAsync(new Login());
        }
    }
}