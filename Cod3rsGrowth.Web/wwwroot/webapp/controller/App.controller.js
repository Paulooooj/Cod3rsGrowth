sap.ui.define([
    "sap/ui/core/mvc/Controller"
 ], (Controller) => {
    "use strict";
 
    return Controller.extend("ui5.Cod3rsGrowth.controller.App", {
       onShowHello() {
          // show a native JavaScript alert
          alert("Hello World");
       }
    });
 });