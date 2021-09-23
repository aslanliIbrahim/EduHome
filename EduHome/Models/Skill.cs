using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Skill
    {
        public int Id { get; set; }

        [Required]
        public string SkillName { get; set; }

        public List<TeacherSkill> TeacherSkills { get; set; }

    }
}
