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
            string email = "titas";
            Assert.IsFalse(new Validator().CheckEmail(email));
            email = "titas@gmail.com";
            Assert.IsTrue(new Validator().CheckEmail(email));
        }

        [Test]
        public void CheckPassword()
        {
            string password = "titas";
            Assert.IsFalse(new Validator().CheckPassword(password));
            password = "its251";
            Assert.IsFalse(new Validator().CheckPassword(password));
            password = "4566521";
            Assert.IsFalse(new Validator().CheckPassword(password));
            password = "Titas251";
            Assert.IsTrue(new Validator().CheckPassword(password));
        }
    } 
}