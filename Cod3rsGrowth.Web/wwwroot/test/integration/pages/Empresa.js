sap.ui.define([
	"sap/ui/test/Opa5",
	"sap/ui/test/actions/Press",
	'sap/ui/test/matchers/AggregationLengthEquals',
	'sap/ui/test/actions/EnterText',
	'sap/ui/test/matchers/I18NText'
], (Opa5, Press, AggregationLengthEquals, EnterText, I18NText) => {
	"use strict";

	const sViewName = "ui5.cod3rsgrowth.view.Empresa";
	var sTableId = "listaEmpresa";

	Opa5.createPageObjects({
		EmpresaPage: {
			actions: {
				bucarPor: function (sBuscaString){
					return this.waitFor({
						id: "searchField",
						viewName: sViewName,
						actions: new EnterText({
							text: sBuscaString
						}),
						errorMessage: "Campo de pesquisa não foi encontrado."
					})
				}
			},
			assertions: {
				tabelaTemUmItem() {
					return this.waitFor({
						id: sTableId,
						viewName: sViewName,
						matchers: new AggregationLengthEquals({
							name: "items",
							length: 1
						}),
						success: function () {
							Opa5.assert.ok(true, "A tabela contéum uma entra correspondente");
						},
						errorMessage: "A tabela não contém um item."
					});
				},
				
				aTabelaDeveTerPaginacao: function () {
					return this.waitFor({
						id: sTableId,
						viewName: sViewName,
						matchers: new AggregationLengthEquals({
							name: "items",
							length: 20
						}),
						success: function () {
							Opa5.assert.ok(true, "A tabela tem 20 itens na primeira página");
						},
						errorMessage: "A tabela não contém todos os items."
					});
				},
				oDisplayDeveTerOTantoDeItems: function () {
					return this.waitFor({
						id: "tituloTabela",
						viewName: sViewName,
						matchers: new I18NText({
							key: "worklistTableTitleCount",
							propertyName: "text",
							parameters: [26]
						}),
						success: function () {
							Opa5.assert.ok(true, "The table header has 23 items");
						},
						errorMessage: "The table header does not contain the number of items: 23"
					});
				},
				
			}
		}
	});
});