using SkillExpose.Models;
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
        public IEnumerable<Game> GetGames();
        public Skill AssignGame();
    }
}
