(function (app) {

    app.controller('ProductCategoryUpdateController', ProductCategoryUpdateController)

    ProductCategoryUpdateController.$inject = ['$scope', 'ApiService', 'notificationService', '$state', '$stateParams', 'CommonService']

    function ProductCategoryUpdateController($scope, ApiService, notificationService, $state, $stateParams, CommonService) {

        $scope.productCategory = {
            ModifiedDate: new Date(),
            Status: true,
        }

        $scope.parentCategories = []
        $scope.updateProductCategory = UpdateProductCategory
        $scope.getSEOTitle = GetSEOTitle

        function GetSEOTitle() {
            $scope.productCategory.Alias = CommonService.getSEOTitle($scope.productCategory.Name)
        }

        function loadProductcategoryDetail() {
            ApiService.get('/api/productcategory/getbyid/' + $stateParams.id, null,
                function (result) {
                    $scope.productCategory = result.data
                },
                function (error) {
                    notificationService.displayError(error.data)
                }
            )
        }        

        function GetParentCategory() {
            ApiService.get('/api/productcategory/getallparent', null,
                (result) => {
                    $scope.parentCategories = result.data
                },
                (error) => {
                    console.log('Cannot get parent ...')
                }
            )
        }

        function UpdateProductCategory() {
            ApiService.put('/api/productcategory/update', $scope.productCategory,
                function (result) {
                    console.log($scope.productCategory, result.data)

                    notificationService.displaySuccess(result.data.Name + ' đã cập nhật thành công.')
                    $state.go('products_category')

                },
                function (error) {
                    notificationService.displaySuccess('Cập nhật thất bại, có lỗi xảy ra.')
                }
            )
        }

        GetParentCategory()
        loadProductcategoryDetail()
    }

})(angular.module('shopexample.products_category'))