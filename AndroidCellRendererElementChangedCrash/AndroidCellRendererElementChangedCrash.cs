using System;

using Xamarin.Forms;
using System.Linq;
using System.Reflection;

namespace AndroidCellRendererElementChangedCrash
{
    public class App : Application
    {
        public App()
        {

            var colors = typeof(Color).GetRuntimeFields().Where((FieldInfo arg) => arg.IsPublic && arg.IsStatic).Select((arg) => arg.Name).ToList();


            // The root page of your application
            var content = new ContentPage
            {
                Title = "AndroidCellRendererElementChangedCrash",
                Content = new ListView
                {
                    ItemsSource = colors,
                    ItemTemplate = new DataTemplate(typeof(CustomCell))
                }
            };

            MainPage = new NavigationPage(content);
        }

        protected override void OnStart()
        {
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
