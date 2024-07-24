sap.ui.define([
    "sap/ui/core/mvc/Controller"
 ], (Controller) => {
    "use strict";
 
    return Controller.extend("ui5.cod3rsgrowth.controller.App", {
       onShowHello() {
          // show a native JavaScript alert
          alert("Olá, mundo!");
       }
    });
 });