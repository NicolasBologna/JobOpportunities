namespace JobOpportunities.Domain
{
    public class Knowledge : EntityBase
    {
        public Knowledge(string title)
        {
            Title = title;
        }
        public string Title { get; set; }
        public string? Description { get; set; }
    }
}
