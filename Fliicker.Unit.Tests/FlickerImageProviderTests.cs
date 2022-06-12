using Microsoft.VisualStudio.TestTools.UnitTesting;
using Flicker;
using System.Collections.Generic;
using System.Linq;
using Rhino.Mocks;
using Infrastructure;

namespace Fliicker.Unit.Tests
{
    [TestClass()]
    public class FlickerImageProviderTests
    {
        [TestMethod()]
        [DataRow("nature")]
        public void GetImagesInfoByKeywordTest(string keyword)
        {
            // Arrange
            var imageFeed = MockRepository.GenerateMock<IImageFeed>();
            var testImageInfos = new List<TestImageInfo>
            {
                new TestImageInfo($"www.testlink.{keyword}1.jpg",
                                  $"Title : {keyword}"),
                new TestImageInfo($"www.testlink.{keyword}2.jpg",
                                  $"Title : {keyword}")
            };

            imageFeed.Stub(obj => obj.LoadImages(keyword)).Return(testImageInfos);
            var flickerImageProvider = new FlickerImageProvider(imageFeed);

            // Act
            var data = ((IImageProvider)flickerImageProvider).GetImagesInfoByKeyword(keyword);

            // Assert 
            Assert.IsNotNull(data, "No added data returned");
            Assert.IsTrue(data.Any(img => img.Title == $"Title : {keyword}"
                                          &&
                                          img.ImageLink == $"www.testlink.{keyword}1.jpg")
                , "Expected image info is not present in returned data");
        }
    }
}