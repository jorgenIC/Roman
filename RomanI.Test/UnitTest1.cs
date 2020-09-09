using NUnit.Framework;
using RomanI.Controllers;
using System;

namespace RomanI.Test
{
    public class Tests
    {
        private ToArabicController _toArabic;
        private ToRomanController _toRoman;

        [SetUp]
        public void Setup()
        {
            _toArabic = new ToArabicController();
            _toRoman = new ToRomanController();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
        //the minimumrequired possitive tests
        [TestCase("I", ExpectedResult = 1)]
        [TestCase("IV",ExpectedResult = 4)]
        [TestCase("IX", ExpectedResult = 9)]
        [TestCase("CM", ExpectedResult = 900)]
        [TestCase("MCMIII", ExpectedResult = 1903)]
        [TestCase("MCMXCVII", ExpectedResult = 1997)]
        //Check single numbers
        [TestCase("II", ExpectedResult = 2)]
        [TestCase("III", ExpectedResult = 3)]
        [TestCase("V", ExpectedResult = 5)]
        [TestCase("VI", ExpectedResult = 6)]
        [TestCase("VII", ExpectedResult = 7)]
        [TestCase("VIII", ExpectedResult = 8)]
        [TestCase("X", ExpectedResult = 10)]
        [TestCase("C", ExpectedResult = 100)]
        [TestCase("M", ExpectedResult = 1000)]
        // Check for 0 units, 0 tens and 0 hundreds.
        [TestCase("XL", ExpectedResult = 40)]
        [TestCase("XC", ExpectedResult = 90)]
        [TestCase("CD", ExpectedResult = 400)]
        [TestCase("CDLXX", ExpectedResult = 470)]
        [TestCase("DCCLXXX", ExpectedResult = 780)]
        [TestCase("CDXC", ExpectedResult = 490)]
        [TestCase("CM", ExpectedResult = 900)]
        [TestCase("MII", ExpectedResult = 1002)]
        [TestCase("MMMIII", ExpectedResult = 3003)]
        [TestCase("MMMLXVI", ExpectedResult = 3066)]
        [TestCase("MCM", ExpectedResult = 1900)]
        //Check the subtraction methods where same roman number is reused in more decimal places
        [TestCase("CDXLIV", ExpectedResult = 444)]
        [TestCase("CMXCIX", ExpectedResult = 999)]
        [TestCase("MCDXLIV", ExpectedResult = 1444)]
        [TestCase("MCMXCIX", ExpectedResult = 1999)]
        //Check bigest number, single numbers and longest roman string
        [TestCase("MMMCMXCIX", ExpectedResult = 3999)]
        [TestCase("MCXI", ExpectedResult = 1111)]
        [TestCase("MDLV", ExpectedResult = 1555)]
        [TestCase("MMMDCCCLXXXVIII", ExpectedResult = 3888)]
        public int Test_toArabic(string roman)
        {
            int result = _toArabic.Get(roman);
            return result;
        }

        //String lenth > 15 (too many roman letters) or empty string
        [TestCase("MMMDCCCLXXXVIIII", ExpectedResult = 0)]  //Error
        [TestCase("", ExpectedResult = 0)]  //Error
        //Invalid roman number
        [TestCase("CDEFIX", ExpectedResult = 0)]  //Error
        [TestCase("MMMIIIDCVILX", ExpectedResult = 0)]  //Error
        [TestCase("XM", ExpectedResult = 0)]  //Error  990?
        [TestCase("M+V", ExpectedResult = 0)]  //Error  1005?
        [TestCase("-C", ExpectedResult = 0)]  //Error  -100?
        [TestCase("M C I", ExpectedResult = 0)]  //Error  1101? or should it be valid
        public void Test_toArabicException(string roman)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _toArabic.Get(roman));
        }
 
        //the minimumrequired possitive tests
        [TestCase(1, ExpectedResult = "I")]
        [TestCase(4, ExpectedResult = "IV")]
        [TestCase(9, ExpectedResult = "IX")]
        [TestCase(900, ExpectedResult = "CM")]
        [TestCase(1903, ExpectedResult = "MCMIII")]
        [TestCase(1997, ExpectedResult = "MCMXCVII")]
        //Check single numbers
        [TestCase(2, ExpectedResult = "II")]
        [TestCase(3, ExpectedResult = "III")]
        [TestCase(5, ExpectedResult = "V")]
        [TestCase(6, ExpectedResult = "VI")]
        [TestCase(7, ExpectedResult = "VII")]
        [TestCase(8, ExpectedResult = "VIII")]
        [TestCase(10, ExpectedResult = "X")]
        [TestCase(100, ExpectedResult = "C")]
        [TestCase(1000, ExpectedResult = "M")]
        // Check for 0 units, 0 tens and 0 hundreds. Also check leading 0
        [TestCase(40, ExpectedResult = "XL")]
        [TestCase(90, ExpectedResult = "XC")]
        [TestCase(400, ExpectedResult = "CD")]
        [TestCase(470, ExpectedResult = "CDLXX")]
        [TestCase(780, ExpectedResult = "DCCLXXX")]
        [TestCase(490, ExpectedResult = "CDXC")]
        [TestCase(900, ExpectedResult = "CM")]
        [TestCase(1002, ExpectedResult = "MII")]
        [TestCase(3003, ExpectedResult = "MMMIII")]
        [TestCase(3066, ExpectedResult = "MMMLXVI")]
        [TestCase(1900, ExpectedResult = "MCM")]
        [TestCase(0900, ExpectedResult = "CM")]
        //Check the subtraction methods where same roman number is reused in more decimal places
        [TestCase(444, ExpectedResult = "CDXLIV")]
        [TestCase(999, ExpectedResult = "CMXCIX")]
        [TestCase(1444, ExpectedResult = "MCDXLIV")]
        [TestCase(1999, ExpectedResult = "MCMXCIX")]
        //Check bigest number, single numbers and longest roman string
        [TestCase(3999, ExpectedResult = "MMMCMXCIX")]
        [TestCase(1111, ExpectedResult = "MCXI")]
        [TestCase(1555, ExpectedResult = "MDLV")]
        [TestCase(3888, ExpectedResult = "MMMDCCCLXXXVIII")]
        public string Test_toRoman(int arabic)
        {
            string roman = _toRoman.Get(arabic);
            return roman;
        }
        //the minimumrequired negative tests. Should throw exception. Invalid input message expected.
        [TestCase(0)]
        [TestCase(4000)]
        [TestCase(-1)]
        public void Test_toRomanException(int arabic)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _toRoman.Get(arabic));
        }

        // Front end testing
        // 1. Evaluate string length <= 15 ?
        // 2. Only roman numbers (letters uppercase MDCLXVI)
        // 3. No special characters
        // 4. Integers only (for to Roman conversion)
    }
}