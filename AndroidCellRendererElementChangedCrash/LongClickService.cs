using System;
using Xamarin.Forms;
namespace AndroidCellRendererElementChangedCrash
{
    public class LongClickService
    {
        static ILongClickService _nativeServiceProvider;
        static ILongClickService NativeServiceProvier
        {
            get
            {
                _nativeServiceProvider = _nativeServiceProvider ?? DependencyService.Get<ILongClickService>();
                return _nativeServiceProvider;
            }
        }

        public LongClickService(VisualElement element)
        {
            NativeServiceProvier.Element = element;
        }
    }
}
