using MongoDB.Bson.Serialization.Attributes;

namespace JobOpportunities.DataNoSql.CustomLogs
{
    public class ExecutionTime
    {
        [BsonElement("path")]
        public string Path { get; set; } = "Missing path";
        [BsonElement("time")]
        public long Time { get; set; }
    }
}
