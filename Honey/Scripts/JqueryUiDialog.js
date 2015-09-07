

$(window).load(function () {

    var dialog, form,

      emailRegex = /^[a-zA-Z0-9.!#$%&'*+\/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$/,
      name = $("[id$=txtName]"),
      amount = $("[id$=txtAmount]"),
      email = $("[id$=txtEmail]"),
      number = $("[id$=txtNumber]"),
      drpList = $("[id$=drpHoney] :selected"),

      allFields = $([]).add(name).add(email).add(amount).add(number).add(drpList),
      tips = $(".validateTipsError");

    function updateTips(t) {
        tips
        .text(t)
        .addClass("ui-state-highlight");
        setTimeout(function () {
            tips.removeClass("ui-state-highlight", 1500);
        }, 500);
    }

    function checkLength(o, n, min, max) {
        if (o.val().length > max || o.val().length < min) {
            o.addClass("ui-state-error");
            updateTips(n + " має містити від " +
          min + " до " + max + " символів.");
            return false;
        } else {
            return true;
        }
    }

    function checkRegexp(o, regexp, n) {
        if (!(regexp.test(o.val()))) {
            o.addClass("ui-state-error");
            updateTips(n);
            return false;
        } else {
            return true;
        }
    }

    function checkEmail(o, regexp, n) {
        if (o.val().length == 0 || o.val() == 'Email') {
            o.val('');
            return true;
        }
        else {
            return checkRegexp(o, regexp, n);
        }
    }

    function checkDropDownText(n) {
        if ($("[id$=drpHoney] :selected").text() == "--Вибрати мед--") {
            $("[id$=drpHoney]").addClass("ui-state-error");
            updateTips(n);
            return false;
        }
        else {
            return true;
        }

    }
    function checkAmountClientInput(n) {
        if (parseFloat($("[id$=txtAmount]").val()) > parseFloat($("[id$=txtAmountUnch]").val())) {

            $("[id$=txtAmount]").addClass("ui-state-error");
            updateTips(n);
            return false;
        }
        else {
            var replaced = $("[id$=txtAmount]").val().replace(/\./g, ',');
            $("[id$=txtAmount]").val(replaced);
            return true;
        }
    }

    function Purchase() {
        var valid = true;
        allFields.removeClass("ui-state-error");

        valid = valid && checkDropDownText("Виберіть мед зі списку");

        valid = valid && checkLength(amount, "Об'єм", 1, 16);
        valid = valid && checkRegexp(amount, /^[0-9]+([\.][0-9]+)?$/g, "Кількість літрів має складатись з [0-9] або [0-.9]");
        valid = valid && checkAmountClientInput("Більше ніж у наявності");

        valid = valid && checkLength(name, "Ім'я", 3, 16);

        valid = valid && checkLength(number, "Номер", 5, 16);
        valid = valid && checkRegexp(number, /^[0-9]+$/i, "Телефон має містити тільки цифри.");

        valid = valid && checkLength(email, "Email", 0, 80);
        valid = valid && checkEmail(email, emailRegex, "eg. med@lviv.com");


        if (valid) {
            dialog.dialog("close");
            $("[id$=btnAccept]").trigger("click");
        }
        return valid;
    }

    function Ajax() {
        $.ajax({
            type: "POST",
            url: "Default.aspx/PriceOfSelectedHoney",
            data: JSON.stringify({ "selectedHoney": $("[id$=drpHoney] :selected").text() }),
            contentType: "application/json;charset=utf-8",
            dataType: 'json',
            async: false,

            success: function (msg) {

                var obj = jQuery.parseJSON(msg.d);
                var remains = obj.Remains.toFixed(1);
                $("[id$=txtAmountUnch]").val(remains + "л");
                $("[id$=txtPriceUnch]").val(obj.Cost + "грн/л");
                OpenDialog();
            },
            error: function (msg) {
                alert(msg.d + " ErRor");
            }
        });

    }
    function OpenDialog() {
        dialog = $("#dialog-form").dialog({
            autoOpen: false,
            zIndex: 700,
            height: 450,
            width: 500,
            modal: true,
            buttons: {
                "Купити": function () {
                    Purchase();
                },
                Cancel: function () {

                    dialog.dialog("close");
                }
            },
            close: function () {
                allFields.removeClass("ui-state-error");


            }
        });

        $("#dialog-form").parent().appendTo($("form:first"));
        dialog.dialog("open");

    }

    $("#create-user").click(function (e) {
        e.preventDefault();
        Ajax();

    });

    $(".Buy").click(function () {
        var divTitle = $(this).attr('data');
        if (String(divTitle) == "none") {
            return;
        }
        $("[id$=drpHoney] option").each(function () {
            this.selected = $(this).text() == divTitle;
        });
        Ajax();
    });

    $("[id$=drpHoney]").change(function () {
        $("#drpHoney").removeClass("ui-state-error");
        Ajax();

    });
});
  