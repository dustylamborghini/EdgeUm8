using Remote_db;
using Remote_db.Models;
using Remote_db.Repositories;
using Remote_db.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Remote_db.Controllers
{
    public class HouseApiController : ApiController
    {
        private HouseRepository houses;

        public HouseApiController() {
            ApplicationDbContext context = new ApplicationDbContext();
            houses = new HouseRepository(context);
        }

        [HttpGet]
        public List<House> GetHouses() {
            return houses.GetAllHouses();
        }
    }
}