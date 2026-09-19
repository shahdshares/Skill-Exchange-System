using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillExchange
{
    public class UserSkill
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int SkillId { get; set; }

        [Required]
        public SkillType Type { get; set; }

        [Required]
        public ProficiencyLevel proficiencyLevel { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null;

        [ForeignKey(nameof(SkillId))]
        public Skill Skill { get; set; } = null;
    }

    public enum SkillType
    {
        Has=1,
        Wants=2
    }

    public enum ProficiencyLevel
    {
        Beginner=1,
        Intermediate=2,
        Advanced=3
    }
}
