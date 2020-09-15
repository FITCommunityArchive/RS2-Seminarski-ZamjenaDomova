using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;
using Xamarin.Forms.Xaml;
using ZamjenaDomova.Mobile.Views;

namespace ZamjenaDomova.Mobile
{
    public partial class App : Xamarin.Forms.Application
    {

        public App()
        {
            InitializeComponent();

            //DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new LoginPage());
            MainPage.On<Windows>().SetToolbarPlacement(ToolbarPlacement.Bottom);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
