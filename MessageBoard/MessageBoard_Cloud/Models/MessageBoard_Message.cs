namespace MessageBoard_Cloud.Models
{
    public class MessageBoard_Message
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string message { get; set; }

        public string owner { get; set; }

        public MessageBoard_Message() { }

        public MessageBoard_Message(string inputMessage, string inputOwner)
        {
            message = inputMessage;
            owner = inputOwner;
        }
    }

    public class MessageBoard_Message_Input
    {
        public string message { get; set; }

        public string owner { get; set; }

        public string thread { get; set; }
    }
}
