using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimerCard.Models;


namespace TimerCard.Models
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options, IConfiguration configuration) : base(options) {

        }

        public DbSet<User> User{get;set;}

        public DbSet<TimerCard.Models.Attribution> Attribution { get; set; }

        public DbSet<TimerCard.Models.Log> Log { get; set; }

    }
}
