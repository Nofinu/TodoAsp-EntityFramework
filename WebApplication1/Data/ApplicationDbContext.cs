﻿using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ToDo> todos {  get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option ) : base(option)
        {

        }
    }
}
