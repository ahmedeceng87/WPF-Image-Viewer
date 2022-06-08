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

        private RelayCommand _searchImagesByKeywordCmd;

        #endregion

        #region Properties

        public ObservableCollection<IImageInfo> ImagesInfo { get; private set; }

        public string ImagesForKeywordLabel { get; private set; }

        #endregion

        #region Relay Commands
        public RelayCommand SearchImagesByKeywordCmd => _searchImagesByKeywordCmd ?? (_searchImagesByKeywordCmd = new RelayCommand(SearchImagesByKeywordCommandHandler));

        #endregion

        #region Private Methods
        void SearchImagesByKeywordCommandHandler(object keyword)
        {
            if (string.IsNullOrEmpty(keyword as string))
            {
                return;
            }
            IImageProvider imageProvider = ImageProviderFactory.GetImageProvider(ImageProviderType.Flickr);
            IEnumerable<IImageInfo> imagesInfo = imageProvider.GetImagesInfoByKeyword((string)keyword);
            ImagesInfo = new ObservableCollection<IImageInfo>(imagesInfo);
            ImagesForKeywordLabel = $"Images for {keyword}";
            NotifyChanges();
        }

        void NotifyChanges()
        {
            RaisePropertyChanged(() => ImagesInfo);
            RaisePropertyChanged(() => ImagesForKeywordLabel);
        }


        #endregion
    }
}
