/// <reference path="../../../Assets/Admin/Libs/angular/angular.js" />


(function () {
	angular.module('shopexample.products', ['shopexample.common']).config(config)

	config.$inject = ['$stateProvider', '$urlRouterProvider']

	function config($stateProvider, $urlRouterProvider) {
		$stateProvider.state('products', {
			url: "/products",
			templateUrl: "/AppClient/Components/Products/ProductListView.html",
			controller: "ProductListController"
		}).state('product_add', {
			url: "/product_add",
			templateUrl: "/AppClient/Components/Products/ProductAddView.html",
			controller: "ProductAddController"
		}).state('update_product', {
			url: "/update_product/:id",
			templateUrl: "/AppClient/Components/Products/ProductEditView.html",
			controller: "ProductEditController"
		})
	}
})();