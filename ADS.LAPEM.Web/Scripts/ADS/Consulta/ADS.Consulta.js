(function (g) {

    g.Init = function () {

        $(".datepicker").mask("99/99/9999");
        $(".datepicker").datepicker({ dateFormat: "dd/mm/yy" });
        $(".datepicker").datepicker({
            changeMonth: true,
            changeYear: true,
            showOtherMonths: true,
            selectOtherMonths: true
        });
        $(".datepicker").datepicker("setDate", new Date());
        $.datepicker.regional['es'];

    };


})(ADS.Consulta = {});