using MessageBoard_Cloud.Models;

namespace MessageBoard_Cloud.Data.Interfaces
{
    public interface UserData
    {
        bool CreateUser(MessageBoard_User_Data input_user);

        MessageBoard_User_Data GetUserById(string id);
    }
}
