using Infrastructure;
using System.Collections.Generic;

namespace Infrastructure
{
    public interface IImageFeed
    {
        IEnumerable<IImageInfo> LoadImages(string keyword);
    }
}
