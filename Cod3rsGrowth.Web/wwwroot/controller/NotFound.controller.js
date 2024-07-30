sap.ui.define([
    "ui5/cod3rsgrowth/controller/BaseController",
    "sap/ui/model/resource/ResourceModel"
 ], function (BaseController, ResourceModel) {
    "use strict";
    return BaseController.extend("ui5.cod3rsgrowth.controller.NotFound", {
       onInit: function () {
        const i18nModel = new ResourceModel({
            bundleName: "ui5.cod3rsgrowth.i18n.i18n"
         });
         this.getView().setModel(i18nModel, "i18n");
         const oBundle = this.getView().getModel("i18n").getResourceBundle();
         const sTitulo = oBundle.getText("nomeDaPaginaNaoEncontrada");
         document.title = sTitulo;
       },

       voltarPaginaInicial: function () {
			this.getRouter().navTo("appEmpresa", {}, true);
		}
    });
 });