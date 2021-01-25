using Curso.Api.Business.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.Api.Infraestruture.Data.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly CursoDbContext _contexto;

        public CursoRepository(CursoDbContext contexto)
        {
            _contexto = contexto;
        }

        public void AdicionarCurso(Business.Entities.Curso curso)
        {
            _contexto.Cursos.Add(curso);
        }

        public void Commit()
        {
            _contexto.SaveChanges();
        }

        public IList<Business.Entities.Curso> ObterPorUsuario(int codigoUsuario)
        {
            return _contexto.Cursos.Include(i => i.Usuario).Where(x => x.CodigoUsuario == codigoUsuario).ToList();
        }
    }
}
