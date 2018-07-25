using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Data
{
    public class PratoRepository : EfRepository<Prato>, IPratoRepository
    {
        public PratoRepository(TesteContext dbContext) : base(dbContext)
        {
        }

        public List<Prato> GetAllWithRestaurante()
        {
           return _dbContext.Pratos.Include(x => x.Restaurante).ToList();
        }

        public Prato GetWithRestaurante(int Id)
        {
            return _dbContext.Pratos.Where(x => x.Id.Equals(Id)).Include(x => x.Restaurante).FirstOrDefault();
        }
    }
}