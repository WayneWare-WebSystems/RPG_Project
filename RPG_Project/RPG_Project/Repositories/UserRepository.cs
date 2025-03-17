using RPG_Project.Context;
using RPG_Project.Repositories.Interfaces;

namespace RPG_Project.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
