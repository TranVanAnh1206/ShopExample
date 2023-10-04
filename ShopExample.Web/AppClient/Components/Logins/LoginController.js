/// <reference path="../../../assets/admin/libs/angular/angular.js" />

(function (app) {

    app.controller('LoginController', LoginController)

    LoginController.$inject = ["$scope", '$state', '$ngBootbox']

    function LoginController($scope, $state, $ngBootbox) {
        $scope.login = Login

        function Login() {
            alert('Đã đăng nhập ... ')
            $state.go('home')
        }

    }

})(angular.module("shopexample"))