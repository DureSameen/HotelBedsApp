function InitDates() {
    $.fn.datepicker.defaults.format = "dd/mm/yyyy";
    //$(".hasDatepicker").hide();

    //  $(".date").bind("focus", function () {
    //    var controlid = $(this).attr("id");
    //    var nextid = $("#" + controlid).parent().next();
    //    if (nextid.hasClass("hasDatepicker"))
    //        nextid.show();
         
    //});

    $('.dates').datepicker({ 
    });;
    //$.validator.addMethod('date',
    //function (value, element) {
    //    if (this.optional(element)) {
    //        return true;
    //    }

    //    var ok = true;
    //    try {
    //        $.datepicker.parseDate('dd/mm/yy', value);
    //    }
    //    catch (err) {
    //        ok = false;
    //    }
    //    return ok;
    //});
   
}
function InitSearch(CurrentDatetime, ServerDatetime, GetAutocompleteListURL) {
    $(".ui-loading").css("display", "none");


    //if (($("#CheckInDate").val() == '') || ($("#CheckInDate").val() == '01/01/0001') || ($("#CheckInDate").val() == CurrentDatetime)) 
    //{
    //    $("#CheckInDate").val(ServerDatetime);
       
    //}
    //if (($("#CheckOutDate").val() == '') || ($("#CheckOutDate").val() == '01/01/0001') || ($("#CheckOutDate").val() == CurrentDatetime)) {
        
 
    //    var dt = $("#CheckInDate").val().split("/");
        
    //    var joindate = new Date(
    //                    parseInt(dt[2], 10),
    //                    parseInt(dt[1], 10) - 1,
    //                    parseInt(dt[0], 10)
    //                );

    //    joindate.setDate(joindate.getDate() + 7);
    //    var dd = ("0" + (joindate.getDate())).slice(-2);
    //    var mm = ("0" + (joindate.getMonth() + 1)).slice(-2);
    //    var yy = joindate.getFullYear();
    //    var retdate = dd + "/" + mm + "/" + yy;
    //    $("#CheckOutDate").val(retdate);

    //}

    
      

       //$("#CheckInDate").bind("change", function () {
       //    var dt = $("#CheckInDate").val().split("/");
          
       //    var joindate = new Date(
       //                 parseInt(dt[2], 10),
       //                 parseInt(dt[1], 10) - 1,
       //                 parseInt(dt[0], 10)
       //             );

       //    joindate.setDate(joindate.getDate() + 7);
       //    var dd = ("0" + (joindate.getDate())).slice(-2);
       //    var mm = ("0" + (joindate.getMonth() + 1)).slice(-2);
       //    var yy = joindate.getFullYear();
       //    var retdate = dd + "/" + mm + "/" + yy;
       //    $("#CheckOutDate").val(retdate);
       //});


    $("#NumberOfRooms").bind("change", function () {
        var option = $("#NumberOfRooms").val();

        if (option == 1) { 
            $("#pnlRoom2Option").css("display", 'none');
            $("#pnlRoom3Option").css("display", 'none');
        }
        else if (option == 2) {
 
            $("#pnlRoom2Option").css("display", 'block');
            if ($("#RoomTwoAdults").val() == '' || $("#RoomTwoAdults").val() == '0')
            $("#RoomTwoAdults").val("1");
            $("#pnlRoom3Option").css("display", 'none');
        }
        else if (option == 3) {
            $("#pnlRoom2Option").css("display", 'block');
            $("#pnlRoom3Option").css("display", 'block');
            if ($("#RoomThreeAdults").val() == '' || $("#RoomThreeAdults").val() == '0')
            $("#RoomThreeAdults").val("1");
        }

 
    });

 

    $(".but").on("click", function () {
        var id = this.id;
        var fldId = id.substring(0, id.length - 3);
        var lowboundvalue = (fldId.indexOf("Adults") !== -1) ? 1 : 0;
        var inc = id.substring(id.length - 3) == "inc";
        var fld = $("#" + fldId);
        var val = +fld.val();
        if (val < 0)
        { val = Math.abs(val); }
        if (inc) {
            if (val < 9)
            { val++; }
        }
        else
        { if (val > lowboundvalue) { val--; } }
        fld.val(val);
    });
}


 


 


    