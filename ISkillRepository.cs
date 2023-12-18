using SkillExpose.Models;
using System.Net.Http.Headers;

namespace SkillExpose
{
    public interface ISkillRepository
    {
        public IEnumerable<Skill> GetAllSkills();
        public Skill GetSkill(int id);
        public void UpdateSkill(Skill skill);
    }
}
