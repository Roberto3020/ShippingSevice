namespace DataAccess
{
    public class DbConnectionOptions
    {
        public string ConnectionString { get; set; } = "";
        public int? CommandTimeout { get; set; }
    }
}
