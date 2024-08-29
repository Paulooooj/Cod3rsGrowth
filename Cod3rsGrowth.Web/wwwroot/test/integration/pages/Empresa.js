sap.ui.define([
	"sap/ui/test/Opa5",
	'sap/ui/test/matchers/AggregationLengthEquals',
	'sap/ui/test/actions/EnterText',
	'sap/ui/test/matchers/I18NText',
	'sap/ui/test/actions/Press',
    'sap/ui/test/matchers/Properties',
	'sap/ui/test/matchers/PropertyStrictEquals'

], (Opa5, AggregationLengthEquals, EnterText, I18NText, Press, Properties, PropertyStrictEquals) => {
	"use strict";

	const sViewName = "empresa.Empresa";
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
							oSelect.setSelectedKey(3);
						},
						errorMessage: "Não foi possível selecionar Serviço."
					});
				},

				filtrarPorRamo: function (ramo) {
					return this.waitFor({
						id: "idEnumSelecaoRamo",
						viewName: sViewName,
						actions: new Press(),
						success: function () 
						{
							this.waitFor({
								controlType: "sap.ui.core.Item",
								matchers: [
									new Properties({text: ramo})
								],
								actions: new Press(),
								errorMessage: `Não foi possivel encontrar ${ramo} na mySelecet`
							})
						}
					});
				},

				deveAoAbertarBotão: function (id, viewName){
					return this.waitFor({
						id: id,
						viewName: viewName,
						actions: new Press(),
						errorMessage : "Não foi possivel encontrar o botão!"
					});
				},

				aoApertarEmUmaLinhaDaTabelaIrParaDetalhes: function (){
					return this.waitFor({
						viewName: sViewName,
						controlType: "sap.m.ColumnListItem",
						actions: new Press(),
						errorMessage: "Não foi possível ir para tela de detalhes"
					})
				}
			},

			assertions: {
				verificarSeTemPaginacaoNaTabela: function () {
					mensagemDeAcerto = "A tabela tem 20 Empresas na primeira página";
					mensagemDeErro = "A tabela não contém todos os items.";
					totalItensFiltrados = 20;

					this.verificarQuantidadeEmpresaTabela(mensagemDeAcerto, mensagemDeErro, totalItensFiltrados);
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
				
				aoPassarNomeInvalidoNaoDeveFiltrar () { 
					mensagemDeAcerto = "A Barra de Pesquisa está filtrando corretamente";
					mensagemDeErro = "A Barra de Pesquisa não está filtrando corretamente";
					totalItensFiltrados = 0;

					this.verificarQuantidadeEmpresaTabela(mensagemDeAcerto, mensagemDeErro, totalItensFiltrados);
				},

				verificarSeTabelaFiltrouUsandoBarraDePesquisa: function () {
					mensagemDeAcerto = "A tabela contém duas entradas correspondentes";
					mensagemDeErro = "Não foi encontrado nada.";
					totalItensFiltrados = 2;

					this.verificarQuantidadeEmpresaTabela(mensagemDeAcerto, mensagemDeErro, totalItensFiltrados);
				},

				verificarItemSelecionadoCombobox: function () {
					return this.waitFor({
						id: "idEnumSelecaoRamo",
						viewName: sViewName,
						success: function (oSelect) {
							Opa5.assert.strictEqual(oSelect.getSelectedKey(), "3", "Foi selecionado Serviço");
						},
						errorMessage: "Serviço não selecionado."
					});
				},

				verificarQuantidadeEmpresasFiltradasPorBarraDePesquisaECombobox: function () {
					mensagemDeAcerto = "Foi encontrada uma Empresa";
					mensagemDeErro = "Não foi encontrado nada.";
					totalItensFiltrados = 1;

					this.verificarQuantidadeEmpresaTabela(mensagemDeAcerto, mensagemDeErro, totalItensFiltrados);
				},

				verificarSeParouDeFiltrar: function () {

					mensagemDeAcerto = "Todos os filtros foram limpos";
					mensagemDeErro = "Não foi possível limpar os filtros.";
					totalItensFiltrados = 20;

					this.verificarQuantidadeEmpresaTabela(mensagemDeAcerto, mensagemDeErro, totalItensFiltrados);
				},
				
				verificarQuantidadeEmpresasFiltradasSomentePorComercio: function () {
					mensagemDeAcerto = "A tabela tem 12 empresas filtradas por Comércio";
					mensagemDeErro = "A tabela não contém empresas filtradas por Comércio.";
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

				deveEstarNaTelaDeAdicionar: function (titulo){
					return this.waitFor({
						controlType: "sap.m.Title",
						matchers: new PropertyStrictEquals({
							name: 'text',
							value: titulo
						}),
						success: () => Opa5.assert.ok(true, "A tela de adicionar foi carregada corretamente"),
						errorMessage: "A tela de adicionar não foi carregada corretamente"
					})
				},

				deveEstarNaTelaDeListagem: function (titulo){
					return this.waitFor({
						viewName: sViewName,
						success: () => Opa5.assert.ok(true, "A tela de listagem de empresa foi carregada corretamente"),
						errorMessage: "A tela de listagem não foi carregada corretamente"
					})
				},

				deveVerificarSeEstaNaPagindaDeDetalhes: function (titulo){
					return this.waitFor({
						controlType: "sap.m.Title",
						matchers: new PropertyStrictEquals({
							name: 'text',
							value: "Detalhes"
						}),
						success: () => Opa5.assert.ok(true, "A tela de Detalhes foi carregada corretamente"),
						errorMessage: "A tela de detalhes não foi carregada corretamente"
					})
				}, 
				
			}
		}
	});
});