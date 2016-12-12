var CustomerSevice = function () {
    var deleteCustomer = function (customerId, success, fail) {
        $.ajax({
            url: "/api/customers/" + customerId,
            method: "DELETE",
            success: success,
            fail: fail
        });
    }

    return {
        deleteCustomer: deleteCustomer
    }
}();
