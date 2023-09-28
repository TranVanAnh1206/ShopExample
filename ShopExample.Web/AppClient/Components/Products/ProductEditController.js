

(function (app) {

    app.controller('ProductEditController', ProductEditController)

    ProductEditController.$inject = ['$scope', 'ApiService', 'CommonService', '$state', 'notificationService', '$stateParams']

    function ProductEditController($scope, ApiService, CommonService, $state, notificationService, $stateParams) {
        // Khu vực định nghĩa các biến

        $scope.product = {
            ModifiedDate: new Date(),
            Status: true,
        }
        $scope.ckeditorOptions = {
            language: 'vi',
            height: '400px',
            uiColor: '#AADC6E',
        }
        $scope.productCategories = []
        $scope.moreImgList = []
        $scope.updateProduct = UpdateProduct
        $scope.getProductCategory = GetProductCategory
        $scope.getSEOTitle = GetSEOTitle
        $scope.loadProductDetail = LoadProdcutDetail
        $scope.chooseMoreImage = ChooseMoreImage
        $scope.chooseImage = ChooseImage

        // Khu vực định nghĩa các hàm

        function GetSEOTitle() {
            $scope.product.Alias = CommonService.getSEOTitle($scope.product.Name)
        }

        function LoadProdcutDetail() {
            ApiService.get('api/product/getbyid/' + $stateParams.id, null,
                function (result) {
                    $scope.product = result.data
                    $scope.moreImgList = JSON.parse($scope.product.MoreImage)
                }, function (error) {
                    notificationService.displayError('Fail to load data ...')
                })
        }

        function GetProductCategory() {
            ApiService.get('api/productcategory/getallparent', null,
                function (result) {
                    $scope.productCategories = result.data
                }, function (error) {
                    notificationService.displayError('There was an error while loading the product category.')
                })
        }

        function UpdateProduct() {
            $scope.product.MoreImage = JSON.stringify($scope.moreImgList)
            ApiService.put('api/product/update', $scope.product, function (result) {
                notificationService.displaySuccess('Update success ...')
                $state.go('products')
            }, function (error) {
                notificationService.displayError('Update failed ... ')
            })
        }

        function ChooseMoreImage() {
            var finder = new CKFinder()
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.moreImgList.push(fileUrl)
                })
            }
            finder.popup()
        }

        function ChooseImage() {
            var finder = new CKFinder()
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.product.Image = fileUrl
                })
            }
            finder.popup()
        }

        // Khu vực gọi hàm

        $scope.getProductCategory()
        $scope.loadProductDetail()
    }

})(angular.module('shopexample.products'))