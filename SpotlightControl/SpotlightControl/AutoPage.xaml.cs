using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SpotlightControl
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AutoPage : ContentPage
    {
        public AutoPage()
        {
            InitializeComponent();
            DrawUI();
        }

        private void DrawUI()
        {
            BackgroundImage.Source = ImageSource.FromStream(() => new MemoryStream(Assets.MainResource.onboarding_characters_free_8));
            RelativeLayout.SetYConstraint(BackgroundImage, Constraint.RelativeToParent((parent) =>
            {
                return parent.Height - parent.Width * 0.8;
            }));
            RelativeLayout.SetXConstraint(BackgroundImage, Constraint.RelativeToParent((parent) =>
            {
                return parent.Width * 0.1;
            }));
            RelativeLayout.SetWidthConstraint(BackgroundImage, Constraint.RelativeToParent((parent) =>
            {
                return parent.Width * 0.8;
            }));
        }

        void BrightenButton_Clicked(System.Object sender, System.EventArgs e)
        {
            TCPFunc.SendMessage("@F1");
        }
    }
}