using AppAPIs.Dtos;
using AppAPIs.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JourneysController : ControllerBase
    {
        private readonly IJourneyServices _journeyServices;
        private readonly IMapper  _mapper;


        public JourneysController(IJourneyServices journeyServices, IMapper mapper)
        {
            _journeyServices = journeyServices;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
           // var journeys = await _journeyServices.GetAll();
            var journeysDto = _mapper.Map<IEnumerable<JourneyDto>>(await _journeyServices.GetAll());

            return Ok(journeysDto);
        }
        [HttpGet ("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            if (!_journeyServices.IdExist(id).Result)
            {
                return BadRequest("This id is not found or not valid!");
            }

            var journey = await _journeyServices.GetByID(id);
            if (journey == null)
                return NotFound();

           // var journeyDto = _mapper.Map<JourneyDto>(journey);
           
            return Ok(_mapper.Map<JourneyDto>(journey));
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(JourneyDto journeyDto)
        {
            var journey = _mapper.Map<Journey>(journeyDto);
            await _journeyServices.Add(journey);            
             return Ok(journey);           
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id ,[FromBody]JourneyDto journeyDto)
        {
            if (!_journeyServices.IdExist(id).Result)
            {
                return BadRequest("This id is not found or not valid!");
            }

            var journey = await _journeyServices.GetByID(id);
           
            if (journey == null)
                return NotFound($"No journey was found with ID:{id}");

            var journeyMapper = _mapper.Map<Journey>(journeyDto);
            _journeyServices.Update(journeyMapper);
            return Ok(journeyMapper);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (!_journeyServices.IdExist(id).Result)
            {
                return BadRequest("This id is not found or not valid!");
            }

            var journey = await _journeyServices.GetByID(id);
            if (journey == null)
                return NotFound($"No journey was found with ID:{id}");

            _journeyServices.Delete(journey);
            return Ok(journey);
        }
    }
}
