using SkillExpose.Models;

namespace SkillExpose.Validations
{
    public static class SkillValidation
    {
        // Form Validation //
        public static void ValidateSkill(Skill skill, out bool isValid, out List<string> messages)
        {
            messages = new List<string>();
            isValid = true;

            if (skill == null)
            {
                var result = "Skill Can not be null or empty";
                messages.Add(result);
                isValid = false;
            }

            if (String.IsNullOrEmpty(skill?.Name))
            {
                var result = "Name Can not be null or empty ";
                messages.Add(result);
                isValid = false;
            }

            if (String.IsNullOrEmpty(skill?.Game))
            {
               var result = "Game Can not be null or empty";
                messages.Add(result);
                isValid = false;
            }

            // Null Conditional Operator
            if (skill?.Name?.Length > 20)
            {
                var result = "Skill Name can not exceed 20 characters";
                messages.Add(result);
                isValid = false;
            }

            // continue to add validation logic
           
        }

        // Database Validation //
    }
}
