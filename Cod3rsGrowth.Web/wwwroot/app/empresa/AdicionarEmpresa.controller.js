sap.ui.define([
   "ui5/cod3rsgrowth/app/BaseController",
   "../model/formatter",
	"sap/m/MessageBox"
 ], function (BaseController, formatter, MessageBox) {
    "use strict";

    const IdInputRazaoSocial = "idInputRazaoSocial";
    const IdInputCnpj = "idInputCNPJ";
    const IdSelectRamo = "idSelectRamoAdicionar";
    const razaoSocialECNPJVazio = "";
    const ramoNaoDefinido = 0;
    const removerValueState = "None";
	 var sResponsivePaddingClasses = "sapUiResponsivePadding--header sapUiResponsivePadding--content sapUiResponsivePadding--footer";

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
         this.getView().byId(IdInputRazaoSocial).setValueState(removerValueState);
         this.getView().byId(IdInputRazaoSocial).setValue("");

         this.getView().byId(IdInputCnpj).setValueState(removerValueState);
         this.getView().byId(IdInputCnpj).setValue("");

         this.getView().byId(IdSelectRamo).setValueState(removerValueState);
         this.getView().byId(IdSelectRamo).setSelectedKey(removerValueState);
      },

      _validacaoDeTela: function (empresa){
         const valueStateErro = "Error";

         if(empresa.razaoSocial  === razaoSocialECNPJVazio || empresa.razaoSocial.trim() === razaoSocialECNPJVazio)
            this.getView().byId(IdInputRazaoSocial).setValueState(valueStateErro);
         else
            this.getView().byId(IdInputRazaoSocial).setValueState(removerValueState);
       
         empresa.cnpj == razaoSocialECNPJVazio? 
         this.getView().byId(IdInputCnpj).setValueState(valueStateErro) : 
         this.getView().byId(IdInputCnpj).setValueState(removerValueState);

         empresa.ramo == ramoNaoDefinido? 
         this.getView().byId(IdSelectRamo).setValueState(valueStateErro) : 
         this.getView().byId(IdSelectRamo).setValueState(removerValueState);
      },

      _adicionarEmpresaAoBancoDeDados: function (empresa){
         const url = '/api/Empresa';
         const options = {
            method: 'Post',
            body: JSON.stringify(empresa),
            headers: {
               "Content-Type": "application/json",
            }
         };

         fetch(url, options)
         .then( res => {return !res.ok? 
            res.json().then(res => this._mensagemDeErro(res)) : 
            this._mensageDeSucesso(empresa);
         })
      },

      _mensageDeSucesso: function (empresa){
         const mensagemDeSucesso = `${empresa.razaoSocial} foi adicionado com sucesso!`
         MessageBox.success(mensagemDeSucesso, {
            id: "messageBoxSucesso",
            styleClass: sResponsivePaddingClasses,
            dependentOn: this.getView(),
            actions: [MessageBox.Action.OK],
            onClose: (sAction) => {
               if(sAction == MessageBox.Action.OK){
				      this.getRouter().navTo("appEmpresa", {}, true);
               }
            }
         })
      },

      aoClicarEmSalvar: function (){
         let empresa = {};
         empresa.razaoSocial = this.getView().byId(IdInputRazaoSocial).getValue();
         empresa.cnpj = this.getView().byId(IdInputCnpj).getValue();
         empresa.cnpj = empresa.cnpj.replace(/[^a-z0-9]/gi,'');
         empresa.ramo = parseInt(this.getView().byId(IdSelectRamo).getSelectedKey());

         this._validacaoDeTela(empresa);

         if(empresa.razaoSocial !== razaoSocialECNPJVazio && empresa.cnpj !== razaoSocialECNPJVazio && empresa.ramo !== ramoNaoDefinido)
            this._adicionarEmpresaAoBancoDeDados(empresa);
      }, 

      aoClicarEmCancelar: function (){
         const mensagemDeSucesso = `Deseja mesmo cancelar?`
         MessageBox.warning(mensagemDeSucesso, {
            styleClass: sResponsivePaddingClasses,
            dependentOn: this.getView(),
            actions: [MessageBox.Action.OK, MessageBox.Action.CANCEL],
            onClose: (sAction) => {
               if(sAction == MessageBox.Action.OK){
				      this.getRouter().navTo("appEmpresa", {}, true);
               }
            }
         })
      },
    });
 });