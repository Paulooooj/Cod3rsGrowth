sap.ui.define([
   "ui5/cod3rsgrowth/app/BaseController",
   "sap/ui/model/json/JSONModel",
   "../model/formatter",
   "sap/m/MessageBox"
], (BaseController, JSONModel, formatter) => {
   "use strict";
   let filtroBarraDePesquisa = "";
   let filtroSelect = "";

    return BaseController.extend("ui5.cod3rsgrowth.app.empresa.Empresa", {
      formatter: formatter,
      onInit: function () {
         const rotaTelaDeAdicionar = "appEmpresa";
         this.getRouter().getRoute(rotaTelaDeAdicionar).attachMatched(this._aoCoincidirRota, this);
      },

      _aoCoincidirRota: function () {
         const nomeDaAba = "nomeDaPaginaEmpresa";
         this._mudarNomeDaAba(nomeDaAba);

         const urlObterTodos = '/api/Empresa';
         this._obterTodos(urlObterTodos);

         const urlEnum = '/api/Enum';
         this._obterDescricaoEnum(urlEnum);
      },
      
      _urlDeTodosOsFiltros : function (){
         let query = {};

         if(filtroBarraDePesquisa){
            query.razaoSocialECnpj = filtroBarraDePesquisa;
         }

         if(filtroSelect && filtroSelect != "Todos"){
            query.ramo = filtroSelect;
         }

         let urlObterTodos = '/api/Empresa?' + new URLSearchParams(query);

         this._obterTodos(urlObterTodos);
      },
      
      _obterTodos: function (url){
         let view = this.getView();
         fetch(url).then(res => {return res.ok? 
            res.json() : 
            res.json().then(res => {this.validacao.mensagemDeErro(res, view)})})
            .then(res => {
            const dataModel = new JSONModel();
            res.forEach(element => {
               element.cnpj = this.formatter.formatarCnpj(element.cnpj);
            })
            dataModel.setData(res);
            this.getView().setModel(dataModel, "listaEmpresa")
         })
      },

      filtroBarraDePesquisa: function (oEvent){
         var evento = oEvent.getSource().getValue();
         filtroBarraDePesquisa = evento.replace(/[^a-z0-9]/gi,'');
         var verificarSeECNPJ = RegExp('^[0-9]+$');

         if(!verificarSeECNPJ.test(filtroBarraDePesquisa))
            filtroBarraDePesquisa = evento;
         this._urlDeTodosOsFiltros();
      },
      
      filtroCombobox: function (oEvent){
         filtroSelect = oEvent.getSource().getSelectedKey();
         this._urlDeTodosOsFiltros();
      },

      atualizarTitulo : function (oEvent){
         var sTitle,
				oTable = oEvent.getSource(),
				iTotalItems = oEvent.getParameter("total");
            const oBundle = this.getView().getModel("i18n").getResourceBundle();
			if (iTotalItems && oTable.getBinding("items").isLengthFinal()) {
				sTitle = oBundle.getText("nomeBarraFerramentasEmpresaCount", [iTotalItems]);
			} else {
				sTitle = oBundle.getText("nomeBarraDeFerramentas");
			}
         this.getView().byId("idtituloTabela").setProperty("text", sTitle);
      },

      irParaAdicionarEmpresa: function (){
         this.getRouter().navTo("appAdicionarEmpresa", {}, true);
      }
   });
 });