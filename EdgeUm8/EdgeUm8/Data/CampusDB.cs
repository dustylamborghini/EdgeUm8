using System;
using System.Collections.Generic;
using System.Text;
using EdgeUm8.Interfaces;
using EdgeUm8.Models;
using System.Linq;
using Xamarin.Forms;
using SQLite;
using System.Threading.Tasks;

namespace EdgeUm8.Data {
    public class CampusDB {
        private SQLiteConnection _SQLiteConnection;

        public CampusDB() {

            _SQLiteConnection = DependencyService.Get<ISQLiteInterface>().GetSQLiteConnection();

            _SQLiteConnection.CreateTable<House>();
            _SQLiteConnection.CreateTable<HouseRoom>();
            _SQLiteConnection.CreateTable<AvailableTimes>();
        }

        public IEnumerable<House> GetHouses() {

            return (from h in _SQLiteConnection.Table<House>()

                    select h).ToList();

        }

        public IEnumerable<HouseRoom> GetRooms() {

            return (from r in _SQLiteConnection.Table<HouseRoom>()

                    select r).ToList();
        }

        //public List<AvailableTimes> GetTimesForSelectedHouse(int houseId) {
        //    //List<HouseRoom> roomsForSelectedHouse = _SQLiteConnection.Table<HouseRoom>().Where(r => r.HouseId.Equals(houseId)).ToList();
        //    return _SQLiteConnection.Table<AvailableTimes>().Where(t => t.RoomId.Equals(_SQLiteConnection.Table<HouseRoom>().Where(r => r.HouseId.Equals(houseId)))).ToList();
        //}

        public AvailableTimesViewModel GetFreeTimesForRoom(string roomId) {

            var data = _SQLiteConnection.Table<AvailableTimes>();
            List<AvailableTimes> tempTimes = data.Where(t => t.RoomId == roomId).ToList();
            var allTimes = new AvailableTimesViewModel() { RoomId = roomId, TimesForRoom = tempTimes };

            return allTimes;
        }

        public House GetSpecificHouse(int id) {

            return _SQLiteConnection.Table<House>().FirstOrDefault(t => t.Id == id);

        }

        public void DeleteUser(int id) {

            _SQLiteConnection.Delete<User>(id);

        }

        public string AddHouse(House house) {

            var data = _SQLiteConnection.Table<House>();

            var d1 = data.Where(x => x.Id == house.Id && x.HouseName == house.HouseName).FirstOrDefault();

            if (d1 == null) {

                _SQLiteConnection.Insert(house);

                return "House Sucessfully Registered!";

            } else

                return "House";

        }
        public string AddRoom(HouseRoom room) {

            var data = _SQLiteConnection.Table<HouseRoom>();

            var d1 = data.Where(x => x.Id.Equals(room.Id) && x.HouseId == room.HouseId).FirstOrDefault();

            if (d1 == null) {

                _SQLiteConnection.Insert(room);

                return "Room Sucessfully Registered!";

            } else

                return "Room was duplicate!";

        }

        public string AddTime(AvailableTimes time) {

            var data = _SQLiteConnection.Table<AvailableTimes>();

            var d1 = data.Where(x => x.Id == time.Id && x.RoomId == time.RoomId).FirstOrDefault();

            if (d1 == null) {

                _SQLiteConnection.Insert(time);

                return "Available time Sucessfully Registered!";

            } else

                return "Time was duplicate!";

        }

        public bool updateUserValidation(string userid) {

            var data = _SQLiteConnection.Table<User>();

            var d1 = (from values in data

                      where values.Email == userid

                      select values).Single();

            if (d1 != null) {

                return true;

            } else

                return false;

        }

        public bool updateUser(string username, string pwd) {

            var data = _SQLiteConnection.Table<User>();

            var d1 = (from values in data

                      where values.Email == username

                      select values).Single();

            if (true) {

                d1.Password = pwd;

                _SQLiteConnection.Update(d1);

                return true;

            } else {

                return false;
            }

        }

        

    }
}

