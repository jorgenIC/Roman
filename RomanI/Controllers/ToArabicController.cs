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
            InitDictionary();
            int arabicNumber = 0;

            while (roman.Length != 0)
            {
                foreach (string token in _romanToArabic.Keys)
                {
                    if (roman.StartsWith(token))
                    {
                        roman = roman.Substring(token.Length);
                        arabicNumber += _romanToArabic[token];
                    }
                }
            }

            return arabicNumber;
        }

        private Dictionary<string, int> _romanToArabic;
        private void InitDictionary()
        {
            _romanToArabic = new Dictionary<string, int>
            {
                {"M", 1000},
                {"CM", 900},
                {"D",  500},
                {"CD", 400},
                {"C",  100},
                {"XC",  90},
                {"L",   50},
                {"XL",  40},
                {"X",   10},
                {"IX",   9},
                {"V",    5},
                {"IV",   4},
                {"I",    1}
            };
        }


    }
}
