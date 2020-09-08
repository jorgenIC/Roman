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
    public class ToRomanController : ControllerBase
    {
        [HttpGet]
        public string Get(int arabic)
        {
            if (arabic == 1) return "I";
            else return "";
        }
    }
}
