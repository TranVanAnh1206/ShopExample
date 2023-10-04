/// <reference path="../../../Assets/Admin/Libs/angular/angular.js" />


(function () {
	angular.module('shopexample.products_category', ['shopexample.common']).config(config)

	config.$inject = ['$stateProvider', '$urlRouterProvider']

	function config($stateProvider, $urlRouterProvider) {
		$stateProvider.state('products_category', {
			url: "/products_category",
			parent: 'base',
			templateUrl: "/AppClient/Components/ProductCategories/ProductCategoryListView.html",
			controller: "ProductCategoryListController"
		}).state('add_product_category', {
			url: "/add_product_category",
			parent: 'base',
			templateUrl: "/AppClient/Components/ProductCategories/ProductCategoryAddView.html",
			controller: "ProductCategoryAddController"
		}).state('update_product_category', {
			url: "/update_product_category/:id",
			parent: 'base',
			templateUrl: "/AppClient/Components/ProductCategories/ProductCategoryUpdateView.html",
			controller: "ProductCategoryUpdateController"
		})
	}
})();