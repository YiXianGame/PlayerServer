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
        private static Dictionary<long, SkillCard> skillCards = new Dictionary<long, SkillCard>();
        private static Model.Repository repository;
        #endregion

        #region --属性--
        public static Model.Repository Repository { get => repository; set => repository = value; }
        public static PlayerServerConfig Config { get => config; set => config = value; }
        public static Dictionary<long, SkillCard> SkillCards { get => skillCards; set => skillCards = value; }
        #endregion

    }
}
