/// <reference path="../../../assets/admin/libs/angular/angular.js" />


(function (app) {
    app.service('ApiService', ApiService)

    ApiService.$inject = ['$http', 'notificationService', 'authenticationService']

    function ApiService($http, notificationService, authenticationService) {
        var baseUrl = 'https://localhost:44398/'

        return {
            get: get,
            post: post,
            put: put,
            del: del,
        }

        function post(url, data, success, failure) {
            authenticationService.setHeader()
            $http.post(url, data)
                .then(
                    function (result) {
                        success(result)
                    },
                    function (error) {
                        if (error.status === 401) {
                            notificationService.displayError('Authenticate is required ...')
                        }
                        else if (failure != null) {
                            failure(error)
                        }

                    }
                )
        }

        function put(url, data, success, failure) {
            authenticationService.setHeader()
            $http.put(url, data)
                .then(function (result) {
                    console.log(result.data)
                    success(result);
                }, function (error) {
                    console.log(error.status)
                    if (error.status === 401) {
                        notificationService.displayError('Authenticate is required.');
                    }
                    else if (failure != null) {
                        failure(error);
                    }

                });
        }

        function del(url, data, success, failure) {
            authenticationService.setHeader()
            $http.delete(url, data)
                .then(
                    function (result) {
                        success(result)
                    },
                    function (error) {
                        if (error.status === 401) {
                            notificationService.displayError('Authenticate is required.');
                        }
                        else if (failure != null) {
                            failure(error);
                        }
                    }
                )
        }

        function get(url, params, success, failure) {
            authenticationService.setHeader()
            $http.get(baseUrl + url, params)
                .then(
                    function (result) {
                        success(result)
                    },
                    function (error) {
                        failure(error)
                    })
        }
    }

})(angular.module('shopexample.common'))