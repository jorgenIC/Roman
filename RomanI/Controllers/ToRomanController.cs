using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;


namespace RomanI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ToRomanController : ControllerBase
    {
        [HttpGet]
        public string Get(int arabic)
        {
            CheckBoundary(arabic);
            InitDictionary();
            romanNumeral = new StringBuilder();
            foreach (var arabicDigit in _arabicToRoman.Keys)
            {
                while (arabic >= arabicDigit)
                {
                    romanNumeral.Append(_arabicToRoman[arabicDigit]);
                    arabic -= arabicDigit;
                }
            }
            return romanNumeral.ToString();
        }

        private void CheckBoundary(int arabic)
        {
            if (arabic <= 0)
                throw new ArgumentOutOfRangeException("Roman Numbers cannot be zero or negative.");
            if (arabic >= 4000)
                throw new ArgumentOutOfRangeException("Roman Numbers cannot exceed 3999.");
        }
        private Dictionary<int, string> _arabicToRoman;
        private StringBuilder romanNumeral;

        private void InitDictionary()
        {
            _arabicToRoman = new Dictionary<int, string>
            {
                {1000,"M"},
                {900,"CM"},
                {500,"D"},
                {400,"CD"},
                {100,"C"},
                {90,"XC"},
                {50,"L"},
                {40,"XL"},
                {10,"X"},
                {9,"IX"},
                {5,"V"},
                {4,"IV"},
                {1 ,"I"}
            };
        }
    }
}
