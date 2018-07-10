using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YoutubeAPIApp.Entities;
using YoutubeAPIApp.ViewModels;

namespace YoutubeAPIApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VideoPage : ContentPage
	{
		public VideoPage (Item googleYoutubeApi)
		{
			InitializeComponent ();
            this.BindingContext = new VideoViewModel(googleYoutubeApi);
		}
	}
}