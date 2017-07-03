using System;
using System.Windows.Input;
using Esri.ArcGISRuntime.Xamarin.Forms;
using Xamarin.Forms;

namespace GeonetPost.Xamarin.Behaviors
{
    public class MapViewViewpointChangedBehavior : BehaviorBase<MapView>
    {
      /// <summary>
      /// 
      /// </summary>
      public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command),
        typeof(ICommand),
        typeof(MapViewViewpointChangedBehavior));

      /// <summary>
      /// 
      /// </summary>
      public ICommand Command
      {
        get { return (ICommand)GetValue(CommandProperty); }
        set
        {
          SetValue(CommandProperty, value);
        }
      }

      /// <summary>
      /// 
      /// </summary>
      protected override void OnAttachedTo(MapView bindable)
      {
        base.OnAttachedTo(bindable);
        bindable.ViewpointChanged += this.MapViewViewpointChanged;
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="bindable"></param>
      protected override void OnDetachingFrom(MapView bindable)
      {
        base.OnDetachingFrom(bindable);
        bindable.ViewpointChanged -= this.MapViewViewpointChanged;
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void MapViewViewpointChanged(object sender, EventArgs e)
      {
        if (this.Command != null)
        {
          MapView mapView = (MapView)sender;
          if (mapView != null)
          {
            var viewpoint = mapView.GetCurrentViewpoint(Esri.ArcGISRuntime.Mapping.ViewpointType.BoundingGeometry);
            
            if (this.Command.CanExecute(viewpoint) && viewpoint != null)
            {
              this.Command.Execute(viewpoint);
            }
          }
        }
      }
    }
  }
