﻿(function (app) {

    app.controller('ProductCategoryAddController', ProductCategoryAddController);

    ProductCategoryAddController.$inject = ['$scope', 'ApiService', 'notificationService', '$state', 'CommonService']

    function ProductCategoryAddController($scope, ApiService, notificationService, $state, CommonService) {
        $scope.productCategory = {
            CreatedDate: new Date(),
            Status: true,
            HomeFlag: true,
        }

        $scope.parentCategories = []
        $scope.addProductCategory = AddproductCategory
        $scope.getSEOTitle = GetSEOTitle

        function GetSEOTitle() {
            $scope.productCategory.Alias = CommonService.getSEOTitle($scope.productCategory.Name)
        }

        function AddproductCategory() {

            ApiService.post('api/productcategory/create', $scope.productCategory, (result) => {
                notificationService.displaySuccess(result.data.Name + ' đã được thêm mới.')
                $state.go('products_category') 
            }, (error) => {
                notificationService.displayError('Thêm mới không thành công.')
            })
        }

        function GetParentCategory() {
            ApiService.get('api/productcategory/getallparent', null, (result) => {
                $scope.parentCategories = result.data
            }, (error) => {
                console.log('Cannot get parent ...')
            })
        }

        GetParentCategory()
    }

})(angular.module('shopexample.products_category'))