sap.ui.define([
   "ui5/cod3rsgrowth/app/BaseController",
   "../model/formatter",
	"sap/m/MessageBox",
   "../servico/validacao",
	"sap/ui/model/json/JSONModel",
 ], function (BaseController, formatter, MessageBox, validacao, JSONModel) {
    "use strict";

    const IdInputRazaoSocial = "idInputRazaoSocial";
    const IdInputCnpj = "idInputCNPJ";
    const IdSelectRamo = "idSelectRamoAdicionar";
    const razaoSocialECNPJVazio = "";
    const ramoNaoDefinido = 0;
    const removerValueState = "None";
	 var sResponsivePaddingClasses = "sapUiResponsivePadding--header sapUiResponsivePadding--content sapUiResponsivePadding--footer";
    var idEmpresaAtualizar = "";

    return BaseController.extend("ui5.cod3rsgrowth.app.empresa.AdicionarEmpresa", {
      formatter: formatter,
      validacao: validacao,
      onInit: function () {
         const nomeDaAba = "nomeDaAbaPaginaIniciar";
         this.mudarNomeDaAba(nomeDaAba);

         const urlEnum = '/api/Enum';
         const viewAtual = this.getView();
         const nomeContexto = "listaEnum";
         this.obterEmpresa(urlEnum, viewAtual, nomeContexto);

         const rotaTelaDeAdicionar = "appAdicionarEmpresa";
         
         this.getRouter().getRoute(rotaTelaDeAdicionar).attachMatched(this._aoCoincidirRota, this);
      },

      _aoCoincidirRota: function (oEvent) {
         this.getView().byId(IdInputRazaoSocial).setValueState(removerValueState);
         this.getView().byId(IdInputRazaoSocial).setValue("");

         this.getView().byId(IdInputCnpj).setValueState(removerValueState);
         this.getView().byId(IdInputCnpj).setValue("");

         this.getView().byId(IdSelectRamo).setValueState(removerValueState);
         this.getView().byId(IdSelectRamo).setSelectedKey(removerValueState);

         idEmpresaAtualizar = this._obterIdPelaRota(oEvent);
         this._verificarSeTemId();
      },

      _obterIdPelaRota: function (oEvent){
         let empresaId = oEvent.getParameters().arguments.empresaId;
         return empresaId;
      },

      _verificarSeTemId: function (){
         if(!idEmpresaAtualizar)
            return;

         const tituloEditar = "Editar Empresa";
         const idTitulo = "idTituloAdicionarEditar";
         this.getView().byId(idTitulo).setText(tituloEditar);
         const viewAtual = this.getView();
         const urlEmpresa = `/api/Empresa/${idEmpresaAtualizar}`;
         this._obterEmpresaAtualizar(urlEmpresa, viewAtual);
      },

      _colocarValorNosCampos:function (empresaAtualizar) {
         var selectRamo = this.getView().byId(IdSelectRamo).getItems();
         var ramo = selectRamo.find((ramoSelecionado) => ramoSelecionado.mProperties.text === empresaAtualizar.ramo);

         this.getView().byId(IdInputRazaoSocial).setValue(empresaAtualizar.razaoSocial);
         const cnpjFormatado = this.formatter.formatarCnpj(empresaAtualizar.cnpj);
         this.getView().byId(IdInputCnpj).setValue(cnpjFormatado);
         this.getView().byId(IdSelectRamo).setSelectedItem(ramo);
      },

      _obterEmpresaAtualizar: function (url, view){
         fetch(url).then(res => {return res.ok? res.json().then(res => {this._colocarValorNosCampos(res)}) :
				res.json().then(res => {this.validacao.mensagemDeErro(res, view)})})
		 },

      _adicionarEmpresaNaApi: function (empresa, requisicao){
         let view = this.getView();
         const url = '/api/Empresa';
         const options = {
            method: requisicao,
            body: JSON.stringify(empresa),
            headers: {
               "Content-Type": "application/json",
            }
         };
         fetch(url, options)
         .then( res => {return !res.ok? 
            res.json().then(res => this.validacao.mensagemDeErro(res, view)) : 
            this.mensageDeSucesso(empresa);
         })
      },
    
      aoClicarEmSalvar: function (){
         let empresa = {};
         empresa.razaoSocial = this.getView().byId(IdInputRazaoSocial).getValue();
         empresa.cnpj = this.getView().byId(IdInputCnpj).getValue();
         empresa.cnpj = empresa.cnpj.replace(/[^a-z0-9]/gi,'');
         empresa.ramo = parseInt(this.getView().byId(IdSelectRamo).getSelectedKey());

         let view = this.getView();
         this.validacao.validacaoDeTela(view, empresa);

         var requisicaoSalvar 
         if(!idEmpresaAtualizar)
            requisicaoSalvar = "Post";
         else{
            requisicaoSalvar = "Patch";
            empresa.id = idEmpresaAtualizar;
         }

         if(empresa.razaoSocial !== razaoSocialECNPJVazio && empresa.cnpj !== razaoSocialECNPJVazio && empresa.ramo !== ramoNaoDefinido)
            this._adicionarEmpresaNaApi(empresa, requisicaoSalvar);
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