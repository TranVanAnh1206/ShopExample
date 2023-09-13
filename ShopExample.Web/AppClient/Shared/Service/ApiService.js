/// <reference path="../../../assets/admin/libs/angular/angular.js" />


(function (app) {
    app.service('ApiService', ApiService)

    ApiService.$inject = ['$http']

    function ApiService($http) {
        return {
            get: get
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