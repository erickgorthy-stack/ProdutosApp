using Microsoft.EntityFrameworkCore;
using ProdutosApp.API.Contexts;
using ProdutosApp.API.Entities;

namespace ProdutosApp.API.Repositories
{
    public class ProdutoRepository
    {
        public void Adicionar(Produto produto)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Add(produto);
                dataContext.SaveChanges();
            }
        }
        public void Atualizar(Produto produto)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Update(produto);
                dataContext.SaveChanges();
            }
        }
        public void Inativar(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                var produto = dataContext.Set<Produto>().Find(id);

                if (produto == null)

                    throw new ApplicationException("Produtos não encontrado.");

                produto.Ativo = false;

                dataContext.SaveChanges();
            }
        }
        public List<Produto> ListarPorNome ( string nome)
        {
            using(var dataContext = new DataContext())
            {
                return dataContext
                    .Set<Produto>()
                    .Include(p => p.Categoria) // LEFT JOIN
                    .Where(p => p.Nome.Contains(nome))
                    .OrderBy(p => p.Nome)
                    .ToList();
            }
        }
        public Produto? ObterPorId(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<Produto>()
                    .Include(p => p.Categoria)
                    .Where(p => p.Id == id && true)
                    .FirstOrDefault();
            }
        }
    }
}
