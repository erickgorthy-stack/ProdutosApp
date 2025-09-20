using ProdutosApp.API.Contexts;
using ProdutosApp.API.Entities;

namespace ProdutosApp.API.Repositories
{
    public class CategoriaRepository
    {
        public List<Categoria> ObterTodos()
        {
            //abrindo conexão com o banco de dados
            using (var dataContext = new DataContext())
            {
                return dataContext
                        .Set<Categoria>() //tabela de categorias
                        .OrderBy(c => c.Nome) //ordem alfabética
                        .ToList(); //retornar uma lista
            }
        }
    }
}
