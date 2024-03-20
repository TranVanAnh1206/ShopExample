/// <reference path="../../../Assets/Admin/Libs/angular/angular.js" />

(function (app) {
    app.controller('ProductCategoryListController', ProductCategoryListController)

    ProductCategoryListController.$inject = ['$scope', 'ApiService', 'notificationService', '$ngBootbox', '$filter', '$location']

    function ProductCategoryListController($scope, ApiService, notificationService, $ngBootbox, $filter, $location) {
        var vm = $scope;

        vm.productCategories = [];
        vm.checked_productcategory_list = [];
        vm.page = 0;
        vm.pagesCount = 0;
        vm.keyword = '';
        vm.getListProductCategory = GetListProductCategory;
        vm.search = Search;
        vm.selectAll = SelectAll
        vm.deleteMultiple = DeleteMultiple;
        vm.isSelectAll = false;
        vm.selectProductCategory = selectProductCategory;
        vm.Dbl_Select_ProductCategory = Dbl_Select_ProductCategory;
        vm.update_product_category = update_product_category;
        function Dbl_Select_ProductCategory(item) {
            var path = '/update_product_category/' + item.ID;

            $location.path(path);
        }

        function update_product_category() {
            if (vm.checked_productcategory_list.length == 0) {
                notificationService.displayError('Please select a record ...');
            } else if (vm.checked_productcategory_list.length > 1) {
                notificationService.displayError('Only one record can be selected ...');
            } else {
                Dbl_Select_ProductCategory(vm.checked_productcategory_list[0]);
            }
        }

        function selectProductCategory(item) {
            //console.log(item);

            var check_all = true

            item.checked = !item.checked;

            angular.forEach(vm.productCategories, (i) => {
                if (!i.checked) {
                    check_all = false;
                    return;
                }
            })

            vm.isSelectAll = check_all;
        }

        // Hàm xử lý tìm kiếm sản phẩm
        function Search() {
            GetListProductCategory()
        }

        // Hàm xử lý get ra tất cả bản ghi
        function GetListProductCategory(page) {
            page = page || 0

            var config = {
                params: {
                    keyword: vm.keyword,
                    page: page,
                    pageSize: 2
                }
            }

            ApiService.get('/api/productcategory/getall', config, function (result) {
                if (result.data.TotalCount === 0) {
                    notificationService.displayWarning('Không tìm thấy danh mục sản phẩm nào.')
                } else {
                    //notificationService.displaySuccess('Đã tìm thấy ' + result.data.TotalCount + ' danh mục sản phẩm.')
                    vm.productCategories = result.data.Items
                    vm.page = result.data.Page
                    vm.pagesCount = result.data.TotalPage
                    vm.totalCount = result.data.TotalCount
                    console.log(result);
                }


            }, function (error) {
                console.log('failed load product category')
            })
        }

        // Hàm select một product category
        vm.$watch('productCategories', function (n, o) {
            var checked = $filter('filter')(n, { checked: true, })

            vm.checked_productcategory_list = checked;


            if (checked.length) {
                if (checked.length === n.length) {
                    vm.isSelectAll = true
                    $('#txb_selectAll').attr('checked', 'checked');
                } else {
                    $('#txb_selectAll').removeAttr('checked');
                    vm.isSelectAll = false
                }
            }
            else {
                vm.isSelectAll = false
            }
        }, true)

        // Hàm sử lý checkout        
        function SelectAll() {
            if (vm.isSelectAll === false) {
                angular.forEach(vm.productCategories, (item) => {
                    item.checked = true
                })
                vm.isSelectAll = true
            }
            else {
                angular.forEach(vm.productCategories, (item) => {
                    item.checked = false
                })
                vm.isSelectAll = false
            }
        }

        // Hàm xử lý xóa nhiều bản ghi
        function DeleteMultiple() {
            if (vm.checked_productcategory_list.length <= 0) {
                notificationService.displayError('Please select a record ...');
            } else {
                var list_checked = [];

                angular.forEach(vm.checked_productcategory_list, item => {
                    var i = {
                        ID: item.ID,
                        Name: item.Name
                    }

                    list_checked.push(i);
                });

                const config = {
                    params: {
                        checkedProductCategoryJson: JSON.stringify(list_checked),
                    }
                }

                ApiService.del('/api/productcategory/deletemulti', config, function (result) {
                    notificationService.displaySuccess('Delete successfully ' + result.data + ' record.');
                    vm.checked_productcategory_list = [];
                    vm.getListProductCategory();
                }, function (error) {
                    notificationService.displayError('Cannot deleted ...');
                })
            }
        }

        // Gọi hàm
        vm.getListProductCategory();

    }

})(angular.module('shopexample.products_category'))