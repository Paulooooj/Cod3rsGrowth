﻿using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Filtros;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Singleton;

namespace Cod3rsGrowth.Testes
{
    public class EmpresaRepositorioMock : IRepositorioEmpresa
    {
        private readonly EmpresaSingleton _instanciaEmpresaSingleton;

        public EmpresaRepositorioMock()
        {
            _instanciaEmpresaSingleton = EmpresaSingleton.Instancia;
        }

        public void Adicionar(Empresa empresa)
        {
            _instanciaEmpresaSingleton.Add(empresa);
        }

        public void Atualizar(Empresa empresa)
        {
            var verificacaoSeTemID = _instanciaEmpresaSingleton.Find(x => x.Id == empresa.Id);
            var posicao = _instanciaEmpresaSingleton.IndexOf(verificacaoSeTemID);
            _instanciaEmpresaSingleton[posicao] = empresa;
        }

        public void Deletar(int id)
        {
            var objetoASerRemovido = _instanciaEmpresaSingleton.Find(x => x.Id == id)
                ?? throw new Exception($"Empresa com Id: {id} não encontrado");
            _instanciaEmpresaSingleton.Remove(objetoASerRemovido);
        }

        public Empresa ObterPorId(int id)
        {
            var empresa = _instanciaEmpresaSingleton.Find(x => x.Id == id)
                ?? throw new Exception($"Empresa com Id: {id} não encontrado");
            return empresa;
        }

        public List<Empresa> ObterTodos(FiltroEmpresa? filtro = null)
        {
            var listaEmpresa = _instanciaEmpresaSingleton.ToList();

            if (!string.IsNullOrEmpty(filtro?.RazaoSocial))
            {
                listaEmpresa = listaEmpresa.FindAll(x => x.RazaoSocial.StartsWith(filtro?.RazaoSocial, StringComparison.OrdinalIgnoreCase));
            }
            if (filtro?.Ramo != null)
            {
                listaEmpresa = listaEmpresa.FindAll(x => x.Ramo == filtro?.Ramo);
            }
            return listaEmpresa;
        }

        public bool verificarSeTemNomeRepetido(Empresa empresa)
        {
            var empresaNomeRepetido = _instanciaEmpresaSingleton.Find(x => x.RazaoSocial == empresa.RazaoSocial);

            if (empresaNomeRepetido != null)
            {
                if (empresaNomeRepetido.Id != empresa.Id)
                {
                    return false;
                }
            }
            return true;
        }
    }
}