namespace MessageBoard_Cloud.Models
{
    public class MessageBoard_Thread
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public Dictionary<string, MessageBoard_Message> messages = new Dictionary<string, MessageBoard_Message>();

        public string owner { get; set; }

        public string name { get; set; }


        public MessageBoard_Thread() { }

        public MessageBoard_Thread(string input_owner, string input_name)
        {
            owner = input_owner;
            name = input_name;
        }
    }
}
