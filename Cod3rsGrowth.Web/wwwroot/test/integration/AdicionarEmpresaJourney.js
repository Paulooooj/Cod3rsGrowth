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
	
			Then.adicionarEmpresa.deveVerificarSeEstaNaPaginaDeAdicionarEditar();
		});

		opaTest("Deve verificar se o botão de ok da message box de cancelar volta para a tela de empresa", function (Given, When, Then) {
	
			When.adicionarEmpresa.deverClicarNoBotaoDeOk();

			Then.adicionarEmpresa.verificarSeFoiParaPaginaListagemEmpresa("empresa.Empresa");

			
		});

		opaTest("Deve voltar para a tela de adicionarr", function (Given, When, Then) {

			When.adicionarEmpresa.voltarParaAPaginaDeAdicionar("idBotaoAdicionar", "empresa.Empresa")

		});

		opaTest("Deve apertar o botão de salvar sem nada nos input e verificar as mensagens de erro", function(Given, When, Then) {

			When.adicionarEmpresa.apertarNoBotaoSalvar();

			Then.adicionarEmpresa.verificarMensagemDeErroIEValorDeStatusAoTentarSalvarSemNadaInputRazaoSocial();

			Then.adicionarEmpresa.verificarMensagemDeErroIEValorDeStatusAoTentarSalvarSemNadaInputCNPJ();

			Then.adicionarEmpresa.verificarMensagemDeErroIEValorDeStatusAoTentarSalvarSemNadaSelectRamo();

		});

		opaTest("Deve verificar se ao tentar preencher com Razão Social que já existe e cnpj inválido vai aparecer erro de validação", function(Given, When, Then) {

			When.adicionarEmpresa.preencherInputs("idInputRazaoSocial", "Apple");

			When.adicionarEmpresa.preencherInputs("idInputCNPJ", "12345678912345");

			When.adicionarEmpresa.selecionarNaCombobox(2);

			When.adicionarEmpresa.apertarNoBotaoSalvar();

			Then.adicionarEmpresa.apertarNoBotaoFecharMessagemErro();

		});

		opaTest("Deve verificar o ver detalhes na mensagem box de erro de validação", function(Given, When, Then){
			
			When.adicionarEmpresa.preencherInputs("idInputRazaoSocial", "Apple");

			When.adicionarEmpresa.preencherInputs("idInputCNPJ", "12345678912345");

			When.adicionarEmpresa.selecionarNaCombobox(2);

			When.adicionarEmpresa.apertarNoBotaoSalvar();

			When.adicionarEmpresa.clicarNoVerDetalhesMessageBox()
		})

		opaTest("Deve fechar a message box de erro", function(Given, When, Then){
			Then.adicionarEmpresa.apertarNoBotaoFecharMessagemErro();
		})
		
		opaTest("Deve verificar se ao apertar no botão de salvar, vai ser salvo a empresa no banco de dados", function(Given, When, Then) {
			
			When.adicionarEmpresa.preencherInputs("idInputRazaoSocial", "Yooso");

			When.adicionarEmpresa.preencherInputs("idInputCNPJ", "88246684000157");

			When.adicionarEmpresa.selecionarNaCombobox(2);

			When.adicionarEmpresa.apertarNoBotaoSalvar();

			When.adicionarEmpresa.confirmarNoOkAposSalvar();

			Then.adicionarEmpresa.conferirQuantidadeEmpresasTabela();

			Then.iTeardownMyApp();

		})
	});
});