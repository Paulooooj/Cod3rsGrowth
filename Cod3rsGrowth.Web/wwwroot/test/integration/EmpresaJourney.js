sap.ui.define([
	"sap/ui/test/opaQunit",
	"./pages/Empresa"
], (opaTest, Empresa) => {
	"use strict";

	QUnit.module("Lista Empresa");

	opaTest("Deve ser capaz de verificar se a tabela tem paginação", function (Given, When, Then) {
		Given.euInicioMinhaApp();

		Then
			.EmpresaPage
			.verificarSeTemPaginacaoNaTabela();
	});

	opaTest("Deve verificar se a quantidade de empresas mostradas no título está correta", function (Given, When, Then){
		Then
			.EmpresaPage
			.oDisplayDeveTerOTantoDeItems();
	});

	opaTest("Deve ao passar um nome inválido na barra de pesquisa e não encontrar nada", function(Given, When, Then){
		When
			.EmpresaPage
			.bucarPor("Empresa Teste");

		Then
			.EmpresaPage
			.aoPassarNomeInvalidoNaoDeveFiltrar();
	});

	opaTest("Deve verificar se é possível selecionar um ramo na select", function(Given, When, Then) {
		When
			.EmpresaPage
			.selecionarCombobox();

		Then
			.EmpresaPage
			.verificarItemSelecionadoCombobox();
	});

	opaTest("Deve ser capaz de pesquisar por um item especifico usando a barra de pesquisa", function (Given, When, Then) {
		When
			.EmpresaPage
			.filtrarPorRamo("Todos")

		When
			.EmpresaPage
			.bucarPor("Apple");

		Then
			.EmpresaPage
			.verificarSeTabelaFiltrouUsandoBarraDePesquisa();
	});

	opaTest("Deve filtrar junto com o filtro anterior da barra de pesquisa, filtrar pelo select escolhendo Indústria e encontrar só uma empresa", function(Given, When, Then) {
		When
			.EmpresaPage
			.filtrarPorRamo("Indústria");

		Then
			.EmpresaPage
			.verificarQuantidadeEmpresasFiltradasPorBarraDePesquisaECombobox();
	});

	opaTest("Deve limpar todos os filtros", function(Given, When, Then){

		When
			.EmpresaPage
			.bucarPor(" ");

		When
			.EmpresaPage
			.filtrarPorRamo("Todos")

		Then
			.EmpresaPage
			.verificarSeParouDeFiltrar();
	});

	opaTest("Deve verificar se está filtrando corretamente o select de ramo, filtrando por Comércio", function(Given, When, Then) {
		When
			.EmpresaPage
			.filtrarPorRamo("Comércio");

		Then
			.EmpresaPage
			.verificarQuantidadeEmpresasFiltradasSomentePorComercio();
	});

	opaTest("Deve verificar se ao clicar no botão de adicionar vai para a tela de adicionar", function(Given, When, Then) {
		When
			.EmpresaPage
			.deveAoAbertarBotão("idBotaoAdicionar", "empresa.Empresa");
		
		Then
			.EmpresaPage
			.deveEstarNaTelaDeAdicionar("Cadastro Empresa");
	});

	opaTest("Deve verificar se o botão de navback da tela de adicionar está voltando para a tela de listagem ", function(Given, When, Then) {
		When
			.EmpresaPage
			.deveAoAbertarBotão("idBotaoDeNavegarAdicionarEditar", "empresa.AdicionarEmpresa");

		Then
			.EmpresaPage
			.deveEstarNaTelaDeListagem();
	});

	opaTest("Deve verificar se a rota de tela de detalhes está funcionando corretamente", function(Given, When, Then){
		When
			.EmpresaPage
			.aoApertarEmUmaLinhaDaTabelaIrParaDetalhes();

		Then
			.EmpresaPage
			.deveVerificarSeEstaNaPagindaDeDetalhes();
	})

	opaTest("Deve voltar para a tela de listagem", function(Given, When, Then){
		When
			.EmpresaPage
			.deveAoAbertarBotão("idBotaoDeNavegarDeVoltaDetalhes", "empresa.DetalhesEmpresa");

		Then
			.EmpresaPage
			.deveEstarNaTelaDeListagem();

		Then.iTeardownMyApp();
	})
});