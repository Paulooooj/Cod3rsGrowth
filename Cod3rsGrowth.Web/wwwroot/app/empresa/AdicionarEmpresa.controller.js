sap.ui.define([
   "ui5/cod3rsgrowth/app/BaseController",
   "../model/formatter",
   "sap/ui/model/json/JSONModel"
 ], function (BaseController, formatter, JSONModel) {
    "use strict";
    return BaseController.extend("ui5.cod3rsgrowth.app.empresa.AdicionarEmpresa", {
      formatter: formatter,
      onInit: function () {
         const urlEnum = '/api/Enum';
         this._obterDescricaoEnum(urlEnum);
      },

      _obterDescricaoEnum: function (url){
         fetch(url).then(res => {return res.ok? res.json() : res.json().then(res => {this._mensagemDeErro(res)})}).then(res => {
            const dataModel = new JSONModel();
            dataModel.setData(res);
            this.getView().setModel(dataModel, "listaEnum")
         }); 
      },
    });
 
 });