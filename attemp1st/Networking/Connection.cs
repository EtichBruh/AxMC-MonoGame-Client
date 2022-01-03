using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using attemp1st.player;

namespace attemp1st.Networking
{
    public class Connection
    {

        //public Connection() { } 
        public Socket Client;
        public byte[] Buffer = new byte[256];
        public void Connect(Player player)
        {
            Client = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                Client.Connect(IPAddress.Parse("127.0.0.1"), 2050);
                if (Client.Connected)
                    Console.WriteLine("connected!");
               // byte[] bytes = new byte[256];

                /*while (Client.Connected)
                {
                    byte[] msg = Encoding.UTF8.GetBytes( (player.Position.ToPoint()).ToString());

                    // Send a message.
                    Client.Send(msg, SocketFlags.None);
                    Console.WriteLine("Sent: {0}", System.Text.Encoding.UTF8.GetString(msg));
                    int i = Client.Receive(Buffer, SocketFlags.None);

                    // Translate data bytes to a UTF8 string.
                    string data = System.Text.Encoding.UTF8.GetString(Buffer, 0, i);
                    Console.WriteLine("Received: {0}", data);

                }
                Client.Close();*/
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Client.Close();
            }
        }//player.Position.ToPoint()).ToString()
        public void Send(string Message)
        {
            byte[] msg = Encoding.UTF8.GetBytes(Message);

            // Send a message.
            Client.Send(msg, SocketFlags.None);
            Console.WriteLine("Sent: {0}", System.Text.Encoding.UTF8.GetString(msg));
        }
        public string Receive()
        {
            int i = Client.Receive(Buffer, 0, Client.Available, SocketFlags.None);
            return Encoding.UTF8.GetString(Buffer, 0, i);
        }
    }
}
