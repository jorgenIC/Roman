using NUnit.Framework;
using RomanI.Controllers;

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
        public int Test_toArabic(string roman)
        {
            int result = _toArabic.Get(roman);
            //if (roman.Equals("I"))
            //    return 1;
            //else
            //    return 0;
            return result;
        }
        //the minimumrequired possitive tests
        [TestCase(1, ExpectedResult = "I")]
        [TestCase(4, ExpectedResult = "IV")]
        [TestCase(9, ExpectedResult = "IX")]
        [TestCase(900, ExpectedResult = "CM")]
        [TestCase(1903, ExpectedResult = "MCMIII")]
        [TestCase(1997, ExpectedResult = "MCMXCVII")]
        public string Test_toRoman(int arabic)
        {
            string roman = _toRoman.Get(arabic);
            return roman;
        }
        //the minimumrequired negative tests
        [TestCase(0)]
        [TestCase(4000)]
        [TestCase(-1)]
        public void Test_toRomanException(int arabic)
        {

        }
    }
}