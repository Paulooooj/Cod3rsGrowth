sap.ui.define([
    "ui5/cod3rsgrowth/app/BaseController",
 ], function (BaseController) {
    "use strict";
    return BaseController.extend("ui5.cod3rsgrowth.app.notFound.NotFound", {
       onInit: function () {
         var nomeDaAba = "nomeDaPaginaNaoEncontrada";
         this._mudarNomeDaAba(nomeDaAba);
       },

       voltarPaginaInicial: function () {
			this.getRouter().navTo("appEmpresa", {}, true);
		}
    });
 });