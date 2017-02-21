using System;
using CoreGraphics;
using Google.MobileAds;
using Ads;
using Ads.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(AdBanner), typeof(AdBanner_iOS))]
namespace Ads.iOS
{
    public class AdBanner_iOS : ViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                BannerView bannerView = null;

                switch ((Element as AdBanner).Size)
                {
                    case "Standardbanner":
                        bannerView = new BannerView(AdSizeCons.Banner, new CGPoint(0, 0));
                        break;
                    case "LargeBanner":
                        bannerView = new BannerView(AdSizeCons.LargeBanner, new CGPoint(0, 0));
                        break;
                    case "MediumRectangle":
                        bannerView = new BannerView(AdSizeCons.MediumRectangle, new CGPoint(0, 0));
                        break;
                    case "FullBanner":
                        bannerView = new BannerView(AdSizeCons.FullBanner, new CGPoint(0, 0));
                        break;
                    case "Leaderboard":
                        bannerView = new BannerView(AdSizeCons.Leaderboard, new CGPoint(0, 0));
                        break;
                    case "SmartBannerPortrait":
                        bannerView = new BannerView(AdSizeCons.SmartBannerPortrait, new CGPoint(0, 0));
                        break;
                    default:
                        bannerView = new BannerView(AdSizeCons.Banner, new CGPoint(0, 0));
                        break;
                }

                bannerView.AdUnitID = "ca-app-pub-3940256099942544/2934735716";
                
                foreach (UIWindow uiWindow in UIApplication.SharedApplication.Windows)
                {
                    if (uiWindow.RootViewController != null)
                    {
                        bannerView.RootViewController = uiWindow.RootViewController;
                    }
                }

                var request = Request.GetDefaultRequest();
                bannerView.LoadRequest(request);

                SetNativeControl(bannerView);
            }
        }
    }
}
