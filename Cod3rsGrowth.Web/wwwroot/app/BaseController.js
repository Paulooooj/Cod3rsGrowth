sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History",
	"sap/ui/core/UIComponent",
	"sap/ui/model/json/JSONModel",
	"sap/ui/model/resource/ResourceModel",
	"sap/m/MessageBox",
	"ui5/cod3rsgrowth/app/servico/validacao",
	"sap/m/Dialog",
    "sap/m/Button",
    "sap/m/library",
    "sap/m/Text",
    "sap/ui/core/library",
], function(Controller, History, UIComponent, JSONModel, ResourceModel, MessageBox, validacao, Dialog, Button, mobileLibrary, Text, coreLibrary) {
	"use strict";
	var sResponsivePaddingClasses = "sapUiResponsivePadding--header sapUiResponsivePadding--content sapUiResponsivePadding--footer";
	
	return Controller.extend("ui5.cod3rsgrowth.app.BaseController", {
		validacao: validacao,
		getRouter: function () {
			return UIComponent.getRouterFor(this);
		},

		onNavBack: function () {
			var oHistory, sPreviousHash;

			oHistory = History.getInstance();
			sPreviousHash = oHistory.getPreviousHash();

			if (sPreviousHash !== undefined) {
				window.history.go(-1);
			} else {
				this.getRouter().navTo("appEmpresa", {}, true);
			}
		},

		mudarDeTema: function (oEvent){
			var eventoAlterarTema = oEvent.getSource().getText();
			const modoClaro = "Claro";
			const temaClaro = "sap_horizon";
			const temaEscuro = "sap_horizon_dark";
   
			if(eventoAlterarTema === modoClaro){
			   sap.ui.getCore().applyTheme(temaClaro);
			}
			else{
			   sap.ui.getCore().applyTheme(temaEscuro);
			}
		 }, 

		 obterEmpresa: function (url, view, nomeContexto){
			fetch(url).then(res => {return res.ok? res.json() :
				res.json().then(res => {this.validacao.mensagemDeErro(res, view)})})
				.then(res => {
			   const dataModel = new JSONModel();
			   dataModel.setData(res);
			   this.getView().setModel(dataModel, nomeContexto)
			}); 
		 },

		 mudarNomeDaAba: function (nomeDaAbaPagina) {
			const i18nModel = new ResourceModel({
			   bundleName: "ui5.cod3rsgrowth.i18n.i18n"
			});
			this.getView().setModel(i18nModel, "i18n");
			const oBundle = this.getView().getModel("i18n").getResourceBundle();
			const sTitulo = oBundle.getText(nomeDaAbaPagina);
			document.title = sTitulo;
		 },

		 adicionarEAtualizarEmpresa: function (empresa, requisicao){
			let view = this.getView();
			const idEmpresa = empresa.id;
			const mensagemDeSucesso = `${empresa.razaoSocial} foi salvo com sucesso!`
			const url = '/api/Empresa';
			const options = {
			   method: requisicao,
			   body: JSON.stringify(empresa),
			   headers: {
				  "Content-Type": "application/json",
			   }
			};

			fetch(url, options)
               .then(res => {
                    if (!res.ok) {
                        res.json()
                            .then(res => {
                                this.validacao.mensagemDeErro(res, view)
                            });
                    }else {
						!!idEmpresa
						?this.mensageDeSucesso(mensagemDeSucesso, idEmpresa)
						:res.json().then(res => this.mensageDeSucesso(mensagemDeSucesso, res.id));
					}
                })
		 },

		 mensageDeSucesso: function (mensagemDeSucesso, id){
			const rotaEmpresa = "appEmpresa";
			const rotaTelaDetalhes = "appDetalhesEmpresa";;
			MessageBox.success(mensagemDeSucesso, {
			   id: "messageBoxSucesso",
			   styleClass: sResponsivePaddingClasses,
			   dependentOn: this.getView(),
			   actions: [MessageBox.Action.OK],
			   onClose: (sAction) => {
				  if(sAction == MessageBox.Action.OK){
					!!id
						? this.getRouter().navTo(rotaTelaDetalhes, {empresaId: id}, true)
						: this.getRouter().navTo(rotaEmpresa, {}, true)
				  }
			   }
			})
		 },

		 mensagemDeAviso: function(mensagemDeAviso, idEmpresa, nomeEmpresa){
			const url = `/api/Empresa/${idEmpresa}`;
				this.mensagemDeCancelarEmpresa = new Dialog({
                    type: mobileLibrary.DialogType.Message,
                    title: "Aviso",
                    state: coreLibrary.ValueState.Warning,
                    content: new Text({ text: mensagemDeAviso }),
                    beginButton: new Button({
                        type: mobileLibrary.ButtonType.Negative,
                        text: "Sim",
                        press: function () {
                            this.mensagemDeCancelarEmpresa.close();
                           nomeEmpresa?
						   	this.deletarEmpresa(url, nomeEmpresa):
							this._navegarPara(idEmpresa);
                        }.bind(this)
                    }),
                    endButton: new Button({
                        type: mobileLibrary.ButtonType.Success,
                        text: "Não",
                        press: function () {
                            this.mensagemDeCancelarEmpresa.close();
                        }.bind(this)
                    })
                });
			this.mensagemDeCancelarEmpresa.open();
		 },

		_navegarPara: function (idEmpresa){
			const rotaTelaEmpresa = "appEmpresa";
			const rotaTelaDetalhes = "appDetalhesEmpresa";
			!!idEmpresa
				? this.getRouter().navTo(rotaTelaDetalhes, {empresaId: idEmpresa}, true)
				: this.getRouter().navTo(rotaTelaEmpresa, {}, true)
		},

		 deletarEmpresa: function (url, empresa){
			const mensagemDeSucesso = `${empresa} foi removido com sucesso!`
			fetch(url, {
			   method: "DELETE",
			})
			.then(res => {return !res.ok? 
				  res.json().then(res => this.validacao.mensagemDeErro(res, view)) : 
				  this.mensageDeSucesso(mensagemDeSucesso);
			})
		 }
	});
});