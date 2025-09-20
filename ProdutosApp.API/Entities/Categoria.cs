using System.Text.Json.Serialization;

namespace ProdutosApp.API.Entities
{
    public class Categoria
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = string.Empty;

        #region Relacionamentos

        [JsonIgnore]
        public List<Produto>? Produtos { get; set; }

        #endregion
    }
}
