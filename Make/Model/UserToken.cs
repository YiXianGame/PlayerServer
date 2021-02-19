using Material.RPCServer.TCP_Async_Event;

namespace Make.Model
{
    public class UserToken : BaseUserToken
    {
        #region --字段--
        private long userId=-1;
        #endregion

        #region --属性--
        public long UserId { get => userId; set => userId = value; }
        #endregion

        #region --方法--
        public override void Init()
        {
            userId = -1;
        }
        public override object GetKey()
        {
            return userId;
        }
        #endregion

    }
}
