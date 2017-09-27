using System;
using Google.MobileAds;
using Ads.iOS;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(AdInterstitial_iOS))]
namespace Ads.iOS
{
    public class AdInterstitial_iOS : IAdInterstitial
    {
        Interstitial interstitial;

        public AdInterstitial_iOS()
        {
            LoadAd();
        }

        void LoadAd()
        {
            // TODO: change this id to your admob id
            interstitial = new Interstitial("ca-app-pub-3940256099942544/4411468910");

            var request = Request.GetDefaultRequest();
            interstitial.LoadRequest(request);
        }

        public void ShowAd()
        {
            if (interstitial.IsReady)
            {
                interstitial.ScreenDismissed += (s, e) => LoadAd();                        
                var viewController = UIApplication.SharedApplication.KeyWindow.RootViewController;
                interstitial.PresentFromRootViewController(viewController);
            }
        }
    }
}
