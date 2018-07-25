using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class Prato : BaseEntity
    {
        public int RestauranteId { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public Restaurante Restaurante { get; set; }
    }
}
