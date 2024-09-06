sap.ui.define([
   "ui5/cod3rsgrowth/app/BaseController",
  "../model/formatter",
	"sap/m/MessageBox"
 ], function (BaseController, formatter, MessageBox) {
    "use strict";
    var idEmpresa = "";

    return BaseController.extend("ui5.cod3rsgrowth.app.empresa.DetalhesEmpresa", {
     formatter: formatter,
      onInit: function () {
         const rotaTelaDetalhes = "appDetalhesEmpresa";
         this.getRouter().getRoute(rotaTelaDetalhes).attachMatched(this._aoCoincidirRota, this);
      },

      _aoCoincidirRota: function (oEvent) {
       const nomeDaAba = "nomeAbaPagindaDetalhes";
       this.mudarNomeDaAba(nomeDaAba);

       idEmpresa = this._obterIdPelaRota(oEvent);
       const viewAtual = this.getView();
       const nomeContexto = "empresaDetalhes";
       const urlEmpresa = `/api/Empresa/${idEmpresa}`;
       this.obterEmpresa(urlEmpresa, viewAtual, nomeContexto);
      },

      _obterIdPelaRota(oEvent){
         let empresaId = oEvent.getParameters().arguments.empresaId
         return empresaId;
      },

      aoClicarDeveIrParaTelaDeEdicao: function (){
         const rotaAtualizar = "appAdicionarEmpresa"; 
         this.getRouter().navTo(rotaAtualizar, {empresaId: idEmpresa}, true); 
      },

      aoClicarDeveRemoverEmpresa: function (){
         const idNomeEmpresa = "idNomeEmpresaTitulo";
         const nomeDaEmpresa = this.getView().byId(idNomeEmpresa).getText();
         const mensagemDeAviso = `Deseja mesmo remover ${nomeDaEmpresa}?`

         this.mensagemDeAviso(mensagemDeAviso, idEmpresa, nomeDaEmpresa);
      },
    });
 });