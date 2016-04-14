///Authors: Justin Mclennan and Chun-Yip Tang
///Last Updated April 13, 2016
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Collections.Generic;

/// <summary>
/// Was planning on using this as a state object for the connection to clean up code, but ran out of time for implementation
/// </summary>
namespace SpriteandDraw
{
    class StateObject
    {
        public Socket workSocket = null;
        public const int BufferSize = 1024;
        public byte[] buffer = new byte[BufferSize];
        public StringBuilder sb = new StringBuilder();
    }
}
