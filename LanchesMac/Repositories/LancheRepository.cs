using LanchesMac.Context;
using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace LanchesMac.Repositories
{
    public class LancheRepository : ILancheRepository
    {
        private readonly AppDbContext _context;
        public LancheRepository(AppDbContext contexto)
        {
            _context = contexto;     
        }
        public IEnumerable<Lanche> Lanches => _context.Lanches.Include(c => c.Categoria);

        public IEnumerable<Lanche> LanchesPreferidos => _context.Lanches.
                                           Where(l => l.IsLanchePreferido).
                                           Include(c => c.Categoria);

        public Lanche GetLancheById(int lancgId)
        {
            return _context.Lanches.FirstOrDefault(l => l.LancheId == lancgId)!;
        }
    }
}
