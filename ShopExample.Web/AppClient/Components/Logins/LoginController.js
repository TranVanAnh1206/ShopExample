/// <reference path="../../../assets/admin/libs/angular/angular.js" />

(function (app) {

    app.controller('LoginController', LoginController)

    LoginController.$inject = ['$scope', 'loginService', '$injector', 'notificationService']

    function LoginController($scope, loginService, $injector, notificationService) {
        $scope.loginData = {
            userName: "",
            password: ""
        };

        $scope.login = function () {
            loginService.login($scope.loginData.userName, $scope.loginData.password)
                .then(function (response) {

                    //console.log('từ loginController, response = ')
                    //console.log(response)
                    //console.log('===============================')

                    if (response != null && response.data.error != undefined) {
                        notificationService.displayError('Username or password is incorrect');

                        //console.log('Login failed ...')
                    }
                    else {
                        var stateService = $injector.get('$state');
                        stateService.go('home');

                        //console.log('Login successed ...')
                    }
                });
        }

    }

})(angular.module("shopexample"))