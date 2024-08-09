sap.ui.define([
	"sap/ui/test/opaQunit",
	"./pages/Empresa"
], (opaTest) => {
	"use strict";

	QUnit.module("Lista Empresa");

	opaTest("Deve ser capaz de procurar itens", function (Given, When, Then) {
		Given.iStartMyUIComponent({
			componentConfig: {
				name: "ui5.cod3rsgrowth"
			}
		});

		Then.EmpresaPage.aTabelaDeveTerPaginacao().
		and.oDisplayDeveTerOTantoDeItems();
	});

	opaTest("Deve ser capaz de pesquisar um item", function (Given, When, Then) {
		
		When.EmpresaPage.bucarPor("Apple");

		Then.EmpresaPage.tabelaTemUmItem();

		Then.iTeardownMyApp();
	});
});