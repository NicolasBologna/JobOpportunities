namespace JobOpportunities.Core.Features.SkillLevels.Models
{
    public class GetSkillLevelsResponse
    {
        public Guid Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
