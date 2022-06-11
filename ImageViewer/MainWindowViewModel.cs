using System.Collections.Generic;
using System.Collections.ObjectModel;
using ImageProvider;
using ImageViewer.Common;
using Infrastructure;

namespace ImageViewer
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Private Fields

        private RelayCommand<string> _searchImagesByKeywordCmd;
        private string _imagesForKeywordLabel;

        #endregion

        #region Constructors

        public MainWindowViewModel()
        {
            ImagesInfo = new ObservableCollection<IImageInfo>();
        }

        #endregion

        #region Properties

        public ObservableCollection<IImageInfo> ImagesInfo { get; }

        public string ImagesForKeywordLabel
        {
            get
            {
                return _imagesForKeywordLabel;
            }

            set
            {
                _imagesForKeywordLabel = value;
                RaisePropertyChanged(() => ImagesForKeywordLabel);
            }
        }

        #endregion

        #region Relay Commands
        public RelayCommand<string> SearchImagesByKeywordCmd => _searchImagesByKeywordCmd ?? (_searchImagesByKeywordCmd = new RelayCommand<string>(SearchImagesByKeywordCommandHandler));

        #endregion

        #region Private Methods
        void SearchImagesByKeywordCommandHandler(object keyword)
        {
            if (string.IsNullOrEmpty(keyword as string))
            {
                return;
            }

            ImagesInfo.Clear();
            ImagesForKeywordLabel = $"Images for {keyword}";

            IImageProvider imageProvider = ImageProviderFactory.GetImageProvider(ImageProviderType.Flickr);
            IEnumerable<IImageInfo> imagesInfo = imageProvider.GetImagesInfoByKeyword((string)keyword);
            foreach (IImageInfo imageInfo in imagesInfo)
            {
                ImagesInfo.Add(imageInfo);
            }
        }


        #endregion
    }
}
