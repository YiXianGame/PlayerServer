﻿using Material.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Material.MySQL.Dao.Interface
{
    public interface ISkillCArdDao
    {
        Task<long> Insert(SkillCard skillCard);
        Task<bool> Update(SkillCard skillCard);
        Task<bool> Delete(long id);
        Task<SkillCard> Query(long id);

        Task<List<SkillCard>> Query_All();
    }
}
