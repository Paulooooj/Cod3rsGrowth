sap.ui.define([
   "ui5/cod3rsgrowth/app/BaseController",
   "../model/formatter",
	"sap/m/MessageBox",
   "../servico/validacao",
   "../model/formatter",
 ], function (BaseController, formatter, MessageBox, validacao, formatter) {
    "use strict";
    const IdInputRazaoSocial = "idInputRazaoSocial";
    const IdInputCnpj = "idInputCNPJ";
    const IdSelectRamo = "idSelectRamoAdicionar";
    const removerValueState = "None";
    var idEmpresaAtualizar = "";

    return BaseController.extend("ui5.cod3rsgrowth.app.empresa.AdicionarEmpresa", {
      formatter: formatter,
      validacao: validacao,
      onInit: function () {
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

         idEmpresaAtualizar = "";
         idEmpresaAtualizar = this._obterIdPelaRota(oEvent);
         if (!!idEmpresaAtualizar){
            const nomeDaAba = "nomeDaAbaPaginaEditar";
            this.mudarNomeDaAba(nomeDaAba);
            const nomeTituloEditar = "tituloPaginaEditar";
            this._mudarTituto(nomeTituloEditar);
            this._fazerUrlRequisicaoPreencherCamposEditar();
         }
         else {
            const nomeDaAba = "nomeDaAbaPaginaAdicionarEmpresa";
            this.mudarNomeDaAba(nomeDaAba);
            const nomeTituloAdicionar = "nomeTituloAdicionar";
            this._mudarTituto(nomeTituloAdicionar);
         }
      },

      _obterIdPelaRota: function (oEvent){
         let empresaId = oEvent.getParameters().arguments.empresaId;
         return empresaId;
      },

      _mudarTituto: function (nomeTitulo) {
         const propriedade = "i18n";
         const propiedadeI18n = this.getView().getModel(propriedade).getResourceBundle();
         const tituloEditar = propiedadeI18n.getText(nomeTitulo);
         const idTitulo = "idTituloAdicionarEditar";
         this.getView().byId(idTitulo).setText(tituloEditar);
      },

      _fazerUrlRequisicaoPreencherCamposEditar: function (){
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
         fetch(url)
            .then(res => 
            {
               return res.ok? 
                  res.json().then(res => {this._colocarValorNosCampos(res)}) :
                  res.json().then(res => {this.validacao.mensagemDeErro(res, view)})
            })
		 },
    
      aoClicarEmSalvar: function (){
         let empresa = {};
         empresa.razaoSocial = this.getView().byId(IdInputRazaoSocial).getValue();
         empresa.cnpj = this.getView().byId(IdInputCnpj).getValue();
         empresa.cnpj = empresa.cnpj.replace(/[^a-z0-9]/gi,'');
         empresa.ramo = parseInt(this.getView().byId(IdSelectRamo).getSelectedKey());

         let view = this.getView();
         var verificarValidacao = this.validacao.validacaoDeTela(view, empresa);
         let requisicaoSalvar = "Post";

         if(idEmpresaAtualizar){
            requisicaoSalvar = "Patch";
            empresa.id = idEmpresaAtualizar;
         }

         if(verificarValidacao)
            this.adicionarEAtualizarEmpresa(empresa, requisicaoSalvar);
      }, 

      aoClicarEmCancelar: function (){
         const mensagemDeAviso = `Deseja mesmo cancelar?`;
         this.mensagemDeAviso(mensagemDeAviso, idEmpresaAtualizar);
      },
    });
 });