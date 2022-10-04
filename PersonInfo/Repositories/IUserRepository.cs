using PersonInfo.Models;

namespace PersonInfo.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<List<User>> GetByName(string name);
        Task Insert(User user);
        Task Update(User user);
        Task Delete(int id);
        Task Save();
    }
}
