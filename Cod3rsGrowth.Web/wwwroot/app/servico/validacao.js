sap.ui.define([
    "sap/m/MessageBox",
], function (MessageBox) {
    "use strict";
    var sResponsivePaddingClasses = "sapUiResponsivePadding--header sapUiResponsivePadding--content sapUiResponsivePadding--footer";

return ("ui5.cod3rsgrowth.app.empresa.AdicionarEmpresa",{
        validacaoDeTela: function (view, empresa){
            const valueStateErro = "Error";
            const razaoSocialECNPJVazio = "";
            const IdInputRazaoSocial = "idInputRazaoSocial";
            const IdInputCnpj = "idInputCNPJ";
            const IdSelectRamo = "idSelectRamoAdicionar";
            const removerValueState = "None";
            const ramoNaoDefinido = 0;

            if(empresa.razaoSocial  === razaoSocialECNPJVazio || empresa.razaoSocial.trim() === razaoSocialECNPJVazio)
                view.byId(IdInputRazaoSocial).setValueState(valueStateErro);
            else
                view.byId(IdInputRazaoSocial).setValueState(removerValueState);
        
            empresa.cnpj === razaoSocialECNPJVazio? 
                view.byId(IdInputCnpj).setValueState(valueStateErro) : 
                view.byId(IdInputCnpj).setValueState(removerValueState);

            empresa.ramo === ramoNaoDefinido? 
                view.byId(IdSelectRamo).setValueState(valueStateErro) : 
                view.byId(IdSelectRamo).setValueState(removerValueState);

            if(empresa.razaoSocial && empresa.cnpj && empresa.ramo){
                return true;
            }
        },

        mensagemDeErro : function (erro, view){
            const tituloErroDeValidacao = "Erro de Validação!";
            const tituloDeErro = "Erro";

            if(erro.Title == tituloErroDeValidacao){
                let mensagemDeErro = Object.values(erro.Extensions.ErroDeValidacao).join("\r\n");
                MessageBox.error(`${erro.Title} \n\n ${mensagemDeErro}`, {
                title: tituloDeErro,
                details:
                `<p><strong>Status: ${erro.Status}</strong></p>` +
                "<p><strong>Detalhes:</strong></p>" +
                "<ul>" +
                `<li>${erro.Detail}</li>` +
                "</ul>",
                styleClass: sResponsivePaddingClasses,
                dependentOn: view
                });
            }
            else {
                MessageBox.error(`${erro.Title}`, {
                    title: tituloDeErro,
                    details:
                    `<p><strong>Status: ${erro.Status}</strong></p>` +
                    "<p><strong>Detalhes:</strong></p>" +
                    "<ul>" +
                    `<li>${erro.Detail}</li>` +
                    "</ul>",
                    styleClass: sResponsivePaddingClasses,
                    dependentOn: view
                });
            }
        },
    })
});