using NUnit.Framework;

namespace YandexMusic.Tests
{
    public class BaseTest
    {
		
        [SetUp]
        public virtual void InitTest()
        {

        }
		
        [TearDown]
        public virtual void CleanTest()
        {
        }
    }
}