(function (app) {
    app.controller('rootController', RootController)

    RootController.$inject = ['$scope', '$state', '$ngBootbox']

    function RootController($scope, $state, $ngBootbox) {
        $scope.logout = Logout

        function Logout() {
            $ngBootbox.confirm('Bạn có chắc muốn đăng xuất.').then(function () {
                $state.go('login')
            })
        }
    }
})(angular.module('shopexample'))