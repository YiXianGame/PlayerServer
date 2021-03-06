using Material.Entity;
using Material.RPCServer.Annotation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Make.RPC.Service
{
    public class LoadService
    {
        [RPCService]
        public List<Team> Connect(Player player,long id,string password)
        {
            Task<User> task = Core.Repository.UserRepository.Login(id,password);
            task.Wait();
            if(task.Result != null)
            {
                if(task.Result.Id == -1)
                {
                    return null;
                }
                else
                {
                    if(player.GetToken(player.Id, out Player value))
                    {
                        
                    }
                }
            }
            return null;
        }
    }
}
