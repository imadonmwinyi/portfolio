using ResumeApp.Models;
using System.Threading.Tasks;

namespace ResumeApp.Data
{
    public interface IResumeRepository
    {
        Task<bool> AddMessageAsync(Message model);
    }
}
