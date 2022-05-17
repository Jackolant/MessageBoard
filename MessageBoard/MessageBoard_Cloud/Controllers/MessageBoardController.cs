using MessageBoard_Cloud.Models;
using MessageBoard_Cloud.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MessageBoard_Cloud.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class MessageBoardController: ControllerBase
    {
        private readonly UserService userService;
        private readonly MessageService messageService;

        public MessageBoardController(UserService _userService, MessageService _messageService)
        {
            userService = _userService;
            messageService = _messageService;
        }

        [Route("Ping")]
        [HttpGet]
        public string ping()
        {
            return "Pong";
        }

        [Route("SignUp")]
        [HttpPost]
        public ActionResult<string> SignUp(MessageBoard_User input_user)
        {
            MessageBoard_User_Data user = userService.SignUp(input_user);
            if (user == null)
            {
                return StatusCode(500);
                
            }
            return $"User Signed Up. Id: {user.Id}";

        }

        [Route("GetUser/{id}")]
        [HttpGet]
        public ActionResult<MessageBoard_User_Data> GetUserById(string id)
        {
            MessageBoard_User_Data user = userService.GetUserByID(id);
            if (user == null)
            {
                return StatusCode(404, $"User {id} Not Found.");
            }
            return user;
        }

        [Route("CreateThread/{userID}")]
        [HttpPost]
        public ActionResult<MessageBoard_Thread> CreateThread(string userID)
        {
            MessageBoard_Thread thread = messageService.CreateMessageThread(userID);
            if (thread != null)
            {
                return thread;
            }
            return StatusCode(500);
        }

        [Route("GetThread/{id}")]
        [HttpGet]
        public ActionResult<MessageBoard_Thread> GetThreadById(string id)
        {
            MessageBoard_Thread thread = messageService.GetMessageThreadByID(id);
            if (thread == null)
            {
                return StatusCode(404, $"Thread {id} not found.");
            }
            return thread;
        }

        [Route("AddMessage")]
        [HttpPost]
        public ActionResult<MessageBoard_Thread> AddMessageToThread([FromBody] MessageBoard_Message_Input inputMessage)
        {
            MessageBoard_Thread thread = messageService.AddMessageToThread(inputMessage);
            if (thread == null)
            {
                return StatusCode(400, "Error Adding Message");
            }
            return thread;
        }

        [Route("GetAllThreads")]
        [HttpGet]
        public ActionResult<Dictionary<string, MessageBoard_Thread>> GetAllThreads()
        {
            return messageService.GetAllThreads();
        }

        [Route("GetMessages/{threadId}")]
        [HttpGet]
        public ActionResult<Dictionary<string, MessageBoard_Message>> GetMessagesForThread(string threadId)
        {
            Dictionary<string, MessageBoard_Message> messages = messageService.GetMessagesForThread(threadId);
            if (messages == null)
            {
                return StatusCode(404, $"Thread {threadId} Not Found.");
            }
            return messages;
        }
    }
}
