
namespace MessageBoard_Cloud.Models
{
    public class MessageBoard_User
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }

    public class MessageBoard_User_Data : MessageBoard_User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public MessageBoard_User_Data(MessageBoard_User input)
        {
            FirstName = input.FirstName;
            LastName = input.LastName;
            Email = input.Email;
            Password = input.Password;
        }
    }
}
