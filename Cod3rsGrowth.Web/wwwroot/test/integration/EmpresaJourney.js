sap.ui.define([
	"sap/ui/test/opaQunit",
	"./pages/Empresa"
], (opaTest) => {
	"use strict";

	QUnit.module("Lista Empresa");

	opaTest("Deve ser capaz de verificar se a tabela tem paginação", function (Given, When, Then) {
		Given.iStartMyUIComponent({
			componentConfig: {
				name: "ui5.cod3rsgrowth"
			}
		});

		Then.EmpresaPage.verificarSeTemPaginacaoNaTabela();
	});

	opaTest("Deve verificar se a quantidade de Empresas mostradas no título está correta", function (Given, When, Then){
		Then.EmpresaPage.oDisplayDeveTerOTantoDeItems();
	});

	opaTest("Deve ser capaz de pesquisar por um item especifico usando a barra de pesquisa", function (Given, When, Then) {
		
		When.EmpresaPage.bucarPor("Apple");

		Then.EmpresaPage.verificarSeTabelaFiltrouUsandoBarraDePesquisa();
	});

	opaTest("Deve verificar se é possível selecionar um Ramo", function(Given, When, Then) {

		When.EmpresaPage.selecionarCombobox();

		Then.EmpresaPage.verificarItemSelecionadoCombobox();
	});

	opaTest("Deve filtrar junto com o filtro anterior da barra de pesquisa, filtrar pelo select escolhendo Indústria e encontrar só uma empresa", function(Given, When, Then) {

		When.EmpresaPage.filtrarPorRamo("Indústria");

		Then.EmpresaPage.verificarQuantidadeEmpresasFiltradas();

	});

	opaTest("Deve verificar se está filtrando corretamente o select de ramo, filtrando por Comércio", function(Given, When, Then) {

		When.EmpresaPage.bucarPor(" ");

		When.EmpresaPage.filtrarPorRamo("Comércio");

		Then.EmpresaPage.verificarQuantidadeEmpresasFiltradasSomentePorComercio();

		Then.iTeardownMyApp();
	});

});