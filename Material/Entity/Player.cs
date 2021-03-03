using Material.RPCServer.TCP_Async_Event;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Make.Model.GameModel
{
    public class Player : BaseUserToken
    {
        #region --Enum--
        [JsonConverter(typeof(StringEnumConverter))]
        public enum UserState { Life,Death };
        #endregion

        #region --字段--
        long id = -1;
        #endregion

        #region --属性--
        public override object Key { get => id; set => id = (long)value; }
        public long Id { get => id; set => id = value; }
        #endregion
    }
}
