using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SkillExchange
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(150)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Bio { get; set; }

        [MaxLength(120)]
        public string? Role { get; set; }

        [MaxLength(160)]
        public string? Location { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public double ReputationScore { get; set; }

        public ICollection<UserSkill> UserSkills { get; set; }
        = new List<UserSkill>();

        public ICollection<ExchangeSession> RequestedSessions { get; set; }
        = new List<ExchangeSession>();

        public ICollection<ExchangeSession> ProvidedSessions { get; set; }
        = new List<ExchangeSession>();

        public ICollection<Review> GivenReviews { get; set; }
        = new List<Review>();

        public ICollection<Review> ReceivedReviews { get; set; }
            = new List<Review>();
    }
}
