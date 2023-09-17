
(function (app) {
    app.controller('ProductListController', ProductListController)

    ProductListController.$inject = ['$scope', 'ApiService', 'notificationService']

    function ProductListController($scope, ApiService, notificationService) {

        $scope.productList = []

        $scope.getListProduct = GetListProduct

        function GetListProduct() {
            ApiService.get('api/product/getall', null, function (result) {

                $scope.productList = result.data
            }, function (error) {
                console.log('Failed to get product list ...')
            })

        }

        $scope.getListProduct()

    }

})(angular.module('shopexample.products'));