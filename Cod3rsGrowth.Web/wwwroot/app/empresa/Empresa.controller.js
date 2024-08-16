sap.ui.define([
   "ui5/cod3rsgrowth/app/BaseController",
   "sap/ui/model/resource/ResourceModel",
   "sap/ui/model/json/JSONModel",
   "../model/formatter",
   "sap/m/MessageBox"
], (BaseController, ResourceModel, JSONModel, formatter, MessageBox) => {
   "use strict";
   let filtroBarraDePesquisa = "";
   let filtroSelect = "";

   var sResponsivePaddingClasses = "sapUiResponsivePadding--header sapUiResponsivePadding--content sapUiResponsivePadding--footer";
 
    return BaseController.extend("ui5.cod3rsgrowth.app.empresa.Empresa", {
      formatter: formatter,
      onInit: function () {
         this._mudarNomeDaAba();

         this.getView().setBusyIndicatorDelay(0);
         this.getView().setBusy(true);
         const urlObterTodos = '/api/Empresa';
         this._obterTodos(urlObterTodos);

         const urlEnum = '/api/Enum';
         this._obterDescricaoEnum(urlEnum);
      },

      _mudarNomeDaAba: function () 
      {
         const i18nModel = new ResourceModel({
            bundleName: "ui5.cod3rsgrowth.i18n.i18n"
         });
         this.getView().setModel(i18nModel, "i18n");
         const oBundle = this.getView().getModel("i18n").getResourceBundle();
         const sTitulo = oBundle.getText("nomeDaPaginaEmpresa");
         document.title = sTitulo;
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
         let urlObterTodosUsandoFiltro;
         if(filtroSelect != "Todos"){
            urlObterTodosUsandoFiltro = `/api/Empresa?RazaoSocialECnpj=${filtroBarraDePesquisa}&Ramo=${filtroSelect}`;
         }else{
            urlObterTodosUsandoFiltro = `/api/Empresa?RazaoSocialECnpj=${filtroBarraDePesquisa}`;
         }
         this._obterTodos(urlObterTodosUsandoFiltro);
      },
      
      _obterTodos: function (url){
         fetch(url).then(res => {return res.ok? res.json() : res.json().then(res => {this._mensagemDeErro(res)})}).then(res => {
            this.getView().setBusy(false);
            const dataModel = new JSONModel();
            res.forEach(element => {
               element.cnpj = this.formatter.formatarCnpj(element.cnpj);
            })
            dataModel.setData(res);
            this.getView().setModel(dataModel, "listaEmpresa")
         })
      },
      
      _obterDescricaoEnum: function (url){
         fetch(url).then(res => {return res.ok? res.json() : res.json().then(res => {this._mensagemDeErro(res)})}).then(res => {
            const dataModel = new JSONModel();
            dataModel.setData(res);
            this.getView().setModel(dataModel, "listaEnum")
         }); 
      },

      _mensagemDeErro : function (erro){
         MessageBox.error(`${erro.Title}`, {
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