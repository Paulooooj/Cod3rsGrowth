﻿using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Servicos;
using FluentValidation;
using Microsoft.IdentityModel.Tokens;

namespace Cod3rsGrowth.Forms
{
    public partial class CadastroEmpresa : Form
    {
        private readonly ServicoEmpresa _servicoEmpresa;
        private readonly Empresa? _empresa;

        public CadastroEmpresa(ServicoEmpresa servicoEmpresa, Empresa? empresa = null)
        {
            InitializeComponent();
            _servicoEmpresa = servicoEmpresa;
            _empresa = empresa;
            MostrarInformacoesAoAtualizar();
            const int valorRamo = 0;
            ramoDaEmpresa.SelectedIndex = valorRamo;
        }

        private void MostrarInformacoesAoAtualizar()
        {
            if (_empresa != null)
            {
                razaoSocialCadastroEmpresa.Text = _empresa.RazaoSocial;
                cnpjEmpresa.Text = _empresa.CNPJ;
                ramoDaEmpresa.SelectedIndex = (int)_empresa.Ramo;
            }
        }

        private void AoClicarDeveCancelarAdicionar(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AoClicarDeveSalvar(object sender, EventArgs e)
        {
            var validacaoDeTela = ValidacaoDeTela();

            if (validacaoDeTela)
            {
                try
                {
                    cnpjEmpresa.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    var empresa = new Empresa
                    {
                        RazaoSocial = razaoSocialCadastroEmpresa.Text,
                        CNPJ = cnpjEmpresa.Text,
                        Ramo = (EnumRamoDaEmpresa)ramoDaEmpresa.SelectedIndex
                    };

                    SalvarDados(empresa);
                    this.Close();
                }
                catch (ValidationException validationException)
                {
                    var listaDeErros = validationException.Errors.ToList();
                    var mensagemErro = "";

                    listaDeErros.ForEach(erro => mensagemErro += erro.ToString() + "\n");
                    const string tituloDoErro = "Erro de validação";

                    MostrarMensagemErro(tituloDoErro, mensagemErro);
                }
                catch (Exception exception)
                {
                    const string tituloDoErro = "Erro inesperado";
                    MostrarMensagemErro(tituloDoErro, exception.Message);
                }
            }

        }

        private void SalvarDados(Empresa empresa)
        {
            if (_empresa != null)
            {
                empresa.Id = _empresa.Id;
                _servicoEmpresa.Atualizar(empresa);
                return;
            }
            _servicoEmpresa.Adicionar(empresa);
        }

        private static void MostrarMensagemErro(string tituloErro, string mensagemErro)
        {
            MessageBox.Show(mensagemErro, tituloErro, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool ValidacaoDeTela()
        {
            const int valorRamo = 0;
            const string tituloErro = "Erro";
            var mensagemErro = "";

            if (razaoSocialCadastroEmpresa.Text.IsNullOrEmpty())
            {
                mensagemErro += "Razão Social não informada!\n";
            }

            cnpjEmpresa.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            if (cnpjEmpresa.Text.IsNullOrEmpty())
            {
                mensagemErro += "CNPJ não informado!\n";
            }

            if (ramoDaEmpresa.SelectedIndex == valorRamo)
            {
                mensagemErro += "Ramo da Empresa não informado!";
            }

            if (mensagemErro.IsNullOrEmpty())
                return true;
            MostrarMensagemErro(tituloErro, mensagemErro);
            return false;
        }
    }
}