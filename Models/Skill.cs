using System.ComponentModel.DataAnnotations;

namespace SkillExpose.Models
{
    public class Skill
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; } = "";

        [RegularExpression("^[0-9]+$")]
        public int GameID { get; set; }

        [StringLength(100)]
        public string Game { get; set; } = "";

        [StringLength(100)]
        public string Type { get; set; } = "";

        [StringLength(1000)]
        public string InGameDescription { get; set; } = "";

        [StringLength(1000)]
        public string AdditionalDescription { get; set; } = "";

        [StringLength(1000)]
        public string Notes { get; set; } = "";

        [StringLength(100)]
        public string YTVideoName { get; set; } = "";

        [StringLength(1000)]
        public string YTCode { get; set; } = "";

        [StringLength(50)]
        public string TSStart { get; set; } = "";

        [StringLength(50)]
        public string TSEnd { get; set; } = "";

        public bool IsDeleted { get; set; } = false; //add soft delete later
        public IEnumerable<VideoGame> Games { get; set; }
        

    }
}
