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

        /*public MessageBoard_Thread CreateMessageThread(string userID)
        {

        }*/
    }
}
