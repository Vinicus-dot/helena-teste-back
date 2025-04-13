namespace Helena.Test.Back.Model
{
    public class ConnectionString : IConnectionString
    {
        public string HelenaDbConnectionString { get ; set; }
    }

    public interface IConnectionString
    {
        public string HelenaDbConnectionString { get; set; }
    }
}
