using Google.Protobuf;
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

            return View(skills);
        }

        public IActionResult ViewSkill(int id)
        {
            var skill = repo.GetSkill(id);

            return View(skill);
        }

        public IActionResult UpdateSkill(int id)
        {
            var skill = repo.GetSkill(id);

            if (skill == null)
            {
                return View("SkillNotFound");
            }

            return View(skill);
        }

        public IActionResult UpdateSkillToDatabase(Skill skill)
        {
            repo.UpdateSkill(skill);

            return RedirectToAction("ViewSkill", new { id = skill.ID });

            //try
            //{
            //    SkillValidation.ValidateSkill(skill, out var isValid, out var messages);

            //    if (isValid)
            //        repo.UpdateSkill(skill);

            //    else
            //    {
            //        // Skill Validation View => Model would be a List<string>
            //        return View("SkillValidationError", messages);
            //    }


            //    return RedirectToAction("ViewSkill", new { id = skill.ID });
            //}
            //catch (Exception ex)
            //{
            //    // Create an Error View to Handle if there is an exception //
            //    return RedirectToAction("ErrorView", ex.Message);
            //}
        }

        public IActionResult InsertSkill()
        {
            var skill = repo.AssignGame();

            return View(skill);
        }

        public IActionResult InsertSkillToDatabase(Skill skillToInsert)
        {

            var nameState = ModelState["Name"];
            if (nameState?.Errors.Count == 0)
            {
                repo.InsertSkill(skillToInsert);
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSkill(Skill skill)
        {
            repo.DeleteSkill(skill);

            return RedirectToAction("Index");
        }
    }
}
