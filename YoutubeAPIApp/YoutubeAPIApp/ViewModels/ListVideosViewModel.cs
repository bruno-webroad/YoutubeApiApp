using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using YoutubeAPIApp.Entities;
using YoutubeAPIApp.Services;
using YoutubeAPIApp.Views;

namespace YoutubeAPIApp.ViewModels
{
    public class ListVideosViewModel : BaseViewModel
    {
        public ICommand SearchCommand { get; set; }
        public ICommand LoadCommand { get; set; }

        private string _search;
        public string Search
        {
            get { return _search; }
            set
            {
                _search = value;
                NotifyPropertyChanged("Search");
            }
        }

        private ObservableCollection<Item> _videos;
        public ObservableCollection<Item> Videos
        {
            get { return _videos; }
            set
            {
                _videos = value;
                this.NotifyPropertyChanged("Videos");
            }
        }

        private Item _video;
        public Item Video
        {
            get { return _video; }
            set
            {
                _video = value;
                this.NotifyPropertyChanged("Video");
                if(Video != null)
                {
                    ShowVideo(_video);
                    Video = null;
                }
            }
        }

        public string TokenNextPage { get; set; }

        public ListVideosViewModel()
        {
            this.SearchCommand = new Command(SearchVideos);
            this.LoadCommand = new Command(LoadMore);
        }

        private async void SearchVideos()
        {
            if (!string.IsNullOrWhiteSpace(Search))
            {               
                Videos = new ObservableCollection<Item>();
                var videos = await YoutubeService.ListarVideosYoutube(Search);
                if (videos != null && videos.items != null && videos.items.Any())
                {
                    Videos = new ObservableCollection<Item>(videos.items);
                    TokenNextPage = videos.nextPageToken;
                }                
            }
        }

        private async void LoadMore()
        {
            var videos = await YoutubeService.ListarVideosYoutube(Search, TokenNextPage);
            if (videos.items != null && videos.items.Any())
            {
                foreach (var item in videos.items)
                {
                    Videos.Add(item);
                }
                TokenNextPage = videos.nextPageToken;
            }
        }

        private async void ShowVideo(Item item)
        {
            await App.Current.MainPage.Navigation.PushAsync(new VideoPage(item));
        }
    }
}
