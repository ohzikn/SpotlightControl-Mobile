using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace SpotlightControl
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FunctionPage : ContentPage
    {
        public FunctionPage()
        {
            InitializeComponent();
            DrawDefaultUI();
        }

        private void DrawDefaultUI()
        {
            // Make new Image objects
            Image backgroundImage = new Image { Source = ImageSource.FromStream(() => new MemoryStream(Assets.MainResource.rgb_top)), Margin = new Thickness(0), VerticalOptions = LayoutOptions.Start, Aspect = Aspect.AspectFill };
            F1_Image.Source = ImageSource.FromStream(() => new MemoryStream(Assets.MainResource.onboarding_characters_free_4));
            F2_Image.Source = ImageSource.FromStream(() => new MemoryStream(Assets.MainResource.onboarding_characters_free_6));
            F3_Image.Source = ImageSource.FromStream(() => new MemoryStream(Assets.MainResource.onboarding_characters_free_14));
            F4_Image.Source = ImageSource.FromStream(() => new MemoryStream(Assets.MainResource.onboarding_characters_free_8));
            // Register Image
            ImageGrid.Children.Add(backgroundImage);
        }

        async private void F1_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ConnectPage());
        }

        async private void F2_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ControlPage());
        }

        async private void F3_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AutoPage());
        }

        async private void F4_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ControlCCTPage());
        }

        async private void Close_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}