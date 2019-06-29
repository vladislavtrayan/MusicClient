using NUnit.Framework;
    
namespace YandexMusic.Tests.SmokeTests
{
    [TestFixture]
    public class LogIn : BaseTest
    {
        [Test]
        [TestCase("never.theless","2012022Trayan")]
        public void LogInTest(string userName,string password)
        {
            var yandexApi = new YandexApi();
            yandexApi.Password = password.ToCharArray();
            yandexApi.UserName = userName.ToCharArray();
            yandexApi.Authorize();
            Assert.True(true, "Some error");
        }
    }
}