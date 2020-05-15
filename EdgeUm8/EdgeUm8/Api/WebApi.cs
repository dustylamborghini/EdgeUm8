using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using EdgeUm8.Models;
using System.Collections;

namespace EdgeUm8.Api {
    public static class WebApi {
        private static string apiUrl = "https://edgeum8remotedb.azurewebsites.net/api/";
        private static List<House> houseData { get; set; }
        private static List<HouseRoom> roomData { get; set; }

        public static async void FetchHouseData() {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(apiUrl + "HouseApi");
            var tempHouseData = JsonConvert.DeserializeObject<List<House>>(response);
            houseData = tempHouseData;
        }

        public static IEnumerable<string> FetchHouseNames() {
            List<string> blabla = new List<string>();
            foreach (House house in houseData) {
                blabla.Add(house.HouseName);
            }
            return blabla;
        }

        public static async void FetchRoomData() {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(apiUrl + "RoomApi");
            var tempRoomData = JsonConvert.DeserializeObject<List<HouseRoom>>(response);
            roomData = tempRoomData;
        }

        public static int FetchHouseIdByHouseName(string name) {
            int id = 0;
            foreach (House house in houseData) {
                if (name.Equals(house.HouseName)){
                    id = house.Id;
                }                
            }
            return id;
        }

        public static IEnumerable<HouseRoom> FetchRoomDataByHouseId(int id) {
            List<HouseRoom> rooms = new List<HouseRoom>();
            foreach (HouseRoom room in roomData) {
                if (room.HouseId.Equals(id)) {
                    rooms.Add(room);
                }
            }
            return rooms;
        }

    }
}
