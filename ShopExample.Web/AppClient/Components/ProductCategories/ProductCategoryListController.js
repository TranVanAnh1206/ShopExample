/// <reference path="../../../Assets/Admin/Libs/angular/angular.js" />

(function (app) {

    app.controller('ProductCategoryListController', ProductCategoryListController)

    ProductCategoryListController.$inject = ['$scope', 'ApiService', 'notificationService']

    function ProductCategoryListController($scope, ApiService, notificationService) {
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
                if (result.data.TotalCount === 0) {
                    notificationService.displayWarning('Không tìm thấy danh mục sản phẩm nào.')
                } else {
                    notificationService.displaySuccess('Đã tìm thấy ' + result.data.TotalCount + ' danh mục sản phẩm.')
                }

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