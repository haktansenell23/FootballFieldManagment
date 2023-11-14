var services = angular.module("services", []);


services.factory('NotifService', function () {
    var root = {};


    root.notification = function (title,message,buttonText,statu) {
        Swal.fire({
            title: title,
            html: message,
            icon: statu ? 'success' : 'warning',
            confirmButtonText: buttonText
        });

    }
    
    return root;

})
