
namespace DataAccessLayer.ORM
{
    public sealed class Settings
    {
        private string databaseServerName;

        private string databaseName;

        public void AddDabaseServer(string serverName)
        {
            this.databaseServerName = serverName;
        }

        public string GetDatabaseServer()
        {
            return this.databaseServerName;
        }

        public void AddDatabaseName(string databaseName)
        { 
            this.databaseName = databaseName; 
        }

        public string GetDatabaseName()
        {
            return this.databaseName;
        }
    }
}
