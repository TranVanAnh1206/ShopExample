/// <reference path="../../../assets/admin/libs/angular/angular.js" />

(function (app) {

    app.filter('StatusFilter', () => {
        return function (input) {
            switch (input) {
                case 1:
                    return "Nháp";
                case 2:
                    return "Sử dụng";
                case 3:
                    return "Không sử dụng";
                case 4:
                    return "Chờ duyệt";
            }
        }
    })

})(angular.module('shopexample.common'))