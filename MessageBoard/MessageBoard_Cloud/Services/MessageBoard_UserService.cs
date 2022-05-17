using MessageBoard_Cloud.Data.Interfaces;
using MessageBoard_Cloud.Models;
using MessageBoard_Cloud.Services.Interfaces;

namespace MessageBoard_Cloud.Services
{
    public class MessageBoard_UserService : UserService
    {
        private readonly UserData userData;

        public MessageBoard_UserService(UserData _userData)
        {
            userData = _userData;
        }

        public MessageBoard_User_Data SignUp(MessageBoard_User input_user)
        {
            MessageBoard_User_Data user = new MessageBoard_User_Data(input_user);
            if (userData.CreateUser(user))
            {
                return user;
            }
            return null;
        }

        public MessageBoard_User_Data GetUserByID(string id)
        {
            MessageBoard_User_Data user = userData.GetUserById(id);
            return user;
        }
    }
}
