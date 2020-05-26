using EdgeUm8.Api;
using EdgeUm8.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EdgeUm8.ViewModel
{
    public class FreeTimesViewModel : INotifyPropertyChanged {

        //holds a bindable collection of available times for the, by the user, currently selected house.
        public static IEnumerable<AvailableTimes> freeTimesForSelection { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public FreeTimesViewModel() {}

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //gets a freshly updated list of house names from the remote db, used as itemssource for a listview.
        public IEnumerable<string> HouseNames { get { return WebApi.FetchHouseNames(); } }

        //controller-method, to ensure data bindings are working... essentially useless in and of itself,
        //but sometimes bindings stop working, and this gives us an instant visual que that it is happening.
        public string LedigText { get { return "Lediga nu"; } }

        public IEnumerable<AvailableTimes> AvailableTimes { get { return WebApi.FetchTimeDataForAll(); } }
        

        public static void SetTimesForSelectedHouse(IEnumerable<AvailableTimes> timesFromSelection) {
            freeTimesForSelection = timesFromSelection;
        }      

    }
}
