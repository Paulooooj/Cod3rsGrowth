sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History",
	"sap/ui/core/UIComponent",
	"sap/ui/model/json/JSONModel",
	"sap/ui/model/resource/ResourceModel",
	"sap/m/MessageBox"
], function(Controller, History, UIComponent, JSONModel, ResourceModel, MessageBox) {
	"use strict";
	
	var sResponsivePaddingClasses = "sapUiResponsivePadding--header sapUiResponsivePadding--content sapUiResponsivePadding--footer";

	return Controller.extend("ui5.cod3rsgrowth.app.BaseController", {
		
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

		 _obterDescricaoEnum: function (url){
			fetch(url).then(res => {return res.ok? res.json() :
				res.json().then(res => {this._mensagemDeErro(res)})})
				.then(res => {
			   const dataModel = new JSONModel();
			   dataModel.setData(res);
			   this.getView().setModel(dataModel, "listaEnum")
			}); 
		 },

		 _mudarNomeDaAba: function (nomeDaAbaPagina) {
			const i18nModel = new ResourceModel({
			   bundleName: "ui5.cod3rsgrowth.i18n.i18n"
			});
			this.getView().setModel(i18nModel, "i18n");
			const oBundle = this.getView().getModel("i18n").getResourceBundle();
			const sTitulo = oBundle.getText(nomeDaAbaPagina);
			document.title = sTitulo;
		 },

		 _mensagemDeErro : function (erro){
			const tituloErroDeValidacao = "Erro de Validação!";

			if(erro.Title == tituloErroDeValidacao){
			let mensagemDeErro = Object.values(erro.Extensions.ErroDeValidacao).join("\r\n");
			MessageBox.error(`${erro.Title} \n\n ${mensagemDeErro}`, {
			   title: "Error",
			   details:
			   `<p><strong>Status: ${erro.Status}</strong></p>` +
			   "<p><strong>Detalhes:</strong></p>" +
			   "<ul>" +
			   `<li>${erro.Detail}</li>` +
			   "</ul>",
			   styleClass: sResponsivePaddingClasses,
			   dependentOn: this.getView()
			});
			}
			else {
				MessageBox.error(`${erro.Title}`, {
					title: "Error",
					details:
					`<p><strong>Status: ${erro.Status}</strong></p>` +
					"<p><strong>Detalhes:</strong></p>" +
					"<ul>" +
					`<li>${erro.Detail}</li>` +
					"</ul>",
					styleClass: sResponsivePaddingClasses,
					dependentOn: this.getView()
				 });
			}
		 },
	});

});