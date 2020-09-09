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
            CheckRomanContent(roman);
            int arabicNumber = 0;
            int cnt = 0;

            while (roman.Length != 0 && cnt <= maxLength)
            {
                foreach (string token in _romanToArabic.Keys)
                {
                    if (roman.StartsWith(token))
                    {
                        roman = roman.Substring(token.Length);
                        arabicNumber += _romanToArabic[token];
                    }
                }
                cnt++;
            }

            return arabicNumber;
        }

        private void CheckRomanContent(string roman)
        {
            if (roman.Length > maxLength)
                throw new ArgumentOutOfRangeException("Roman Number is too long. Max 15 characters.");
            if (roman.Length == 0)
                throw new ArgumentOutOfRangeException("Please type a Roman Number to Convert using letters: MDCLXVI = 1666");
            if (roman.Contains("MMMM"))
                throw new ArgumentOutOfRangeException("Max Roman Number is: MMMCMXCIX = 3999");
            int i = string.Compare(roman, roman.ToUpper(), true);
            if (i >= 0)
                throw new ArgumentOutOfRangeException("Roman Number should only contain upper case characters.");
        }

        private Dictionary<string, int> _romanToArabic;
        private int maxLength = 15;
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
