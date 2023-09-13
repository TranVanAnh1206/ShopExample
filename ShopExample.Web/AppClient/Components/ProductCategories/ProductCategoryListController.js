/// <reference path="../../../Assets/Admin/Libs/angular/angular.js" />

(function (app) {

    app.controller('ProductCategoryListController', ProductCategoryListController)

    ProductCategoryListController.$inject = ['$scope', 'ApiService']

    function ProductCategoryListController($scope, ApiService) {
        $scope.productCategories = []
        $scope.page = 0
        $scope.pagesCount = 0
        $scope.keyword = ''
        $scope.getListProductCategory = GetListProductCategory
        $scope.search = Search

        function Search() {
            GetListProductCategory()
        }

        function GetListProductCategory(page) {
            page = page || 1

            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 20
                }
            }

            ApiService.get('/api/productcategory/getall', config, function (result) {
                $scope.productCategories = result.data.Items
                $scope.page = result.data.Page
                $scope.pagesCount = result.data.TotalPage
                $scope.totalCount = result.data.TotalCount
            }, function (error) {
                console.log('failed load product category')
            })
        }

        // Gọi hàm
        $scope.getListProductCategory();

    }

})(angular.module('shopexample.products_category'))