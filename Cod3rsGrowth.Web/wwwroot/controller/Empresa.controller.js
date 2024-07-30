sap.ui.define([
   "ui5/cod3rsgrowth/controller/BaseController",
   "sap/m/MessageToast",
   "sap/ui/model/resource/ResourceModel"
], (BaseController, MessageToast, ResourceModel) => {
   "use strict";
 
    return BaseController.extend("ui5.cod3rsgrowth.controller.Empresa", {
      onInit: function () {
         const i18nModel = new ResourceModel({
            bundleName: "ui5.cod3rsgrowth.i18n.i18n"
         });
         this.getView().setModel(i18nModel, "i18n");
         const oBundle = this.getView().getModel("i18n").getResourceBundle();
         const sTitulo = oBundle.getText("nomeDaPaginaEmpresa");
         document.title = sTitulo;
      },
       mostrarOla: function () {
          const oBundle = this.getView().getModel("i18n").getResourceBundle();
          const sMsg = oBundle.getText("mensagemOla");
          MessageToast.show(sMsg);
       }
    });
 
 });