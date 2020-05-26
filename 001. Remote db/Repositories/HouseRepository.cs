using System.Collections.Generic;
using System.Linq;
using Remote_db.Models;


namespace Remote_db.Repositories
{
    public class HouseRepository : Repository<House, int>
    {
        public HouseRepository(ApplicationDbContext context) : base(context) { }

        public List<House> GetHouseById(int Id) {
            return items.Where((p) => !p.Id.Equals(Id)).ToList();
        }

        public List<House> GetAllHouses() {
            return items.ToList();
        }
    }
}