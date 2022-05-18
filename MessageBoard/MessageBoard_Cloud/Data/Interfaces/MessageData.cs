using MessageBoard_Cloud.Models;

namespace MessageBoard_Cloud.Data.Interfaces
{
    public interface MessageData
    {
        bool CreateThread(MessageBoard_Thread inputThread);

        MessageBoard_Thread GetThreadByID(string id);

        bool UpdateThread(MessageBoard_Thread inputThread);

        Dictionary<string, MessageBoard_Thread> GetAllThreads();
    }
}
