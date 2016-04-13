using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace SpriteandDraw {
    class Join {
        public static Socket _clientSocket = new Socket
            (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private static IPAddress searchAddress = null;

        private const int _PORT = 100;
        static Board board = new Board();
        public Join() {
        }
        private static void ConnectToServer() {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            //Writes out the ip address in ipv6 form
            for (int i = 0; i < ipHostInfo.AddressList.Length; i++)
            {
                if (ipHostInfo.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                {
                    searchAddress = ipHostInfo.AddressList[i];
                    break;
                }
            }
            int attempts = 0;

            while (!_clientSocket.Connected) {
                try {
                    attempts++;
                    Console.WriteLine("Connection attempt " + attempts);
                    _clientSocket.Connect(searchAddress, _PORT);
                }
                catch (SocketException) {
                    //Console.Clear();
                }
            }

            Console.Clear();
            Console.WriteLine("Connected");
        }

        private static void RequestLoop() {

            while (true) {
                ReceiveResponse();
            }
        }

        /// <summary>
        /// Close socket and exit app
        /// </summary>
        private static void Exit() {
            Send("exit"); // Tell the server we re exiting
            _clientSocket.Shutdown(SocketShutdown.Both);
            _clientSocket.Close();
            Environment.Exit(0);
        }

        /// <summary>
        /// Sends a string to the server with ASCII encoding
        /// </summary>
        public static void Send(string text) {
            try
            {
                byte[] buffer = Encoding.ASCII.GetBytes(text);
                _clientSocket.BeginSend(buffer, 0, buffer.Length, 0, new AsyncCallback(SendCallback), _clientSocket);

            }
            catch(SocketException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket handler = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.
                int bytesSent = handler.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to client.", bytesSent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void ReceiveResponse() {
            var buffer = new byte[2048];
            int received = _clientSocket.Receive(buffer, SocketFlags.None);
            if (received == 0) return;
            var data = new byte[received];
            Array.Copy(buffer, data, received);
            string text = Encoding.ASCII.GetString(data);
            board.UpdateBoard(text);
        }
    }
}
