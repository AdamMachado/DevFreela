using DevFreela.API.Model;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    public class UserControllers : ControllerBase
    {
        readonly IUserService _userService;
        public UserControllers(IUserService userService)
        {
            _userService = userService;
        }

        //api/users/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetUser(id);
            if(user == null)
            {
                return NotFound();
            }
            
            return Ok(user);
        }

        //api/users
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserInputModel createUserModel)
        {
            var id = _userService.Create(createUserModel);
            
            return CreatedAtAction(nameof(GetById), new {Id = id }, createUserModel);
        }

        // api/users/1/login
        [HttpPut("{id}/login")]
        public IActionResult Login(int id, [FromBody] LoginModel login)
        {
            return NoContent();
        }

    }
}
