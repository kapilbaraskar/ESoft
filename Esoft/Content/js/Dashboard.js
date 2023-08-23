function DisplayDashBoardData(Data) {

    //code For Marquee tag
    if (Data.Table != null && Data.Table.length > 0 && Data.Table != undefined) {
        $("#marqueeTag").html(Data.Table[0]['mrqTest'])
    } else { $("#marqueeTag").html(''); $("#marqueeTag").html('No Data'); }

    //if (Data.Table1 != null && Data.Table1.length > 0 && Data1.Table != undefined) { } else { $("#tb1").html(''); $("#tb1").html('No Data'); }
    //if (Data.Table3 != null && Data.Table3.length > 0 && Data.Table3 != undefined) { } else { $("#tb1").html(''); $("#tb1").html('No Data'); }

    //Code For Pending Request
    if (Data.Table5 != null && Data.Table5.length > 0 && Data.Table5 != undefined) {
        var str =''
        str += '<table class="table table-sm" >';
        str += '<thead style="position: sticky;top: 0;">';
        str += '<tr>';
        str += '<th scope="col" class="w-75">Request</th>';
        str += '<th scope = "col" > No. of Peinding</th>';
        str += '</tr>';
        str += '</thead>';
        str += '<tbody>';
        for (var i = 0; i < Data.Table5.length; i++) {
            str += '<tr>'
            str += '<td>' + Data.Table5[i]['RecDesc']+'</td>'
            str += '<td>' + Data.Table5[i]['ReqStatus']+'</td>'
            str += '</tr>'
        }
        str += '</tbody>';
        str += '</table>';

        $("#dashboardPendingReq").html(str);
    } else {
        $("#dashboardPendingReq").html('');
        $("#dashboardPendingReq").html('No Data');
    }

    // Code For Employee Detail
    if (Data.Table7 != null && Data.Table7.length > 0 && Data.Table7 != undefined) {
        var str = ''
        str += '<table class="table table-sm" >';
        str += '<thead style="position: sticky;top: 0;">';
        str += '<tr>';
        str += '<th scope="col" class="w-75">Description</th>';
        str += '<th scope = "col" >No. of Candidates</th>';
        str += '</tr>';
        str += '</thead>';
        str += '<tbody>';
        for (var i = 0; i < Data.Table7.length; i++) {
            str += '<tr>'
            str += '<td>' + Data.Table7[i]['RecDesc'] + '</td>'
            str += '<td>' + Data.Table7[i]['TotCandidt'] + '</td>'
            str += '</tr>'
        }
        str += '</tbody>';
        str += '</table>';

        $("#dashboardEmployeeDetail").html(str);
    } else {
        $("#dashboardEmployeeDetail").html('');
        $("#dashboardEmployeeDetail").html('No Data');
    }


    // Code For Birthday/Anniversary Data
    if (Data.Table4 != null && Data.Table4.length > 0 && Data.Table4 != undefined) {
        
        var str = ''
        str += '<table class="table table-sm" >';
        str += '<thead style="position: sticky;top: 0;">';
        str += '<tr>';
        str += '<th style="width: 100px;">EMP ID</th>';
        str += '<th style="">EMP Name</th>';
        str += '<th style="">Mobile</th>';
        str += '<th style="">BirthDay</th>';
       

      
            str += '</tr>';
            str += '</thead>';
            str += '<tbody>';
            for (var i = 0; i < Data.Table4.length; i++) {
                str += '<tr>'
                str += '<td>' + Data.Table4[i]['EmpID'] + '</td>'
                str += '<td>' + Data.Table4[i]['EmpName'] + '</td>'
                str += '<td>' + Data.Table4[i]['MobNum'] + '</td>'
                str += '<td>' + Data.Table4[i]['BirthDayDate'] + '</td>'
                str += '</tr>'
            }
        
        
        str += '</tbody>';
        str += '</table>';

        $("#dashboardBirthdayAnni").html(str);
    } else {
        $("#dashboardBirthdayAnni").html('');
        $("#dashboardBirthdayAnni").html('No Data');
    }
    //if (Data.Table != null && Data.Table.length > 0 && Data.Table != undefined) { } else { $("#tb1").html(''); $("#tb1").html('No Data'); }

}

