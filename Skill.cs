using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace SkillExchange
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        [MaxLength(80)]
        public string? Category { get; set; }

        public ICollection<UserSkill> UserSkills { get; set; }
        = new List<UserSkill>();
    }
}
