sap.ui.define([
	"sap/ui/test/opaQunit",
	"./pages/DetalhesEmpresa"
], (opaTest) => {
	"use strict";

	QUnit.module("Detalhes Empresa", () => {
		opaTest("Deve ir para tela de detalhes", function (Given, When, Then) {
			Given.euInicioMinhaApp({
			});

            When.detalhesEmpresa.deveIrParaATelaDeDetalhes();

            Then.detalhesEmpresa.deveVerificarSeFoiParaPagindaDeDetalhes();
		});

        opaTest("Deve verificar se o Razão Social da Empresa está correta", function (Given, When, Then){

            Then.detalhesEmpresa.verificarSeARazaoSocialEstaCorreta();
        })

        opaTest("Deve verificar se o CNPJ está correto", function (Given, When, Then){

            Then.detalhesEmpresa.verificarSeCnpjEstaCorreta();
        })

        opaTest("Deve verificar se o Ramo está correto", function(Given, When, Then){

            Then.detalhesEmpresa.verificarSeORamoEstaCorreto();
        })

        opaTest("Deve verificar rota do botão de editar está correto", function(Given, When, Then){

            When.detalhesEmpresa.deveApertarNoBotaoDeEditar();

            Then.detalhesEmpresa.deveVerificarSeEstaNaPaginaDeEditar();
        })

        opaTest("Deve voltar para a página de listagem", function(Given, When, Then){

            When.detalhesEmpresa.deveVoltarParaTelaDeListagemEmpresa();

            Then.detalhesEmpresa.deveConfirmarQueEstaNaTelaDeListagem();

            Then.iTeardownMyApp();
        })
	});
});