using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_players.Models;

namespace WebApi_players.Context
{
    public class AppDBContext : DbContext{

        public AppDBContext(DbContextOptions<AppDBContext> options): base(options){



        }
        public DbSet<players> players { get; set; }
    }
}
