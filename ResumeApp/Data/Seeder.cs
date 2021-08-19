using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ResumeApp.Models;
using System.Linq;

namespace ResumeApp.Data
{
    public class Seeder
    {
        public static async void Seed(IApplicationBuilder app)
        {

            ResumeContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ResumeContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (context.Messages.Any())
            {
                return;
            }
            else
            {
                var message = new Message { FirstName = "osazee", LastName = "Imadonmwinyi", Email = "osasfrank246@gmail.com", Subject = "Job", Comment = "Let see" };
                await context.Messages.AddAsync(message);
                await context.SaveChangesAsync();

            }
        }
    }
}
