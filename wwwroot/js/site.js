$(document).ready(function () {
    fieldsMask();
    enableStateRegistration();
    showNaturalPersonInfo();

    $("#dateRangeInput").daterangepicker({
        opens: 'left',
        drops: 'down',
        autoApply: true,
        locale: {
            format: 'DD/MM/YYYY',
            separator: ' - ',
            customRangeLabel: 'Custom',
            daysOfWeek: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sab'],
            monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro']
        }
    });

    $("#Exempt").click(function () {
        enableStateRegistration();
    });

    $("#Type").change(function () {
        enableStateRegistration();
        showNaturalPersonInfo();
    });
});

function fieldsMask() {

    var options = {
        onKeyPress: function (cpf, e, field, options) {
            var masks = ["000.000.000-000", "00.000.000/0000-00"];
            $("#CpfCnpj").mask((cpf.length > 14) ? masks[1] : masks[0], options);
        }
    }

    $("#CpfCnpj").mask("000.000.000-00#", options);
    $("#phoneInput").mask("(00) 00000-0000");
    $("#StateRegistration").mask("000.000.000-000");
}

function clearForm() {
    $("#formCustomerFilter")[0].reset();
}

function filterCustomers() {
    $("#customerFilter").collapse("hide");
}

function enableStateRegistration() {
    $("#StateRegistration").prop("disabled", $("#Type").val() == 0 || $("#Exempt").prop("checked"));
}

function showNaturalPersonInfo() {
    if ($("#Type").val() == 0)
        $("#naturalPersonInfo").collapse("show");
    else
        $("#naturalPersonInfo").collapse("hide");
}

function toggleViewPassword(id) {
    var type = $(`#${id}`).attr("type")
    $(`#btnToggle${id} i`).removeClass();

    if (type == "password") {
        $(`#${id}`).attr("type", "text");
        $(`#btnToggle${id} i`).addClass("bi bi-eye-slash")
    }
    else {
        $(`#${id}`).attr("type", "password");
        $(`#btnToggle${id} i`).addClass("bi bi-eye")
    }
}