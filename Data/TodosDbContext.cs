using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class TodosDbContext:DbContext
    {
        public TodosDbContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Todos> Todos { get; set; }
        
    }
}