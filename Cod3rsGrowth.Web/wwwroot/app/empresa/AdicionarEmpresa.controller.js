sap.ui.define([
   "ui5/cod3rsgrowth/app/BaseController",
   "../model/formatter",
	"sap/m/MessageBox"
 ], function (BaseController, formatter, MessageBox) {
    "use strict";

    const IdInputRazaoSocial = "valorInputRazaoSocial";
    const IdInputCnpj = "valorInputCNPJ";
    const IdSelectRamo = "selectRamoAdicionar";
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

      _validacaoDeTela: function (empresa){
         const valueStateErro = "Error";

         if(empresa.razaoSocial === razaoSocialECNPJVazio)
            this.getView().byId(IdInputRazaoSocial).setValueState(valueStateErro);
         else 
            this.getView().byId(IdInputRazaoSocial).setValueState(removerValueState);

         if(empresa.cnpj === razaoSocialECNPJVazio)
            this.getView().byId(IdInputCnpj).setValueState(valueStateErro);
         else 
            this.getView().byId(IdInputCnpj).setValueState(removerValueState);

         if(empresa.ramo === ramoNaoDefinido)
            this.getView().byId(IdSelectRamo).setValueState(valueStateErro);
         else 
            this.getView().byId(IdSelectRamo).setValueState(removerValueState);
      }, 

      aoClicarEmCancelar: function (){
			 this.getRouter().navTo("appEmpresa", {}, true);
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
         .then( res => {
               if(!res.ok){
                  res.json()
                  .then(res => {this._mensagemDeErro(res)})
               }
         })
      },

      _mensagemDeErro : function (erro){
			let mensagemDeErro = Object.values(erro.Extensions.ErroDeValidacao).join("\r\n");
			MessageBox.error(`${erro.Title} \n\n ${mensagemDeErro}`, {
			   title: "Error",
            
			   details:
			   `<p><strong>Status: ${erro.Status}</strong></p>` +
			   "<p><strong>Detalhes:</strong></p>" +
			   "<ul>" +
			   `<li>${erro.Detail}</li>` +
			   "</ul>",
			   styleClass: sResponsivePaddingClasses,
			   dependentOn: this.getView()
			});
		 },
    });
 });