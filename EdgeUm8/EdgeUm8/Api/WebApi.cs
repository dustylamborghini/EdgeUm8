using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using EdgeUm8.Models;

namespace EdgeUm8.Api {
    public static class WebApi {
        //address to our api server in the cloud
        private static string apiUrl = "https://edgeum8remotedb.azurewebsites.net/api/";

        //lists of the most vital models from the remote db
        private static List<House> houseData { get; set; }
        private static List<HouseRoom> roomData { get; set; }
        private static List<AvailableTimes> timeData { get; set; }

        //method to fetch all houses from the remote db, asynchronous so that it can be awaited
        public static async void FetchHouseData() {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(apiUrl + "HouseApi");
            var tempHouseData = JsonConvert.DeserializeObject<List<House>>(response);
            houseData = tempHouseData;
        }

        //extract a list of strings to populate listview of all houses for user.
        //TODO: move to population class, refactor to accept listview as parameter.
        public static IEnumerable<string> FetchHouseNames() {
            List<string> houses = new List<string>();
            foreach (House house in houseData) {
                houses.Add(house.HouseName);
            }
            return houses;
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

        public static async void FetchAvailableTimesData() {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(apiUrl + "AvailableTimesApi");
            var tempTimeData = JsonConvert.DeserializeObject<List<AvailableTimes>>(response);
            timeData = tempTimeData;
        }

        public static IEnumerable<AvailableTimes> FetchTimeDataByRoomId(string id) {
            List<AvailableTimes> times = new List<AvailableTimes>();
            foreach (AvailableTimes time in timeData) {
                if (time.RoomId.Equals(id)) {
                    times.Add(time);
                }
            }
            return times;
        }

        public static IEnumerable<AvailableTimes> FetchTimeDataByHouseId(int id) {
            List<AvailableTimes> times = new List<AvailableTimes>();
            List<HouseRoom> roomsForSelectedHouse = new List<HouseRoom>();

            foreach (HouseRoom room in roomData) {
                if (room.HouseId.Equals(id)) {
                    roomsForSelectedHouse.Add(room); 
                }
            }

            foreach (AvailableTimes time in timeData) {
                foreach (HouseRoom room in roomsForSelectedHouse) {
                    if (time.RoomId.Equals(room.Id)) {
                        times.Add(time);
                    }
                }
            }
            return times;
        }

        public static List<AvailableTimes> GetTimesForUserDibs(List<Dibs> dibsForUser) {
            List<AvailableTimes> timesForUser = new List<AvailableTimes>();
            foreach (AvailableTimes time in timeData) {
                bool matchFound = false;
                foreach (Dibs dib in dibsForUser) {
                    if (time.Id.Equals(dib.AvailabilityId)) {
                        matchFound = true;
                    }
                }
                if (matchFound) {
                    timesForUser.Add(time);
                }
            }

            return timesForUser;
        }

        public static IEnumerable<AvailableTimes> FetchTimeDataForAll() {
            return timeData;
        }

        public static List<House> GetAllHouses() {
            return houseData;
        }

        public static List<HouseRoom> GetAllRooms() {
            return roomData;
        }

    }
}
