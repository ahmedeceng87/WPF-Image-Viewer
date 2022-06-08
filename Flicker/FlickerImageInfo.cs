using Infrastructure;

namespace Flicker
{
    public class FlickerImageInfo : IImageInfo
    {
        public FlickerImageInfo(string imageLink,
                                string title)
        {
            ImageLink = imageLink;
            Title = title;
        }
        public string ImageLink { get; }
        public string Title { get; }
    }
}
