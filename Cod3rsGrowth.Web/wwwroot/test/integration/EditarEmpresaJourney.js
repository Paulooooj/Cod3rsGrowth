sap.ui.define([
	"sap/ui/test/opaQunit",
	"./pages/AdicionarEditarEmpresa"
], (opaTest) => {
	"use strict";

	QUnit.module("Editar Empresa", () => {
		opaTest("Deve ir para página de Detalhes e verifica se está nela", function (Given, When, Then) {
			Given.euInicioMinhaApp({
            
			});
            When
				.adicionarEditarEmpresa
				.irParaTelaDetalhaes();

			Then
				.adicionarEditarEmpresa
				.verificarSeFoiParaTelaDetalhes();
		});

        opaTest("Deve ir para a página de editar", function (Given, When, Then){
            When
				.adicionarEditarEmpresa
				.deveIrParaTelaDeEditar();

            Then
				.adicionarEditarEmpresa
				.deveVerificarSeFoiParaTelaDeEditar();
        });

        opaTest("Deve verificar se o valor da Razão Social está correta", function (Given, When, Then){
            Then
				.adicionarEditarEmpresa
				.deveVerficarSeRazaoSocialEstaCorreta();
        })

        opaTest("Deve verificar se o valor do CNPJ está correto", function (Given, When, Then){
            Then
				.adicionarEditarEmpresa
				.deveVerificarSeCnpjEstaCorreto();
        })

        opaTest("Deve verifiar se o valor na select está correto", function (Given, When, Then){
            Then
				.adicionarEditarEmpresa
				.deveVerificarSeValorSelectEstaCorreto();
        })

		opaTest("Deve verificar se o botão de ok da message box de cancelar volta para a tela de detalhes", function (Given, When, Then) {
			When
				.adicionarEditarEmpresa
				.deverClicarNoBotaoDeOk();

			Then
				.adicionarEditarEmpresa
				.verificarSeFoiParaPaginaListagemEmpresa("empresa.DetalhesEmpresa");
		});

		opaTest("Deve voltar para a tela de Editar apos usar o botão de cancelar", function (Given, When, Then) {

            When
				.adicionarEditarEmpresa
				.deveIrParaTelaDeEditar();

            Then
				.adicionarEditarEmpresa
				.deveVerificarSeFoiParaTelaDeEditar();
		});

		opaTest("Deve apertar o botão de salvar sem nada nos input e verificar as mensagens de erro", function(Given, When, Then) {
           
            When
				.adicionarEditarEmpresa
				.preencherInputs("idInputRazaoSocial", "");

			When
				.adicionarEditarEmpresa
				.preencherInputs("idInputCNPJ", "");

			When
				.adicionarEditarEmpresa
				.selecionarNaCombobox(0);

			When
				.adicionarEditarEmpresa
				.apertarNoBotaoSalvar();

			Then
				.adicionarEditarEmpresa
				.verificarMensagemDeErroIEValorDeStatusAoTentarSalvarSemNadaInputRazaoSocial();

			Then
				.adicionarEditarEmpresa.verificarMensagemDeErroIEValorDeStatusAoTentarSalvarSemNadaInputCNPJ();

            Then
				.adicionarEditarEmpresa
				.verificarMensagemDeErroIEValorDeStatusAoTentarSalvarSemNadaSelectRamo();
		});

		opaTest("Deve verificar se ao tentar preencher com Razão Social que já existe e cnpj inválido vai aparecer erro de validação", function(Given, When, Then) {
			When
				.adicionarEditarEmpresa
				.preencherInputs("idInputRazaoSocial", "Apple");

			When
				.adicionarEditarEmpresa
				.preencherInputs("idInputCNPJ", "12345678912345");

            When
				.adicionarEditarEmpresa
				.selecionarNaCombobox(1);

			When
				.adicionarEditarEmpresa.apertarNoBotaoSalvar();


			Then
				.adicionarEditarEmpresa
				.apertarNoBotaoFecharMessagemErro();
		});

		opaTest("Deve verificar o ver detalhes na mensagem box de erro de validação", function(Given, When, Then){
			When
				.adicionarEditarEmpresa
				.preencherInputs("idInputRazaoSocial", "Apple");

			When
				.adicionarEditarEmpresa
				.preencherInputs("idInputCNPJ", "12345678912345");

			When
				.adicionarEditarEmpresa
				.selecionarNaCombobox(1);

			When
				.adicionarEditarEmpresa
				.apertarNoBotaoSalvar();

			When.
				adicionarEditarEmpresa
				.clicarNoVerDetalhesMessageBox()
		})

		opaTest("Deve fechar a message box de erro", function(Given, When, Then){
			Then
				.adicionarEditarEmpresa
				.apertarNoBotaoFecharMessagemErro();
		})
		
		opaTest("Deve salvar o item e ir para tela de listagem", function(Given, When, Then) {
            When
				.adicionarEditarEmpresa
				.preencherInputs("idInputRazaoSocial", "Buriti Shopping");

			When
				.adicionarEditarEmpresa
				.preencherInputs("idInputCNPJ", "26489114000130");

            When
				.adicionarEditarEmpresa
				.selecionarNaCombobox(2);
            
			When
				.adicionarEditarEmpresa
				.apertarNoBotaoSalvar();

			When
				.adicionarEditarEmpresa
				.confirmarNoOkAposSalvar();

			When
				.adicionarEditarEmpresa
				.deveVoltarParaTelaDeListagem();

            Then
				.adicionarEditarEmpresa
				.verificarSeOKVoltouParaTelaListagem();

			Then.iTeardownMyApp();
		})
	});
});