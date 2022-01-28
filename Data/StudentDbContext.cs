using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;

namespace StudentManagement.Data
{
    public class StudentDbContext : DbContext
    {
        //here we create constructor
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }

        //here we create table
        public DbSet<Student> Students { get; set; }
    }
}
