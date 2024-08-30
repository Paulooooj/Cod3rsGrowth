sap.ui.define([
    'sap/ui/test/Opa5',
    './arrangements/Startup',
    './EmpresaJourney',
    './AdicionarEmpresaJourney',
    './DetalhesEmpresaJourney'
], function(Opa5, Startup, EmpresaJourney, AdicionarEmpresaJourney, DetalhesEmpresa) {
    'use strict';
 
    Opa5.extendConfig({
        arrangements: new Startup(),
        viewNamespace: "ui5.cod3rsgrowth.app",
        autoWait: true
    });   
});