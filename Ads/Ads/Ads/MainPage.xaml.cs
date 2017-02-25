using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ads
{
    public partial class MainPage : ContentPage
    {
        IAdInterstitial adInterstitial;

        public MainPage()
        {
            InitializeComponent();

            var label = new Label();
            label.Text = "C# Ad Banner";
            stackLayout.Children.Add(label);

            var adBanner = new AdBanner();
            adBanner.Size = AdBanner.Sizes.MediumRectangle;
            stackLayout.Children.Add(adBanner);

            adInterstitial = DependencyService.Get<IAdInterstitial>();
        }

        void Show_Interstitial(object sender, EventArgs e)
        {
            adInterstitial.ShowAd();
        }
    }
}
