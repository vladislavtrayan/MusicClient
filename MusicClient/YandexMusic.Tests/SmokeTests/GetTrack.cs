using NUnit.Framework;
    
namespace YandexMusic.Tests.SmokeTests
{
    [TestFixture]
    public class GetTrack : BaseTest
    {
        [Test]
        [TestCase("never.theless","2012022Trayan","martin garrix scared to be lonely","Scared to Be Lonely")]
        public void GetTrackTest(string userName,string password,string trackName,string expectedResult)
        {
            var yandexApi = new YandexApi();
            yandexApi.Password = password.ToCharArray();
            yandexApi.UserName = userName.ToCharArray();
            Assert.AreEqual(expectedResult, yandexApi.GetTrack(trackName).Title);
        }
    }
}