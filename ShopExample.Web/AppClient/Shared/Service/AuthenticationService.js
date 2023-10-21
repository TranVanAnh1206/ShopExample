(function (app) {
    'use strict';
    app.service('authenticationService', ['$http', '$q', '$window', 'localStorageService', 'authData',
        function ($http, $q, $window, localStorageService, authData) {
            var tokenInfo;

            this.setTokenInfo = function (data) {
                tokenInfo = data;
                //$window.sessionStorage["TokenInfo"] = JSON.stringify(tokenInfo);
                localStorageService.set('TokenInfo', JSON.stringify(tokenInfo))

                //console.log('token info: ')
                //console.log(tokenInfo)
                //console.log($window.sessionStorage["TokenInfo"])
                //console.log('===============end token info=================')
            }

            this.getTokenInfo = function () {
                return tokenInfo;
            }

            this.removeToken = function () {
                tokenInfo = null;
                //$window.sessionStorage["TokenInfo"] = null;
                localStorageService.set('TokenInfo', null)
            }

            this.init = function () {

                //if ($window.sessionStorage["TokenInfo"]) {
                //    tokenInfo = JSON.parse($window.sessionStorage["TokenInfo"]);
                //}

                var tokenInfo = localStorageService.get('TokenInfo')

                if (tokenInfo) {
                    tokenInfo = JSON.parse(tokenInfo);
                    authData.authenticationData.IsAuthenticated = true;
                    authData.authenticationData.userName = tokenInfo.userName;
                    authData.authenticationData.accessToken = tokenInfo.accessToken;
                }
            }

            this.setHeader = function () {
                delete $http.defaults.headers.common['X-Requested-With'];

                //if ((tokenInfo != undefined) && (tokenInfo.accessToken != undefined) && (tokenInfo.accessToken != null) && (tokenInfo.accessToken != "")) {
                //    $http.defaults.headers.common['Authorization'] = 'Bearer ' + tokenInfo.accessToken;
                //    $http.defaults.headers.common['Content-Type'] = 'application/x-www-form-urlencoded;charset=utf-8';
                //}

                if ((authData.authenticationData != undefined) && (authData.authenticationData.accessToken != undefined) && (authData.authenticationData.accessToken != null) && (authData.authenticationData.accessToken != "")) {
                    $http.defaults.headers.common['Authorization'] = 'Bearer ' + authData.authenticationData.accessToken;
                    $http.defaults.headers.common['Content-Type'] = 'application/x-www-form-urlencoded;charset=utf-8';
                }
            }

            this.validateRequest = function () {
                var url = 'api/home/TestMethod';

                var deferred = $q.defer();
                $http.get(url)
                    .then(
                        function () {
                            deferred.resolve(null);
                        },
                        function (error) {
                            deferred.reject(error);
                        }
                    );
                return deferred.promise;
            }

            this.init();
        }
    ]);
})(angular.module('shopexample.common'));