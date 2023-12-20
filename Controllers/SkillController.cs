using Microsoft.AspNetCore.Mvc;
using SkillExpose.Models;
using SkillExpose.Validations;

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
            skills = null;
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
                return View("SkillNotFound");
            }

            return View(skill);
        }

        public IActionResult UpdateSkillToDatabase(Skill skill)
        {
            try
            {
                SkillValidation.ValidateSkill(skill, out var isValid, out var messages);

                if (isValid)
                    repo.UpdateSkill(skill);

                else
                {
                    // Skill Validation View => Model would be a List<string>
                    return View("SkillValidationError", messages);
                }


                return RedirectToAction("ViewSkill", new { id = skill.ID });
            }
            catch (Exception ex)
            {
                // Create an Error View to Handle if there is an exception //
                return RedirectToAction("ErrorView", ex.Message);
            }

            finally 
            { 
                // Always Happens //
                // Logging messages, cleanup 
            }

        }
    }
}
