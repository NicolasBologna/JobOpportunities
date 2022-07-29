namespace JobOpportunities.Domain
{
    public class Candidate : ApplicationUser
    {
        public ICollection<Skill> Skills { get; set; }
    }
}
