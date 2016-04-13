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
        private const int _BUFFER_SIZE = 2048;
        private static byte[] _buffer = new byte[_BUFFER_SIZE];
        private static ManualResetEvent receiveDone = new ManualResetEvent(false);
        private const int _PORT = 100;
        static Board board = new Board();

        public Join() {
        }
        public void ConnectToServer(string ipAddress) {

            searchAddress = IPAddress.Parse("192.168.18.2");
            int attempts = 0;

           // while (!_clientSocket.Connected) {
                try {
                    attempts++;
                    Console.WriteLine("Client side Connection attempt " + attempts);
                    _clientSocket.Connect(searchAddress, _PORT);
                    _clientSocket.Listen(5000);
                    ////////////////////////////////////////////////////Console.WriteLine("Works up to clientSocket.Listen(5000)");
                    _clientSocket.BeginAccept(AcceptCallback, null);
                }
<<<<<<< HEAD
                catch (SocketException) {
                    //Console.Clear();
=======
                catch (SocketException e) {
                    Console.Write("Client Side " + e.ToString());
>>>>>>> master
                }
                catch(Exception e)
                {
                    Console.Write("Client Side ConnectTo Server Exception e " + e.ToString());
                }
          //  }
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
                Console.WriteLine("Sending from Client: " + text);
                byte[] buffer = Encoding.ASCII.GetBytes(text);
                _clientSocket.BeginSend(buffer, 0, buffer.Length, 0, new AsyncCallback(SendCallback), _clientSocket);
                ///////////////////////////////////////////////////////////////////////////System.Diagnostics.Debug.WriteLine("Send to host ");
            }
            catch(SocketException e)
            {
                Console.WriteLine("Client Side" + e.ToString());
            }
        }

        private static void SendCallback(IAsyncResult ar)
        {
                // Retrieve the socket from the state object.
                Socket handler = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.
                int bytesSent = handler.EndSend(ar);
                ///////////////////////////////////////////////////////////////////////////Console.WriteLine("Sent {0} bytes to host.", bytesSent);
        }


        private void AcceptCallback(IAsyncResult AR) {
            Socket socket;
            Console.WriteLine("Entered AcceptCallback");
            try {
                socket = _clientSocket.EndAccept(AR);
            }
            catch (ObjectDisposedException) // I cannot seem to avoid this (on exit when properly closing sockets)
            {
                return;
            }
            Console.WriteLine("Client beginning receive");
            socket.BeginReceive(_buffer, 0, _BUFFER_SIZE, SocketFlags.None, ReceiveCallback, socket);
            _clientSocket.BeginAccept(AcceptCallback, null);
        }

        private void ReceiveCallback(IAsyncResult AR) {
            Console.WriteLine("Client Receiving Callback");
            Socket current = (Socket)AR.AsyncState;
            int received = 0;
            try
            {
                received = current.EndReceive(AR);
            }
            catch(SocketException)
            {
                Console.Write("SocketException at Join.ReceiveCallback");
            }
            Console.WriteLine("Client EndReceive");
            //read in data
            byte[] recBuf = new byte[received];
            Array.Copy(_buffer, recBuf, received);
            string text = Encoding.ASCII.GetString(recBuf);
            ////////////////////////////////////////////////Console.WriteLine("client " + text);
            Console.WriteLine("Client Received Text: " + text);

            board.UpdateBoard(text);
            
            current.BeginReceive(_buffer, 0, _BUFFER_SIZE, SocketFlags.None, ReceiveCallback, current);
            //Console.WriteLine(text);
        }





        //private static void RequestLoop() {

        //    while (true) {
        //        ReceiveResponse();
        //    }
        //}
        //private static void ReceiveResponse() {
        //    var buffer = new byte[2048];
        //    int received = _clientSocket.Receive(buffer, SocketFlags.None);
        //    if (received == 0) return;
        //    byte[] data = new byte[received];
        //    Array.Copy(buffer, data, received);
        //    string text = Encoding.ASCII.GetString(data);
        //    System.Diagnostics.Debug.WriteLine("Client Update ");
        //    board.UpdateBoard(text);
        //}
    }
}
