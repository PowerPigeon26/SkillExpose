using SkillExpose.Models;
using System.Net.Http.Headers;

namespace SkillExpose
{
    public interface ISkillRepository
    {
        public IEnumerable<Skill> GetAllSkills();
    }
}
