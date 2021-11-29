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
    public partial class ControlCCTPage : ContentPage
    {
        int[] rgbValue = new int[3] { 0, 0, 0 };

        public ControlCCTPage()
        {
            InitializeComponent();
            DrawUI();
        }

        private void DrawUI()
        {
            CCT_Banner1.Source = ImageSource.FromStream(() => new MemoryStream(Assets.MainResource.color_temp_lights_v2));
            CCT_Picker.Title = "Select a CCT value";
            CCT_Picker.Items.Clear();
            for (int i = 3000; i <= 25000; i += 1000)
            {
                CCT_Picker.Items.Add(i.ToString());
            }
            CCT_Picker.SelectedIndex = 0;
            Deco_Image.Source = ImageSource.FromStream(() => new MemoryStream(Assets.MainResource.onboarding_characters_free_16));
        }

        private void CCT_Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = CCT_Picker.SelectedIndex;
                CCT_ProgressBar.Progress = (index / (double)CCT_Picker.Items.Count);
            }
            catch (Exception)
            {

            }
            /*try
            {
                int temperature = int.Parse(CCT_Picker.SelectedItem.ToString());
                if (temperature < 1000) temperature = 1000;
                if (temperature > 12000) temperature = 12000;
                RgbConverter(temperature);
                CCT_ProgressBar.Progress = ((double)temperature - 1000) / 11000;
            }
            catch (Exception)
            {
                return;
            }*/
        }

        /*private void CCT_Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            double value = Math.Round(CCT_Slider.Value * 110 + 10) * 100;
            //CCT_Picker.SelectedIndex = -1;
            CCT_Picker.TitleColor = Color.Black;
            CCT_Picker.Title = value.ToString();
            try
            {
                int temperature = (int)value;
                if (temperature < 1000) temperature = 1000;
                if (temperature > 12000) temperature = 12000;
                RgbConverter(temperature);
            }
            catch (Exception)
            {
                return;
            }
        }*/

        /*private void RgbConverter(int kelvin)
        {
            double red, green, blue;

            double temp = (double)kelvin / 100;
            if (temp <= 66)
            {
                red = 255;
                green = temp;
                green = 99.4708025861 * Math.Log(green) - 161.1195681661;
                if (temp <= 19)
                {
                    blue = 0;
                }
                else
                {
                    blue = temp - 10;
                    blue = 138.5177312231 * Math.Log(blue) - 305.0447927307;
                }
            }
            else
            {
                red = temp - 60;
                red = 329.698727446 * Math.Pow(red, -0.1332047592);
                green = temp - 60;
                green = 288.1221695283 * Math.Pow(green, -0.0755148492);
                blue = 255;
            }
            (rgbValue[0], rgbValue[1] ,rgbValue[2]) = ((int)red, (int)green, (int)blue);
        }*/

        private void Reset_Button_Clicked(object sender, EventArgs e)
        {
            CCT_ProgressBar.Progress = 0;
            CCT_Picker.SelectedIndex = 0;
            TCPFunc.SendRgb(new int[] { 0, 0, 0 });
        }

        private void Send_Button_Clicked(object sender, EventArgs e)
        {
            //TCPFunc.SendRgb(rgbValue);
            try
            {
                int[] rgbValue = { cctValue[CCT_Picker.SelectedIndex, 0], cctValue[CCT_Picker.SelectedIndex, 1], cctValue[CCT_Picker.SelectedIndex, 2] };
                TCPFunc.SendRgb(rgbValue);
            }
            catch (Exception)
            {

            }
        }
    }

    public partial class ControlCCTPage : ContentPage
    {
        private int[,] cctValue = new int[,]
        {
            // 3000 - 25000 (K)
            {255, 227, 3},
            {127, 204, 1},
            {50, 159, 1},
            {18, 114, 1},
            {1, 214, 4},
            {0, 51, 8},
            {12, 18, 35},
            {2, 67, 24},
            {0, 53, 21},
            {6, 3, 9},
            {2, 74, 37},
            {106, 186, 140},
            {165, 245, 189},
            {74, 214, 148},
            {73, 216, 152},
            {136, 245, 185},
            {106, 191, 153},
            {80, 221, 164},
            {150, 203, 172},
            {176, 225, 193},
            {73, 215, 164},
            {150, 198, 172},
            {130, 150, 152}
        };
    }
}