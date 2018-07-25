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
    [Route("api/restaurantes")]
    public class RestaurantesController : Controller
    {
        private readonly IRestauranteRepository _restaurante;

        public RestaurantesController(IRestauranteRepository restauranteRepository)
        {
            _restaurante = restauranteRepository;
        }

        [HttpGet]
        public IActionResult Get(string search)
        {
            List<Restaurante> restaurantes = null;
            if (!string.IsNullOrEmpty(search))
            {
                restaurantes = _restaurante.GetByNome(search);
                if (restaurantes == null)
                {
                    return new NotFoundObjectResult(new { mensagem = String.Format("Nenhum restaurante encontrado com o termo '{0}'", search) });
                }
                else
                {
                    return new OkObjectResult(restaurantes);
                }
            }
            else
            {
                restaurantes = _restaurante.ListAll().ToList();
            }
            return new OkObjectResult(restaurantes);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var restaurante = _restaurante.GetById(id);
            if(restaurante == null)
            {
                return new NotFoundObjectResult(new { mensagem = "Restaurante não encontrado" });
            }
            else
            {
                return new OkObjectResult(restaurante);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Restaurante restaurante)
        {
            try
            {
                var retorno = _restaurante.Add(restaurante);
                return new CreatedAtRouteResult("Restaurante criado com sucesso",retorno);
            }
            catch(Exception e)
            {
                return new BadRequestObjectResult(new {mensagem = e.Message});
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Restaurante restaurante)
        {
            try
            {
                restaurante.Id = id;
                _restaurante.Update(restaurante);
                return new OkObjectResult(restaurante);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(new { mensagem = e.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var restaurante = _restaurante.GetById(id);
                if(restaurante == null)
                {
                    return new NotFoundObjectResult(new { mensagem = "Restaurante não encontrado" });
                }
                else
                {
                    _restaurante.Delete(restaurante);
                    return new OkObjectResult(new {mensagem = "Restaurante deletado com sucesso"});
                }
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(new { mensagem = e.Message});
            }
        }
    }
}