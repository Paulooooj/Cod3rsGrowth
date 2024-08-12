sap.ui.define([
	"sap/ui/test/Opa5",
	"sap/ui/test/actions/Press",
	'sap/ui/test/matchers/AggregationLengthEquals',
	'sap/ui/test/actions/EnterText',
	'sap/ui/test/matchers/I18NText',
	"sap/ui/test/matchers/Ancestor",
	"sap/ui/test/matchers/Properties",
], (Opa5, Press, AggregationLengthEquals, EnterText, I18NText, Ancestor, Properties) => {
	"use strict";

	const sViewName = "ui5.cod3rsgrowth.app.empresa.Empresa";
	var sTableId = "listaEmpresa";
	var mensagemDeAcerto = "";
	var mensagemDeErro = "";
	var totalItensFiltrados = 0;

	Opa5.createPageObjects({
		EmpresaPage: {
			actions: {
				bucarPor: function (sBuscaString) {
					return this.waitFor({
						id: "idInputRazaoSocial",
						viewName: sViewName,
						actions: new EnterText({
							text: sBuscaString
						}),
						errorMessage: "Campo de pesquisa não foi encontrado."
					});
				},

				selecionarCombobox: function ()
				{	
					return this.waitFor({
						id: "idEnumSelecaoRamo",
						viewName: sViewName,
						actions: function (oSelect) {
							oSelect.setSelectedKey("Servico");
						},
						errorMessage: "Não foi possível selecionar Serviço."
					});
				},

				filtrarPorIndustria: function () {
					return this.waitFor({
						id: "idEnumSelecaoRamo",
						viewName: sViewName,
						actions: new EnterText({
							text: "Indústria"
						}),
						errorMessage: "Select não encontrado"
					});
				},

			},
			assertions: {
				verificarSeTabelaFiltrouUmItem: function (){
					mensagemDeAcerto = "A tabela contém duas entrada correspondente";
					mensagemDeErro = "A tabela não contém esse item.";
					totalItensFiltrados = 2;

					this.verificarQuantidadeEmpresaTabela(mensagemDeAcerto, mensagemDeErro, totalItensFiltrados);
					
				},

				verificarSeTemPaginacaoNaTabela: function (){
					mensagemDeAcerto = "A tabela tem 20 itens na primeira página";
					mensagemDeErro = "A tabela não contém todos os items.";
					totalItensFiltrados = 20;

					this.verificarQuantidadeEmpresaTabela(mensagemDeAcerto, mensagemDeErro, totalItensFiltrados);
				},
				
				verificarQuantidadeEmpresasFiltradas: function (){
					mensagemDeAcerto = "A tabela tem 1 itens na primeira página";
					mensagemDeErro = "A tabela não contém todos os items.";
					totalItensFiltrados = 1;

					this.verificarQuantidadeEmpresaTabela(mensagemDeAcerto, mensagemDeErro, totalItensFiltrados);
				},
				
				verificarQuantidadeEmpresaTabela: function (mensagemDeAcerto, mensagemDeErro, totalItensFiltrados) {
					return this.waitFor({
						id: sTableId,
						viewName: sViewName,
						matchers: new AggregationLengthEquals({
							name: "items",
							length: totalItensFiltrados
						}),
						success: function () {
							Opa5.assert.ok(true, mensagemDeAcerto);
						},
						errorMessage: mensagemDeErro
					});
				},


				oDisplayDeveTerOTantoDeItems: function () {
					return this.waitFor({
						id: "idtituloTabela",
						viewName: sViewName,
						matchers: new I18NText({
							key: "nomeBarraFerramentasEmpresaCount",
							propertyName: "text",
							parameters: [27]
						}),
						success: function () {
							Opa5.assert.ok(true, "O titulo da tabela contém 27 elementos");
						},
						errorMessage: "A tabela não contém 27 elementos."
					});
				},

				verificarItemSelecionadoCombobox: function () {
					return this.waitFor({
						id: "idEnumSelecaoRamo",
						viewName: sViewName,
						success: function (oSelect) {
							Opa5.assert.strictEqual(oSelect.getSelectedKey(), "Servico", "Selecionado Serviço");
						},
						errorMessage: "Serviço não selecionado."
					});
				},
			}
		}
	});
});