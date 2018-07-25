using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces
{
    public interface IPratoRepository : IRepository<Prato>
    {
        List<Prato> GetAllWithRestaurante();
        Prato GetWithRestaurante(int Id);
    }
}
