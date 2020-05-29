using API.Funcionarios.Context;
using API.Funcionarios.Entities;
using API.Funcionarios.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Funcionarios.Repository
{
    public class HabilidadeRepository : IHabilidadeRepository
    {
        private readonly DataContext dataContext;
        public HabilidadeRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task<IEnumerable<Habilidade>> ListarAsync()
        {
            var habilidades = await dataContext.Habilidades.AsNoTracking().ToListAsync();
            return habilidades;
        }
    }
}
