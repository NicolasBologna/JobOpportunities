namespace JobOpportunities.DataNoSql.CustomLogs
{
    public interface IMongoDbLogger
    {
        void LogRequestTime(ExecutionTime execTime);
    }
}