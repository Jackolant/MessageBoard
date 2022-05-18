using MessageBoard_Cloud.Data.Interfaces;
using MessageBoard_Cloud.Models;

namespace MessageBoard_Cloud.Data
{
    public class MessageBoard_UserData : UserData
    {
        /*NOTE: If I were implementing this for reals I would hook this up to real database. For the sake of simplicity I'm just creating a static Dictionary and storing the data there*/
        private static Dictionary<string, MessageBoard_User_Data> cache = new Dictionary<string, MessageBoard_User_Data>();

        public MessageBoard_UserData()
        {

        }

        public bool CreateUser(MessageBoard_User_Data input_user)
        {
            try
            {
                cache.Add(input_user.Id, input_user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public MessageBoard_User_Data GetUserById(string id)
        {
            MessageBoard_User_Data user = null;
            cache.TryGetValue(id, out user);
            return user;
        }


    }
}
