using Make.RPC.Request;
using Make.RPC.Service;
using Material.Entity;
using Material.Entity.Config;
using Material.Entity.Frame;
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
            Redis redis = new Redis("127.0.0.1:6379");
            MySQL mySQL = new MySQL("127.0.0.1", "3306", "yixian", "root", "root");
            Model.Repository repository = new Model.Repository(redis, mySQL);
            Core.Repository = repository;
            CoreInit(PlayerServerConfig.PlayerServerCategory.StandardServer);
            #region --RPCServer--
            //Types
            EtherealS.Model.RPCTypeConfig types = new EtherealS.Model.RPCTypeConfig();
            types.Add<int>("Int");
            types.Add<string>("String");
            types.Add<bool>("Bool"); 
            types.Add<long>("Long");
            types.Add<Player>("Player");
            types.Add<FrameGroup>("FrameGroup");
            types.Add<CardGroup>("CardGroup");
            types.Add<List<FrameGroup>>("List<FrameGroup>");
            types.Add<List<Team>>("List<Team>");
            types.Add<List<long>>("List<Long>");
            types.Add<List<SkillCard>>("List<SkillCard>");
            //Service
            EtherealS.RPCService.ServiceConfig serviceConfig = new EtherealS.RPCService.ServiceConfig(types);
            serviceConfig.InterceptorEvent += EtherealS.Extension.Authority.AuthorityCheck.ServiceCheck;
            serviceConfig.ExceptionEvent += OnExceptionEvent;
            serviceConfig.LogEvent += LogEvent;
            EtherealS.RPCService.Service service = EtherealS.RPCService.ServiceCore.Register(new PlayerServerService(),Core.Config.Ip, Core.Config.Port, "PlayerServer", serviceConfig);

            EtherealS.RPCService.ServiceCore.Register(new LoadService(), Core.Config.Ip, Core.Config.Port, "LoadServer", serviceConfig);
            EtherealS.RPCService.ServiceCore.Register(new GameService(), Core.Config.Ip, Core.Config.Port, "GameServer", serviceConfig);
            //Request
            EtherealS.RPCRequest.RequestConfig requestConfig = new EtherealS.RPCRequest.RequestConfig(types);
            requestConfig.ExceptionEvent += OnExceptionEvent;
            requestConfig.LogEvent += LogEvent;
            Core.LoadRequest = EtherealS.RPCRequest.RequestCore.Register<LoadRequest>(Core.Config.Ip, Core.Config.Port, "LoadClient", requestConfig);
            Core.GameRequest = EtherealS.RPCRequest.RequestCore.Register<GameRequest>(Core.Config.Ip, Core.Config.Port, "GameClient", requestConfig);
            //Net
            EtherealS.RPCNet.NetConfig netConfig = EtherealS.RPCNet.NetCore.Register(Core.Config.Ip, Core.Config.Port);
            netConfig.ExceptionEvent += OnExceptionEvent;
            netConfig.LogEvent += LogEvent;
            //Native-Server
            EtherealS.NativeServer.ServerConfig serverConfig = new EtherealS.NativeServer.ServerConfig(() => new Player());
            serverConfig.ExceptionEvent += OnExceptionEvent;
            serverConfig.LogEvent += LogEvent;
            EtherealS.NativeServer.ServerCore.Register(Core.Config.Ip, Core.Config.Port, serverConfig).Start();
            #endregion
            SkillCardInit();
            Console.WriteLine("Initialization Sucess!");
        }

        private void LogEvent(EtherealS.Model.RPCLog log)
        {
            Console.WriteLine(log.Message);
        }

        private void OnExceptionEvent(Exception exception)
        {
            try
            {
                throw exception;
            }
            catch (EtherealS.Model.RPCException e)
            {
                Console.WriteLine($"错误类型:{e.Error}-{e.Message}");
                Console.WriteLine(e.StackTrace);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
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

        public async void SkillCardInit()
        {
            Console.WriteLine("SkillCard Loading....");
            List<SkillCard> skillCards = await Core.Repository.SkillCardRepository.Query_All();
            foreach (SkillCard item in skillCards)
            {
                Core.SkillCards.Add(item.Id, item);
            }
            Console.WriteLine("SkillCard Load Success!");
        }
    }
}
