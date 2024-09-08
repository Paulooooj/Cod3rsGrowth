sap.ui.define([
   "ui5/cod3rsgrowth/app/BaseController",
  "../model/formatter",
	"sap/m/MessageBox",
   "sap/ui/model/json/JSONModel",
   'sap/ui/core/Fragment',
 ], function (BaseController, formatter, MessageBox, JSONModel, Fragment) {
    "use strict";
    var idEmpresa = "";
    var filtroBarraDePesquisaProduto = "";

    return BaseController.extend("ui5.cod3rsgrowth.app.empresa.DetalhesEmpresa", {
     formatter: formatter,
      onInit: function () {
         const rotaTelaDetalhes = "appDetalhesEmpresa";
         this.getRouter().getRoute(rotaTelaDetalhes).attachMatched(this._aoCoincidirRota, this);
      },

      _aoCoincidirRota: function (oEvent) {
       const nomeDaAba = "nomeAbaPagindaDetalhes";
       this.mudarNomeDaAba(nomeDaAba);

       idEmpresa = this._obterIdPelaRota(oEvent);
       const viewAtual = this.getView();
       const nomeContexto = "empresaDetalhes";
       const urlEmpresa = `/api/Empresa/${idEmpresa}`;
       this.obterEmpresa(urlEmpresa, viewAtual, nomeContexto);

       const urlObterTodos = '/api/Produto';
       this._obterTodos(urlObterTodos);
      },

      _obterIdPelaRota(oEvent){
         let empresaId = oEvent.getParameters().arguments.empresaId
         return empresaId;
      },

      aoClicarDeveIrParaTelaDeEdicao: function (){
         const rotaAtualizar = "appAdicionarEmpresa"; 
         this.getRouter().navTo(rotaAtualizar, {empresaId: idEmpresa}, true); 
      },

      aoClicarDeveRemoverEmpresa: function (){
         const idNomeEmpresa = "idNomeEmpresaTitulo";
         const nomeDaEmpresa = this.getView().byId(idNomeEmpresa).getText();
         const mensagemDeAviso = `Deseja mesmo remover ${nomeDaEmpresa}?`

         this.mensagemDeAviso(mensagemDeAviso, idEmpresa, nomeDaEmpresa);
      },

      _obterTodos: function (url){
         let view = this.getView();
         fetch(url).then(res => {return res.ok? 
            res.json() : 
            res.json().then(res => {this.validacao.mensagemDeErro(res, view)})})
            .then(res => {
            const dataModel = new JSONModel();
            res = res.filter((produto) => produto.empresaId == idEmpresa);
            dataModel.setData(res);
            this.getView().setModel(dataModel, "listaProduto")
         })
      },

      buscarPorProduto: function (oEvent){
         filtroBarraDePesquisaProduto = oEvent.getSource().getValue();
         this._urlTodosOsFiltros();
      },

      _urlTodosOsFiltros: function(){
         let query = {};
         query.nome = filtroBarraDePesquisaProduto;

         let urlFiltro = `/api/Produto?` + new URLSearchParams(query);
         this._obterTodos(urlFiltro);
      },

      filterResetValue: 50,
		filterPreviousValue: 50,

		handleViewSettingsDialogPress: function () {
			var oView = this.getView();

			if (!this._pDialog) {
				this._pDialog = Fragment.load({
					id: oView.getId(),
					name: "ui5.cod3rsgrowth.app.Fragment.Filtro",
					controller: this
				})
			}
			this._pDialog.then(function(oDialog){
				oDialog.setModel(oView.getModel());
				oDialog.open();
			});
		},

		

		handleConfirm: function (oEvent) {
			var oSlider = this.byId("settingsDialog").getFilterItems()[0].getCustomControl();
			this.filterPreviousValue = oSlider.getValue();
			if (oEvent.getParameters().filterString) {
				MessageToast.show(oEvent.getParameters().filterString + " Value is " + oSlider.getValue());
			}
		},

		handleCancel: function () {
			var oCustomFilter = this.byId("settingsDialog").getFilterItems()[0],
				oSlider = oCustomFilter.getCustomControl();

			oSlider.setValue(this.filterPreviousValue);

			if (this.filterPreviousValue !== this.filterResetValue) {
				oCustomFilter.setFilterCount(1);
				oCustomFilter.setSelected(true);
			} else {
				oCustomFilter.setFilterCount(0);
				oCustomFilter.setSelected(false);
			}
		},

		handleResetFilters: function () {
			var oCustomFilter = this.byId("settingsDialog").getFilterItems()[0],
				oSlider = oCustomFilter.getCustomControl();
			oSlider.setValue(this.filterResetValue);
			oCustomFilter.setFilterCount(0);
			oCustomFilter.setSelected(false);
		}
    });
 });