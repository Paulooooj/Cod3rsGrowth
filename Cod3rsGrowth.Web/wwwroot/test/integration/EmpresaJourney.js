sap.ui.define([
	"sap/ui/test/opaQunit",
	"./pages/Empresa"
], (opaTest) => {
	"use strict";

	QUnit.module("Lista Empresa");

	opaTest("Deve ser capaz de procurar itens", function (Given, When, Then) {
		// Arrangements
		Given.iStartMyUIComponent({
			componentConfig: {
				name: "ui5.cod3rsgrowth"
			}
		});

		//Actions
		Then.EmpresaPage.aTabelaDeveTerPaginacao();
		// and.oDisplayDeveTerOTantoDeItems();
	});

	opaTest("Should be able to search for items", function (Given, When, Then) {
		//Actions
		When.EmpresaPage.bucarPor("Apple");

		// Assertions
		Then.EmpresaPage.tabelaTemUmItem();

		// Cleanup
		Then.iTeardownMyApp();
	});
});