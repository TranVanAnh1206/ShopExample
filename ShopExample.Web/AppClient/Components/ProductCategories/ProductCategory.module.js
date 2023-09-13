/// <reference path="../../../Assets/Admin/Libs/angular/angular.js" />


(function () {
	angular.module('shopexample.products_category', ['shopexample.common']).config(config)

	config.$inject = ['$stateProvider', '$urlRouterProvider']

	function config($stateProvider, $urlRouterProvider) {
		$stateProvider.state('products_category', {
			url: "/products_category",
			templateUrl: "/AppClient/Components/ProductCategories/ProductCategoryListView.html",
			controller: "ProductCategoryListController"
		})
	}
})();