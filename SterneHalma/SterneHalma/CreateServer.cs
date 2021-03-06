﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;


namespace SterneHalma
{
    class CreateServer
    {

        public static ManualResetEvent allDone = new ManualResetEvent(false);
        //private variable for the host IPAddress with getters and setters.
        private static IPAddress hostAddress { get; set; }
        public static int count {get; set; }
        

        /// <summary>
        /// Empty Constructor for now. May fill it later if needed.
        /// </summary>
        public CreateServer()
        {
            hostAddress = null;
            Create();
            count = 0;
        }

        /// <summary>
        /// Creates the Server and begins listeneing
        /// </summary>
        public void Create()
        {
            //buffer for incoming data
            byte[] bytes = new Byte[1024];

            //Gets the hosts DNS and endpoint for socket
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            //Writes out the ip address in ipv6 form
            for (int i = 0; i < ipHostInfo.AddressList.Length; i++)
            {
                if (ipHostInfo.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                {
                    hostAddress = ipHostInfo.AddressList[i];
                    break;
                }
            }
            Console.WriteLine(hostAddress.ToString());
                IPEndPoint localEndPoint = new IPEndPoint(hostAddress, 11000);
            //Have to write out the IP Address onto the host screen 

            Socket listener = new Socket(hostAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(100);

                while(true)
                {
                    allDone.Reset();

                    Console.WriteLine("Waiting for Connection");     //change to output on the screen
                    listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
                    allDone.WaitOne();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("Press Enter to continue...");
            Console.Read();
        }

        public static void AcceptCallback(IAsyncResult ar)
        {
            allDone.Set();

            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            StateObject state = new StateObject();
            state.workSocket = handler;
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize,
                0, new AsyncCallback(ReadCallback), state);
            count++;
        }

        public static void ReadCallback(IAsyncResult ar)
        {
            String content = String.Empty;

            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;

            int bytesRead = handler.EndReceive(ar);
            
                if (bytesRead > 0)
                {
                    state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));

                    content = state.sb.ToString();
                    if (content.IndexOf("EOF") > -1)
                    {
                        Console.WriteLine("Read {0} bytes from socket. \n Data : {1}", content.Length, content);
                        Send(handler, content);
                    }
                    else
                    {
                        handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
                    }
                }
            
        }

        private static void Send(Socket handler, String data)
        {
            byte[] byteData = Encoding.ASCII.GetBytes(data);
            handler.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), handler);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                Socket handler = (Socket)ar.AsyncState;
                int bytesSend = handler.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to client.", bytesSend);

                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
