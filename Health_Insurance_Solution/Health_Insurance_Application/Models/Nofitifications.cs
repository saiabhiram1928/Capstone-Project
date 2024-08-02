namespace Health_Insurance_Application.Models
{
    public class Nofitifications
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CustomerId { get; set; }
    }
}
