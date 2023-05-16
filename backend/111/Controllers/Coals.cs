using _111.Schemas;
using Microsoft.AspNetCore.Mvc;
using MySQLApp;

namespace _111.Controllers
{
    [ApiController]
    public class Coals : ControllerBase
    {
        [HttpGet]
        [Route("/coals")]
        public IActionResult GetAllCoals(ApplicationContext db, [FromHeader] string authorization)
        {
            if (!Utils.CheckToken(db, authorization)) return Unauthorized();
            List<DislayCoal> toDisplay = new List<DislayCoal>();

            foreach (var coal in db.Coals.ToList())
            {
                var coal_class = db.Coal.FirstOrDefault(x => x.ID == coal.coal);


                var coal_name = db.Coal_names.FirstOrDefault(x => x.ID == coal_class.Name);

                toDisplay.Add(new DislayCoal
                {
                    coal = $"{coal_name.Name} {coal_class.Class}",
                    coast = coal.coast,
                    ID = coal.ID,
                    supplier = coal.supplier
                });
            }


            return Ok(toDisplay);
        }

    }
}
