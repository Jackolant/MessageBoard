using MessageBoard_Cloud.Models;

namespace MessageBoard_Cloud.Services.Interfaces
{
    public interface UserService
    {
        MessageBoard_User_Data SignUp(MessageBoard_User input_user);

        MessageBoard_User_Data GetUserByID(string id);
    }
}
