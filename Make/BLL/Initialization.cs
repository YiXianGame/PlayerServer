using Make.Model;
using Make.RPC.Adapt;
using Material.Entity;
using Material.Entity.Config;
using Material.MySQL;
using Material.Redis;
using Material.RPCServer;
using System;
using System.Collections.Generic;

namespace Make.BLL
{
    public class Initialization
    {
        public Initialization()
        {
            Console.WriteLine("Initialization....");
            Redis redis = new Redis("127.0.0.1:6379");
            MySQL mySQL = new MySQL("127.0.0.1", "3306", "yixian", "root", "root");
            Model.Repository repository = new Model.Repository(redis, mySQL);
            Core.Repository = repository;
            CoreInit(PlayerServerConfig.PlayerServerCategory.StandardPlayerServer);
            #region --RPCServer--
            Material.RPCServer.RPCType serverType = new Material.RPCServer.RPCType();
            serverType.Add<int>("int");
            serverType.Add<string>("string");
            serverType.Add<bool>("bool");
            serverType.Add<long>("long");
            serverType.Add<Material.Entity.User>("user");
            serverType.Add<SkillCard>("skillCard");
            serverType.Add<List<SkillCard>>("skillCards");
            serverType.Add<List<CardItem>>("cardItem");
            serverType.Add<List<CardGroup>>("cardGroups");
            serverType.Add<List<Friend>>("friends");
            serverType.Add<List<Material.Entity.User>>("users");
            //适配Server远程客户端服务
            Material.RPCServer.RPCAdaptFactory.Register<PlayerServerAdapt>("PlayerServer", "192.168.0.105", "28016", serverType);
            //启动Server服务
            RPCNetServerFactory.StartServer("192.168.0.105", "28016", () => new Model.User());
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
                Core.Config.Token = Material.Utils.MD5Util.GetMD5Hash(Core.Config.Ip + Core.Config.Port, false);
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
