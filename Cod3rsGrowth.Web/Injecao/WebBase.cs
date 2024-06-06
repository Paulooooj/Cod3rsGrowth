namespace Cod3rsGrowth.Web.Injecao
{
    public class WebBase : IDisposable
    {
        protected ServiceProvider ServiceProvider;

        public WebBase()
        {
            var servicos = new ServiceCollection();
            ModuloDeInjecao.AdicionarDependenciasNoEscopo(servicos);
            ServiceProvider = servicos.BuildServiceProvider();
        }

        public void Dispose()
        {
            ServiceProvider.Dispose();
        }
    }
}
