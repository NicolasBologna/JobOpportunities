namespace JobOpportunities.Domain
{
    public class ApplicationUser : EntityBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
