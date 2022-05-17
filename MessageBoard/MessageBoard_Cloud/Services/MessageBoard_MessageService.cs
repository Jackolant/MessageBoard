using MessageBoard_Cloud.Data.Interfaces;
using MessageBoard_Cloud.Models;
using MessageBoard_Cloud.Services.Interfaces;

namespace MessageBoard_Cloud.Services
{
    public class MessageBoard_MessageService : MessageService
    {
        private readonly MessageData messageData;

        public MessageBoard_MessageService(MessageData _messageData)
        {
            messageData = _messageData;
        }

        public MessageBoard_Thread CreateMessageThread(string userID)
        {
            MessageBoard_Thread thread = new MessageBoard_Thread(userID);
            if (messageData.CreateThread(thread))
            {
                return thread;
            }
            else
            {
                return null;
            }
        }

        public MessageBoard_Thread GetMessageThreadByID(string id)
        {
            return messageData.GetThreadByID(id);
        }

        public MessageBoard_Thread AddMessageToThread(MessageBoard_Message_Input messageInput)
        {
            MessageBoard_Thread thread = GetMessageThreadByID(messageInput.thread);
            if (thread == null)
            {
                return null;
            }
            MessageBoard_Message message = new MessageBoard_Message(messageInput.message, messageInput.owner);
            thread.messages.Add(message.Id, message);
            if (!messageData.UpdateThread(thread))
            {
                return null;
            }

            return thread;
        }

        public Dictionary<string, MessageBoard_Thread> GetAllThreads()
        {
            return messageData.GetAllThreads();
        }

        public Dictionary<string, MessageBoard_Message> GetMessagesForThread(string threadId)
        {
            MessageBoard_Thread thread = GetMessageThreadByID(threadId);
            if (thread == null)
            {
                return null;
            }
            return thread.messages;
        }
    }
}
