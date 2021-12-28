using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using attemp1st.player;

namespace attemp1st.Networking
{
    public class Connection
    {

        public Connection() { } // Currently outdated + need to use tcp instead http + need rewrite all code, allow requesting images, json etc.. also streamD
        public async Task Connect(Player _player)
        {

            using (ClientWebSocket client = new())
            {
                Uri ServiceUri = new("ws://localhost:5000/send");

                var cTc = new CancellationTokenSource();
                cTc.CancelAfter(TimeSpan.FromSeconds(120));
                try
                {
                    await client.ConnectAsync(ServiceUri, cTc.Token);
                    while (client.State == WebSocketState.Open)
                    {
                        string message = new($"PlayerX {_player.Position.X}; PlayerY {_player.Position.Y}");
                        if (!string.IsNullOrEmpty(message))
                        {
                            ArraySegment<byte> byteToSend = new(Encoding.UTF8.GetBytes(message));
                            await client.SendAsync(byteToSend, WebSocketMessageType.Binary, true, cTc.Token);
                            var responseBuffer = new byte[1024];
                            var offset = 0;
                            var packet = 1024;
                            while (true)
                            {
                                ArraySegment<byte> byteReceived = new(responseBuffer, offset, packet);
                                WebSocketReceiveResult responce = await client.ReceiveAsync(byteReceived, cTc.Token);
                                var responseMessage = Encoding.UTF8.GetString(responseBuffer, offset, responce.Count);
                                if (responce.EndOfMessage)
                                    break;
                            }
                        }
                    }
                }
                catch (WebSocketException wse)
                {
                    Console.WriteLine(wse.Message);
                }
            }
        }
    }
}
