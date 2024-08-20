sap.ui.define([
   "ui5/cod3rsgrowth/app/BaseController",
   "../model/formatter",
 ], function (BaseController, formatter, JSONModel) {
    "use strict";

    const IdInputRazaoSocial = "valorInputRazaoSocial";
    const IdInputCnpj = "valorInputCNPJ";
    const IdSelectRamo = "selectRamoAdicionar";
    const razaoSocialECNPJVazio = "";
    const ramoNaoDefinido = "NaoDefinido";

    return BaseController.extend("ui5.cod3rsgrowth.app.empresa.AdicionarEmpresa", {
      formatter: formatter,
      onInit: function () {
         const nomeDaAba = "nomeDaAbaPaginaIniciar";
         this._mudarNomeDaAba(nomeDaAba);

         const urlEnum = '/api/Enum';
         this._obterDescricaoEnum(urlEnum);

         const rotaTelaDeAdicionar = "appAdicionarEmpresa";
         this.getRouter().getRoute(rotaTelaDeAdicionar).attachMatched(this._aoCoincidirRota, this);
      },

      _aoCoincidirRota: function () {
         const valueStateNenhum = "None";

         this.getView().byId(IdInputRazaoSocial).setValueState(valueStateNenhum);
         this.getView().byId(IdInputRazaoSocial).setValue("");

         this.getView().byId(IdInputCnpj).setValueState(valueStateNenhum);
         this.getView().byId(IdInputCnpj).setValue("");

         this.getView().byId(IdSelectRamo).setValueState(valueStateNenhum);
         this.getView().byId(IdSelectRamo).setSelectedKey(valueStateNenhum);
      },

      salvar: function (){
         var razaoSocial = this.getView().byId(IdInputRazaoSocial).getValue();
         var cnpj = this.getView().byId(IdInputCnpj).getValue();
         cnpj = cnpj.replace(/[^a-z0-9]/gi,'');
         var ramo = this.getView().byId(IdSelectRamo).getSelectedKey();

         this._validacaoDeTela(razaoSocial, cnpj, ramo);

         if(razaoSocial !== razaoSocialECNPJVazio && cnpj !== razaoSocialECNPJVazio && ramo !== ramoNaoDefinido)
            debugger;
      }, 

      _validacaoDeTela: function (razaoSocial, cnpj, ramo){
         const valueStateErro = "Error";
         const valueStateSucesso = "None";

         if(razaoSocial === razaoSocialECNPJVazio)
            this.getView().byId(IdInputRazaoSocial).setValueState(valueStateErro);
         else 
            this.getView().byId(IdInputRazaoSocial).setValueState(valueStateSucesso);

         if(cnpj === razaoSocialECNPJVazio)
            this.getView().byId(IdInputCnpj).setValueState(valueStateErro);
         else 
            this.getView().byId(IdInputCnpj).setValueState(valueStateSucesso);

         if(ramo === ramoNaoDefinido)
            this.getView().byId(IdSelectRamo).setValueState(valueStateErro);
         else 
            this.getView().byId(IdSelectRamo).setValueState(valueStateSucesso);
      }
    });
 });