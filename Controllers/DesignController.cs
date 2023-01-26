using Backend.Dtos;
using Backend.Interface.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class DesignController : ControllerBase
    {
        private readonly IDesignService _designService;
        public DesignController(IDesignService designService) => (_designService) = (designService);
        [HttpPost("design/add")]
        public async Task<IActionResult> AddDesign(DesignDto designDto)
        {
            var design = await _designService.Add(designDto);
            return (design.Status) ? Ok(design) : BadRequest(design);
        }
        [HttpGet("design/get/{designName}")]
        public async Task<IActionResult> GetDesign(string designName)
        {
            var design = await _designService.Get(designName);
            return (design.Status) ? Ok(design) : BadRequest(design);
        }
        [HttpGet("designs/all")]
        public async Task<IActionResult> GetAllDesigns()
        {
            var design = await _designService.GetAll();
            return (design.Status) ? Ok(design) : BadRequest(design);
        }
        [HttpDelete("design/delete/{name}")]
        public async Task<IActionResult> DeleteDesign(string name)
        {
            var design = await _designService.Delete(name);
            return (design.Status) ? Ok(design) : BadRequest(design);
        }
    }
}