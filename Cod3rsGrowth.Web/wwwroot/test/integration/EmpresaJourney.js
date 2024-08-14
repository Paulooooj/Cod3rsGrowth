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

	opaTest("Deve verificar se a quantidade de empresas mostradas no título está correta", function (Given, When, Then){
		Then.EmpresaPage.oDisplayDeveTerOTantoDeItems();
	});

	opaTest("Deve ao passar um nome inválido na barra de pesquisa e não encontrar nada", function(Given, When, Then){
		
		When.EmpresaPage.bucarPor("Empresa Teste");

		Then.EmpresaPage.aoPassarNomeInvalidoNaoDeveFiltrar();
	});

	opaTest("Deve verificar se é possível selecionar um ramo na select", function(Given, When, Then) {

		When.EmpresaPage.selecionarCombobox();

		Then.EmpresaPage.verificarItemSelecionadoCombobox();
	});

	opaTest("Deve ser capaz de pesquisar por um item especifico usando a barra de pesquisa", function (Given, When, Then) {

		When.EmpresaPage.filtrarPorRamo("NaoDefinido")

		When.EmpresaPage.bucarPor("Apple");

		Then.EmpresaPage.verificarSeTabelaFiltrouUsandoBarraDePesquisa();
	});

	opaTest("Deve filtrar junto com o filtro anterior da barra de pesquisa, filtrar pelo select escolhendo Indústria e encontrar só uma empresa", function(Given, When, Then) {

		When.EmpresaPage.filtrarPorRamo("Industria");

		Then.EmpresaPage.verificarQuantidadeEmpresasFiltradasPorBarraDePesquisaECombobox();

	});

	opaTest("Deve limpar todos os filtros", function(Given, When, Then){

		When.EmpresaPage.bucarPor(" ");

		When.EmpresaPage.filtrarPorRamo("NaoDefinido")

		Then.EmpresaPage.verificarSeParouDeFiltrar();
	});

	opaTest("Deve verificar se está filtrando corretamente o select de ramo, filtrando por Comércio", function(Given, When, Then) {

		When.EmpresaPage.filtrarPorRamo("Comercio");

		Then.EmpresaPage.verificarQuantidadeEmpresasFiltradasSomentePorComercio();

		Then.iTeardownMyApp();
	});

});