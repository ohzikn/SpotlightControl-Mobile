using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace SpotlightControl
{
    public partial class MainPage : ContentPage
    {
        public MainPage()       
        {
            InitializeComponent();
            DrawDefaultU();
            //devfunc();
        }

        async private void devfunc()
        {
            //await Navigation.PushModalAsync(new UIDevPage());
        }

        private void DrawDefaultU()
        {
            // Make new Image objects
            Image spotlightImage = new Image { Source = ImageSource.FromStream(() => new MemoryStream(Assets.MainResource.spotlight)), Margin = new Thickness(0, 0, 0, 20) };
            Image womenImage = new Image { Source = ImageSource.FromStream(() => new MemoryStream(Assets.MainResource.women)), Margin = new Thickness(40) };
            // Register images to main grid
            Grid.SetRow(spotlightImage, 0);
            Grid.SetRowSpan(spotlightImage, 2);
            Grid.SetRow(womenImage, 1);
            ImageGrid.Children.Add(spotlightImage);
            ImageGrid.Children.Add(womenImage);
            LogoImage.Source = ImageSource.FromStream(() => new MemoryStream(Assets.MainResource.logo_rgb__));
        }

        async private void Start_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(PagesDelegate.functionPage);
        }
    }
}
