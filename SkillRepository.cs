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

        public Skill GetSkill(int id)
        {
            return _conn.QuerySingle<Skill>("SELECT * FROM skills WHERE ID = @id",
                new { id = id });
        }

        public void UpdateSkill(Skill skill)
        {
            _conn.Execute("UPDATE skills SET Name = @name, Game = @game, Type = @type, InGameDescription = @inGameDes, " +
                "AdditionalDescription = @additionalDes, Notes = @notes, YTVideoName = @youtubeVidName, YTCode = @youtubeCode, " +
                "TSStart = @timestampStart, TSEnd = @timestampEnd", new { name = skill.Name, game = skill.Game, type = skill.Type,
                inGameDes = skill.InGameDescription, additionalDes = skill.AdditionalDescription, notes = skill.Notes, 
                youtubeVidName = skill.YTVideoName, youtubeCode = skill.YTCode, timestampStart = skill.TSStart, 
                timestampEnd = skill.TSEnd});
        }
    }
}
