using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Infra.Singleton
{
    public sealed class EmpresaSingleton : List<Empresa>
    {
        private EmpresaSingleton()
        {
        }

        private static EmpresaSingleton? _instancia;
        public static EmpresaSingleton Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    lock (typeof(EmpresaSingleton))
                        if (_instancia == null) _instancia = new EmpresaSingleton();
                }
                return _instancia;
            }
        }
    }
}