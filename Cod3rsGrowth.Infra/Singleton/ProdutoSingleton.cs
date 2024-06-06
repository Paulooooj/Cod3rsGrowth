using Cod3rsGrowth.Dominio.Entidades;
using System.Collections.Generic;

namespace Cod3rsGrowth.Infra.Singleton
{
    public sealed class ProdutoSingleton : List<Produto>
    {
        private ProdutoSingleton()
        {
        }

        private static ProdutoSingleton? _instancia;
        public static ProdutoSingleton Instancia
        {
            get
            {
                lock (typeof(ProdutoSingleton))
                    if (_instancia == null) _instancia = new ProdutoSingleton();
                return _instancia;
            }
        }
    }
}
