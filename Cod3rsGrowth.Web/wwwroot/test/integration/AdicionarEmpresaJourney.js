sap.ui.define([
	"sap/ui/test/opaQunit",
	"./pages/AdicionarEditarEmpresa"
], (opaTest) => {
	"use strict";

	QUnit.module("Adicionar Empresa", () => {
		opaTest("Deve verificar se está na página de adicionar empresa", function (Given, When, Then) {
			Given.euInicioMinhaApp({
				hash: "AdicionarEmpresa"
			});
	
			Then.adicionarEditarEmpresa.deveVerificarSeEstaNaPaginaDeAdicionarEditar();
		});

		opaTest("Deve verificar se o botão de ok da message box de cancelar volta para a tela de empresa", function (Given, When, Then) {
	
			When.adicionarEditarEmpresa.deverClicarNoBotaoDeOk();

			Then.adicionarEditarEmpresa.verificarSeFoiParaPaginaListagemEmpresa("empresa.Empresa");

			
		});

		opaTest("Deve voltar para a tela de adicionarr", function (Given, When, Then) {

			When.adicionarEditarEmpresa.voltarParaAPaginaDeAdicionar("idBotaoAdicionar", "empresa.Empresa")

		});

		opaTest("Deve apertar o botão de salvar sem nada nos input e verificar as mensagens de erro", function(Given, When, Then) {

			When.adicionarEditarEmpresa.apertarNoBotaoSalvar();

			Then.adicionarEditarEmpresa.verificarMensagemDeErroIEValorDeStatusAoTentarSalvarSemNadaInputRazaoSocial();

			Then.adicionarEditarEmpresa.verificarMensagemDeErroIEValorDeStatusAoTentarSalvarSemNadaInputCNPJ();

			Then.adicionarEditarEmpresa.verificarMensagemDeErroIEValorDeStatusAoTentarSalvarSemNadaSelectRamo();

		});

		opaTest("Deve verificar se ao tentar preencher com Razão Social que já existe e cnpj inválido vai aparecer erro de validação", function(Given, When, Then) {

			When.adicionarEditarEmpresa.preencherInputs("idInputRazaoSocial", "Apple");

			When.adicionarEditarEmpresa.preencherInputs("idInputCNPJ", "12345678912345");

			When.adicionarEditarEmpresa.selecionarNaCombobox(2);

			When.adicionarEditarEmpresa.apertarNoBotaoSalvar();

			Then.adicionarEditarEmpresa.apertarNoBotaoFecharMessagemErro();

		});

		opaTest("Deve verificar o ver detalhes na mensagem box de erro de validação", function(Given, When, Then){
			
			When.adicionarEditarEmpresa.preencherInputs("idInputRazaoSocial", "Apple");

			When.adicionarEditarEmpresa.preencherInputs("idInputCNPJ", "12345678912345");

			When.adicionarEditarEmpresa.selecionarNaCombobox(2);

			When.adicionarEditarEmpresa.apertarNoBotaoSalvar();

			When.adicionarEditarEmpresa.clicarNoVerDetalhesMessageBox()
		})

		opaTest("Deve fechar a message box de erro", function(Given, When, Then){
			Then.adicionarEditarEmpresa.apertarNoBotaoFecharMessagemErro();
		})
		
		opaTest("Deve verificar se ao apertar no botão de salvar, vai ser salvo a empresa no banco de dados", function(Given, When, Then) {
			
			When.adicionarEditarEmpresa.preencherInputs("idInputRazaoSocial", "Yooso");

			When.adicionarEditarEmpresa.preencherInputs("idInputCNPJ", "88246684000157");

			When.adicionarEditarEmpresa.selecionarNaCombobox(2);

			When.adicionarEditarEmpresa.apertarNoBotaoSalvar();

			When.adicionarEditarEmpresa.confirmarNoOkAposSalvar();

			Then.adicionarEditarEmpresa.conferirQuantidadeEmpresasTabela();

			Then.iTeardownMyApp();

		})
	});
});