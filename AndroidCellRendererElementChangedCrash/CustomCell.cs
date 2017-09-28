using System;
using Xamarin.Forms;

namespace AndroidCellRendererElementChangedCrash
{
    public class CustomCell : ViewCell
    {
        Label _label = new Label();

        public CustomCell()
        {
            View = _label;
            var longClick = new LongClickService(_label);
            _label.BackgroundColor = Color.Black.MultiplyAlpha(0.25);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            _label.Text = BindingContext.ToString();
        }
    }
}
