using Material.Entity;

namespace Model.GameRoom.Round
{
    public class RealTimeSoloRoom : RealTimeRoom
    {
        #region --方法--
        public RealTimeSoloRoom()
        {
            min_players = 2;
            max_players = 2;
        }
        public override bool Enter(Player player)
        {
            player.Hp = 100;
            player.HpMax = 100;
            player.Mp = 30;
            player.MpMax = 30;
            return base.Enter(player);
        }
        #endregion
    }
}
