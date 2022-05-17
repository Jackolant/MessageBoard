using MessageBoard_Cloud.Data.Interfaces;
using MessageBoard_Cloud.Models;

namespace MessageBoard_Cloud.Data
{
    public class MessageBoard_MessageData : MessageData
    {
        /*NOTE: If I were implementing this for reals I would hook this up to real database. For the sake of simplicity I'm just creating a static Dictionary and storing the data there*/
        private static Dictionary<string, MessageBoard_Thread> cache = new Dictionary<string, MessageBoard_Thread>();


        public MessageBoard_MessageData()
        {

        }

        public bool CreateThread(MessageBoard_Thread inputThread)
        {
            try
            {
                cache.Add(inputThread.Id, inputThread);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public MessageBoard_Thread GetThreadByID(string id)
        {
            MessageBoard_Thread thread = null;
            cache.TryGetValue(id, out thread);
            return thread;
        }

        public bool UpdateThread(MessageBoard_Thread inputThread)
        {
            try
            {
                cache.Remove(inputThread.Id);
                cache.Add(inputThread.Id, inputThread);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Dictionary<string, MessageBoard_Thread> GetAllThreads()
        {
            return cache;
        }
    }
}
