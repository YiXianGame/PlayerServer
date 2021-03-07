namespace Material.Entity.EventArgs
{
    public class DeathEventArgs : System.EventArgs
    {
        #region --字段--
        private Player killer;
        private Player killed;
        #endregion

        #region --属性--
        public Player Killer { get => killer; set => killer = value; }
        public Player Killed { get => killed; set => killed = value; }
        #endregion

        #region --方法--
        public DeathEventArgs(Player killer, Player killed)
        {
            this.killer = killer;
            this.killed = killed;
        }
        #endregion


    }
}
