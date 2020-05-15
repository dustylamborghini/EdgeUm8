using Remote_db;
using Remote_db.Models;
using Remote_db.Repositories;
using Remote_db.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using System.Web.Helpers;
using Microsoft.Ajax.Utilities;

namespace Remote_db.Controllers
{
    public class HouseApiController : ApiController
    {
        private HouseRepository houses;
        private AvailableTimesRepository availableTimes;

        public HouseApiController() {
            ApplicationDbContext context = new ApplicationDbContext();
            houses = new HouseRepository(context);
            availableTimes = new AvailableTimesRepository(context);
            
            //SetHouseData();
        }

        [HttpGet]
        //[Route("api/HouseApi")]
        public List<House> GetHouses() {
            return houses.GetAllHouses();
        }

        //public List<HouseViewModel> FetchHousesForXamarin() {
        //    //House houseToAdd = new House();

        //    List<HouseViewModel> allHousesForXamarin = new List<HouseViewModel>();

        //    foreach (House house in houses.items.ToList()) {

        //        List<HouseRoom> roomsForHouse = rooms.GetRoomsByHouseId(house.Id);
        //        List<HouseRoomViewModel> roomsForHouseConverted = new List<HouseRoomViewModel>();
        //        foreach (HouseRoom room in roomsForHouse) {
        //            List<AvailableTimes> timesForRoom = new List<AvailableTimes>();
        //            timesForRoom = availableTimes.GetAllTimesByRoomId(room.Id);

        //            HouseRoomViewModel convertedRoom = new HouseRoomViewModel { HouseId = room.HouseId, Projector = room.Projector, WhiteBoard = room.WhiteBoard, FreeTimes = timesForRoom };
        //            roomsForHouseConverted.Add(convertedRoom);
        //        }
        //        HouseViewModel houseView = new HouseViewModel() {
        //            HouseName = house.HouseName,
        //            Opens = house.Opens,
        //            Closes = house.Closes,
        //            MapPic = house.MapPic,
        //            Rooms = roomsForHouseConverted
        //        };
        //        allHousesForXamarin.Add(houseView);
        //    }
        //    return allHousesForXamarin;
        //}

        //public void SetHouseData() {
        //    convertedData = FetchHousesForXamarin();
        //}

        //public static List<HouseViewModel> FetchAllData() {
        //    return convertedData;
        //}

    }
}