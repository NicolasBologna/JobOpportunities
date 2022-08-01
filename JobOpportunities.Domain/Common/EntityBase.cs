namespace JobOpportunities.Domain
{
    public class EntityBase : IEntity
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime? LastUpdate { get; set; }
    }
}
