using Make.RPC.Request;
using Material.Entity;
using Material.Entity.Config;
using System;
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
        private static LoadRequest loadRequest;
        private static GameRequest gameRequest;
        private static Random random = new Random((int)(Material.Utils.TimeStamp.Now() % 2147483640));
        #endregion

        #region --属性--
        public static Model.Repository Repository { get => repository; set => repository = value; }
        public static PlayerServerConfig Config { get => config; set => config = value; }
        public static Dictionary<long, SkillCard> SkillCards { get => skillCards; set => skillCards = value; }
        public static LoadRequest LoadRequest { get => loadRequest; set => loadRequest = value; }
        public static GameRequest GameRequest { get => gameRequest; set => gameRequest = value; }
        public static Random Random { get => random; set => random = value; }

        #endregion

    }
}
