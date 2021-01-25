using Curso.Api.Business.Entities;
using Curso.Api.Business.Repositories;
using System.Linq;

namespace Curso.Api.Infraestruture.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly CursoDbContext _contexto;

        public UsuarioRepository(CursoDbContext contexto)
        {
            this._contexto = contexto;
        }

        public void Adicionar(Usuario usuario)
        {
            _contexto.Usuarios.Add(usuario);
        }

        public void Comnit()
        {
            _contexto.SaveChanges();
        }

        public Usuario ObterUsuario(string login)
        {
            return _contexto.Usuarios.FirstOrDefault(u => u.Login == login);
        }
    }
}