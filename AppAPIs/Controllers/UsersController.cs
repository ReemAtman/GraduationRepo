using AppAPIs.Dtos;
using AppAPIs.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;


        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var userDto = _mapper.Map<IEnumerable<UserDto>>(await _userService.GetAll());

            return Ok(userDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            if (!_userService.IdExist(id).Result)
            {
                return BadRequest("This id is not found or not valid!");
            }

            var user = await _userService.GetByID(id);
            if (user == null)
                return NotFound();

            // var userDto = _mapper.Map<UserDto>(user);

            return Ok(_mapper.Map<UserDto>(user));
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userService.Add(user);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UserDto userDto)
        {
            if (!_userService.IdExist(id).Result)
            {
                return BadRequest("This id is not found or not valid!");
            }

            var user = await _userService.GetByID(id);

            if (user == null)
                return NotFound($"No user was found with ID:{id}");

            var userMapper = _mapper.Map<User>(userDto);
            _userService.Update(userMapper);
            return Ok(userMapper);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (!_userService.IdExist(id).Result)
            {
                return BadRequest("This id is not found or not valid!");
            }

            var user = await _userService.GetByID(id);
            if (user == null)
                return NotFound($"No user was found with ID:{id}");

            _userService.Delete(user);
            return Ok(user);
        }
    }
}
