using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace YoutubeAPIApp.Controls
{
    public class InfiniteScrollListView : ListView
    {
        public static readonly BindableProperty LoadCommandProperty = BindableProperty.Create(nameof(LoadCommand), typeof(ICommand), typeof(InfiniteScrollListView), null);
        public ICommand LoadCommand
        {
            get { return (ICommand)this.GetValue(LoadCommandProperty); }
            set { this.SetValue(LoadCommandProperty, value); }
        }

        public InfiniteScrollListView()
        {
            this.ItemAppearing += (object sender, ItemVisibilityEventArgs e) =>
            {
                var items = this.ItemsSource as IList;
                if (items != null && e.Item == items[items.Count - 1])
                {
                    if (this.LoadCommand != null && this.LoadCommand.CanExecute(null))
                    {
                        this.LoadCommand.Execute(null);
                    }
                }
            };
        }
    }
}
