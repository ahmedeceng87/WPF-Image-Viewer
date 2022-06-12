using System.Collections.Generic;
using Infrastructure;

namespace Flicker
{
    public class FlickerImageProvider : IImageProvider
    {
        IImageFeed flickerImageFeed;

        public FlickerImageProvider(IImageFeed imageFeed)
        {
            flickerImageFeed = imageFeed;
        }
        public static IImageProvider GetInstance()
        {
            return new FlickerImageProvider(new FlickerImageFeed());
        }
        public IEnumerable<IImageInfo> GetImagesInfoByKeyword(string keyword)
        {           
            return flickerImageFeed.LoadImages(keyword);
        }
    }
}
