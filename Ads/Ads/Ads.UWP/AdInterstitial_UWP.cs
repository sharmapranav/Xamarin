using Microsoft.Advertising.WinRT.UI;
using Ads.UWP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.System.Profile;
using Xamarin.Forms;

[assembly: Dependency(typeof(AdInterstitial_UWP))]
namespace Ads.UWP
{
    class AdInterstitial_UWP : IAdInterstitial
    {
        InterstitialAd interstitialAd;
        string applicationID = null;
        string adUnitID = null;

        public AdInterstitial_UWP()
        {
            interstitialAd = new InterstitialAd();

            // TODO: change these ids to your windows ad ids
            if (AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile")
            {
                applicationID = "d25517cb-12d4-4699-8bdc-52040c712cab";
                adUnitID = "11389925";
            }
            else
            {
                applicationID = "d25517cb-12d4-4699-8bdc-52040c712cab";
                adUnitID = "11389925";
            }

            interstitialAd.Completed += (s, e) => LoadAd();
            LoadAd();
        }

        void LoadAd()
        {
            interstitialAd.RequestAd(AdType.Video, applicationID, adUnitID);
        }

        public void ShowAd()
        {
            if (InterstitialAdState.Ready == interstitialAd.State)
                interstitialAd.Show();
        }
    }
}
