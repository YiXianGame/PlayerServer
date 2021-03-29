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
        public bool Connect(Player player,long id,string password)
        {
            Task<User> task = Core.Repository.UserRepository.Login(id,password);
            task.Wait();
            if(task.Result != null)
            {
                if(task.Result.Id == -1)
                {
                    return false;
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
                            lock (value)
                            {
                                player.Team.Teammates.Remove(player.Id);
                                player.Team.Teammates.Add(player.Id, player);
                            }
                        }
                        Core.LoadRequest.SyncRoom(player, player.Room.Type.ToString(), player.Room.Teams);
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }
        [RPCService]
        public List<SkillCard> SyncSkillCard(Player player)
        {
            HashSet<SkillCard> skillCards = new HashSet<SkillCard>();
            foreach(Team team in player.Room.Teams)
            {
                foreach(Player item in player.Team.Teammates.Values)
                {
                    foreach(long id in item.CardGroup.Cards)
                    {
                        if(Core.SkillCards.TryGetValue(id, out SkillCard skillCard))
                        {
                            if(!skillCards.Contains(skillCard))skillCards.Add(skillCard);
                        }
                    }
                }
            }
            return new List<SkillCard>(skillCards);
        }
        [RPCService]
        public void SyncSkillCardSuccess(Player player)
        {
            player.Room.Enter(player);
        }
    }
}
