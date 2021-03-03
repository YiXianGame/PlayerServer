using Material.Entity;
using Material.Entity.Config;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Make
{
    public static class Core
    {
        #region --字段--
        private static PlayerServerConfig config;
        private static Dictionary<long, SkillCard> skill_Card_ID_Skllcard = new Dictionary<long, SkillCard>();
        private static Model.Repository repository;
        #endregion

        #region --属性--
        public static Dictionary<long, SkillCard> SkillCardByID { get => skill_Card_ID_Skllcard; set => skill_Card_ID_Skllcard = value; }
        public static Model.Repository Repository { get => repository; set => repository = value; }

        public static PlayerServerConfig Config { get => config; set => config = value; }
        #endregion

    }
}
