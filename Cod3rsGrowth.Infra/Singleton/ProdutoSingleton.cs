using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Infra.Singleton
{
    public sealed class ProdutoSingleton : List<Produto>
    {
        private ProdutoSingleton()
        {
        }

        private static ProdutoSingleton _instancia;
        public List<Produto> ListaDeProdutos;
        private static object ObjetoLock = new object();

        public static ProdutoSingleton Instancia
        {
            get
            {
                lock (ObjetoLock)
                {
                    if (_instancia == null) _instancia = new ProdutoSingleton();
                    return _instancia;
                }
            }
        }
    }
}
