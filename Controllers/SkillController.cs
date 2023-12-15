using Microsoft.AspNetCore.Mvc;

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
    }
}
