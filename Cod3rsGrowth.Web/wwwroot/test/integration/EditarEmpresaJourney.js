sap.ui.define([
	"sap/ui/test/opaQunit",
	"./pages/AdicionarEditarEmpresa"
], (opaTest) => {
	"use strict";

	QUnit.module("Editar Empresa", () => {
		opaTest("Deve ir para página de Detalhes e verifica se está nela", function (Given, When, Then) {
			Given.euInicioMinhaApp({
            
			});
            
            When.adicionarEmpresa.irParaTelaDetalhaes();

			Then.adicionarEmpresa.verificarSeFoiParaTelaDetalhes();
		});

        opaTest("Deve ir para a página de editar", function (Given, When, Then){

            When.adicionarEmpresa.deveIrParaTelaDeEditar();

            Then.adicionarEmpresa.deveVerificarSeFoiParaTelaDeEditar();
        });

        opaTest("Deve verificar se o valor da Razão Social está correta", function (Given, When, Then){
            
            Then.adicionarEmpresa.deveVerficarSeRazaoSocialEstaCorreta();
        })

        opaTest("Deve verificar se o valor do CNPJ está correto", function (Given, When, Then){

            Then.adicionarEmpresa.deveVerificarSeCnpjEstaCorreto();
        })

        opaTest("Deve verifiar se o valor na select está correto", function (Given, When, Then){

            Then.adicionarEmpresa.deveVerificarSeValorSelectEstaCorreto();
        })

		opaTest("Deve verificar se o botão de ok da message box de cancelar volta para a tela de empresa", function (Given, When, Then) {
	
			When.adicionarEmpresa.deverClicarNoBotaoDeOk();

			Then.adicionarEmpresa.verificarSeFoiParaPaginaListagemEmpresa("empresa.Empresa");

			
		});

		opaTest("Deve voltar para a tela de Editar apos usar o botão de cancelar", function (Given, When, Then) {

			When.adicionarEmpresa.irParaTelaDetalhaes();

            When.adicionarEmpresa.deveIrParaTelaDeEditar();

            Then.adicionarEmpresa.deveVerificarSeFoiParaTelaDeEditar();

		});

		opaTest("Deve apertar o botão de salvar sem nada nos input e verificar as mensagens de erro", function(Given, When, Then) {
           
            When.adicionarEmpresa.preencherInputs("idInputRazaoSocial", "");

			When.adicionarEmpresa.preencherInputs("idInputCNPJ", "");

			When.adicionarEmpresa.selecionarNaCombobox(0);

			When.adicionarEmpresa.apertarNoBotaoSalvar();

			Then.adicionarEmpresa.verificarMensagemDeErroIEValorDeStatusAoTentarSalvarSemNadaInputRazaoSocial();

			Then.adicionarEmpresa.verificarMensagemDeErroIEValorDeStatusAoTentarSalvarSemNadaInputCNPJ();

            Then.adicionarEmpresa.verificarMensagemDeErroIEValorDeStatusAoTentarSalvarSemNadaSelectRamo();

		});

		opaTest("Deve verificar se ao tentar preencher com Razão Social que já existe e cnpj inválido vai aparecer erro de validação", function(Given, When, Then) {

			When.adicionarEmpresa.preencherInputs("idInputRazaoSocial", "Apple");

			When.adicionarEmpresa.preencherInputs("idInputCNPJ", "12345678912345");

            When.adicionarEmpresa.selecionarNaCombobox(1);

			When.adicionarEmpresa.apertarNoBotaoSalvar();

			Then.adicionarEmpresa.apertarNoBotaoFecharMessagemErro();

		});

		opaTest("Deve verificar o ver detalhes na mensagem box de erro de validação", function(Given, When, Then){
			
			When.adicionarEmpresa.preencherInputs("idInputRazaoSocial", "Apple");

			When.adicionarEmpresa.preencherInputs("idInputCNPJ", "12345678912345");

			When.adicionarEmpresa.selecionarNaCombobox(1);

			When.adicionarEmpresa.apertarNoBotaoSalvar();

			When.adicionarEmpresa.clicarNoVerDetalhesMessageBox()
		})

		opaTest("Deve fechar a message box de erro", function(Given, When, Then){
			Then.adicionarEmpresa.apertarNoBotaoFecharMessagemErro();
		})
		
		opaTest("Deve verificar se item foi editado corretamente", function(Given, When, Then) {
            
            When.adicionarEmpresa.preencherInputs("idInputRazaoSocial", "Buriti Shopping");

			When.adicionarEmpresa.preencherInputs("idInputCNPJ", "26489114000130");

            When.adicionarEmpresa.selecionarNaCombobox(2);
            
			When.adicionarEmpresa.apertarNoBotaoSalvar();

			When.adicionarEmpresa.confirmarNoOkAposSalvar();

            Then.adicionarEmpresa.verificarSeOKVoltouParaTelaListagem();

			Then.iTeardownMyApp();

		})
	});
});