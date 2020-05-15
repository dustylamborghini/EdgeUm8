﻿using EdgeUm8.Api;
using EdgeUm8.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace EdgeUm8.ViewModel
{
    public class FreeTimesViewModel : INotifyPropertyChanged {

        

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        

        //public IEnumerable<HouseRoom> RoomsFromSelectedHouse { get { return WebApi.FetchRoomDataByHouseId(selectedHouseId); } }
        //public FreeTimesViewModel() {

        //}

        public IEnumerable<string> HouseNames {
            get { return WebApi.FetchHouseNames(); } }

        public string LedigText { get { return "Lediga nu"; } }

        
        //public List<string> SetHouseNames() {
            
        //}

    }
}
