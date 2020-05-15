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
    public class RoomApiController : ApiController {
        private HouseRoomRepository rooms;

        public RoomApiController() {
            ApplicationDbContext context = new ApplicationDbContext();
            rooms = new HouseRoomRepository(context);
        }

        [HttpGet]
        public List<HouseRoom> GetRooms() {
            return rooms.GetAllRooms();
        }
    }
}