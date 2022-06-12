using System.Collections.Generic;

namespace Infrastructure
{
    public interface IImageProvider
    {
        IEnumerable<IImageInfo> GetImagesInfoByKeyword(string keyword);
    }
}
