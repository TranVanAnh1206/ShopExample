﻿/// <reference path="../../../assets/admin/libs/angular/angular.js" />


(function (app) {
    app.service('ApiService', ApiService)

    ApiService.$inject = ['$http', 'notificationService']

    function ApiService($http, notificationService) {
        return {
            get: get,
            post: post,
            put: put,
            del: del,
        }

        function post(url, data, success, failure) {
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
            $http.get(url, params)
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