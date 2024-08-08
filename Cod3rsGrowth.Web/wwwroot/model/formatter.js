sap.ui.define([], () => {
    "use strict";
return{
    formatarCnpj: function (cnpj)
    {
        return cnpj.replace(/(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})/, '$1.$2.$3/$4-$5');
    },
    
    formatarValorPadraoCombobox : function(ramo)
    {
        const oResourceBundle = this.getOwnerComponent().getModel("i18n").getResourceBundle();
        if(ramo === "Não Definido"){
            return oResourceBundle.getText("enumNaoDevinido");
        }
        return ramo;
    }
    }
});