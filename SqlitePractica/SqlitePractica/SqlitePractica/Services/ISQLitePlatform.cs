using SQLite;

namespace PracticaSQLite.Services
{
    public interface ISQLitePlatform
    {
        SQLiteConnection GetConnection();
    }
}
