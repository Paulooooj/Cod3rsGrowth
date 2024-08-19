sap.ui.define([
   "ui5/cod3rsgrowth/app/BaseController",
   "../model/formatter",
 ], function (BaseController, formatter, JSONModel) {
    "use strict";
    return BaseController.extend("ui5.cod3rsgrowth.app.empresa.AdicionarEmpresa", {
      formatter: formatter,
      onInit: function () {
         var nomeDaAba = "nomeDaAbaPaginaIniciar";
         this._mudarNomeDaAba(nomeDaAba);

         const urlEnum = '/api/Enum';
         this._obterDescricaoEnum(urlEnum);

         this.getRouter().getRoute("appAdicionarEmpresa").attachMatched(this._aoCoincidirRota, this);
      },

      _aoCoincidirRota: function () {
         this.getView().byId("valorInputRazaoSocial").setValueState("None");
         this.getView().byId("valorInputCNPJ").setValueState("None");
         this.getView().byId("selectRamoAdicionar").setValueState("None");
      },

      salvar: function (){
         var razaoSocial = this.getView().byId("valorInputRazaoSocial").getValue();
         var cnpj = this.getView().byId("valorInputCNPJ").getValue();
         cnpj = cnpj.replace(/[^a-z0-9]/gi,'');
         var ramo = this.getView().byId("selectRamoAdicionar").getSelectedKey();

         if(razaoSocial === ""){
            this.getView().byId("valorInputRazaoSocial").setValueState("Error");
            this.getView().byId("valorInputRazaoSocial").setValueStateText("Informe a Razão Social");
         }

         if(cnpj === ""){
            this.getView().byId("valorInputCNPJ").setValueState("Error");
            this.getView().byId("valorInputCNPJ").setValueStateText("Informe o CNPJ");
         }

         if(ramo === "NaoDefinido"){
            this.getView().byId("selectRamoAdicionar").setValueState("Error");
            this.getView().byId("selectRamoAdicionar").setValueStateText("Informe o Ramo");
         }
      }
    });
 
 });