using System.Collections.Generic;
using Infrastructure;

namespace Flicker
{
    public class FlickerImageProvider : IImageProvider
    {
        public IEnumerable<IImageInfo> GetImagesInfoByKeyword(string keyword)
        {
            var flickerImageFeed = new FlickerImageFeed();
            return flickerImageFeed.LoadImages(keyword);
        }
    }
}