function BirthAnniJoing(e) {
    $('.DashBirthAnnibtn.activebtn').removeClass('activebtn');
    e.classList.add('activebtn');
    var btnData = $('.DashBirthAnnibtn.activebtn').attr('detalData');
    Data = DashBoardData
    $("#dashboardBirthdayAnni").html('');
    if (btnData == 'Birthday') {
        if (Data.Table4 != null && Data.Table4.length > 0 && Data.Table4 != undefined) {
            var str = ''
            str += '<table class="table table-sm" >';
            str += '<thead style="position: sticky;top: 0;">';
            str += '<tr>';
            str += '<th style="width: 100px;">EMP ID</th>';
            str += '<th style="">EMP Name</th>';
            str += '<th style="">Mobile</th>';
            str += '<th style="">BirthDay</th>';
            str += '</tr>';
            str += '</thead>';
            str += '<tbody>';
            for (var i = 0; i < Data.Table4.length; i++) {
                str += '<tr>'
                str += '<td>' + Data.Table4[i]['EmpID'] + '</td>'
                str += '<td>' + Data.Table4[i]['EmpName'] + '</td>'
                str += '<td>' + Data.Table4[i]['MobNum'] + '</td>'
                str += '<td>' + Data.Table4[i]['BirthDayDate'] + '</td>'
                str += '</tr>'
            }
            str += '</tbody>';
            str += '</table>';

            $("#dashboardBirthdayAnni").html(str);
        }
        else {
            $("#dashboardBirthdayAnni").html('');
            $("#dashboardBirthdayAnni").html('No Data');
        }
    }
    if (btnData == 'Anniversary') {
        if (Data.Table8 != null && Data.Table8.length > 0 && Data.Table8 != undefined) {
            var str = ''
            str += '<table class="table table-sm" >';
            str += '<thead style="position: sticky;top: 0;">';
            str += '<tr>';
            str += '<th style="width: 100px;">EMP ID</th>';
            str += '<th style="">EMP Name</th>';
            str += '<th style="">Mobile</th>';      
            str += '<th style="">Anniversary</th>';
            str += '</tr>';
            str += '</thead>';
            str += '<tbody>';
            for (var i = 0; i < Data.Table8.length; i++) {
                str += '<tr>'
                str += '<td>' + Data.Table8[i]['EmpID'] + '</td>'
                str += '<td>' + Data.Table8[i]['EmpName'] + '</td>'
                str += '<td>' + Data.Table8[i]['MobNum'] + '</td>'
                str += '<td>' + Data.Table8[i]['AnniversaryDate'] + '</td>'
                str += '</tr>'
            }
            str += '</tbody>';
            str += '</table>';

            $("#dashboardBirthdayAnni").html(str);
        }
        else {
            $("#dashboardBirthdayAnni").html('');
            $("#dashboardBirthdayAnni").html('No Data');
        }
    }
    if (btnData == 'Joining') {
        if (Data.Table9 != null && Data.Table9.length > 0 && Data.Table9 != undefined) {
            var str = ''
            str += '<table class="table table-sm" >';
            str += '<thead style="position: sticky;top: 0;">';
            str += '<tr>';
            str += '<th style="width: 100px;">EMP ID</th>';
            str += '<th style="">EMP Name</th>';
            str += '<th style="">Mobile</th>';         
            str += '<th style="">Joining</th>';
            str += '</tr>';
            str += '</thead>';
            str += '<tbody>';
            for (var i = 0; i < Data.Table9.length; i++) {
                str += '<tr>'
                str += '<td>' + Data.Table9[i]['EmpID'] + '</td>'
                str += '<td>' + Data.Table9[i]['EmpName'] + '</td>'
                str += '<td>' + Data.Table9[i]['MobNum'] + '</td>'
                str += '<td>' + Data.Table9[i]['JoininDate'] + '</td>'
                str += '</tr>'
            }
            str += '</tbody>';
            str += '</table>';

            $("#dashboardBirthdayAnni").html(str);
            $('#dashboardBirthdayAnni').DataTable(
                {
                    pagingType: 'full_numbers',
                    scrollX: true,
                    dom: 'Bfrtip',
                    buttons: [
                        // 'copyHtml5',
                        'excelHtml5', 'csvHtml5'
                        //, 'pdfHtml5'

                        //'copy', 'csv', 'excel', 'pdf', 'print'
                    ]
                });
        }
        else {
            $("#dashboardBirthdayAnni").html('');
            $("#dashboardBirthdayAnni").html('No Data');
        }
    }
}


