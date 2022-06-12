using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Infrastructure;

namespace Flicker
{
    public class FlickerImageFeed : IImageFeed
    {
        private const string FlickerPublicPhotosApi = "https://www.flickr.com/services/feeds/photos_public.gne/";
        private const string EntryElementName = "entry";
        private const string TitleElementName = "title";
        private const string LinkElementName = "link";
        private const string HrefAttributeName = "href";
        private const string RelAttributeName = "rel";

        public IEnumerable<IImageInfo> LoadImages(string keyword)
        {
            var flickerImagesInfo = new List<FlickerImageInfo>();
            var uri = $"{FlickerPublicPhotosApi}?tags={keyword}";
            var apiResult = XElement.Load(uri);
            var entries = apiResult.Elements().Where(itm => itm.Name.LocalName == EntryElementName);
            foreach (var entry in entries)
            {
                var title = entry.Elements().FirstOrDefault(itm => itm.Name.LocalName == TitleElementName)?.Value;
                var linkElements = entry.Elements().Where(itm => itm.Name.LocalName == LinkElementName);
                var linkElement = linkElements.FirstOrDefault(itm => itm.Attribute(RelAttributeName)?.Value == "enclosure");
                var imageLink = linkElement?.Attribute(HrefAttributeName)?.Value;
                flickerImagesInfo.Add(new FlickerImageInfo(imageLink, title));
            }

            return flickerImagesInfo;
        }
    }
}
