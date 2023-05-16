using _111.Schemas;
using Microsoft.AspNetCore.Mvc;
using MySQLApp;

namespace _111.Controllers
{
    [ApiController]
    public class Suppliers : ControllerBase
    {
        [HttpGet]
        [Route("/suppliers")]
        public IActionResult GetAllSupplies(ApplicationContext db, [FromHeader] string authorization)
        {
            if (!Utils.CheckToken(db, authorization)) return Unauthorized();
            return Ok(db.Suppliers.ToList());
        }

    }
}
