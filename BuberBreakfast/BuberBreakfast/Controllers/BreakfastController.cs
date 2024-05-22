using BuberBreakfast.Models;
using BuberBreakfast.Services;
using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreakfastController : ControllerBase
    {
        private readonly IBreakfastService _breakfastService;
        public BreakfastController(IBreakfastService breakfastService)
        {
            this._breakfastService = breakfastService;
        }
        [HttpPost]
        public IActionResult CreateBreakfast([FromBody] CreateBreakfastRequest request)
        {
            Breakfast newBreakfast = new Breakfast(
                Guid.NewGuid(),
                request.Name,
                request.Description,
                request.StartDateTime,
                request.EndDateTime,
                DateTime.UtcNow,
                request.Savory,
                request.Sweet
                );
            _breakfastService.CreateBreakfast(newBreakfast);
           
            return CreatedAtAction(nameof(GetBreakfast),new {id=newBreakfast.Id},newBreakfast);
        }

        [HttpGet]
        public IActionResult GetResults()
        {
            
            return Ok(_breakfastService.GetBreakfasts());
        }
        [HttpGet("{id:guid}")]
        public IActionResult GetBreakfast(Guid id)
        {
           Breakfast breakfastFound = _breakfastService.GetBreakfast(id);
            if(breakfastFound != null)
            {

            return Ok(breakfastFound);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPut("{id:guid}")]
        public IActionResult UpdateBreakfast(Guid id,[FromBody] UpdateBreakfastRequest request)
        {
            Breakfast found = _breakfastService.GetBreakfast(id);
            Breakfast newObj = new Breakfast(
                found.Id,
                request.Name,
                request.Description,
                request.StartDateTime,
                request.EndDateTime,
                DateTime.UtcNow,
                request.Savory,
                request.Sweet
            );
            if(found != null){
                _breakfastService.UpdateBreakfast(newObj);
                return NoContent();
            }else{
                return NotFound();
            }
        }
        [HttpDelete("{id:guid}")]
        public IActionResult DeleteBreakfast(Guid id)
        {
            Breakfast found = _breakfastService.GetBreakfast(id);
            if(found != null){
                _breakfastService.DeleteBreakfast(found.Id);
                return NoContent();
            }else{
                return NotFound();
            }
        }


    }
}
