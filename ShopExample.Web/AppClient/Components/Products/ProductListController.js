
(function (app) {
    app.controller('ProductListController', ProductListController)

    ProductListController.$inject = ['$scope', 'ApiService', 'notificationService', '$filter']

    function ProductListController($scope, ApiService, notificationService, $filter) {

        $scope.productList = []
        $scope.keyword = ''
        $scope.totalCount = 0
        $scope.pagesCount = 0
        $scope.page = 0,
        $scope.search = Search
        $scope.getListProduct = GetListProduct
        $scope.isSelectAll = false
        $scope.selectAll = SelectAll
        $scope.deleteProductMulti = DeleteProductMulti

        function GetListProduct(page) {
            page = page || 0

            var config = {
                params: {
                    searchKeyword: $scope.keyword,
                    page: page,
                    pageSize: 5,
                }
            }

            ApiService.get('api/product/getall', config, function (result) {
                if (result.data.TotalCount === 0) {
                    notificationService.displayError('Product not found ...')
                } else {
                    $scope.productList = result.data.Items
                    $scope.page = result.data.Page
                    $scope.pagesCount = result.data.TotalPage
                    $scope.totalCount = result.data.TotalCount
                }
            }, function (error) {
                notificationService.displayError('Failed to get product list ...')
            })
        }

        function SelectAll() {
            if ($scope.isSelectAll === false) {
                angular.forEach($scope.productList, (item) => {
                    item.checked = true
                })
                $scope.isSelectAll = true
            }
            else {
                angular.forEach($scope.productList, (item) => {
                    item.checked = false
                })
                $scope.isSelectAll = false
            }
        }

        $scope.$watch('productList', function (n, o) {
            var checked = $filter('filter')(n, { checked: true, })

            if (checked.length) {
                $scope.selected = checked
                $('#btnDeleteMulti').removeAttr('hidden')
            }
            else {
                $('#btnDeleteMulti').attr('hidden', 'hidden')
                $scope.isSelectAll = false
            }
        }, true)

        function DeleteProductMulti() {
            var config = {
                params: {
                    productCheckedJSON: JSON.stringify($scope.selected)
                }
            }

            ApiService.del('api/product/deleteMultiple', config, function (result) {
                notificationService.displaySuccess('deleted ' + result.data + ' product ...')
               
            }, function (error) {
                notificationService.displayError('Failed to delete this product ...');
            })
        }

        function Search() {
            GetListProduct()
        }

        $scope.getListProduct()

    }

})(angular.module('shopexample.products'));