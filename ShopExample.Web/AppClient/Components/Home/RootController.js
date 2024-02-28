(function (app) {
    app.controller('rootController', RootController)

    RootController.$inject = ['$scope', '$state', '$ngBootbox', 'loginService', 'authenticationService', 'authData']

    function RootController($scope, $state, $ngBootbox, loginService, authenticationService, authData) {
        $scope.logout = Logout
        $scope.copyright = new Date().getFullYear();

        function Logout() {
            $ngBootbox.confirm('Bạn có chắc muốn đăng xuất.')
                .then(function () {
                    loginService.logOut()
                    $state.go('login')
                }
            )
        }

        $scope.authentication = authData.authenticationData

        function CheckLoad() {
            //$(window).on('beforeunload', function () {
            //    return "Bạn có chắc chắn muốn rời khỏi trang này?";
            //});
        }

        CheckLoad();


        //console.log(authData.authenticationData)

        //authenticationService.validateRequest()
    }
})(angular.module('shopexample'))