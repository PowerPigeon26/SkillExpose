﻿using SkillExpose.Models;
using System.ComponentModel;
using System.Net.Http.Headers;

namespace SkillExpose
{
    public interface ISkillRepository
    {
        public IEnumerable<Skill> GetAllSkills();
        public Skill GetSkill(int id);
        public void UpdateSkill(Skill skill);
        public void InsertSkill(Skill skillToInsert);
        public IEnumerable<VideoGame> GetGames();
        public Skill AssignGame();
        public void DeleteSkill(Skill skill);

    }
}
