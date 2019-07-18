using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iTopClientService.Contract.V1;
using iTopClientService.Contract.V1.Response;
using iTopClientService.Contract.V1.Requests;
using iTopClientService.Service;
using Microsoft.AspNetCore.Mvc;

namespace iTopClientService.Controllers
{
    
    [ApiController]
    public class iTopServiceController : ControllerBase
    {
        private readonly IiTopService itopService;

        public iTopServiceController(IiTopService iTopService)
        {
            itopService = iTopService;
        }
        // POST api/values
       [HttpPost(APIRoute.iTopService.CreateIncident)]
        public async Task<IActionResult> CreateIncident([FromBody] iTopCreateRequest value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await itopService.CreateInsidentAsync(value);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + APIRoute.iTopService.CreateIncident;

            return Created(locationUri, response);
        }
    }
}