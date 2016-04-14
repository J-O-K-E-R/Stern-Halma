using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace SpriteandDraw {
    class Host {

        private static Socket _serverSocket;
        private static List<Socket> _clientSockets = new List<Socket>();
        private const int _BUFFER_SIZE = 2048;
        private const int _PORT = 100;
        private static byte[] _buffer = new byte[_BUFFER_SIZE];
        public static IPAddress hostAddress { get; set; }
        public static Board board = new Board();
        public int playerCount = 0;


        public Host() {
            hostAddress = null;
        }

        public void Create() {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            //Writes out the ip address in ipv6 form
            for (int i = 0; i < ipHostInfo.AddressList.Length; i++) {
                if (ipHostInfo.AddressList[i].AddressFamily == AddressFamily.InterNetwork) {
                    hostAddress = ipHostInfo.AddressList[i];
                    break;
                }
            }
           // Console.WriteLine("Setting up server...");
            _serverSocket = new Socket(hostAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            if (!_serverSocket.IsBound) {
                try {
                    _serverSocket.Bind(new IPEndPoint(hostAddress, _PORT));
                    _serverSocket.Listen(5000);
                    _serverSocket.BeginAccept(AcceptCallback, _serverSocket);
                    //Console.WriteLine("Server setup complete");
                }
                catch (Exception e) {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// Close all connected client (we do not need to shutdown the server socket as its connections
        /// are already closed with the clients)
        /// </summary>
        private void CloseAllSockets() {
            foreach (Socket socket in _clientSockets) {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }

            _serverSocket.Close();
        }

        private void AcceptCallback(IAsyncResult AR) {
            Socket socket;

            try {
                socket = _serverSocket.EndAccept(AR);
            }
            catch (ObjectDisposedException) // I cannot seem to avoid this (on exit when properly closing sockets)
            {
                return;
            }

            _clientSockets.Add(socket);
            playerCount++;
            socket.BeginReceive(_buffer, 0, _BUFFER_SIZE, SocketFlags.None, ReceiveCallback, socket);
            //Console.WriteLine("Client connected, waiting for request...");
            if(playerCount < 5)
                _serverSocket.BeginAccept(AcceptCallback, _serverSocket);
        }

        private void ReceiveCallback(IAsyncResult AR) {
            Socket current = (Socket)AR.AsyncState;
            int received = 0;

            try {
                received = current.EndReceive(AR);
            }
            catch (SocketException) {
                //Console.WriteLine("Client forcefully disconnected");
                current.Close(); // Dont shutdown because the socket may be disposed and its disconnected anyway
                _clientSockets.Remove(current);
                playerCount--;
                return;
            }

            //read in data
            byte[] recBuf = new byte[received];
            Array.Copy(_buffer, recBuf, received);
            string text = Encoding.ASCII.GetString(recBuf);
            board.UpdateBoard(text);

            //echo data back to other clients
            //Console.WriteLine("Echoing data back to clients");
            Send(text);
            current.BeginReceive(_buffer, 0, _BUFFER_SIZE, SocketFlags.None, ReceiveCallback, current);
        }

        public static void Send(string data) {
            // Convert the string data to byte data using ASCII encoding.
            try {
                //Console.WriteLine("Sending from Host: " + data);
                byte[] byteData = Encoding.ASCII.GetBytes(data);
                foreach (Socket current in _clientSockets) {
                    // Begin sending the data to the remote device.
                    current.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), current);
                    //Console.WriteLine("Sent to current");
                }
            }
            catch (SocketException e) {
                Console.WriteLine(e.ToString());
            }

        }

        private static void SendCallback(IAsyncResult ar) {
            try {
                // Retrieve the socket from the state object.
                Socket handler = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.
                int bytesSent = handler.EndSend(ar);
                //Console.WriteLine("SendCallback received");
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
