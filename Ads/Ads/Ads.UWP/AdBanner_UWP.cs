using System;
using Ads;
using Xamarin.Forms;
using Ads.UWP;
using Xamarin.Forms.Platform.UWP;
using Microsoft.Advertising.WinRT.UI;
using Windows.UI.Xaml;
using Windows.System.Profile;

[assembly: ExportRenderer(typeof(AdBanner), typeof(AdBanner_UWP))]
namespace Ads.UWP
{
    public class AdBanner_UWP : ViewRenderer<View, FrameworkElement>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                AdControl bannerView = new AdControl();

                switch ((Element as AdBanner).Size)
                {
                    case "Standardbanner":
                        bannerView.Width = 320;
                        bannerView.Height = 50;
                        break;
                    case "LargeBanner":
                        bannerView.Width = 320;
                        bannerView.Height = 50;
                        break;
                    case "MediumRectangle":
                        bannerView.Width = 300;
                        bannerView.Height = 250;
                        break;
                    case "FullBanner":
                        bannerView.Width = 480;
                        bannerView.Height = 80;
                        break;
                    case "Leaderboard":
                        bannerView.Width = 728;
                        bannerView.Height = 90;
                        break;
                    case "SmartBannerPortrait":
                        bannerView.Width = 320;
                        bannerView.Height = 50;
                        break;
                    default:
                        bannerView.Width = 320;
                        bannerView.Height = 50;
                        break;
                }

                if (AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile")
                {
                    bannerView.ApplicationId = "3f83fe91-d6be-434d-a0ae-7351c5a997f1";
                    bannerView.AdUnitId = "10865275";
                }
                else
                {
                    bannerView.ApplicationId = "3f83fe91-d6be-434d-a0ae-7351c5a997f1";
                    bannerView.AdUnitId = "10865275";
                }

                if (bannerView != null)
                    SetNativeControl(bannerView);
            }
        }
    }
}
