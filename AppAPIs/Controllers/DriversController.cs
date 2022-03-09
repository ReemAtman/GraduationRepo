using AppAPIs.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly IDriverService _driverServices;
        private readonly IMapper _mapper;


        public DriversController(IDriverService driverServices, IMapper mapper)
        {
            _driverServices = driverServices;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {            
            var driverDto = _mapper.Map<IEnumerable<DriverDto>>(await _driverServices.GetAll());

            return Ok(driverDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            if (!_driverServices.IdExist(id).Result)
            {
                return BadRequest("This id is not found or not valid!");
            }

            var driver = await _driverServices.GetByID(id);
            if (driver == null)
                return NotFound();

            return Ok(_mapper.Map<DriverDto>(driver));
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(DriverDto driverDto)
        {
            var driver = _mapper.Map<Driver>(driverDto);
            await _driverServices.Add(driver);
            return Ok(driver);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] DriverDto driverDto)
        {
            if (!_driverServices.IdExist(id).Result)
            {
                return BadRequest("This id is not found or not valid!");
            }

            var driver = await _driverServices.GetByID(id);

            if (driver == null)
                return NotFound($"No driver was found with ID:{id}");

            var driverMapper = _mapper.Map<Driver>(driverDto);
            _driverServices.Update(driverMapper);
            return Ok(driverMapper);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (!_driverServices.IdExist(id).Result)
            {
                return BadRequest("This id is not found or not valid!");
            }

            var driver = await _driverServices.GetByID(id);
            if (driver == null)
                return NotFound($"No driver was found with ID:{id}");

            _driverServices.Delete(driver);
            return Ok(driver);
        }
    }
}
