using System;
using Flicker;
using Infrastructure;

namespace ImageProvider
{
    public static class ImageProviderFactory
    {
        public static IImageProvider GetImageProvider(ImageProviderType imageProviderType)
        {
            switch (imageProviderType)
            {
                case ImageProviderType.Flickr:
                    return FlickerImageProvider.GetInstance(new FlickerImageFeed());
                default:
                    throw new ArgumentOutOfRangeException(nameof(imageProviderType), imageProviderType, null);
            }
        }
    }
}
