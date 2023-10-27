namespace Domain.DtoModels
{
    public class PollOptionDto
    {
        public int PollOptionId { get; set; }
        public int PollEventId { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
        public int Precentage { get; set; }
    }
}
