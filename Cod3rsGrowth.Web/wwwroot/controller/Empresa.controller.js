sap.ui.define([
   "ui5/cod3rsgrowth/controller/BaseController",
   "sap/ui/model/resource/ResourceModel",
   "sap/ui/model/json/JSONModel",
   "../model/formatter"
], (BaseController, ResourceModel, JSONModel, formatter) => {
   "use strict";
   let eventoPesquisa = "";
   let eventoCombox = "";
 
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
      },
      
      formatarCnpj: function (cnpj)
      {
          return cnpj.replace(/(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})/, '$1.$2.$3/$4-$5');
      },

      onfiltroEmpresa: function (oEvent){
         var teste = oEvent.getSource().getValue();
         eventoPesquisa = teste.replace(/[^a-z0-9]/gi,'')
         this.filtros();
      },

      filtroCombobox: function (oEvent){
         eventoCombox = oEvent.getSource().getValue();
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
         fetch(url).then(res => res.json()).then(res => {
            const dataModel = new JSONModel();
            var teste = res;
            teste.forEach(element => {
              element.cnpj = this.formatarCnpj(element.cnpj);
            });
            dataModel.setData(teste);
            dataModel
            this.getView().setModel(dataModel, "listaEmpresa")
        })
      }
    });
 
 });