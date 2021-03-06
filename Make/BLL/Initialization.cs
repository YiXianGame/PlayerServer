using Make.RPC.Service;
using Material.Entity;
using Material.Entity.Config;
using Material.EtherealS.Model;
using Material.EtherealS.Net;
using Material.EtherealS.Service;
using Material.MySQL;
using Material.Redis;
using System;
using System.Collections.Generic;

namespace Make.BLL
{
    public class Initialization
    {
        public Initialization()
        {
            Console.WriteLine("Initialization....");
            Redis redis = new Redis("127.0.0.1 : 6379");
            MySQL mySQL = new MySQL("127.0.0.1", "3306", "yixian", "root", "root");
            Model.Repository repository = new Model.Repository(redis, mySQL);
            Core.Repository = repository;
            CoreInit(PlayerServerConfig.PlayerServerCategory.StandardServer);
            #region --RPCServer--
            RPCType serverType = new RPCType();
            serverType.Add<int>("Int");
            serverType.Add<string>("String");
            serverType.Add<bool>("Bool");
            serverType.Add<long>("Long");
            serverType.Add<CardGroup>("CardGroup");
            serverType.Add<List<Team>>("List<Team>");
            //适配Server远程客户端服务
            RPCServiceFactory.Register(new PlayerServerService(),"PlayerServer", "192.168.0.105", "28016", new RPCNetServiceConfig(serverType));
            //启动Server服务
            RPCNetConfig serverNetConfig = new RPCNetConfig(() => new Player());
            RPCNetFactory.StartServer("192.168.80.1", "28015", serverNetConfig);
            #endregion
            Console.WriteLine("Initialization Sucess!");
        }

        private async void CoreInit(PlayerServerConfig.PlayerServerCategory category)
        {
            Console.WriteLine("Core Loading....");
            //全局静态，查询以后会将Core静态属性全部设置好.
            PlayerServerConfig config= await Core.Repository.ConfigRepository.Query(category);
            //如果没找到，就执行默认配置
            if (config == null)
            {
                Core.Config = new PlayerServerConfig();
                Core.Config.Category = category;
                Core.Config.Ip = "127.0.0.1";
                Core.Config.Port = "28016";
                Core.Config.SecretKey = Material.Utils.MD5Util.GetMD5Hash(Core.Config.Ip + Core.Config.Port, false);
                if (!(await Core.Repository.ConfigRepository.Insert(Core.Config)))
                {
                    Console.WriteLine("Core Load Fail!");
                }
                else
                {
                    Core.Config = config;
                }
            }
            else Core.Config = config;
            Console.WriteLine("Core Load Sucess!");
        }
    }
}
