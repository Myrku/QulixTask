//Данные функции отвечают за показ и скрытие форм для добавления и редактирования данных,
//    а так же за установку данных для редкатирования.

$(function () {
    let companyForm = $("#addCompanyForm");
    let updateCompanyForm = $("#updateCompanyForm");

    let employeeForm = $("#addEmployeeForm");
    let updateEmployeeForm = $("#updateEmployeeForm");

    $("#btnAddCompany").click(function () {
        companyForm.css('display', 'block');
    });

    $("#btnAddCompanyCancel").click(function () {
        companyForm.css('display', 'none');
        updateCompanyForm.css('display', 'none');
    });

    $(".btnUpdate").click(function () {
        var tds = $(this).parent('td').siblings('td');
        var row = [];
        $.each(tds, function (i, c) {
            row.push($(c).text().replace(/\s/g, ''));
        });
        $("#inpUpdateId").val(row[0]);
        $("#inpUpdateCompanyName").val(row[1]);
        $("#inpUpdateCompanyForm").val(row[2]);
        updateCompanyForm.css('display', 'block');
        companyForm.css('display', 'none');
    });

    $("#btnUpdateCompanyCancel").click(function () {
        updateCompanyForm.css('display', 'none');
    });

    $("#btnAddEmployee").click(function () {
        employeeForm.css('display', 'block');
        updateEmployeeForm.css('display', 'none');
    });

    $("#btnAddEmployeeCancel").click(function () {
        employeeForm.css('display', 'none');
    });

    $(".btnUpdateEmpl").click(function () {
        var tds = $(this).parent('td').siblings('td');
        var row = [];
        $.each(tds, function (i, c) {
            row.push($(c).text().replace(/\s/g, ''));
        });
        console.log(row[4]);
        $("#updateEmplId").val(row[0]);
        $("#updateEmplName").val(row[1]);
        $("#updateEmplSurname").val(row[2]);
        $("#updateEmplPatronymic").val(row[3]);
        document.getElementById("updateEmplDate").valueAsDate = new Date(row[4]);
        $("#updateEmplPosition").val(row[5]);
        var opt = $('option');
        opt.each(function (indx, element) {
            if ($(element).attr('label').toLowerCase().replace(/\s/g, '') == row[6].toLowerCase()) {
                $(this).attr("selected", "selected");
            }
        });
        updateEmployeeForm.css('display', 'block');
        employeeForm.css('display', 'none');
    });

    $("#btnUpdateEmployeeCancel").click(function () {
        updateEmployeeForm.css('display', 'none');
    });

});