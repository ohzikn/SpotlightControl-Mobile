using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpotlightControl
{
    class TCPFunc
    {
        async static internal void SendRgb(int[] rgbValue)
        {
            var hex = int.Parse(string.Format("{0:D3}{1:D3}{2:D3}", rgbValue[0], rgbValue[1], rgbValue[2])).ToString("X8");
            await SendMessage(string.Format("#{0}", hex));
        }

        async static internal Task<bool> SendMessage(string message)
        {
            try
            {
                GlobalVariables.tcpClient = new System.Net.Sockets.TcpClient();
                await GlobalVariables.tcpClient.ConnectAsync(GlobalVariables.iPEndPoint.Address, GlobalVariables.iPEndPoint.Port);
                GlobalVariables.networkStream = GlobalVariables.tcpClient.GetStream();
                GlobalVariables.networkStream.ReadTimeout = 1000;
                GlobalVariables.networkStream.WriteTimeout = 1000;
                System.Text.Encoding enc = System.Text.Encoding.UTF8;
                byte[] sendBytes = enc.GetBytes(message);
                await GlobalVariables.networkStream.WriteAsync(sendBytes, 0, sendBytes.Length);
                GlobalVariables.tcpClient.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
