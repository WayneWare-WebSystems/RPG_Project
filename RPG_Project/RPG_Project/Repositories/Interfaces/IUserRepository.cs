using RPG_Project.Models;

namespace RPG_Project.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public User GetUsuarioById(Guid value);
        public User GetUsuarioLogado(string nome, string senha);
        public Personagem GetPersonagemById(Guid userId);
    }
}
