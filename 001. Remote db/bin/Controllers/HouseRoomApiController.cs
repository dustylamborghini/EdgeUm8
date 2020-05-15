using Remote_db.Models;
using Remote_db.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System.Web.Helpers;

namespace Remote_db.Controllers
{
    public class HouseRoomApiController : ApiController
    {
        private HouseRoomRepository rooms;

        public HouseRoomApiController() {
            ApplicationDbContext context = new ApplicationDbContext();
            rooms = new HouseRoomRepository(context); }

        [HttpGet]
        public List<HouseRoom> GetRooms() {
            return rooms.GetAllRooms();
        }
    }
}
