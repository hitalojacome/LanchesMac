using LanchesMac.Context;
using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace LanchesMac.Repositories
{
    public class LancheRepository : ILancheRepository
    {
        // Atributo _context do tipo AppDbContext somente leitura.
        private readonly AppDbContext _context;

        // Construtor da classe, recebe um parametro do tipo AppDbContext
        public LancheRepository(AppDbContext contexto)
        {
            // Atributo == Parametro
            _context = contexto;
        }

        // Implementação da Interface
            // Retorna uma coleção de lanches incluindo suas categorias
        public IEnumerable<Lanche> Lanches => _context.Lanches.Include(c => c.Categoria);

            // Retorna uma coleção de lanches onde o lanche é preferido (true 1) e inclue suas categorias
        public IEnumerable<Lanche> LanchesPreferidos => _context.Lanches.
                                           Where(l => l.IsLanchePreferido).
                                           Include(c => c.Categoria);

            // Método para retornar um único lanche, recebe um parametro inteiro
        public Lanche GetLancheById(int lancgId)
        {
            // Retorna um único lanche conforme a variavel id passado no argumento
            return _context.Lanches.FirstOrDefault(l => l.LancheId == lancgId)!;
        }
    }
}
