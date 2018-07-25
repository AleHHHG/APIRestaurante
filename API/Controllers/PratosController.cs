using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Interfaces;
using ApplicationCore.Entities;
namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/pratos")]
    public class PratosController : Controller
    {
        private readonly IPratoRepository _prato;
        private readonly IRestauranteRepository _restaurante;

        public PratosController(IPratoRepository pratoRepository, IRestauranteRepository restauranteRepository)
        {
            _prato = pratoRepository;
            _restaurante = restauranteRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var pratos = _prato.GetAllWithRestaurante();
            return new OkObjectResult(pratos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var prato = _prato.GetWithRestaurante(id);
            if (prato == null)
            {
                return new NotFoundObjectResult(new { mensagem = "Prato não encontrado" });
            }
            else
            {
                return new OkObjectResult(prato);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Prato prato)
        {
            try
            {
                if (_restaurante.GetById(prato.RestauranteId) == null)
                {
                    return new NotFoundObjectResult(new { mensagem = "Restaurante não encontrado" });
                }
                var retorno = _prato.Add(prato);
                return new CreatedAtRouteResult("Prato criado com sucesso",retorno );
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(new { mensagem = e.Message });
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Prato prato)
        {
            try
            {
                prato.Id = id;
                _prato.Update(prato);
                return new OkObjectResult(prato);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(new { mensagem = e.Message });
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var prato = _prato.GetById(id);
                if (prato == null)
                {
                    return new NotFoundObjectResult(new { mensagem = "Prato não encontrado" });
                }
                else
                {
                    _prato.Delete(prato);
                    return new OkObjectResult(new { mensagem = "Prato deletado com sucesso" });
                }
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(new { mensagem = e.Message });
            }
        }
    }
}