$(window).load(function () {
    $("[id$=txtName]").val('Імя');
    $("[id$=txtName]").focusin(function () {
        $("[id$=txtName]").val('');

    });
    $("[id$=txtName]").focusout(function () {
        if ($("[id$=txtName]").val() == "") {
            $("[id$=txtName]").val('Імя');
        }
    });

    $("[id$=txtAmount]").val('Кількість');
    $("[id$=txtAmount]").focusin(function () {
        $("[id$=txtAmount]").val('');

    });
    $("[id$=txtAmount]").focusout(function () {
        if ($("[id$=txtAmount]").val() == "") {
            $("[id$=txtAmount]").val('Кількість');
        }
    });

    $("[id$=txtNumber]").val('Номер');
    $("[id$=txtNumber]").focusin(function () {
        $("[id$=txtNumber]").val('');

    });
    $("[id$=txtNumber]").focusout(function () {
        if ($("[id$=txtNumber]").val() == "") {
            $("[id$=txtNumber]").val('Номер');
        }
    });

    $("[id$=txtEmail]").val('Email');
    $("[id$=txtEmail]").focus(function () {
        $("[id$=txtEmail]").val('');
    });
    $("[id$=txtEmail]").focusout(function () {
        if ($("[id$=txtEmail]").val() == "") {
            $("[id$=txtEmail]").val('Email');
        }
    });
});
  