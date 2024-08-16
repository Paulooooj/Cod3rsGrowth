sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History",
	"sap/ui/core/UIComponent",
], function(Controller, History, UIComponent) {
	"use strict";

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
	});

});