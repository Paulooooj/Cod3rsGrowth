﻿using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Servicos;
using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Repositorio;
using Cod3rsGrowth.Servico.Servicos;
using Cod3rsGrowth.Servico.Validacao;
using FluentValidation;
using LinqToDB;
using LinqToDB.AspNet;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Forms.Injecao
{
    public static class ModuloInjecaoServicos
    {
        public static void ModuloInjecaoServico(this IServiceCollection servico)
        {
            const string nomeVariavelAmbiente = "ConnectionString";
            var stringConexao = Environment.GetEnvironmentVariable(nomeVariavelAmbiente)
                ?? throw new Exception($"Variavel de ambiente [{nomeVariavelAmbiente}] nao encontrada");

            servico
               .AddLinqToDBContext<DbCod3rsGrowth>((provider, options) => options
               .UseSqlServer(stringConexao));

            servico.AddScoped<ServicoEmpresa>();
            servico.AddScoped<ServicoProduto>();
            servico.AddScoped<IValidator<Empresa>, EmpresaValidacao>();
            servico.AddScoped<IValidator<Produto>, ProdutoValidacao>();
            servico.AddScoped<IRepositorioEmpresa, RepositorioEmpresa>();
            servico.AddScoped<IRepositorioProduto, RepositorioProduto>();
            servico.AddScoped<FormListaEmpresa>();
        }
    }
}
