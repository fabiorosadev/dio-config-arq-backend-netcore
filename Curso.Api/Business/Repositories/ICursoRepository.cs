using System.Collections.Generic;

namespace Curso.Api.Business.Repositories
{
    public interface ICursoRepository
    {
        void AdicionarCurso(Entities.Curso curso);
        void Commit();
        IList<Entities.Curso> ObterPorUsuario(int codigoUsuario);

    }
}
