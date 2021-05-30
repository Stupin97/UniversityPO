$(function () {
    $(document).on('click', '.search-button', function (e) {
        let $text = $('input.form-text'),
            $dirs = $('.content .row .col-8').children(".list-teacher");

        if ($text.val() !== "") {
            $.each($dirs, function (i, $value) {
                const $val = $value;
                if ($($value).text().toLowerCase().indexOf($('input.form-text').val()) === -1) {
                    $($val).hide("slow");
                } else {
                    $($val).show("slow");
                }
            });
        }
        else {
            $('input.form-text').attr("placeholder", "Введите данные, пожалуйста!");
            $.each($dirs, function (i, $value) {
                const $val = $value;
                $($val).show("slow");
            });
        }
    });

    $('#stud').keyup(function () {
        let value = $('#stud').val(),
            hrefText = $('#a-stud').attr('href').split('=')[0] + "=" + value;

        $("#a-stud").attr("href", hrefText);
    });

    $('#teac').keyup(function () {
        let value = $('#teac').val(),
            hrefText = $('#a-teacher').attr('href').split('=')[0] + "=" + value;

        $("#a-teacher").attr("href", hrefText);
    });

    $('#schedule').keyup(function () {
        let value = $('#schedule').val(),
            hrefText = $('#a-schedule').attr('href').split('=')[0] + "=" + value;

        $("#a-schedule").attr("href", hrefText);
    });
});