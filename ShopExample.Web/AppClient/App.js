/// <reference path="../assets/admin/libs/angular/angular.js" />

/// có nhiệm cụ đăng ký các moodule cho cả hệ thống

(function () {
    angular
        .module('shopexample',
            ['shopexample.products',
            'shopexample.products_category',
            'shopexample.post_category',
            'shopexample.common'    
            ])
        .config(config)
        .config(configAuthentication)

    config.$inject = ['$stateProvider', '$urlRouterProvider']

    function config($stateProvider, $urlRouterProvider) {
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

    function configAuthentication($httpProvider) {
        $httpProvider.interceptors.push(function ($q, $location) {
            return {
                request: function (config) {
                    return config;
                },
                requestError: function (rejection) {
                    return $q.reject(rejection);
                },
                response: function (response) {
                    if (response.status == "401") {
                        $location.path('/login');
                    }
                    //the same response/modified/or a new one need to be returned.
                    return response;
                },
                responseError: function (rejection) {
                    if (rejection.status == "401") {
                        $location.path('/login');
                    }
                    return $q.reject(rejection);
                }
            };
        });
    }
})();