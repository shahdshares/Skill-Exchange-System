using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace SkillExchange
{
    public  class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<ExchangeSession> ExchangeSessions { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<UserSkill>()
                .HasOne(us => us.User)
                .WithMany(u => u.UserSkills)
                .HasForeignKey(us => us.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserSkill>()
                .HasIndex(us => new
                {
                    us.UserId,
                    us.SkillId
                })
                .IsUnique();

            modelBuilder.Entity<ExchangeSession>()
                .HasOne(es => es.Requester)
                .WithMany(u => u.RequestedSessions)
                .HasForeignKey(es => es.RequesterId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ExchangeSession>()
                .HasOne(es => es.Provider)
                .WithMany(u => u.ProvidedSessions)
                .HasForeignKey(es => es.ProviderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.ExchangeSession)
                .WithMany(es => es.Reviews)
                .HasForeignKey(r => r.ExchangeSessionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Reviewer)
                .WithMany(u => u.GivenReviews)
                .HasForeignKey(r => r.ReviewerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.ReviewedUser)
                .WithMany(u => u.ReceivedReviews)
                .HasForeignKey(r => r.ReviewedUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Review>()
                .Property(r => r.Stars)
                .HasAnnotation(
                "Range",
                new[] { 1, 5 }
                );

        }
    }
}
