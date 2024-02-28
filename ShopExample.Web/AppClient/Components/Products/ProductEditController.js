

(function (app) {

    app.controller('ProductEditController', ProductEditController)

    ProductEditController.$inject = ['$scope', 'ApiService', 'CommonService', '$state', 'notificationService', '$stateParams']

    function ProductEditController($scope, ApiService, CommonService, $state, notificationService, $stateParams) {
        // Khu vực định nghĩa các biến
        $scope.EditMode = false;
        $scope.product = {};
        $scope.productOriginal = {};
        $scope.status = [];
        $scope.product_Status;
        $scope.ckeditorOptions = {
            language: 'vi',
            height: '400px',
            uiColor: '#AADC6E',
        }
        $scope.productCategories = [];
        $scope.product_CategoryID;
        $scope.moreImgList = [];
        $scope.updateProduct = UpdateProduct;
        $scope.getProductCategory = GetProductCategory;
        $scope.getSEOTitle = GetSEOTitle;
        $scope.loadProductDetail = LoadProdcutDetail;
        $scope.chooseMoreImage = ChooseMoreImage;
        $scope.chooseImage = ChooseImage;
        $scope.GetStatus = GetStatus;

        
        function GetStatus() {
            ApiService.get('/api/Sys_StatusAPI/GetStatusForProduct/1', null, (result) => {
                console.log(result);
                $scope.status = result.data;
            }, (err) => {
                notificationService.displayError('Can not get status ....');
            });
        }

        // Khu vực định nghĩa các hàm

        function GetSEOTitle() {
            $scope.product.Alias = CommonService.getSEOTitle($scope.product.Name)
        }

        function LoadProdcutDetail() {
            ApiService.get('/api/product/getbyid/' + $stateParams.id, null,
                function (result) {
                    $scope.product = result.data;
                    $scope.productOriginal = angular.copy($scope.product);
                    $scope.moreImgList = JSON.parse(result.data.MoreImage);

                    angular.forEach($scope.status, (item) => {
                        if (item.ID === $scope.product.Status) {
                            $scope.product_Status = item;
                        }
                    })

                    angular.forEach($scope.productCategories, item => {
                        if (item.ID === $scope.product.CategoryID) {
                            $scope.product_CategoryID = item;
                        }
                    })

                    //console.log($scope.product_Status);

                }, function (error) {
                    notificationService.displayError('Fail to load data ...')
                })
        }

        function GetProductCategory() {
            ApiService.get('/api/productcategory/GetWithUse', null,
                function (result) {
                    $scope.productCategories = result.data;
                }, function (error) {
                    notificationService.displayError('There was an error while loading the product category.')
                })
        }

        function UpdateProduct() {
            if (!$scope.EditMode) {
                $scope.EditMode = true;
            }
            else {
                $scope.product.CategoryID = $scope.product_CategoryID.ID;
                $scope.product.Status = $scope.product_Status.ID;
                $scope.product.MoreImage = JSON.stringify($scope.moreImgList);
                ApiService.put('/api/product/update', $scope.product, function (result) {
                    notificationService.displaySuccess('Update successfully ...');
                    $state.go('products')
                }, function (error) {
                    notificationService.displayError('Update failed ... ');
                })

                $scope.EditMode = false;
            }
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

        $scope.GetStatus();
        $scope.getProductCategory()
        $scope.loadProductDetail()
    }

})(angular.module('shopexample.products'))