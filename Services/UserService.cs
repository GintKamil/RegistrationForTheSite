using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using RegistrationSite.Model;

namespace RegistrationSite.Services
{
    public interface IUserService
    {
        public Task<RegistrationModel> Create(RegistrationModel model);
        public Task<RegistrationModel> Get(string email);
    }

    public class UserService : IUserService
    {
        private readonly DataBaseContext _context;

        public UserService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<RegistrationModel> Create(RegistrationModel model)
        {
            _context.Users.Add(model);
            await _context.SaveChangesAsync();
            Console.WriteLine($"Пользователь с почтой {model.Email} добавлен в БД");
            return model;
        }

        public async Task<RegistrationModel> Get(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
