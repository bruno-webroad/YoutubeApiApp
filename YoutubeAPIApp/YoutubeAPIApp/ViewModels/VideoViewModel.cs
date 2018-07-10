using System;
using System.Collections.Generic;
using System.Text;
using YoutubeAPIApp.Entities;

namespace YoutubeAPIApp.ViewModels
{
    public class VideoViewModel : BaseViewModel
    {
        private Item _video;
        public Item Video
        {
            get { return _video; }
            set
            {
                _video = value;
                this.NotifyPropertyChanged("Video");
            }
        }

        private string _url;
        public string Url
        {
            get { return $"https://www.youtube.com/embed/{Video.id.videoId}"; }           
        }

        public VideoViewModel(Item googleYoutubeApi)
        {            
            Video = googleYoutubeApi;
        }
    }
}
