using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YoutubeAPIApp.ViewModels;

namespace YoutubeAPIApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListVideosPage : ContentPage
	{
		public ListVideosPage ()
		{
			InitializeComponent ();
            this.BindingContext = new ListVideosViewModel();
		}
	}
}