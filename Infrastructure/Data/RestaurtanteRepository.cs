using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Data
{
    public class RestauranteRepository : EfRepository<Restaurante>, IRestauranteRepository
    {
        public RestauranteRepository(TesteContext dbContext) : base(dbContext)
        {
        }

        public List<Restaurante> GetByNome(string nome)
        {
            return _dbContext.Restaurantes.Where(x => x.Nome.Contains(nome)).ToList();
        }
    }
}