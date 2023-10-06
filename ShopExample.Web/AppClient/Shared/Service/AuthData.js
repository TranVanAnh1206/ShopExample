/// <reference path="../../../assets/admin/libs/angular/angular.js" />

(function (app) {
    'use strict'

    app.factory('authData', [
        function () { 
            var authDataFactory = {}

            var authentication = {
                IsAuthenticated: false,
                userName: '',
            }

            authDataFactory.authenticationData = authentication

            return authDataFactory
        }
    ])
})(angular.module('shopexample.common'))