/// <reference path="../../../Assets/Admin/Libs/angular/angular.js" />

(function (app) {

    app.controller('ProductCategoryListController', ProductCategoryListController)

    ProductCategoryListController.$inject = ['$scope', 'ApiService']

    function ProductCategoryListController($scope, ApiService) {
        $scope.productCategories = []

        $scope.getListProductCategory = GetListProductCategory

        function GetListProductCategory() {
            ApiService.get('/api/productcategory/getall', null, function (result) {
                $scope.productCategories = result.data
            }, function (error) {
                console.log('failed load product category')
            })
        }

        // Gọi hàm
        $scope.getListProductCategory();

        

    }

})(angular.module('shopexample.products_category'))