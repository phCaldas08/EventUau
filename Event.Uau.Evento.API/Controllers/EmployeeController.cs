using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Event.Uau.Evento.API.Controllers
{
    [Route("api/event/{eventKey}/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class EmployeeController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetEmployees([FromRoute] Guid eventKey)
        {

            return Ok();
        }
    }
}