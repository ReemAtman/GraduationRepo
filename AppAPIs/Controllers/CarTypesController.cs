using AppAPIs.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarTypesController : ControllerBase
    {
        private readonly ICarTypeService _carTypeService;
        private readonly IMapper _mapper;


        public CarTypesController(ICarTypeService carTypeService, IMapper mapper)
        {
            _carTypeService = carTypeService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {            
            var cartypeDto = _mapper.Map<IEnumerable<CarTypeDto>>(await _carTypeService.GetAll());

            return Ok(cartypeDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            if (!_carTypeService.IdExist(id).Result)
            {
                return BadRequest("This id is not found or not valid!");
            }

            var cartype = await _carTypeService.GetByID(id);
            if (cartype == null)
                return NotFound();                      

            return Ok(_mapper.Map<CarTypeDto>(cartype));
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(CarTypeDto cartypeDto)
        {
            var cartype = _mapper.Map<CarType>(cartypeDto);
            await _carTypeService.Add(cartype);
            return Ok(cartype);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] CarTypeDto cartypeDto)
        {
            if (!_carTypeService.IdExist(id).Result)
            {
                return BadRequest("This id is not found or not valid!");
            }

            var cartype = await _carTypeService.GetByID(id);

            if (cartype == null)
                return NotFound($"No car type was found with ID:{id}");

            var cartypeMapper = _mapper.Map<CarType>(cartypeDto);
            _carTypeService.Update(cartypeMapper);
            return Ok(cartypeMapper);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (!_carTypeService.IdExist(id).Result)
            {
                return BadRequest("This id is not found or not valid!");
            }

            var cartype = await _carTypeService.GetByID(id);
            if (cartype == null)
                return NotFound($"No car type was found with ID:{id}");

            _carTypeService.Delete(cartype);
            return Ok(cartype);
        }
    }
}
