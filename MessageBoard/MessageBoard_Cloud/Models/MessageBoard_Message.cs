namespace MessageBoard_Cloud.Models
{
    public class MessageBoard_Message
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string message { get; set; }
    }
}
