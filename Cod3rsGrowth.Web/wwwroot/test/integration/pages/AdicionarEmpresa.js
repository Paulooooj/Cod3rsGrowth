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

	const sViewName = "empresa.AdicionarEmpresa";
	const tituloPaginaAdicionar = "Cadastro Empresa";
	const viewNamePaginaListagemEmpresa = "empresa.Empresa";

	Opa5.createPageObjects({
		adicionarEmpresa: {
			actions: {
				deverClicarNoBotaoDeOk: function (){
					return this.waitFor({
						id: "idBotaoCancelar", 
						viewName: sViewName,   
						actions: new Press(),  
						success: function () {
							this.waitFor({
								controlType: "sap.m.Dialog",   
								success: function(oDialog) {
									this.waitFor({
										controlType: "sap.m.Button",
										matchers: new PropertyStrictEquals({
											name: "text",
											value: "OK" 
										}),
										actions: new Press(),  
										errorMessage: "O botão 'OK' não foi encontrado na Message Box."
									});
								},
								errorMessage: "A Message Box não foi encontrada."
							});
						},
					});
				},

				voltarParaAPaginaDeAdicionar: function (idBotaoAdicionar, nomeView){
					return this.waitFor({
						id: "idBotaoAdicionar",
						viewName: nomeView,
						actions: new Press(),
						success: () => Opa5.assert.ok(true, "A tela de Adicionar Empresa foi carregada corretamente"),
						errorMessage: "Não foi possível voltar para a tela de adicionar"
					})
				},

				apertarNoBotaoSalvar: function (){
					return this.waitFor({
						id: "idBotaoSalvar",
						viewName: sViewName,
						actions: new Press(),
						errorMessage: "Não foi possível encontrar o botão de Salvar"
					})
				},

				preencherInputs: function (id, sBuscaString) {
					return this.waitFor({
						id: id,
						viewName: sViewName,
						actions: new EnterText({
							text: sBuscaString
						}),
						errorMessage: "Input de pesquisa não foi encontrado."
					});
				},

				selecionarNaCombobox: function () {	
					return this.waitFor({
						id: "idSelectRamoAdicionar",
						viewName: sViewName,
						actions: function (oSelect) {
							oSelect.setSelectedKey(2);
						},
						errorMessage: "Não foi possível selecionar Serviço."
					});
				},

				confirmarNoOkAposSalvar: function () {
					return this.waitFor({
						viewName: sViewName,
						controlType: "sap.m.Button",
						matchers: new PropertyStrictEquals({
							name: "text",
							value: "OK"
						}),
						actions: new Press(),
						errorMessage: "Botão OK não encontrado!"
					});	
				},

				clicarNoVerDetalhesMessageBox: function (){
					return this.waitFor({
						viewName: sViewName,
						controlType:  "sap.m.Link",
						actions: new Press(),
						success: function () {
							Opa5.assert.ok(true, "Foi possível encontrar o link visualizar detalhes");
						},
						errorMessage: "Não foi possível encontrar o visualizar detalhes. "
					})
				}

			},

			assertions: {
				deveVerificarSeEstaNaPaginaDeAdicionar: function () {
					return this.waitFor({
						controlType: "sap.m.Title",
						matchers: new PropertyStrictEquals({
							name: 'text',
							value: tituloPaginaAdicionar
						}),
						success: () => Opa5.assert.ok(true, "A tela de adicionar foi carregada corretamente"),
						errorMessage: "A tela de adicionar não foi carregada corretamente"
					})
				},

				verificarSeFoiParaPaginaListagemEmpresa: function (nomeView){
					return this.waitFor({
						viewName: nomeView,
						success: () => Opa5.assert.ok(true, "A tela de listagem de empresa foi carregada corretamente"),
						errorMessage: "A tela de listagem não foi carregada corretamente"
					})
				},

				verificarMensagemDeErroIEValorDeStatusAoTentarSalvarSemNadaInputRazaoSocial: function (){
					const idInputRazaoSocial = "idInputRazaoSocial";
					const valorStatusTexto = "Informe a Razão Social";

					this.deveVerificarMensagemDeErroAoTentarSalvarSemNadaNosInput(idInputRazaoSocial, valorStatusTexto);
				},

				verificarMensagemDeErroIEValorDeStatusAoTentarSalvarSemNadaInputCNPJ: function (){
					const idInputRazaoSocial = "idInputCNPJ";
					const valorStatusTexto = "Informe o CNPJ";

					this.deveVerificarMensagemDeErroAoTentarSalvarSemNadaNosInput(idInputRazaoSocial, valorStatusTexto);
				},

				verificarMensagemDeErroIEValorDeStatusAoTentarSalvarSemNadaSelectRamo: function (){
					const idInputRazaoSocial = "idSelectRamoAdicionar";
					const valorStatusTexto = "Informe o Ramo";

					this.deveVerificarMensagemDeErroAoTentarSalvarSemNadaNosInput(idInputRazaoSocial, valorStatusTexto);
				},

				deveVerificarMensagemDeErroAoTentarSalvarSemNadaNosInput: function (id, valorStatusTexto){
					return this.waitFor({
						id: id,
						viewName: sViewName,
						matchers: [
							new Properties({valueState: "Error"}),
							new Properties({valueStateText: valorStatusTexto})
						], 
						success: function (){
							Opa5.assert.ok(true, "A mensagem de erro e valor de status está correta");
						},
						errorMessage: "Não tem mensagem de erro e nem valor de status"
						
					});
				},

				apertarNoBotaoFecharMessagemErro: function (){
					return this.waitFor({
						viewName: sViewName,
						controlType: "sap.m.Button",
						matchers: new PropertyStrictEquals({
							name: "text",
							value: "Fechar"
						}),
						actions: new Press(),
						success: function (){
							Opa5.assert.ok(true, "Erro de validação encontrado! ")
						},
						errorMessage: "Não apareceu messagem box de erro de validação!"
					});	
				},

				conferirQuantidadeEmpresasTabela: function (){
					return this.waitFor({
						id: "idtituloTabela",
						viewName: viewNamePaginaListagemEmpresa,
						matchers: new I18NText({
							key: "nomeBarraFerramentasEmpresaCount",
							propertyName: "text",
							parameters: [28]
						}),
						success: function () {
							Opa5.assert.ok(true, "O título da tabela contém 27 elementos");
						},
						errorMessage: "O título da tabela não contém 27 elementos."
					})
				}	
			},
		}
	});
});
