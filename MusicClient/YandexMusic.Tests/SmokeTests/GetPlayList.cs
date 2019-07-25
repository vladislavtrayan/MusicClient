using NUnit.Framework;
    
namespace YandexMusic.Tests.SmokeTests
{
    [TestFixture]
    public class GetPlayList : BaseTest
    {
        [Test]
        [TestCase("never.theless","2012022Trayan","Плейлист дня")]
        public void GetPlayListOfTheDay(string userName,string password,string expectedResult)
        {
            var yandexApi = new YandexApi();
            yandexApi.Password = password.ToCharArray();
            yandexApi.UserName = userName.ToCharArray();
            Assert.AreEqual(expectedResult, yandexApi.GetPlayOfTheDay().Title);
        }
        
        [Test]
        [TestCase("never.theless","2012022Trayan","Дежавю")]
        public void GetPlayListODeJaVu(string userName,string password,string expectedResult)
        {
            var yandexApi = new YandexApi();
            yandexApi.Password = password.ToCharArray();
            yandexApi.UserName = userName.ToCharArray();
            Assert.AreEqual(expectedResult, yandexApi.GetPlayListDeJaVu().Title);
        }
    }
}