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
        // POST api/values
        [HttpPost(APIRoute.iTopService.CreateIncident)]
        public async Task<IActionResult> CreateIncident([FromBody] string value)
        {
            var response = await iTopService.CreateInsidentAsync();

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Posts.Get.Replace("{PostId}", post.Id.ToString());

            return Created(locationUri, response);
        }
    }
}