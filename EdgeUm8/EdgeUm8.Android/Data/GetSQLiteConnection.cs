using System.IO;
using EdgeUm8.Droid.Data;
using EdgeUm8.Interfaces;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(GetSQLiteConnnection))]

namespace EdgeUm8.Droid.Data
{
    public class GetSQLiteConnnection : ISQLiteInterface {

        public GetSQLiteConnnection() { }

        public SQLite.SQLiteConnection GetSQLiteConnection() {
            var fileName = "UserDatabase.db3";
            var documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentPath, fileName);
            var connection = new SQLiteConnection(path);
            return connection;
        }
    }
}