# WPF Image Viewer

WPF app that retrieves photos from Flickr's public photo stream. It's a graphical user interface that takes in a search string and displays photographs
that matches the search string. Flickr’s public photo feed at https://api.flickr.com/services/feeds/photos_public.gne is used as a service.
    
Steps:
  - Retrieve photos from: https://api.flickr.com/services/feeds/photos_public.gne
  - Parse the XML output from the photo stream.
  - Display the list of photos in a list. Each item in the list should display the Title of the photo.
  - CICD engine to build and generate installer.
  - Testability – unit tests
  installer will be uploaded as artifacts
