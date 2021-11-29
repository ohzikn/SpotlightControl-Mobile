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
    public partial class ControlPage : ContentPage
    {
        int[] rgbValue = new int[3] { 0, 0, 0 };

        int[,] rgbMemory = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

        public ControlPage()
        {
            InitializeComponent();
            DrawUI();
        }
        private void DrawUI()
        {
            Image backgroundImage = new Image { Source = ImageSource.FromStream(() => new MemoryStream(Assets.MainResource.rgb_top)), Margin = new Thickness(0), VerticalOptions = LayoutOptions.Start, Aspect = Aspect.AspectFill };
            R_Entry.Text = "0";
            G_Entry.Text = "0";
            B_Entry.Text = "0";
            R_Slider.Value = 0;
            G_Slider.Value = 0;
            B_Slider.Value = 0;
            ImageGrid.Children.Add(backgroundImage);
            ColorFrame.Background = new SolidColorBrush(Color.FromRgb(rgbValue[0], rgbValue[1], rgbValue[2]));
        }

        private void RGB_Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            rgbValue[0] = (int)(R_Slider.Value * 255);
            R_Entry.Text = ((int)(R_Slider.Value * 255)).ToString();
            rgbValue[1] = (int)(G_Slider.Value * 255);
            G_Entry.Text = ((int)(G_Slider.Value * 255)).ToString();
            rgbValue[2] = (int)(B_Slider.Value * 255);
            B_Entry.Text = ((int)(B_Slider.Value * 255)).ToString();
            ColorFrame.Background = new SolidColorBrush(Color.FromRgb(rgbValue[0], rgbValue[1], rgbValue[2]));
        }

        private void Reset_Button_Clicked(object sender, EventArgs e)
        {
            R_Entry.Text = "0";
            G_Entry.Text = "0";
            B_Entry.Text = "0";
            R_Slider.Value = 0;
            G_Slider.Value = 0;
            B_Slider.Value = 0;
            rgbValue[0] = 0;
            rgbValue[1] = 0;
            rgbValue[2] = 0;
            TCPFunc.SendRgb(rgbValue);
        }

        private void Send_Button_Clicked(object sender, EventArgs e)
        {
            TCPFunc.SendRgb(rgbValue);
        }

        private void SaveRGB(int index)
        {
            rgbMemory[index, 0] = rgbValue[0];
            rgbMemory[index, 1] = rgbValue[1];
            rgbMemory[index, 2] = rgbValue[2];
        }

        private void LoadRGB(int index)
        {
            R_Slider.Value = (double)rgbMemory[index, 0] / 255;
            G_Slider.Value = (double)rgbMemory[index, 1] / 255;
            B_Slider.Value = (double)rgbMemory[index, 2] / 255;
        }

        void R_Entry_Unfocused(System.Object sender, Xamarin.Forms.FocusEventArgs e)
        {
            try
            {
                int temp = Int32.Parse(R_Entry.Text);
                if (temp > 255)
                {
                    temp = 255;
                }
                else if (temp < 0)
                {
                    temp = 0;
                }
                R_Entry.Text = temp.ToString();
                R_Slider.Value = (double)temp / 255;
                rgbValue[0] = temp;
            }
            catch (Exception)
            {
                R_Entry.Text = "0";
                R_Slider.Value = 0;
                rgbValue[0] = 0;
            }
        }

        void G_Entry_Unfocused(System.Object sender, Xamarin.Forms.FocusEventArgs e)
        {
            try
            {
                int temp = Int32.Parse(G_Entry.Text);
                if (temp > 255)
                {
                    temp = 255;
                }
                else if (temp < 0)
                {
                    temp = 0;
                }
                G_Entry.Text = temp.ToString();
                G_Slider.Value = (double)temp / 255;
                rgbValue[1] = temp;
            }
            catch (Exception)
            {
                G_Entry.Text = "0";
                G_Slider.Value = 0;
                rgbValue[1] = 0;
            }
        }

        void B_Entry_Unfocused(System.Object sender, Xamarin.Forms.FocusEventArgs e)
        {
            try
            {
                int temp = Int32.Parse(B_Entry.Text);
                if (temp > 255)
                {
                    temp = 255;
                }
                else if (temp < 0)
                {
                    temp = 0;
                }
                B_Entry.Text = temp.ToString();
                B_Slider.Value = (double)temp / 255;
                rgbValue[2] = temp;
            }
            catch (Exception)
            {
                B_Entry.Text = "0";
                B_Slider.Value = 0;
                rgbValue[2] = 0;
            }
        }

        private void Save1_Button_Clicked(object sender, EventArgs e)
        {
            SaveRGB(0);
        }

        private void Save2_Button_Clicked(object sender, EventArgs e)
        {
            SaveRGB(1);
        }

        private void Save3_Button_Clicked(object sender, EventArgs e)
        {
            SaveRGB(2);
        }

        private void Load1_Button_Clicked(object sender, EventArgs e)
        {
           LoadRGB(0);
        }

        private void Load2_Button_Clicked(object sender, EventArgs e)
        {
            LoadRGB(1);
        }

        private void Load3_Button_Clicked(object sender, EventArgs e)
        {
            LoadRGB(2);
        }
    }
}