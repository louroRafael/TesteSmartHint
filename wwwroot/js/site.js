$(document).ready(function () {
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
});

function clearForm() {
    $("#formCustomerFilter")[0].reset();
}

function filterCustomers() {
    $("#customerFilter").collapse("hide");
}
