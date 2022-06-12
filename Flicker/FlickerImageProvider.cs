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

        public IEnumerable<IImageInfo> GetImagesInfoByKeyword(string keyword)
        {           
            return flickerImageFeed.LoadImages(keyword);
        }
    }
}
