using MessageBoard_Cloud.Models;

namespace MessageBoard_Cloud.Services.Interfaces
{
    public interface MessageService
    {
        MessageBoard_Thread CreateMessageThread(string userID, string name);

        MessageBoard_Thread GetMessageThreadByID(string id);

        MessageBoard_Thread AddMessageToThread(MessageBoard_Message_Input messageInput);

        Dictionary<string, MessageBoard_Thread> GetAllThreads();

        Dictionary<string, MessageBoard_Message> GetMessagesForThread(string threadId);
    }
}
