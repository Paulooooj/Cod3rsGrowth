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
                        controlType: "sap.m.ObjectAttribute",
                        matchers: [
							new Properties({text: valor}),
						], 
						success: () => Opa5.assert.ok(true, mensageDeSucesso),
						errorMessage: mensageDeErro
                    })
                },
			},
		}
	});
});
