sap.ui.define([
   "ui5/cod3rsgrowth/app/BaseController",
   "sap/ui/model/json/JSONModel",
  "../model/formatter",
 ], function (BaseController, JSONModel, formatter) {
    "use strict";
    return BaseController.extend("ui5.cod3rsgrowth.app.empresa.DetalhesEmpresa", {
     formatter: formatter,
      onInit: function () {
         const rotaTelaDetalhes = "appDetalhesEmpresa";
         this.getRouter().getRoute(rotaTelaDetalhes).attachMatched(this._aoCoincidirRota, this);
      },

      _aoCoincidirRota: function (oEvent) {
       const nomeDaAba = "nomeDaAbaPaginaIniciar";
       this.mudarNomeDaAba(nomeDaAba);

       let empresaId = this._obterIdPelaRota(oEvent);
       const viewAtual = this.getView();
       const nomeContexto = "empresaDetalhes";
       const urlEmpresa = `/api/Empresa/${empresaId}`;
       this.obterEmpresa(urlEmpresa, viewAtual, nomeContexto);
      },

      _obterIdPelaRota(oEvent){
         let empresaId = oEvent.getParameters().arguments.empresaId
         return empresaId;
      }
    });
 });