sap.ui.define([
    "ui5/cod3rsgrowth/app/BaseController",
    "sap/ui/model/resource/ResourceModel"
 ], function (BaseController, ResourceModel) {
    "use strict";
    return BaseController.extend("ui5.cod3rsgrowth.app.notFound.NotFound", {
       onInit: function () {
         this._mudarNomeDaAba();
       },

       voltarPaginaInicial: function () {
			this.getRouter().navTo("appEmpresa", {}, true);
		},

      _mudarNomeDaAba: function () 
      {
         const i18nModel = new ResourceModel({
            bundleName: "ui5.cod3rsgrowth.i18n.i18n"
         });
         this.getView().setModel(i18nModel, "i18n");
         const oBundle = this.getView().getModel("i18n").getResourceBundle();
         const sTitulo = oBundle.getText("nomeDaPaginaNaoEncontrada");
         document.title = sTitulo;
      }
    });
 });