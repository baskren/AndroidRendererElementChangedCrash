using System;
using System.ComponentModel;
using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidCellRendererElementChangedCrash.Droid.LongClickServiceProvider))]
namespace AndroidCellRendererElementChangedCrash.Droid
{
    public class LongClickServiceProvider : ILongClickService
    {
        VisualElement _element;
        public VisualElement Element
        {
            get
            {
                return _element;
            }
            set
            {
                if (_element != value)
                {
                    if (_element != null)
                        _element.PropertyChanged -= OnElementPropertyChanged;
                    _element = value;
                    if (_element != null)
                        _element.PropertyChanged += OnElementPropertyChanged;
                    ConnectToRenderer(_element);
                }
            }
        }


        void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Renderer" && _element != null)
                ConnectToRenderer(_element);
        }

        void OnRendererElementChanged(object sender, VisualElementChangedEventArgs e)
        {
            if (e.OldElement != null)
                DisconnectFromRenderer(e.OldElement);
        }

        void ConnectToRenderer(VisualElement element)
        {
            // Can connect to renderer by either:
            // 1) Element is set and renderer already exists
            // 2) by responding to a change in the Element's Renderer property
            var renderer = Platform.GetRenderer(element);
            if (renderer != null)
                renderer.ElementChanged += OnRendererElementChanged;

            var viewGroup = renderer?.ViewGroup;
            if (viewGroup != null)
                viewGroup.LongClick += OnLongClick;
        }

        void DisconnectFromRenderer(VisualElement element)
        {
            // If we don't disconnect, the
            // Disconnect from renderer by responding to a change in renderer's Element property
            var renderer = Platform.GetRenderer(element);
            if (renderer != null)
                renderer.ElementChanged -= OnRendererElementChanged;
        }

        void OnLongClick(object sender, Android.Views.View.LongClickEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("!!!!  LONG CLICK !!!!");
        }


    }
}
