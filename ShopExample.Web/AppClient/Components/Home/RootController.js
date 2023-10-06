(function (app) {
    app.controller('rootController', RootController)

    RootController.$inject = ['$scope', '$state', '$ngBootbox', 'loginService', 'authenticationService', 'authData']

    function RootController($scope, $state, $ngBootbox, loginService, authenticationService, authData) {
        $scope.logout = Logout

        function Logout() {
            $ngBootbox.confirm('Bạn có chắc muốn đăng xuất.')
                .then(function () {
                    loginService.logOut()
                    $state.go('login')
                }
            )
        }

        $scope.authentication = authData.authenticationData

        //authenticationService.validateRequest()
    }
})(angular.module('shopexample'))