using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aprende.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class AprendeController : Controller
    {
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(from u in User.Claims select new { u.Type, u.Value });
        }

        
    }
}
