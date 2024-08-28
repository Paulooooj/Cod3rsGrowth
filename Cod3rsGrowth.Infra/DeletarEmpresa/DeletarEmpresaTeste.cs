using LinqToDB;

namespace Cod3rsGrowth.Infra.DeletarEmpresa
{
    public class DeletarEmpresaTeste
    {
        public static void DeletarEmpresaUsadaNosTestes(DbCod3rsGrowth _db)
        {
            const string empresaQueDeveSerDeletada = "Yooso";
            _db.Empresas
                .Delete(x => x.RazaoSocial == empresaQueDeveSerDeletada);
        }
    }
}