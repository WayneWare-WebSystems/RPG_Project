using Microsoft.AspNetCore.Server.Kestrel.Core;
using RPG_Project.Context;
using RPG_Project.Models;
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

        public User GetUsuarioById(Guid value)
        {
            try
            {
                var usuario = _context.Users.FirstOrDefault(u => u.Id_Usuario == value);
                return usuario;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public User GetUsuarioLogado(string nome, string senha)
        {
            try
            {
                var usuarioLogado = _context.Users.FirstOrDefault(u => u.Usuario == nome && u.Senha == senha);
                return usuarioLogado;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IEnumerable<Personagem> GetPersonagemById(Guid userId)
        {
            var Personagens = _context.Personagens.Where(p => p.UserId == userId);
            return Personagens;
        }
        Personagem IUserRepository.GetPersonagemById(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
