using EduHome.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.DAL
{
    public class AppDbContext: IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Sms> sms { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<AboutUs> about { get; set; }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<TeacherSkill> TeacherSkills { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Spekear> Spekears { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<NoticeBoard> NoticeBoards  { get; set; }
    }
}
