sap.ui.define([
    'sap/ui/test/Opa5',
    './arrangements/Startup',
    './EmpresaJourney',
    './AdicionarEmpresaJourney'
], function(Opa5, Startup, EmpresaJourney, AdicionarEmpresaJourney) {
    'use strict';
 
    Opa5.extendConfig({
        arrangements: new Startup(),
        viewNamespace: "ui5.cod3rsgrowth.app",
        autoWait: true
    });   
});