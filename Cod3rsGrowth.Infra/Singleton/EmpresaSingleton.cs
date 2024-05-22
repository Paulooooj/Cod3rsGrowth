using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Infra.Singleton
{
    public sealed class EmpresaSingleton : List<Empresa>
    {
        private EmpresaSingleton()
        {
        }

        private static EmpresaSingleton? _instancia;
        private static object ObjetoLock = new object();

        public static EmpresaSingleton Instancia
        {
            get
            {
                lock (ObjetoLock)
                {
                    if (_instancia == null) _instancia = new EmpresaSingleton();
                    return _instancia;
                }
            }
        }
    }
}