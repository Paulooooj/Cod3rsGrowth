sap.ui.define([
   "ui5/cod3rsgrowth/app/BaseController",
   "sap/ui/model/resource/ResourceModel",
   "sap/ui/model/json/JSONModel",
   "../model/formatter",
   "sap/m/MessageBox"
], (BaseController, ResourceModel, JSONModel, formatter, MessageBox) => {
   "use strict";
   let eventoBarraDePesquisa = "";
   let eventoCombobox = "";

   var sResponsivePaddingClasses = "sapUiResponsivePadding--header sapUiResponsivePadding--content sapUiResponsivePadding--footer";
 
    return BaseController.extend("ui5.cod3rsgrowth.app.empresa.Empresa", {
      formatter: formatter,
      onInit: function () {
         this.mudarNomeDaAba();

         const urlObterTodos = '/api/Empresa';
         this.buscarApi(urlObterTodos);

         const urlEnum = '/api/Enum';
         this.buscarApiEnum(urlEnum);
      },

      mudarNomeDaAba: function () 
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
         eventoBarraDePesquisa = evento.replace(/[^a-z0-9]/gi,'');
         var verificarSeECNPJ = RegExp('^[0-9]+$');
         if(!verificarSeECNPJ.test(eventoBarraDePesquisa))
            eventoBarraDePesquisa = evento;
         this.filtros();
      },
      
      filtroCombobox: function (oEvent){
         eventoCombobox = oEvent.getSource().getSelectedKey();
         this.filtros();
      },

      filtros : function (){
         let urlObterTodosUsandoFiltro;
         if(eventoCombobox != "Todos"){
            urlObterTodosUsandoFiltro = `/api/Empresa?RazaoSocialECnpj=${eventoBarraDePesquisa}&Ramo=${eventoCombobox}`;
         }else{
            urlObterTodosUsandoFiltro = `/api/Empresa?RazaoSocialECnpj=${eventoBarraDePesquisa}`;
         }
         this.buscarApi(urlObterTodosUsandoFiltro);
      },
      
      
      buscarApi: function (url){
         const statusOk = 200;
         
         fetch(url).then(res => res.json()).then(res => {
            if(res.Status && res.Status !== statusOk){
               this.mensagemDeErro(res);
            }
            const dataModel = new JSONModel();
            res.forEach(element => {
               element.cnpj = this.formatter.formatarCnpj(element.cnpj);
            })
            dataModel.setData(res);
            this.getView().setModel(dataModel, "listaEmpresa")
         })
      },
      
      buscarApiEnum: function (url){
         fetch(url).then(res => res.json()).then(res => {
            if(res.Status && res.Status !== statusOk){
               this.mensagemDeErro(res);
            }
            const dataModel = new JSONModel();
            dataModel.setData(res);
            this.getView().setModel(dataModel, "listaEnum")
         }); 
      },

      mensagemDeErro : function (erro){
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
      }
      
   });
 });