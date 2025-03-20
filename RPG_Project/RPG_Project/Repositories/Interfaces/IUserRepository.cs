using RPG_Project.Models;

namespace RPG_Project.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public User GetUsuarioLogado(string nome, string senha);
    }
}
