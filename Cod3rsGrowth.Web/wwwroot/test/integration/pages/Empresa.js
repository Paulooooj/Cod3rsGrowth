sap.ui.define([
	"sap/ui/test/Opa5",
	'sap/ui/test/matchers/AggregationLengthEquals',
	'sap/ui/test/actions/EnterText',
	'sap/ui/test/matchers/I18NText',

], (Opa5, AggregationLengthEquals, EnterText, I18NText) => {
	"use strict";

	const sViewName = "ui5.cod3rsgrowth.app.empresa.Empresa";
	var sTableId = "idTabelaEmpresa";
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
						errorMessage: "Barra de pesquisa não foi encontrado."
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

				filtrarPorRamo: function (ramo) {
					return this.waitFor({
						id: "idEnumSelecaoRamo",
						viewName: sViewName,
						actions: new EnterText({
							text: `${ramo}`
						}),
						errorMessage: `${ramo} não foi encontrado`
					});
				},

			},
			assertions: {
				verificarSeTabelaFiltrouUsandoBarraDePesquisa: function (){
					mensagemDeAcerto = "A tabela contém duas entrada correspondente";
					mensagemDeErro = "Não foi encontrado nada.";
					totalItensFiltrados = 2;

					this.verificarQuantidadeEmpresaTabela(mensagemDeAcerto, mensagemDeErro, totalItensFiltrados);
				},

				verificarSeTemPaginacaoNaTabela: function (){
					mensagemDeAcerto = "A tabela tem 20 Empresas na primeira página";
					mensagemDeErro = "A tabela não contém todos os items.";
					totalItensFiltrados = 20;

					this.verificarQuantidadeEmpresaTabela(mensagemDeAcerto, mensagemDeErro, totalItensFiltrados);
				},
				
				verificarQuantidadeEmpresasFiltradas: function (){
					mensagemDeAcerto = "Foi encontrada uma Empresa";
					mensagemDeErro = "Não foi encontrado nada.";
					totalItensFiltrados = 1;

					this.verificarQuantidadeEmpresaTabela(mensagemDeAcerto, mensagemDeErro, totalItensFiltrados);
				},
				
				verificarQuantidadeEmpresasFiltradasSomentePorComercio: function () {
					mensagemDeAcerto = "A tabela tem 12 empresas filtradas por Comércio";
					mensagemDeErro = "A tabela não contém empresas filtradas por Comércio..";
					totalItensFiltrados = 12;

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
							Opa5.assert.ok(true, "O título da tabela contém 27 elementos");
						},
						errorMessage: "O título da tabela não contém 27 elementos."
					});
				},

				verificarItemSelecionadoCombobox: function () {
					return this.waitFor({
						id: "idEnumSelecaoRamo",
						viewName: sViewName,
						success: function (oSelect) {
							Opa5.assert.strictEqual(oSelect.getSelectedKey(), "Servico", "Foi selecionado Serviço");
						},
						errorMessage: "Serviço não selecionado."
					});
				},
			}
		}
	});
});