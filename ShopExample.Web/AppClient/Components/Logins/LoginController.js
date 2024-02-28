/// <reference path="../../../assets/admin/libs/angular/angular.js" />

(function (app) {

    app.controller('LoginController', LoginController)

    LoginController.$inject = ['$scope', 'loginService', '$injector', 'notificationService']

    function LoginController($scope, loginService, $injector, notificationService) {
        $scope.loginData = {
            userName: "TranVanAnh",
            password: "12345$"
        };
        $scope.loading = false;

        $scope.login = function () {
            $scope.loading = true;
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
                })
                .finally(function () {
                    $scope.loading = false; // Ẩn hiệu ứng loading khi xử lý đăng nhập hoàn thành (thành công hoặc thất bại)
                });
        }

    }

})(angular.module("shopexample"))