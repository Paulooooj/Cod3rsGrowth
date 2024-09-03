sap.ui.define([
	"sap/ui/test/Opa5",
	'sap/ui/test/actions/Press',
    'sap/ui/test/matchers/Properties',
	'sap/ui/test/matchers/PropertyStrictEquals'

], (Opa5, Press, Properties, PropertyStrictEquals) => {
	"use strict";
	const viewName = "empresa.DetalhesEmpresa";

	Opa5.createPageObjects({
		detalhesEmpresa: {
			actions: {
                deveIrParaATelaDeDetalhes: function (){
                    return this.waitFor({
                        viewName: "empresa.Empresa",
                        controlType: "sap.m.ObjectIdentifier",
                        matchers: [
							new Properties({title: "Microsoft"}),
						], 
						actions: new Press(),
						errorMessage: "Não foi possível ir para tela de detalhes"
                    })
                },
				
				deveVoltarParaTelaDeListagemEmpresa: function (){
					return this.waitFor({
						id: "botaoDeNavegarDeVoltar",
						viewName: "empresa.AdicionarEmpresa",
						actions: new Press(),
						errorMessage : "Não foi possivel encontrar o botão!"
					});
				},

				deveApertarNoBotaoDeEditar: function (){
					return this.waitFor({
						controlType: "sap.m.Button",
						viewName: viewName,
						actions: new Press(),
						errorMessage: "Não foi possível encontrar o botão de editar"
					})
				}
			},

			assertions: {
                deveVerificarSeFoiParaPagindaDeDetalhes: function (){
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

                verificarSeARazaoSocialEstaCorreta: function (){
                    return this.waitFor({
                        controlType: "sap.m.Title",
						matchers: new PropertyStrictEquals({
							name: 'text',
							value: "Microsoft"
						}),
						success: () => Opa5.assert.ok(true, "A Razão Social está correta"),
						errorMessage: "A Razão Social está incorreta"
                    })
                },

                verificarSeCnpjEstaCorreta: function (){
                    const mensageDeSucesso = "O CNPJ está correto";
					const mensagemErro = "O CNPJ está incorreto";
                    const cnpj = "87.439.722/0001-25";
                    this.deveVerificarSeAsInformacoesEstaoCorretas(mensageDeSucesso, mensagemErro, cnpj);
                },

                verificarSeORamoEstaCorreto: function (){
						const mensageDeSucesso = "O Ramo está correto";
						const mensagemErro = "O Ramo está incorreto";
                        const ramo = "Serviço";
                        this.deveVerificarSeAsInformacoesEstaoCorretas(mensageDeSucesso, mensagemErro, ramo);
                },

                deveVerificarSeAsInformacoesEstaoCorretas: function (mensageDeSucesso, mensageDeErro, valor){
                    return this.waitFor({
                        controlType: "sap.m.ObjectStatus",
                        matchers: [
							new Properties({text: valor}),
						], 
						success: () => Opa5.assert.ok(true, mensageDeSucesso),
						errorMessage: mensageDeErro
                    })
                },

				deveConfirmarQueEstaNaTelaDeListagem: function (){
					return this.waitFor({
						viewName: "empresa.Empresa",
						success: () => Opa5.assert.ok(true, "A tela de listagem de empresa foi carregada corretamente"),
						errorMessage: "A tela de listagem não foi carregada corretamente"
					})
				},

				deveVerificarSeEstaNaPaginaDeEditar: function(){
					return this.waitFor({
						viewName: "empresa.AdicionarEmpresa",
						controlType: "sap.m.Title",
						matchers: new PropertyStrictEquals({
							name: 'text',
							value: "Editar Empresa"
						}),
						success: () => Opa5.assert.ok(true, "Deve estar na página de editar"),
						errorMessage: "Não está na página de editar"
					})
				}
			},
		}
	});
});
