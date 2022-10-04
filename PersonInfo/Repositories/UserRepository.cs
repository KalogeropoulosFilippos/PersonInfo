using Microsoft.EntityFrameworkCore;
using PersonInfo.Models;

namespace PersonInfo.Repositories
{
    public class UserRepository:IUserRepository
    {
        private PersonDetailsContext _context;
        public UserRepository(PersonDetailsContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetAll()
        {
            return await _context.Users.Include(x => x.UserType).Include(x => x.UserTitle).Where(x=>x.IsActive==true).ToListAsync();
        }
        public async Task<List<User>> GetByName(string name)
        {
            return await _context.Users.Include(x => x.UserTitle).Include(z => z.UserType).Where(x => x.Name == name).ToListAsync();
        }
        public async Task Insert(User user)
        {
            _context.Users.Add(user);
            await Save();
        }
        public async Task Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.Entry(user.UserType).State = EntityState.Modified;
            _context.Entry(user.UserTitle).State = EntityState.Modified;
            await Save();
        }
        public async Task Delete(int id)
        {
            User existing = _context.Users.Include(x => x.UserTitle).Include(z => z.UserType).FirstOrDefault(x=>x.Id==id);
            existing.IsActive = false;
            await Save();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
