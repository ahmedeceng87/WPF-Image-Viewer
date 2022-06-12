using System;
using Flicker;
using Infrastructure;

namespace ImageProvider
{
    public class ImageProviderFactory
    {
        public IImageProvider GetImageProvider(ImageProviderType imageProviderType)
        {
            switch (imageProviderType)
            {
                case ImageProviderType.Flickr:
                    return GetFlickerImageProvider();
                default:
                    throw new ArgumentOutOfRangeException(nameof(imageProviderType), imageProviderType, null);
            }
        }

        private IImageProvider GetFlickerImageProvider()
        {
            var imageFeed = new FlickerImageFeed();
            return new FlickerImageProvider(imageFeed);
        }
    }
}
