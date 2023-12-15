namespace SkillExpose.Models
{
    public class VideoGame
    {
        public int GameID { get; set; }
        public string Name { get; set; } = "";
        public List<Skill> Skills { get; set; } = new List<Skill>();


    }
}
