﻿using Microsoft.EntityFrameworkCore;

namespace Asp.net_core_Mvc.Models
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
            
        }
        public DbSet<Student> Students { get; set; }
    }
 }
