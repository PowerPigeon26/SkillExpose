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
            var skill = _conn.QuerySingle<Skill>("SELECT * FROM skills WHERE ID = @id",
                new { id = id });

            var gameList = GetGames();
            skill.Games = gameList;

            return skill;
        }

        public void UpdateSkill(Skill skill)
        {
            _conn.Execute("UPDATE skills SET Name = @name, GameID = @gameID, Game = @game, Type = @type, InGameDescription = @inGameDes, " +
                "AdditionalDescription = @additionalDes, Notes = @notes, YTVideoName = @youtubeVidName, YTCode = @youtubeCode, " +
                "TSStart = @timestampStart, TSEnd = @timestampEnd WHERE ID = @id", new { name = skill.Name, gameID = skill.GameID, game = skill.Game, 
                type = skill.Type, inGameDes = skill.InGameDescription, additionalDes = skill.AdditionalDescription, notes = skill.Notes, 
                youtubeVidName = skill.YTVideoName, youtubeCode = skill.YTCode, timestampStart = skill.TSStart, 
                timestampEnd = skill.TSEnd, id = skill.ID});
        }

        public void InsertSkill(Skill skillToInsert)
        {
            _conn.Execute("INSERT INTO skills (NAME, GAMEID, GAME, TYPE, INGAMEDESCRIPTION, ADDITIONALDESCRIPTION, NOTES, YTVIDEONAME, YTCODE, " +
                "TSSTART, TSEND) VALUES (@name, @gameID, @game, @type, @inGameDes, @additionalDes, @notes, @youtubeVidName, @youtubeCode, " +
                "@timestampStart, @timestampEnd);", new
                {
                    name = skillToInsert.Name,
                    gameID = skillToInsert.GameID,
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

        public IEnumerable<VideoGame> GetGames()
        {
            return _conn.Query<VideoGame>("SELECT * FROM games;");
        }

        public Skill AssignGame()
        {
            var gameList = GetGames();
            var skill = new Skill();
            skill.Games = gameList;

            return skill;
        }

        public void DeleteSkill(Skill skill)
        {
            _conn.Execute("DELETE FROM skills WHERE ID = @id;", new { id = skill.ID });
        }
    }
}
