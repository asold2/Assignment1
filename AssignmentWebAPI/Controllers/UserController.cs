using System;
using System.Threading.Tasks;
using AssignmentWebAPI.Data;
using AssignmentWebAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AssignmentWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<LoginUser>> ValidateUser([FromQuery] string username, [FromQuery] string password)
        {
            Console.WriteLine("Here");
            try
            {
                var user = userService.ValidateUser(username, password);
                Console.WriteLine(user.Result.UserName);
                return Ok(user.Result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    
        
    }
}