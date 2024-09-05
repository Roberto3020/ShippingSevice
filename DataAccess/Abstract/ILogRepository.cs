namespace DataAccess.Abstract
{
    public interface ILogRepository
    {
        //Task InsertLog(WebServiceLog webServiceLog);
        Task InsertLog(string procedure, IDictionary<string, object> parameters, string result);
    }
}
