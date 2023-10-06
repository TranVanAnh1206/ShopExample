(function (app) {
    'use strict';

    app.service('loginService', ['$http', '$q', 'authenticationService', 'authData',
        function ($http, $q, authenticationService, authData) {
            var userInfo;
            var deferred;

            this.login = function (userName, password) {
                deferred = $q.defer();

                var data = "grant_type=password&username=" + userName + "&password=" + password;

                //console.log('Từ LoginService :')
                //console.log(data)
                //console.log('==================')

                $http.post('/oauth/token', data,
                    {
                        headers: {
                            'Content-Type': 'application/x-www-form-urlencoded'
                        }
                    })
                    .then(function (response) {
                        userInfo = {
                            accessToken: response.data.access_token,
                            userName: userName
                        };

                        authenticationService.setTokenInfo(userInfo);

                        //console.log(userInfo)

                        authData.authenticationData.IsAuthenticated = true;
                        authData.authenticationData.userName = userName;

                        deferred.resolve(null);

                    }, function (error, status) {
                        authData.authenticationData.IsAuthenticated = false;
                        authData.authenticationData.userName = "";

                        //console.log('Nhánh vào error func: ')
                        //console.log(authData.authenticationData)
                        //console.log('====================== ')

                        deferred.resolve(error);
                    })

                return deferred.promise;
            }

            this.logOut = function () {
                authenticationService.removeToken();
                authData.authenticationData.IsAuthenticated = false;
                authData.authenticationData.userName = "";
            }
        }]);
})(angular.module('shopexample.common'));


