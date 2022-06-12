using Infrastructure;

namespace Fliicker.Unit.Tests
{
    public class TestImageInfo : IImageInfo
    {
        public TestImageInfo(string imageLink,
                             string title)
        {
            ImageLink = imageLink;
            Title = title;
        }
        public string ImageLink { get; }
        public string Title { get; }
    }
}
