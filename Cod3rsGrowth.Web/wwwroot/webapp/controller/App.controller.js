sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/m/MessageToast",
    "sap/ui/model/resource/ResourceModel"
 ], (Controller, MessageToast, ResourceModel) => {
    "use strict";
 
    return Controller.extend("ui5.cod3rsgrowth.controller.App", {
      onInit() {
        
         const i18nModel = new ResourceModel({
            bundleName: "ui5.cod3rsgrowth.i18n.i18n"
         });
         this.getView().setModel(i18nModel, "i18n");

         const oBundle = this.getView().getModel("i18n").getResourceBundle();
         const sTitulo = oBundle.getText("nomeDaPagina");
         document.title = sTitulo;

      },
       mostrarOla() {
          const oBundle = this.getView().getModel("i18n").getResourceBundle();
          const sMsg = oBundle.getText("mensagemOla");
          
          MessageToast.show(sMsg);
          
       }
    });
 });