
(function (app) {
    app.controller('ProductListController', ProductListController)

    ProductListController.$inject = ['$scope', 'ApiService', 'notificationService', '$filter', '$location']

    function ProductListController($scope, ApiService, notificationService, $filter, $location) {

        var baseUrl = 'https://localhost:44398';

        $scope.productList = [];
        $scope.keyword = '';
        $scope.totalCount = 0;
        $scope.pagesCount = 0;
        $scope.page = 0;
        $scope.search = Search;
        $scope.getListProduct = GetListProduct;
        $scope.isSelectAll = false;
        $scope.selectAll = SelectAll;
        $scope.deleteProductMulti = DeleteProductMulti;
        $scope.selectProduct = selectProduct;
        $scope.Dbl_Select_Product = Dbl_Select_Product;
        $scope.update_product = update_product;

        function Dbl_Select_Product(item) {
            console.log(item);
            var path = '/update_product/' + item.ID;

            $location.path(path);
        }

        function selectProduct(item) {
            //console.log(item);

            var check_all = true

            item.checked = !item.checked;

            angular.forEach($scope.productList, (i) => {
                if (!i.checked) {
                    check_all = false;
                    return;
                }
            })

            $scope.isSelectAll = check_all;
        }

        function GetListProduct(page) {
            page = page || 0;

            var config = {
                params: {
                    searchKeyword: $scope.keyword,
                    page: page,
                    pageSize: 20,
                }
            }

            ApiService.get('/api/product/getallasync', config, function (result) {
                //console.log(result);

                if (result.data.TotalCount === 0) {
                    notificationService.displayError('Product not found ...');
                } else {
                    $scope.productList = result.data.Items;
                    $scope.page = result.data.Page;
                    $scope.pagesCount = result.data.TotalPage;
                    $scope.totalCount = result.data.TotalCount;
                }
            }, function (error) {
                notificationService.displayError('Failed to get product list ...');
            })
        }

        function SelectAll(select_all) {
            angular.forEach($scope.productList, (item) => {
                item.checked = !select_all;
            })
            $scope.isSelectAll = !select_all;
        }

        $scope.$watch('productList', function (n, o) {
            var checked = $filter('filter')(n, { checked: true, })

            $scope.checked_product_list = checked;

            if (checked.length) {
                //$('#btnDeleteMulti').removeAttr('hidden');
            }
            else {
                //$('#btnDeleteMulti').attr('hidden', 'hidden');
                $scope.isSelectAll = false;
            }
        }, true)

        function DeleteProductMulti() {
            if ($scope.checked_product_list.length > 0) {
                var list_checked_id = [];

                angular.forEach($scope.checked_product_list, (item) => {
                    var prod_item = {
                        ID: item.ID,
                        Name: item.Name
                    }

                    list_checked_id.push(prod_item);
                });

                var config = {
                    params: {
                        productCheckedJSON: JSON.stringify(list_checked_id)
                    }
                }

                ApiService.del('/api/product/deleteMultiple', config, function (result) {
                    notificationService.displaySuccess('deleted ' + result.data + ' product ...');
                    $scope.checked_product_list = [];
                    $scope.getListProduct();

                }, function (error) {
                    notificationService.displayError('Failed to delete this product ...');
                })
            }
            else {
                notificationService.displayError('Please select a record ...');
            }
        }

        function update_product() {
            if ($scope.checked_product_list.length == 0) {
                notificationService.displayError('Please select a record ...');
            } else if ($scope.checked_product_list.length > 1) {
                notificationService.displayError('Only one record can be selected ...');
            } else {
                console.log($scope.checked_product_list[0]);

                var path = '/update_product/' + $scope.checked_product_list[0].ID;

                $location.path(path);
            }
        }

        function Search() {
            GetListProduct();
        }

        $scope.getListProduct();

    }

})(angular.module('shopexample.products'));