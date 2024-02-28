/// <reference path="../../../assets/admin/libs/angular/angular.min.js" />

(function () {
	angular.module("shopexample.post_category", ['shopexample.common']).config(config)

	config.$inject = ['$stateProvider', '$urlRouterProvider', '$locationProvider']

	function config($stateProvider, $urlRouterProvider, $locationProvider) {
		$stateProvider.state('postCategory', {
			url: "/post_category",
			parent: 'base',
			templateUrl: "/AppClient/Components/PostCategories/PostCategoryListView.html",
			controller: "PostCategoryListController"
		}).state('addPostCategory', {
			url: "/add_post_category",
			parent: 'base',
			templateUrl: "/AppClient/Components/PostCategories/PostCategoryAddView.html",
			controller: "PostCategoryAddController"
		}).state('UpdatePostCategory', {
			url: "/update_post_category",
			parent: 'base',
			templateUrl: "/AppClient/Components/PostCategories/PostCategoryUpdateView.html",
			controller: "PostCategoryUpdateController"
		})  

		// Thiết lập $locationProvider để loại bỏ ký tự !# từ URL
		//$locationProvider.html5Mode(true);

		//// Đường dẫn mặc định nếu không có trạng thái nào khớp
		//$urlRouterProvider.otherwise('/admin');
	}
})();