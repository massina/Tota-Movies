var CustomersController = function (customerService) {

    var customersTable;
    var deleteButton;

    var createCustomersTable = function () {
        customersTable = $("#customers").DataTable({
            ajax: {
                url: "/api/customers",
                dataSrc: ""
            },
            columns: [
                {
                    data: "name",
                    render: function (data, type, customer) {
                        return "<a href='/customers/edit/" + customer.id + "'>" + customer.name + "</a>";
                    }
                },
                {
                    data: "membershipType.name"
                },
                {
                    data: "id",
                    render: function (data) {
                        return "<button data-customer-id=" + data + " class='btn-link text-danger js-delete'>Delete</button>";
                    }
                }
            ]
        });
    }

    var success = function () {
        customersTable.row(deleteButton.parents("tr")).remove().draw();
        toastr.success("Customer deleted successfully.");
    }

    var fail = function () {
        toastr.error("Something unexpected happened!");
    }



    var toggleCustomer = function () {
        deleteButton = $(this);
        var customerId = deleteButton.attr("data-customer-id");
        bootbox.confirm("Are you sure you want to delete this customer?", function (result) {
            if (result)
                customerService.deleteCustomer(customerId, success, fail);
        });
    }

    var init = function (container) {
        createCustomersTable();
        $(container).on("click", ".js-delete", toggleCustomer);
    }

    return {
        init: init
    };
}(CustomerSevice);
