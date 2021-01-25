using Curso.Api.Models.Usuarios;

namespace Curso.Api.Configurations
{
    public interface IAuthenticationService
    {
        string GerarToken(UsuarioViewModelOutput usuarioViewModelOutput);
    }
}