namespace ProdutosApp.API.Entities
{
    public class Produto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = string.Empty;
        public double Preco { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public bool Ativo { get; set; } = true;
        public Guid CategoriaId { get; set; }

        #region Relacionamentos

        public Categoria? Categoria { get; set; }

        #endregion
    }
}
