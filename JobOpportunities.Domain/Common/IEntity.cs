namespace JobOpportunities.Domain
{
    public interface IEntity
    {
        Guid Id { get; set; }
        DateTime? CreatedAt { get; set; }
        string? CreatedBy { get; set; }
        DateTime? LastModifiedByAt { get; set; }
        string? LastModifiedBy { get; set; }
    }
}