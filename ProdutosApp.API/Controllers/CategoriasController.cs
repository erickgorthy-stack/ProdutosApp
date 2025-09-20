using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosApp.API.Repositories;

namespace ProdutosApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        [HttpGet] 
        public IActionResult GetAll()
        {
            //instanciando a classe do repositório
            var categoriaRepository = new CategoriaRepository();

            //executando a consulta e armazenar em uma variável (lista)
            var categorias = categoriaRepository.ObterTodos();

            //retornando os dados
            return Ok(categorias);
        }
    }
}
