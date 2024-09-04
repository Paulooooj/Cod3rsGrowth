sap.ui.define([
	"sap/ui/test/opaQunit",
	"./pages/DetalhesEmpresa"
], (opaTest) => {
	"use strict";

	QUnit.module("Remover Empresa", () => {
		opaTest("Deve selecionar Yooso na tabela e ir para tela de listagem", function (Given, When, Then) {
			Given.euInicioMinhaApp({
			});

            When.detalhesEmpresa.deveApertaNaPaginacao();

            When.detalhesEmpresa.deveIrParaATelaDeDetalhes("Yooso");

            Then.detalhesEmpresa.deveVerificarSeFoiParaPaginaDeDetalhes();
		});
     
        opaTest("Deve clicar em remover depois em cancel da mensagem box de confirmação", function(Given, When, Then){

            When.detalhesEmpresa.deveApertarNoBotaoDeSalvar();

            When.detalhesEmpresa.deveApertarNoBotaoMensagemBox("Cancelar");

            Then.detalhesEmpresa.deveVerificarSeFoiParaPaginaDeDetalhes();

        })

        opaTest("Deve apagar o item a empresa Yooso da lista", function(Given, When, Then){

            When.detalhesEmpresa.deveApertarNoBotaoDeSalvar();

            When.detalhesEmpresa.deveApertarNoBotaoMensagemBox("OK");

            When.detalhesEmpresa.deveApertarNoBotaoMensagemBox("OK");

            Then.detalhesEmpresa.conferirSeEmpresaFoiAdicionada();

            Then.iTeardownMyApp();
        })

	});
});