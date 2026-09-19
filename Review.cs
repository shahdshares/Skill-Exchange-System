using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillExchange
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ExchangeSessionId { get; set; }

        [Required]
        public int ReviewerId { get; set; }

        [Required]
        public int ReviewedUserId { get; set; }

        [Required]
        [Range(1,5)]
        public int Stars { get; set; }

        [MaxLength(1000)]
        public string? Comment { get; set; }

        [ForeignKey(nameof(ExchangeSessionId))]
        public ExchangeSession ExchangeSession { get; set; } = null;

        [ForeignKey(nameof(ReviewerId))]
        public User Reviewer { get; set; } = null;

        [ForeignKey(nameof(ReviewedUserId))]
        public User ReviewedUser { get; set; } = null;
    }
}
