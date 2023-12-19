namespace SkillExpose.Models
{
    public class Skill
    {
        public int ID { get; set; }
        public string Name { get; set; } = "";
        public int GameID { get; set; }
        public string Game { get; set; } = "";
        public string Type { get; set; } = "";
        public string InGameDescription { get; set; } = "";
        public string AdditionalDescription { get; set; } = "";
        public string Notes { get; set; } = "";
        public string YTVideoName { get; set; } = "";
        public string YTCode { get; set; } = "";
        public string TSStart { get; set; } = "";
        public string TSEnd { get; set; } = "";
        

    }
}
