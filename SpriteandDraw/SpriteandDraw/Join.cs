﻿///Authors: Justin Mclennan and Chun-Yip Tang
///Last Updated April 13, 2016
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

/// <summary>
/// Creates the Client side of the client server asynchronous socket
/// </summary>
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

        /// <summary>
        /// Connects to the server and sets up with ipaddress
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <returns></returns>
        public bool ConnectToServer(string ipAddress) {
            if (!IPAddress.TryParse(ipAddress, out searchAddress))
                return false;

            try {
                if (!_clientSocket.Connected) {
                    _clientSocket.BeginConnect(new IPEndPoint(searchAddress, _PORT), new AsyncCallback(ConnectCallback), _clientSocket);
                }
            }
            catch (SocketException e) {

                Console.Write("Client Side " + e.ToString());

                Console.Write("Client Side " + e.ToString() + " " + e.SocketErrorCode);

                return false;
            }
            catch (Exception e) {
                Console.Write("Client Side ConnectTo Server Exception e " + e.ToString());
                return false;
            }
            return true;
        }

        /// <summary>
        /// Ends the connection request because we are already connected
        /// </summary>
        /// <param name="AR"></param>
        public void ConnectCallback(IAsyncResult AR)
        {
            try
            {
                Socket client = (Socket) AR.AsyncState;
                client.EndConnect(AR);
                //Console.WriteLine("Client now connected");
                client.BeginReceive(_buffer, 0, _BUFFER_SIZE, SocketFlags.None, ReceiveCallback, client);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        /// <summary>
        /// Closes all the sockets that are currently connected to the client
        /// </summary>
        public static void CloseAllSockets()
        {
            _clientSocket.Shutdown(SocketShutdown.Both);
            _clientSocket.Close();
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
                //Console.WriteLine("Sending from Client: " + text);
                byte[] buffer = Encoding.ASCII.GetBytes(text);
                _clientSocket.BeginSend(buffer, 0, buffer.Length, 0, new AsyncCallback(SendCallback), _clientSocket);
            }
            catch(SocketException e)
            {
                Console.WriteLine("Client Side" + e.ToString());
            }
        }

        /// <summary>
        /// Sends the callback and makes sure that all data sent has been receieved
        /// </summary>
        /// <param name="ar"></param>
        private static void SendCallback(IAsyncResult ar)
        {
                // Retrieve the socket from the state object.
                Socket handler = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.
                int bytesSent = handler.EndSend(ar);
        }

        /// <summary>
        /// Handles how the system handles the data sent to it.
        /// </summary>
        /// <param name="AR"></param>
        private void ReceiveCallback(IAsyncResult AR) {
            //Console.WriteLine("Client Receiving Callback");
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
            //Console.WriteLine("Client EndReceive");
            //read in data
            byte[] recBuf = new byte[received];
            Array.Copy(_buffer, recBuf, received);
            string text = Encoding.ASCII.GetString(recBuf);

            Console.WriteLine("Client Received Text: " + text);

            ///Updates the board with the text received
            board.UpdateBoard(text);
            
            try
            {
                current.BeginReceive(_buffer, 0, _BUFFER_SIZE, SocketFlags.None, ReceiveCallback, current);
            }
            catch(SocketException e)
            {
                Console.WriteLine("Exception at Join line 146: " + e.ToString() + " " + e.SocketErrorCode);
            }
            //Console.WriteLine(text);
        }
    }
}
