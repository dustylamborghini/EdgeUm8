using EdgeUm8.Interfaces;
using EdgeUm8.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Linq;

namespace EdgeUm8.Data {
    public class DibsDb {
        private SQLiteConnection _DibsDb;

        public DibsDb() {
            _DibsDb = DependencyService.Get<ISQLiteInterface>().GetSQLiteConnection();

            _DibsDb.CreateTable<Dibs>();
        }

        public IEnumerable<Dibs> GetDibs() {

            return (from d in _DibsDb.Table<Dibs>()

                    select d).ToList();

        }

        public bool AddDib(Dibs dib) {

            var data = _DibsDb.Table<Dibs>();

            var d1 = data.Where(x => x.AvailabilityId == dib.AvailabilityId && x.UserId == dib.UserId).FirstOrDefault();

            if (d1 == null) {

                _DibsDb.Insert(dib);

                return true;

            } else

                return false;

        }

        public bool EraseDib(Dibs dib) {

            var possibleDibsToDelete = _DibsDb.Table<Dibs>().Where(d => d.AvailabilityId.Equals(dib.AvailabilityId) && d.UserId.Equals(dib.UserId));

            var dibToDelete = possibleDibsToDelete.Where(d => d.AvailabilityId.Equals(dib.AvailabilityId)).FirstOrDefault();

            _DibsDb.Delete<Dibs>(dibToDelete.Id);

            if (dibToDelete == null) {
                return false;
            } else {
                return true;
            }
        }

        public List<Dibs> GetDibsForUser(int userId) {
            return _DibsDb.Table<Dibs>().Where(d => d.UserId == userId).ToList();
        }
    }
}
