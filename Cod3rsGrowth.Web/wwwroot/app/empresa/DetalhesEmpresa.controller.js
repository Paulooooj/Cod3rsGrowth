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

      _aoCoincidirRota: function () {
       const nomeDaAba = "nomeDaAbaPaginaIniciar";
       this.mudarNomeDaAba(nomeDaAba);

       const posicaoDoId = 1;
       var empresaId = this.getOwnerComponent().getRouter().getHashChanger().getHash().split("/")[posicaoDoId];

       const viewAtual = this.getView();
       const nomeContexto = "empresaDetalhes";
       const urlEmpresa = `/api/Empresa/${empresaId}`;
       this.obterEmpresa(urlEmpresa, viewAtual, nomeContexto);
      },
    });
 });