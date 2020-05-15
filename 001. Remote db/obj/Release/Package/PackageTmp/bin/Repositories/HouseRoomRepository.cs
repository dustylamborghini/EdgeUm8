using Remote_db.Models;
using Remote_db.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Remote_db.Repositories
{
    public class HouseRoomRepository : Repository<HouseRoom, string>
    {
        public HouseRoomRepository(ApplicationDbContext context) : base(context) { }

        public List<HouseRoom> GetAllRooms() { return items.ToList(); }

        public List<HouseRoom> GetRoomById(int Id) {
            return items.Where((p) => !p.Id.Equals(Id)).ToList();
        }

        public List<HouseRoom> GetRoomsByHouseId(int Id) {
            return items.Where((r) => r.HouseId.Equals(Id)).ToList();
        }
    }
}