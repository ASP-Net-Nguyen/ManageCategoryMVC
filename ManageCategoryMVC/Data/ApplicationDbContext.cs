using Microsoft.EntityFrameworkCore;
using ManageCategoryMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageCategoryMVC.Data
{
    public class ApplicationDbContext: DbContext
    {
        public  ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> categories { get; set; }
    }
}
