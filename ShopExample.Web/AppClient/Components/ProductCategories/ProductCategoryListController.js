/// <reference path="../../../Assets/Admin/Libs/angular/angular.js" />

(function (app) {
    app.controller('ProductCategoryListController', ProductCategoryListController)

    ProductCategoryListController.$inject = ['$scope', 'ApiService', 'notificationService', '$ngBootbox', '$filter']

    function ProductCategoryListController($scope, ApiService, notificationService, $ngBootbox, $filter) {
        $scope.productCategories = []
        $scope.page = 0
        $scope.pagesCount = 0
        $scope.keyword = ''
        $scope.getListProductCategory = GetListProductCategory
        $scope.search = Search
        $scope.deleteProductCategory = DeleteProductCategory
        $scope.selectAll = SelectAll
        $scope.deleteMultiple = DeleteMultiple
        $scope.isSelectAll = false

        // Hàm xử lý tìm kiếm sản phẩm
        function Search() {
            GetListProductCategory()
        }

        // Hàm xử lý get ra tất cả bản ghi
        function GetListProductCategory(page) {
            page = page || 0

            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 2
                }
            }

            ApiService.get('/api/productcategory/getall', config, function (result) {
                if (result.data.TotalCount === 0) {
                    notificationService.displayWarning('Không tìm thấy danh mục sản phẩm nào.')
                } else {
                    //notificationService.displaySuccess('Đã tìm thấy ' + result.data.TotalCount + ' danh mục sản phẩm.')
                    $scope.productCategories = result.data.Items
                    $scope.page = result.data.Page
                    $scope.pagesCount = result.data.TotalPage
                    $scope.totalCount = result.data.TotalCount
                }

                
            }, function (error) {
                console.log('failed load product category')
            })
        }

        // Hàm xử lý chỉ xóa một bản ghi
        function DeleteProductCategory(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa.').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }

                ApiService.del('/api/productcategory/delete', config, function (result) {
                    notificationService.displaySuccess('Xóa thành công.')
                    Search()
                }, function (error) {
                    notificationService.displayError('Xóa không thành công, có lỗi phát sinh')
                })
            })
        }

        // Hàm select một product category
        $scope.$watch('productCategories', function (n, o) {
            var checked = $filter('filter')(n, { checked: true, })

            if (checked.length) {
                $scope.selected = checked
                $('#btnDeleteMulti').removeAttr('hidden')

                if (checked.length === n.length) {
                    $scope.isSelectAll = true
                    $('#txb_selectAll').attr('checked', 'checked');
                } else {
                    $('#txb_selectAll').removeAttr('checked');
                    $scope.isSelectAll = false
                }
            }
            else {
                $('#btnDeleteMulti').attr('hidden', 'hidden');
                $scope.isSelectAll = false
            }
        }, true)

        // Hàm sử lý checkout        
        function SelectAll() {
            if ($scope.isSelectAll === false) {
                angular.forEach($scope.productCategories, (item) => {
                    item.checked = true
                })
                $scope.isSelectAll = true
            }
            else {
                angular.forEach($scope.productCategories, (item) => {
                    item.checked = false
                })
                $scope.isSelectAll = false
            }
        }

        // Hàm xử lý xóa nhiều bản ghi
        function DeleteMultiple() {
            const config = {
                params: {
                    checkedProductCategoryJson: JSON.stringify($scope.selected),
                }
            }

            ApiService.del('api/productcategory/deletemulti', config, function (result) {
                notificationService.displaySuccess('Xóa thành công ' + result.data + ' bản ghi.')
                Search()
            }, function (error) {
                notificationService.displayError('Không thể xóa, có lỗi phát sinh.')
            })
        }

        // Gọi hàm
        $scope.getListProductCategory();

    }

})(angular.module('shopexample.products_category'))