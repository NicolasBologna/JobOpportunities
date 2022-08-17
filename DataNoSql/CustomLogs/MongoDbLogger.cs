using MongoDB.Driver;

namespace JobOpportunities.DataNoSql.CustomLogs;

public class MongoDbLogger : IMongoDbLogger
{
    public async void LogRequestTime(ExecutionTime execTime)
    {
        var client = new MongoClient("mongodb+srv://serilogMongo:serilogMongo@cluster0.vzwjbbc.mongodb.net/?retryWrites=true&w=majority");
        var database = client.GetDatabase("JobOpportunities");

        var logsDB = database.GetCollection<ExecutionTime>("logs");

        await logsDB.InsertOneAsync(execTime);
    }
}
