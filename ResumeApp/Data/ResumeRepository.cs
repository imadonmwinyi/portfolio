using ResumeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeApp.Data
{
    public class ResumeRepository:IResumeRepository
    {
        private readonly ResumeContext _context;

        public ResumeRepository(ResumeContext context)
        {
            _context = context;
        }

        public async Task<bool> AddMessageAsync(Message model)
        {
            await _context.AddAsync(model);
            var changes = await _context.SaveChangesAsync();
            if (changes < 1)
            {
                return false;
            }
            return true;
        }
    }
}
