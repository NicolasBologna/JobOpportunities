namespace EndavaCareers.API.Dto
{
    public class JobOfferForUpdateDto
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime ValidUntil { get; set; }
    }
}
