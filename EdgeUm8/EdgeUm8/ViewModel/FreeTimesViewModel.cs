using EdgeUm8.Api;
using EdgeUm8.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using System.Linq;
using System.Collections.ObjectModel;

namespace EdgeUm8.ViewModel
{
    public class FreeTimesViewModel : INotifyPropertyChanged {

        public static IEnumerable<AvailableTimes> freeTimesForSelection { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        public FreeTimesViewModel() {}

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public IEnumerable<string> HouseNames { get { return WebApi.FetchHouseNames(); } }

        public string LedigText { get { return "Lediga nu"; } }

        public IEnumerable<AvailableTimes> AvailableTimes { get { return WebApi.FetchTimeDataForAll(); } }

        

        public static void SetTimesForSelectedHouse(IEnumerable<AvailableTimes> timesFromSelection) {
            freeTimesForSelection = timesFromSelection;
        }

        

        

        
        //public List<string> SetHouseNames() {
            
        //}

    }
}
