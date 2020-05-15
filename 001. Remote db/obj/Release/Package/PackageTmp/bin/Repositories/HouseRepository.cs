using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        //public List<House> GetAllActiveProfiles() {
       //     return items.Where((p) => p.IsActive).ToList();}

        public bool IfProfileExists(string userId) {
            List<House> profile = items.Where((p) => p.Id.Equals(userId)).ToList(); // Should only ever be 0 or 1
            if (profile.Count == 1) return true;
            else return false;
        }
    }
}