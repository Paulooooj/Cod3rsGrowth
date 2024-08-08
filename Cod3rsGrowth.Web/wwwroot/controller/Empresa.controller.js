sap.ui.define([
   "ui5/cod3rsgrowth/controller/BaseController",
   "sap/ui/model/resource/ResourceModel",
   "sap/ui/model/json/JSONModel",
   "../model/formatter",
   "sap/m/MessageBox"
], (BaseController, ResourceModel, JSONModel, formatter, MessageBox) => {
   "use strict";
   let eventoPesquisa = "";
   let eventoCombox = "";

   var sResponsivePaddingClasses = "sapUiResponsivePadding--header sapUiResponsivePadding--content sapUiResponsivePadding--footer";
 
    return BaseController.extend("ui5.cod3rsgrowth.controller.Empresa", {
      formatter: formatter,
      onInit: function () {
         const i18nModel = new ResourceModel({
            bundleName: "ui5.cod3rsgrowth.i18n.i18n"
         });
         this.getView().setModel(i18nModel, "i18n");
         const oBundle = this.getView().getModel("i18n").getResourceBundle();
         const sTitulo = oBundle.getText("nomeDaPaginaEmpresa");
         document.title = sTitulo;

         const urlObterTodos = '/api/Empresa';
         this.buscarApi(urlObterTodos);
         const urlEnum = '/api/Enum';
         this.buscarApiEnum(urlEnum);
      },
      
      onfiltroEmpresa: function (oEvent){
         var evento = oEvent.getSource().getValue();
         eventoPesquisa = evento.replace(/[^a-z0-9]/gi,'');
         var verificarSeECNPJ = RegExp('^[0-9]+$');
         if(!verificarSeECNPJ.test(eventoPesquisa))
            eventoPesquisa = evento;
         this.filtros();
      },
      
      filtroCombobox: function (oEvent){
         eventoCombox = oEvent.getSource().getSelectedKey();
         this.filtros();
      },

      filtros : function (){
         let urlObterTodosUsandoFiltro;
         if(eventoCombox != "Todos"){
            urlObterTodosUsandoFiltro = `/api/Empresa?RazaoSocialECnpj=${eventoPesquisa}&Ramo=${eventoCombox}`;
         }else{
            urlObterTodosUsandoFiltro = `/api/Empresa?RazaoSocialECnpj=${eventoPesquisa}`;
         }
         this.buscarApi(urlObterTodosUsandoFiltro);
      },
      
      buscarApi: function (url){
         const statusOk = 200;

         fetch(url).then(res => res.json()).then(res => {
            if(res.Status && res.Status !== statusOk){
               this.funcaoTesteErro(res);
            }
            const dataModel = new JSONModel();
            res.forEach(element => {
               element.cnpj = this.formatter.formatarCnpj(element.cnpj);
            })
            dataModel.setData(res);
            this.getView().setModel(dataModel, "listaEmpresa")
         })
      },

      funcaoTesteErro : function(erro){
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

      buscarApiEnum: function (url){
         fetch(url).then(res => res.json()).then(res => {
            if(res.Status && res.Status !== statusOk){
               this.funcaoTesteErro(res);
            }
            const dataModel = new JSONModel();
            dataModel.setData(res);
            this.getView().setModel(dataModel, "listaEnum")
        }); 
      }
      
   });
 });