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

		Then.EmpresaPage.verificarSeTabelaFiltrouUmItem();
	});

	opaTest("Deve selecionar Serviço na combobox", function(Given, When, Then) {

		When.EmpresaPage.selecionarCombobox();

		Then.EmpresaPage.verificarItemSelecionadoCombobox();
	});

	opaTest("Deve filtrar por Indústria e verificar a quantidade filtrada somando com o filtro de barra de pesquisa.", function(Given, When, Then) {

		When.EmpresaPage.filtrarPorIndustria();

		Then.EmpresaPage.verificarQuantidadeEmpresasFiltradas();

		Then.iTeardownMyApp();
	});
});