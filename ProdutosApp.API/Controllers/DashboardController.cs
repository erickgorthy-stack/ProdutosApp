using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosApp.API.Repositories;

namespace ProdutosApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        [HttpGet("categoria-quatidade")]
        public IActionResult GetCategoriaQuantidade()
        {
            var produtoRepository = new ProdutoRepository();
            var result = produtoRepository.AgruparCategoriaPorQuantidade();
            return Ok(result);
        }
        [HttpGet("categoria-preco")]
        public IActionResult GetCategoriaPreco()
        {
            var produtoRepository = new ProdutoRepository();
            var result = produtoRepository.AgruparCategoriaPorPreco();
            return Ok(result);
        }
    }
}
