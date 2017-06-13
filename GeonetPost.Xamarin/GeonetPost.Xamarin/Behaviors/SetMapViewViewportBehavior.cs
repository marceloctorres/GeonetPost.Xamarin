using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Xamarin.Forms;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace GeonetPost.Xamarin.Behaviors
{
  public class SetMapViewViewportBehavior : BehaviorBase<MapView>
  {
    /// <summary>
    /// 
    /// </summary>
    public static readonly BindableProperty ViewpointProperty =
      BindableProperty.Create(nameof(Viewpoint), typeof(Viewpoint), typeof(SetMapViewViewportBehavior));

    /// <summary>
    /// 
    /// </summary>
    public Viewpoint Viewpoint
    {
      get { return (Viewpoint)GetValue(ViewpointProperty); }
      set { SetValue(ViewpointProperty, value); }
    }

    /// <summary>
    /// 
    /// </summary>
    public SetMapViewViewportBehavior()
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="propertyName"></param>
    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      base.OnPropertyChanged(propertyName);
      if (propertyName == nameof(this.Viewpoint))
      {
        SetViewpoint(this.Viewpoint);
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="vp"></param>
    private async void SetViewpoint(Viewpoint vp)
    {
      if (vp != null)
      {
        var actualVp = this.AssociatedObject.GetCurrentViewpoint(ViewpointType.BoundingGeometry);
        if (actualVp == null || (actualVp != null && !actualVp.Equals(vp)))
        {
          Debug.WriteLine("SetViewpoint");
          await this.AssociatedObject.SetViewpointAsync(vp);
        }
      }
    }
  }
}


