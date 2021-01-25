using Curso.Api.Business.Entities;

namespace Curso.Api.Business.Repositories
{
    public interface IUsuarioRepository
    {
        void Adicionar(Usuario usuario);
        void Comnit();
        Usuario ObterUsuario();
    }
}