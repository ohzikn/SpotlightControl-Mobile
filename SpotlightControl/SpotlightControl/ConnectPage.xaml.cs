using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace SpotlightControl
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConnectPage : ContentPage
    {
        public ConnectPage()
        {
            InitializeComponent();
            DrawDefaultUI();
            CheckConnectionStatus();
        }

        private void DrawDefaultUI()
        {
            Connect_Button.Text = "Save Server Token";
            Connect_Button.IsEnabled = true;
            Status_Image.Source = null;
            //Status_Image.Source = ImageSource.FromStream(() => new MemoryStream(Assets.MainResource.onboarding_characters_free_7));
        }

        private void CheckConnectionStatus()
        {
            if (GlobalVariables.iPEndPoint != null)
            {
                Connect_Button.Text = "Update Server Token";
                IP_Entry.Text = GlobalVariables.iPEndPoint.Address.ToString();
                //Port_Entry.Text = GlobalVariables.iPEndPoint.Port.ToString();
            }
        }

        async private void Connect_Button_Clicked(object sender, EventArgs e)
        {
            IPAddress ip;
            if (IPAddress.TryParse(IP_Entry.Text, out ip))
            {
                Connect_Button.Text = "Connecting....";
                Connect_Button.IsEnabled = false;
                try
                {
                    //GlobalVariables.iPEndPoint = new IPEndPoint(ip, int.Parse(Port_Entry.Text));
                    GlobalVariables.iPEndPoint = new IPEndPoint(ip, int.Parse("9000"));
                    if (GlobalVariables.tcpClient != null) GlobalVariables.tcpClient.Dispose();
                    if (! await TCPFunc.SendMessage("Hello, World!")) throw new Exception();
                    /*GlobalVariables.tcpClient = new System.Net.Sockets.TcpClient();
                    await GlobalVariables.tcpClient.ConnectAsync(GlobalVariables.iPEndPoint.Address, GlobalVariables.iPEndPoint.Port);
                    GlobalVariables.networkStream = GlobalVariables.tcpClient.GetStream();
                    GlobalVariables.networkStream.ReadTimeout = 1000;
                    GlobalVariables.networkStream.WriteTimeout = 1000;
                    System.Text.Encoding enc = System.Text.Encoding.UTF8;
                    byte[] sendBytes = enc.GetBytes("Hello, World!" + '\n');
                    GlobalVariables.networkStream.Write(sendBytes, 0, sendBytes.Length);
                    GlobalVariables.tcpClient.Close();*/
                    Connect_Button.Text = "Connected";
                    Connect_Button.BackgroundColor = Color.DarkSeaGreen;
                    Connect_Button.IsEnabled = false;
                    Status_Image.Source = ImageSource.FromStream(() => new MemoryStream(Assets.MainResource.onboarding_characters_free_7));
                    await Task.Delay(800);
                    await Navigation.PopAsync();
                }
                catch (Exception ex)
                {
                    GlobalVariables.iPEndPoint = null;
                    GlobalVariables.tcpClient = new System.Net.Sockets.TcpClient();
                    Connect_Button.Text = "Connection Failed";
                    Connect_Button.IsEnabled = true;
                    Status_Image.Source = ImageSource.FromStream(() => new MemoryStream(Assets.MainResource.onboarding_characters_free_3));
                }
            }
        }
    }
}