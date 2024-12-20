﻿using Microsoft.EntityFrameworkCore;

namespace Asp.net_core_Mvc.Models
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}
