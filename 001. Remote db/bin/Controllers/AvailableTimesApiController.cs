using Remote_db.Models;
using Remote_db.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Remote_db.Controllers
{
    public class AvailableTimesApiController : ApiController {

        private AvailableTimesRepository freeTimes;

        public AvailableTimesApiController() {
            ApplicationDbContext context = new ApplicationDbContext();
            freeTimes = new AvailableTimesRepository(context);
        }

        [HttpGet]
        public List<AvailableTimes> GetRooms() {
            return freeTimes.GetAll();
        }
    }
}
