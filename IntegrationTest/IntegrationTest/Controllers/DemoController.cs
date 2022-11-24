using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntegrationTest.Interfaces;

namespace IntegrationTest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        IEnumerable<string> bdg;

        public DemoController(IBDG bolsadegatos)
        {
            bdg = bolsadegatos.GetList();
        }

        [HttpGet]
        public IActionResult get(string toFind)
        {
            var eleme = bdg.Where(X => X.ToLower() == toFind.ToLower());
            if (eleme != null && eleme.Count() > 0)
                return Content("Exists");
            else
                return NotFound();

        }
    }
}
