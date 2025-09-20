using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosApp.API.Dto_s;
using ProdutosApp.API.Entities;
using ProdutosApp.API.Repositories;

namespace ProdutosApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] ProdutoRequestDto request)
        {
            //criando um objeto da classe produto para capturar os dados do dto
            var produto = new Produto()
            {
                Nome = request.Nome, //capturando o nome do produto
                Preco = request.Preco.Value, //capturando o preço
                Quantidade = request.Quantidade.Value, //capturando a quantidade
                CategoriaId = request.CategoriaId.Value, //capturando o id categoria
            };

            //salvar o produto no banco de dados
            var produtoRepository = new ProdutoRepository();
            produtoRepository.Adicionar(produto);

            //Retornando sucesso
            return StatusCode(201, new
            {
                Mensagem = "Produto cadastrado com sucesso.", //Menssagem de sucesso
                id = produto.Id, // Id do produto Cadastrado
                data = request //Dados guardados no Banco
            });

        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] ProdutoRequestDto request)
        {
            //Instanciando o repositório
            var produtorepository = new ProdutoRepository();
            
            //Buscando o produto no banco de dados através do ID
            var produto = produtorepository.ObterPorId(id);
            
            //Verificando se o produto foi encontrado
            if(produto != null)
            {
                //Modificar os dados do produto
                produto.Nome = request.Nome;
                produto.Preco = request.Preco.Value;
                produto.Quantidade = request.Quantidade.Value;
                produto.CategoriaId = request.CategoriaId.Value;
                
                //Enviando o produto para ser atualizado no banco de dados
                produtorepository.Atualizar(produto);

                //Retornando sucesso
                return StatusCode(200, new
                {
                    Mensagem = "Produto atualizado com sucesso.", //Menssagem de sucesso
                    id = produto.Id, // Id do produto atualizado com sucesso
                    data = request //Dados guardados no Banco
                });
            }
            else
            {
                //Retornar um erro 404 (NOT FOUND)
                return StatusCode(404, new { mensagem = 
                    "Produto não encontrado. Verifique o ID informado." });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            //Criando um objeto da classe repositório
            var produtoRepository = new ProdutoRepository();

            //buscar o produto no banco de dados através do ID
            var produto = produtoRepository.ObterPorId(id);

            //Verificar se o produto foi encontrado
            if(produto != null)
            {
                //enviando para inativar no banco de dados
                produtoRepository.Inativar(id);

                //Retornando sucesso
                return StatusCode(200, new
                {
                    mensagem = "Produto excluído com sucesso.", //mensagem de sucesso
                    id = produto.Id, //id do produto atualizado
                });
            }
            else
            {
                //Retornar um erro 404 (NOT FOUND)
                return StatusCode(404, new
                {mensagem =
                    "Produto não encontrado. Verifique o ID informado."
                });
                
            }

                
        }

        [HttpGet]
        public IActionResult GetByName([FromQuery]string nome)
        {
            //Criando um objeto da classe de repositório
            var produtoRepository = new ProdutoRepository();

            //Consultar os produtos no banco de dados através do nome
            var produtos = produtoRepository.ListarPorNome(nome);

            //Retornar o resultado
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            //Criando um objeto da classe de repositório
            var produtoRepository = new ProdutoRepository();

            //Consultar 1 produto no banco de dados através do ID
            var produto = produtoRepository.ObterPorId(id);

            //Retornar o resultado
            return Ok(produto);
        }
    }
}
