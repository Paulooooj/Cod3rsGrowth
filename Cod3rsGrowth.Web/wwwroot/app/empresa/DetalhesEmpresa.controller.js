sap.ui.define([
   "ui5/cod3rsgrowth/app/BaseController",
   "sap/ui/model/json/JSONModel",
  "../model/formatter",
	"sap/m/MessageBox"
 ], function (BaseController, JSONModel, formatter, MessageBox) {
    "use strict";
    var idEmpresa = "";
	 var sResponsivePaddingClasses = "sapUiResponsivePadding--header sapUiResponsivePadding--content sapUiResponsivePadding--footer";

    return BaseController.extend("ui5.cod3rsgrowth.app.empresa.DetalhesEmpresa", {
     formatter: formatter,
      onInit: function () {
         const rotaTelaDetalhes = "appDetalhesEmpresa";
         this.getRouter().getRoute(rotaTelaDetalhes).attachMatched(this._aoCoincidirRota, this);
      },

      _aoCoincidirRota: function (oEvent) {
       const nomeDaAba = "nomeDaAbaPaginaIniciar";
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
         this.getRouter().navTo(rotaAtualizar, {empresaId: idEmpresa}); 
      },

      aoClicarDeveRemoverEmpresa: function (){
         const idNomeEmpresa = "idNomeEmpresaTitulo";
         const nomeDaEmpresa = this.getView().byId(idNomeEmpresa).getText();
         const mensagemDeAviso = `Deseja mesmo remover ${nomeDaEmpresa}?`

         MessageBox.warning(mensagemDeAviso, {
            styleClass: sResponsivePaddingClasses,
            dependentOn: this.getView(),
            actions: [MessageBox.Action.OK, MessageBox.Action.CANCEL],
            onClose: (sAction) => {
               if(sAction == MessageBox.Action.OK){
                  let url = `/api/Empresa/${idEmpresa}`;
                  this.deletarEmpresa(url, nomeDaEmpresa);
               }
            }
         })
      },
      
      deletarEmpresa: function (url, empresa){
         const mensagemDeSucesso = `${empresa} foi removido com sucesso!`
         fetch(url, {
            method: "DELETE",
         })
         .then(res => {return !res.ok? 
			   res.json().then(res => this.validacao.mensagemDeErro(res, view)) : 
			   this.mensageDeSucesso(mensagemDeSucesso);
			})
      }
    });
 });