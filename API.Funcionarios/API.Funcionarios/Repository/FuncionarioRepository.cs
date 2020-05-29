using API.Funcionarios.Context;
using API.Funcionarios.Entities;
using API.Funcionarios.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Funcionarios.Repository
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly DataContext dataContext;

        public FuncionarioRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task InserirHabilidadesFuncionarioAsync(Funcionario funcionario)
        {
            foreach (var habilidade in funcionario.Habilidades)
                await dataContext.AddAsync(new FuncionarioHabilidades
                {
                    FuncionarioId = funcionario.Id,
                    HabilidadeId = habilidade.Id
                });
            await dataContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<Habilidade>> ObterHabilidadesFuncionarioAsync(int funcionarioId)
        {
            var habilidadesId = await dataContext.FuncionarioHabilidades.Where(fh => fh.FuncionarioId == funcionarioId).Select(fh => fh.HabilidadeId).ToListAsync();
            return await dataContext.Habilidades.Where(h => habilidadesId.Contains(h.Id)).ToListAsync();
        }
        public async Task DeletarHabilidadesFuncionarioAsync(int funcionarioId)
        {
            var funcionarioHabilidades = dataContext.FuncionarioHabilidades.Where(fh => fh.FuncionarioId == funcionarioId);
            foreach (var fh in funcionarioHabilidades)
                dataContext.Remove(fh);
            await dataContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<Funcionario>> ListarAsync()
        {
            var funcionarios = await dataContext.Funcionarios.AsNoTracking().ToListAsync();
            foreach (var funcionario in funcionarios)
                funcionario.Habilidades = await ObterHabilidadesFuncionarioAsync(funcionario.Id);
            return funcionarios;
        }

        public async Task<Funcionario> ObterPorIdAsync(int id)
        {
            var funcionario = await dataContext.Funcionarios.FirstOrDefaultAsync(f => f.Id == id);
            if (funcionario == null)
                return null;
            funcionario.Habilidades = await ObterHabilidadesFuncionarioAsync(id);
            return funcionario;
        }

        public async Task InserirAsync(Funcionario funcionario)
        {
            await dataContext.AddAsync(funcionario);
            await dataContext.SaveChangesAsync();
            await InserirHabilidadesFuncionarioAsync(funcionario);
        }
        public async Task EditarAsync(Funcionario funcionario)
        {
            dataContext.Update(funcionario);
            await DeletarHabilidadesFuncionarioAsync(funcionario.Id);
            await InserirHabilidadesFuncionarioAsync(funcionario);
            await dataContext.SaveChangesAsync();
        }
    }
}
