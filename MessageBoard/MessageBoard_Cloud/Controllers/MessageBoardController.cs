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

        public MessageBoardController(UserService _userService)
        {
            userService = _userService;
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

        [Route("CreateThread")]
        public ActionResult<string> CreateThread()
        {
            return StatusCode(500);
        }
    }
}
