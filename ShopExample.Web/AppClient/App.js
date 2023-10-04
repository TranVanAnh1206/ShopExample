/// <reference path="../assets/admin/libs/angular/angular.js" />

/// có nhiệm cụ đăng ký các moodule cho cả hệ thống

(function () {
    angular
        .module('shopexample', ['shopexample.products',
            'shopexample.products_category',
            'shopexample.common'])
        .config(config)

    config.$inject = ['$stateProvider', '$urlRouterProvider', '$locationProvider']

    function config($stateProvider, $urlRouterProvider, $locationProvider) {

        $locationProvider.html5Mode(true);

        $stateProvider
            .state('base', {
                url: '',
                templateUrl: '/AppClient/Shared/Views/BaseView.html',
                abstract: true
            })
            .state('home', {
                url: "/admin",
                parent: 'base',
                templateUrl: "/AppClient/Components/Home/HomeView.html",
                controller: "HomeController"
            })
            .state('login', {
                url: '/login',
                templateUrl: '/AppClient/Components/Logins/LoginView.html',
                controller: 'LoginController'
            })

        $urlRouterProvider.otherwise('/login')
    }
})();