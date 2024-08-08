QUnit.config.autostart = false;

sap.ui.require(["sap/ui/core/Core"], async(Core) => {
	"use strict";

	await Core.ready();

	sap.ui.require([
		"ui5/cod3rsgrowth/test/integration/EmpresaJourney"
	], () => {
		QUnit.start();
	});
});