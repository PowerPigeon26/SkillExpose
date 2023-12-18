using Microsoft.AspNetCore.Mvc;
using SkillExpose.Models;

namespace SkillExpose.Controllers
{
    public class SkillController : Controller
    {
        private readonly ISkillRepository repo;

        public SkillController(ISkillRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var skills = repo.GetAllSkills();
            return View(skills);
        }

        public IActionResult ViewSkill(int id)
        {
            var skill = repo.GetSkill(id);

            return View(skill);
        }

        public IActionResult UpdateSkill(int id)
        {
            Skill skill = repo.GetSkill(id);

            if (skill == null)
            {
                return View("ProductNotFound");
            }

            return View(skill);
        }

        public IActionResult UpdateSkillToDatabase(Skill skill)
        {
            repo.UpdateSkill(skill);

            return RedirectToAction("ViewSkill", new { id = skill.ID });
        }
    }
}
