using Asp_Core_Crud_Relational.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp_Core_Crud_Relational.Infrastructure
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
            
         }
        public DbSet<Student> tbl_Student { get; set; }
        public DbSet<Departments> tbl_Departments { get; set; }
    }
}
