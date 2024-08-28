sap.ui.define([
    "ui5/cod3rsgrowth/app/BaseController",
  ], function (BaseController) {
     "use strict";
        var empresaId = 0;
     return BaseController.extend("ui5.cod3rsgrowth.app.empresa.DetalhesEmpresa", {
       onInit: function () {
          const rotaTelaDetalhes = "appDetalhesEmpresa";
          this.getRouter().getRoute(rotaTelaDetalhes).attachMatched(this._aoCoincidirRota, this);
       },
 
       _aoCoincidirRota: function () {
        const nomeDaAba = "nomeDaAbaPaginaIniciar";
        this.mudarNomeDaAba(nomeDaAba);

        const posicaoDoId = 1;
        empresaId = this.getOwnerComponent().getRouter().getHashChanger().getHash().split("/")[posicaoDoId];
       },
     });
  });