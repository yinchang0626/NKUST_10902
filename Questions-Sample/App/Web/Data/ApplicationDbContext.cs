using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public virtual DbSet<YC.Models.QuestionGroup> QuestionGroups { get; set; }
        public virtual DbSet<YC.Models.QuestionType> QuestionTypes { get; set; }
        public virtual DbSet<YC.Models.Question> Questions { get; set; }
        public virtual DbSet<YC.Models.QuestionOption> QuestionOptions { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
