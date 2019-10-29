using NUnit.Framework;
using StudyBuddy;

namespace UnitTest
{
    [TestFixture]
    public class ValidatorTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckEmail()
        {
            string email = "titas@gmail.com";         //change for checking
            Assert.IsTrue(new Validator().CheckEmail(email));
        }

        [Test]
        public void CheckPassword()
        {
            string password = "Titas251";             //change for checking
            Assert.IsTrue(new Validator().CheckPassword(password));
        }
    } 
}