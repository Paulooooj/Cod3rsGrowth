sap.ui.define([
   "ui5/cod3rsgrowth/app/BaseController",
   "sap/ui/model/json/JSONModel",
   "../model/formatter",
   "sap/m/MessageBox"
], (BaseController, JSONModel, formatter, MessageBox) => {
   "use strict";
   let filtroBarraDePesquisa = "";
   let filtroSelect = "";

   var sResponsivePaddingClasses = "sapUiResponsivePadding--header sapUiResponsivePadding--content sapUiResponsivePadding--footer";
 
    return BaseController.extend("ui5.cod3rsgrowth.app.empresa.Empresa", {
      formatter: formatter,
      onInit: function () {
         const nomeDaAba = "nomeDaPaginaEmpresa";
         this._mudarNomeDaAba(nomeDaAba);

         const urlObterTodos = '/api/Empresa';
         this._obterTodos(urlObterTodos);

         const urlEnum = '/api/Enum';
         this._obterDescricaoEnum(urlEnum);
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
         fetch(url).then(res => {return res.ok? res.json() : res.json().then(res => {this._mensagemDeErro(res)})}).then(res => {
            const dataModel = new JSONModel();
            res.forEach(element => {
               debugger;
               element.cnpj = this.formatter.formatarCnpj(element.cnpj);
            })
            dataModel.setData(res);
            this.getView().setModel(dataModel, "listaEmpresa")
         })
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

      _mensagemDeErro : function (erro){
			MessageBox.error(`${erro.Title}`, {
			   title: "Error",
			   details: A
			   `<p><strong>Status: ${erro.Status}</strong></p>` +
			   "<p><strong>Detalhes:</strong></p>" +
			   "<ul>" +
			   `<li>${erro.Detail}</li>` +
			   "</ul>",
			   styleClass: sResponsivePaddingClasses,
			   dependentOn: this.getView()
			});
		 },

      irParaAdicionarEmpresa: function (){
         this.getRouter().navTo("appAdicionarEmpresa", {}, true);
      }
   });
 });