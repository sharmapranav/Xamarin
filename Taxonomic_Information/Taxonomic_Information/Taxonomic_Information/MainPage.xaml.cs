using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Taxonomic_Information
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            listView.ItemsSource = new APICollection().GetGroupedList();
        }

        private void Sort_Clicked(object sender, EventArgs e)
        {
            var toolbarItem = (sender as Button);

            if (toolbarItem.Text.Equals("Sort By Functional Area"))
            {
                toolbarItem.Text = "Sort Alphabetically";
                listView.ItemsSource = new APICollection().GetGroupedList();
            }
            else
            {
                toolbarItem.Text = "Sort By Functional Area";
                listView.ItemsSource = new APICollection().GetAlphabeticalList();
            }
        }

        private async void listView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedAPIItem = e.Item as APIItem;
            await Navigation.PushAsync(new SearchPage(selectedAPIItem));
        }
    }
}
