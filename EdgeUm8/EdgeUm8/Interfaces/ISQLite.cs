using SQLite;

namespace EdgeUm8.Interfaces {

    public interface ISQLiteInterface {
        SQLiteConnection GetSQLiteConnection();
    }
}
