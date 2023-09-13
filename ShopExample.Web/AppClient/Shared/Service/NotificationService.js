(function (app) {

    app.factory('notificationService', notificationService)

    function notificationService() {
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "newestOnTop": false,
            "progressBar": false,
            "positionClass": "toast-top-center",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }

        function DisplaySuccess(success) {
            toastr.success(success)
        }

        function DisplayError(error) {
            if (Array.isArray(error)) {
                error.forEach((item) => {
                    toastr.error(item)
                })
            } else {
                toastr.error(error)
            }
        }

        function DisplayWarning(warning) {
            toastr.warning(warning)
        }

        function DisplayInfo(info) {
            toastr.info(info)
        }

        return {
            displaySuccess: DisplaySuccess,
            displayError: DisplayError,
            displayWarning: DisplayWarning,
            displayInfo: DisplayInfo,
        }
    }

})(angular.module('shopexample.common'))