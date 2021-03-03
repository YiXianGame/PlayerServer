using Make.Model.GameModel;
using Material.Entity;

namespace Model.GameModel.GameRoom
{
    public abstract class RealTimeRoom : Room
    {
        public override void Action(Player player)
        {
            throw new System.NotImplementedException();
        }

        public override void Action_Stage()
        {
            throw new System.NotImplementedException();
        }

        public override void Enter(Player player)
        {
            throw new System.NotImplementedException();
        }

        public override void Force_Close()
        {
            throw new System.NotImplementedException();
        }

        public override void Leave(Player player)
        {
            throw new System.NotImplementedException();
        }

        public override void Raise_Stage()
        {
            throw new System.NotImplementedException();
        }

        public override void Result_Stage()
        {
            throw new System.NotImplementedException();
        }

        public override void Start_Stage()
        {
            throw new System.NotImplementedException();
        }
    }
}
