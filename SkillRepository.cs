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
                "TSStart = @timestampStart, TSEnd = @timestampEnd WHERE ID = @id", new { name = skill.Name, game = skill.Game, 
                type = skill.Type, inGameDes = skill.InGameDescription, additionalDes = skill.AdditionalDescription, notes = skill.Notes, 
                youtubeVidName = skill.YTVideoName, youtubeCode = skill.YTCode, timestampStart = skill.TSStart, 
                timestampEnd = skill.TSEnd, id = skill.ID});
        }

        public void InsertSkill(Skill skillToInsert)
        {
            _conn.Execute("INSERT INTO skills (NAME, GAME, TYPE, INGAMEDESCRIPTION, ADDITIONALDESCRIPTION, NOTES, YTVIDEONAME, YTCODE, " +
                "TSSTART, TSEND) VALUES (@name, @game, @type, @inGameDes, @additionalDes, @notes, @youtubeVidName, @youtubeCode, " +
                "@timestampStart, @timestampEnd);", new
                {
                    name = skillToInsert.Name,
                    game = skillToInsert.Game,
                    type = skillToInsert.Type,
                    inGameDes = skillToInsert.InGameDescription,
                    additionalDes = skillToInsert.AdditionalDescription,
                    notes = skillToInsert.Notes,
                    youtubeVidName = skillToInsert.YTVideoName,
                    youtubeCode = skillToInsert.YTCode,
                    timestampStart = skillToInsert.TSStart,
                    timestampEnd = skillToInsert.TSEnd
                });
        }

        public IEnumerable<Game> GetGames()
        {
            return _conn.Query<Game>("SELECT * FROM categories;");
        }

        public Skill AssignGame()
        {
            throw new NotImplementedException();
        }

        public void SoftDelete(int id)
        {
            var skill = GetSkill(id);

            // Flagging the Skill as Deleted //
            skill.IsDeleted = true;

            UpdateSkill(skill);
        }

        // You or Admin //
        public void HardDelte()
        {
            // Permant Delete From the Database //
        }
    }
}
