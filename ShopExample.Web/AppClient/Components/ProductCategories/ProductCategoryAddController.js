(function (app) {

    app.controller('ProductCategoryAddController', ProductCategoryAddController);

    ProductCategoryAddController.$inject = ['$scope', 'ApiService', 'notificationService', '$state', 'CommonService']

    function ProductCategoryAddController($scope, ApiService, notificationService, $state, CommonService) {
        $scope.productCategory = {
            HomeFlag: true,
        };
        $scope.parentCategories = [];
        $scope.status = [];
        $scope.productcategory_Status;
        $scope.productCategory_ParentID;
        $scope.addProductCategory = AddproductCategory;
        $scope.getSEOTitle = GetSEOTitle;
        $scope.GetStatus = GetStatus;

        function GetStatus() {
            ApiService.get('/api/Sys_StatusAPI/GetStatusForProduct/1', null, (result) => {
                if (!result.data) {
                    notificationService.displayWarning('Status is empty ...');
                    return;
                }

                $scope.status = result.data;
            }, (err) => {
                notificationService.displayError('Can not get status ....');
            });
        }

        function GetSEOTitle() {
            $scope.productCategory.Alias = CommonService.getSEOTitle($scope.productCategory.Name)
        }

        function AddproductCategory(valid) {
            $scope.submitted = valid;

            if ($scope.submitted) return;

            if ($scope.productcategory_Status)
                $scope.productCategory.Status = $scope.productcategory_Status.ID;

            if ($scope.productCategory_ParentID)
                $scope.productCategory.ParentID = $scope.productCategory_ParentID.ID;

            ApiService.post('/api/productcategory/create', $scope.productCategory, (result) => {
                notificationService.displaySuccess(result.data.Name + ' đã được thêm mới.');
                $state.go('products_category');
            }, (error) => {
                notificationService.displayError('Add new product category unsuccessful.');
            })
        }

        function GetParentCategory() {
            ApiService.get('/api/productcategory/getallparent', null, (result) => {
                $scope.parentCategories = result.data;
            }, (error) => {
                notificationService.displayError('Cannot get parent category...');
            })
        }

        GetParentCategory();
        $scope.GetStatus();
    }

})(angular.module('shopexample.products_category'))