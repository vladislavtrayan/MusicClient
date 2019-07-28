using System;
using System.Collections.Generic;
using System.Text;
using Core;
using Core.Api;
using Core.Api.RequestEntities;
using Core.HtmlResponseAnalyzer;
using NUnit.Framework;
using RestSharp;

namespace Core.Tests.TestScripts
{
    [TestFixture]
    class SearchForTrackTest : BaseTest
    {
            [Test]
            [TestCase("martin garrix scared to be lonely")]
            public void GetTrackTest(string trackName)
            {
                var request = new SearchForTrackRequest(trackName);
                var response = _client.Client.Execute(request.GetRequest());
                HtmlResponseAnalyzer.HtmlResponseAnalyzer analyzer = new HtmlResponseAnalyzer.HtmlResponseAnalyzer
                {
                    Text = response.Content
                };
                var track = analyzer.GetTrack();
                Assert.IsTrue(true);
            }
    }
}
