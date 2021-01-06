﻿using Make.MODEL.TCP_Async_Event;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Make.MODEL.RPC
{
    /// <summary>
    /// 客户端工厂
    /// </summary>
    public class RPCServerFactory 
    {
        private static ConcurrentDictionary<Tuple<string, string>, SocketListener> socketservers { get; } = new ConcurrentDictionary<Tuple<string, string>, SocketListener>();
        
        /// <summary>
        /// 获取客户端
        /// </summary>
        /// <param name="serverIp">远程服务IP</param>
        /// <param name="port">远程服务端口</param>
        /// <returns>客户端</returns>
        public static SocketListener GetServer(Tuple<string, string> key)
        {
            SocketListener socketserver;
            socketservers.TryGetValue(key, out socketserver);
            if (socketserver == null)
            {
                try
                {
                    socketserver = new SocketListener(key.Item1, key.Item2, 1000, 1024);
                    for(int i = 0; i < 5; i++)
                    {
                        Thread thread = new Thread(() => socketserver.StartAccept(null));
                        thread.Name = i.ToString();
                        thread.Start();
                    }   
                    socketservers[key] = socketserver;
                }
                catch (SocketException err)
                {
                    Console.WriteLine("发生异常报错,销毁注册");
                    socketserver.Dispose();
                }
            }
            return socketserver;
        }

        public static void Destory(Tuple<string, string> key)
        {
            socketservers.TryRemove(key, out SocketListener socket);
            socket.Dispose();
        }
    }
}
