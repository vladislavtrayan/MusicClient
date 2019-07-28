using System;
using System.Collections.Generic;
using System.Text;
using Core.Api;
using NUnit.Framework;

namespace Core.Tests
{
    public class BaseTest
    {
        protected RestFrameworkClient _client;

        [SetUp]
        public virtual void InitTest()
        {
            _client = RestFrameworkClientFactory.GetRestClient();
        }

        [TearDown]
        public virtual void CleanTest()
        {
        }
    }

}
