using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces
{
    public interface IRestauranteRepository : IRepository<Restaurante>
    {
        List<Restaurante> GetByNome(string nome);
    }
}
