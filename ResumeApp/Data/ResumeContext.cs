using Microsoft.EntityFrameworkCore;
using ResumeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeApp.Data
{
    public class ResumeContext:DbContext
    {
        public ResumeContext(DbContextOptions<ResumeContext> options):base(options)
        {

        }
        public DbSet<Message> Messages { get; set; }
    }
}
