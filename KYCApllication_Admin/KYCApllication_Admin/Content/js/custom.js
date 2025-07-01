(function ($) {
    "use strict";
    $("#form1").submit(function (e) {
        e.preventDefault();
        if(validate()){
            var name = $.trim($('input[name=name]').val());
            var mob = $.trim($('input[name=mob]').val());
            var email = $.trim($('input[name=email]').val());
            var loan_amt = $.trim($('#loan_amt :selected').val());
            var prd_name = $.trim($('#prd_name :selected').val());
            var pincode = $.trim($('input[name=pincode]').val());
            //var study = $.trim($('input[name=study]:checked').val());
            // var pass ="word";
            // var term ="yes";
            var dataString = 'name=' + name + '&mob=' + mob + '&email=' + email + '&pincode=' + pincode + '&loan_amt=' + loan_amt + '&prd_name=' + prd_name + '&pass=word&term=yes';
            $.ajax({

                type: "POST",

                url: "insert.php",

                data: dataString,

                dataType:'json',

                success: function (data) { //alert(data); return;

                    if(data['msg'] == 'done'){

                        window.location='thankyou.php';                        

                    }else{

                        //$('#mnEr').html('<b>'+data['msg']+'</b>');
                        swal(data['msg'],"", "warning");
                    }

                }

            });

        }else{

            e.preventDefault();

        }

    });



function validate(){

    var rtn = true;

    var regex = /^[a-zA-Z ]{2,30}$/;    

    var regex1 = /^[a-zA-Z0-9 ]{2,3000}$/;    

    $('#q2').html(''); $('#q1').html(''); $('#nEr').html(''); $('#mEr').html(''); $('#eEr').html(''); $('#q3').html(''); $('#tEr').html(''); $('#q4Er').html(''); $('#q5').html('');

    if($.trim($('input[name=name]').val()) == ''){

        rtn = false;

        $('#nEr').html('Name is required.');

    }else if(!regex.test($.trim($('input[name=name]').val()))){

        rtn = false;

        $('#nEr').html('Invalid Name.');

    }

    if($.trim($('input[name=mob]').val()).length != 10){ 

        rtn = false;

        $("#mEr").html("Mobile number must be 10 digit.");

    }

    if(!$.trim($('input[name=email]').val())) {

        rtn = false;

        $("#eEr").html("Email ID is required.");

    }

    if(!$.trim($('input[name=email]').val()).match(/^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/)) {

        rtn = false;

        $("#eEr").html("Invalid Email ID.");

    }

    if($.trim($('[name=loan_amt]').val()) == ''){

        rtn = false;

        $('#q1').html('Select loan amount is required.');

    }

    if($.trim($('[name=prd_name]').val()) == ''){

        rtn = false;

        $('#q2').html('Select product name is required.');

    }

    if($('[name=term]:checked').val() != 'yes'){

        rtn = false;

        $('#tEr').html('Please Accept the Terms & Conditions.');

    }

    return rtn;

}

})(jQuery);



