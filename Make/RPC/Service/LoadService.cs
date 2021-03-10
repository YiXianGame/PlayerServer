using Material.Entity;
using Material.EtherealS.Annotation;
using Material.EtherealS.Extension.Authority;
using Material.EtherealS.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Make.RPC.Service
{
    public class LoadService : IAuthoritable
    {
        public object Authority { get => 1; set { } }

        [RPCService(Authority = 0)]
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
                    if(player.GetToken(id, out Player value))
                    {
                        player.SetAttribute(value);
                        player.AddIntoTokens(true);
                        player.Authority = 1;
                        if (player.Team.Teammates.TryGetValue(player.Id, out Player result))
                        {
                            lock (value)//即时游戏，所以要尽可能的将锁原子化
                            {
                                player.Team.Teammates.Remove(player.Id);
                                player.Team.Teammates.Add(player.Id, player);
                            }
                        }
                        return player.Room.Teams;
                    }
                    return null;
                }
            }
            return null;
        }
        [RPCService]
        public List<SkillCard> SyncSkillCard(Player suer,List<SkillCard> skillCards)
        {
            List<SkillCard> refresh = new List<SkillCard>();
            if (skillCards != null)
            {
                foreach (SkillCard skillCard in skillCards)
                {
                    if (Core.SkillCards.TryGetValue(skillCard.Id, out SkillCard value))
                    {
                        if (value.AttributeUpdate != skillCard.AttributeUpdate)
                        {
                            refresh.Add(value);
                        }
                    }
                    else
                    {
                        skillCard.AttributeUpdate = -2;//需要删掉
                        refresh.Add(skillCard);
                    }
                }
                return refresh;
            }
            else return null;
        }
        [RPCService]
        public void SyncSkillCardSuccess(Player player)
        {
            player.Room.Enter(player);
        }
    }
}
