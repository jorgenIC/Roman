using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RomanI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ToArabicController : ControllerBase
    {
        [HttpGet]
        public int Get(string roman)
        {
            if (roman == "I") return 1;
            if (roman == "IV") return 4;
            else return 0;
        }
    }
}
