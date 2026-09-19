using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillExchange
{
    public class ExchangeSession
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int RequesterId { get; set; }

        [Required]
        public int ProviderId { get; set; }

        [Required]
        public SessionStatus Status { get; set; }

        [Required]
        public DateTime ScheduledAt { get; set; }

        [MaxLength(160)]
        public string? OfferedSkill { get; set; }

        [MaxLength(160)]
        public string? RequestedSkill { get; set; }

        [MaxLength(1000)]
        public string? Note { get; set; }

        public int DurationMinutes { get; set; } = 60;

        [ForeignKey(nameof(RequesterId))]
        public User Requester { get; set; } = null;

        [ForeignKey(nameof(ProviderId))]
        public User Provider { get; set; } = null;

        public ICollection<Review> Reviews { get; set; }
        = new List<Review>();
    }

    public enum SessionStatus
    {
        Pending=1,
        Accepted=2,
        Rejected=3,
        Completed=4
    }
}
