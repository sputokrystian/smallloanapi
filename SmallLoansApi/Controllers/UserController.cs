using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmallLoansApi.Models.Dtos;
using SmallLoansApi.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SmallLoansApi.Models.Status;

namespace SmallLoansApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="createUser"></param>
        /// <response code="201">User Created at ID</response>
        /// <response code="400">Bad request</response>
        /// <response code="409">User already exists</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost("[action]")]
        public IActionResult CreateUser(CreateUserDto createUser)
        {
            if (_userService.CheckUserExistsByName(createUser.Name))
            {
                return StatusCode((int)Reponse.Confilict);
            }
            var userId = _userService.CreateUser(createUser);

            if (userId != 0)
                return CreatedAtRoute("GetUser", new { id = userId }, userId);
            else
                return StatusCode((int)Reponse.InternalServerError);
        }

        /// <summary>
        /// Get all users. Loan statuses
        /// </summary>
        /// <response code="200">OK</response>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet("[action]")]
        public async Task<ActionResult<List<UserDto>>> GetUsers()
        {
            return await _userService.GetUsers();
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">OK</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">User doesn't exist</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet("{id}", Name = "[action]")]
        public ActionResult<UserDto> GetUser([FromRoute] int id)
        {
            var user = _userService.GetUserWithLoans(id);

            if (user == null)
                return NotFound();

            return user;
        }
    }
}