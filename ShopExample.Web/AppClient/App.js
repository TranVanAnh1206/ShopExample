/// <reference path="../assets/admin/libs/angular/angular.js" />

/// có nhiệm cụ đăng ký các moodule cho cả hệ thống

(function () {
	angular.module('shopexample', ['shopexample.products',
									'shopexample.products_category',
									'shopexample.common']).config(config)

	config.$inject = ['$stateProvider', '$urlRouterProvider']

	function config($stateProvider, $urlRouterProvider) {
		$stateProvider.state('home', {
			url: "/admin",
			templateUrl: "/AppClient/Components/Home/HomeView.html",
			controller: "HomeController"
		})

		$urlRouterProvider.otherwise('/admin')
	}
})();