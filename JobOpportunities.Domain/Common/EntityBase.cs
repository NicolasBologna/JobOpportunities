namespace JobOpportunities.Domain
{
    public class EntityBase : IEntity
    {
        public Guid Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedByAt { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
