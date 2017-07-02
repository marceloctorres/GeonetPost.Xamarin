using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using Microsoft.Azure.Mobile.Distribute;
using Microsoft.Azure.Mobile.Push;
using Xamarin.Forms;

namespace GeonetPost.Xamarin
{
  public partial class App : Application
  {
    public App()
    {
      InitializeComponent();
      MainPage = new GeonetPost.Xamarin.Views.MapPage();
    }

    protected override void OnStart()
    {
      MobileCenter.Start("uwp=5a0a9d44-80dc-433f-907a-dbd1ed0ad26d", typeof(Analytics), typeof(Crashes), typeof(Distribute), typeof(Push));
      // Handle when your app starts
    }

    protected override void OnSleep()
    {
      // Handle when your app sleeps
    }

    protected override void OnResume()
    {
      // Handle when your app resumes
    }
  }
}
