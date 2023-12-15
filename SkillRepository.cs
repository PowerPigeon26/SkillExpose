using SkillExpose.Models;
using Dapper;
using System.Data;

namespace SkillExpose
{
    public class SkillRepository : ISkillRepository
    {
        private readonly IDbConnection _conn;

        public SkillRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        public IEnumerable<Skill> GetAllSkills()
        {
            return _conn.Query<Skill>("SELECT * FROM skills");
        }
    }
}
