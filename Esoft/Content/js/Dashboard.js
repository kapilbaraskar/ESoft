function DisplayDashBoardData(Data) {

    //code For Marquee tag
    if (Data.Table != null && Data.Table.length > 0 && Data.Table != undefined) {
        $("#marqueeTag").html(Data.Table[0]['mrqTest'])
    } else { $("#marqueeTag").html(''); $("#marqueeTag").html('No Data'); }
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
        $("#dashboardPendingReq").css("padding-top", "0%");
    } else {
        $("#dashboardPendingReq").html('');
        $("#dashboardPendingReq").html('No Data');
        $("#dashboardPendingReq").css("text-align", "center");
        $("#dashboardPendingReq").css("padding-top", "10%");
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
        $("#dashboardEmployeeDetail").css("padding-top", "0%")

    } else {
        $("#dashboardEmployeeDetail").html('');
        $("#dashboardEmployeeDetail").html('No Data');
        $("#dashboardEmployeeDetail").css("text-align", "center")
        $("#dashboardEmployeeDetail").css("padding-top", "10%")
    }


    // Code For Birthday/Anniversary Data
    if (Data.Table4 != null && Data.Table4.length > 0 && Data.Table4 != undefined) {
        var str = ''
        str += '<table class="table table-sm" id="dashboardBirthdayAnni">';
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


        $("#BirthAnniReportDiv").html(str);
        $("#BirthAnniReportDiv").css("padding-top", "0%")
    } else {
        $("#BirthAnniReportDiv").html('');
        $("#BirthAnniReportDiv").html('No Data');
        $("#BirthAnniReportDiv").css("text-align", "center")
        $("#BirthAnniReportDiv").css("padding-top", "10%")
    }


    //Code For Chart Data
    if (Data.Table6 != null && Data.Table6.length > 0 && Data.Table6 != undefined) {
        var ChartData = new Array();
        var lables = new Array();
        var lableChart = new Array();
        var DataSource = new Array();
        var BarColor = new Array();
        var LableFieldTitle = new Array();
        ChartData = Data.Table6;
        lableChart = ['ValFld1', 'ValFld2', 'ValFld3', 'ValFld4', 'ValFld5']
        BarColor = ['#AFBAFD', '#AFFDF5', '#B3FDAF', '#FDAFC3', '#FDEDAF']
        LableFieldTitle = ['ValFld1Title', 'Prv Yr Sal', 'ValFld3Title', 'ValFld4Title', 'ValFld5Title']

        for (var i = 0; i < ChartData.length; i++) {
            lables.push(ChartData[i]['FldDscription']);

        }

        for (var k = 0; k < lableChart.length; k++) {
            var obj = new Object();
            var labelData = new Array()
            obj['label'] = LableFieldTitle[k];
            obj['backgroundColor'] = BarColor[k];

            for (var j = 0; j < ChartData.length; j++) {
                labelData.push(ChartData[j][lableChart[k]]);
            }
            obj['data'] = labelData
            DataSource.push(obj)
        }


        var myContext = document.getElementById("stackedChartID").getContext('2d');
        var myChart = new Chart(myContext, {
            type: 'bar',
            data: {
                labels: lables,
                datasets: DataSource,
            },
            options: {
                plugins: {
                    title: {
                        display: false,
                        text: 'Stacked Bar chart for pollution status'
                    },
                    legend: {
                        display: true,
                        position: 'bottom'
                    }
                },
                scales: {
                    x: {
                        stacked: true,
                    },
                    y: {
                        stacked: true
                    }
                }
            }
        });


        $("#stackedChartID").css("padding-top", "0%")
    } else {

        $("#stackedChartID").html(''); $("#stackedChartID").html('No Data');
        $("#stackedChartID").css("text-align", "center")
        $("#stackedChartID").css("padding-top", "10%")
    }

}

function BirthAnniJoing(e) {
    $('.DashBirthAnnibtn.activebtn').removeClass('activebtn');
    e.classList.add('activebtn');
    var btnData = $('.DashBirthAnnibtn.activebtn').attr('detalData');
    Data = DashBoardData
    $("#BirthAnniReportDiv").html('');
    if (btnData == 'Birthday') {
        if (Data.Table4 != null && Data.Table4.length > 0 && Data.Table4 != undefined) {
            var str = ''
            str += '<table class="table table-sm" id="dashboardBirthdayAnni">';
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

            $("#BirthAnniReportDiv").html(str);
            $("#BirthAnniReportDiv").css("padding-top", "0%")
        }
        else {
            $("#BirthAnniReportDiv").html('');
            $("#BirthAnniReportDiv").html('No Data');
            $("#BirthAnniReportDiv").css("text-align", "center")
            $("#BirthAnniReportDiv").css("padding-top", "10%")
        }
    }
    if (btnData == 'Anniversary') {
        if (Data.Table8 != null && Data.Table8.length > 0 && Data.Table8 != undefined) {
            var str = ''
            str += '<table class="table table-sm" id="dashboardBirthdayAnni">';
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

            $("#BirthAnniReportDiv").html(str);

            $("#BirthAnniReportDiv").css("padding-top", "0%")
        }
        else {
            $("#BirthAnniReportDiv").html('');
            $("#BirthAnniReportDiv").html('No Data');
            $("#BirthAnniReportDiv").css("text-align", "center")
            $("#BirthAnniReportDiv").css("padding-top", "10%")
        }
    }
    if (btnData == 'Joining') {
        if (Data.Table9 != null && Data.Table9.length > 0 && Data.Table9 != undefined) {
            var str = ''
            str += '<table class="table table-sm" id="dashboardBirthdayAnni">';
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

            $("#BirthAnniReportDiv").html(str);
            $("#BirthAnniReportDiv").css("padding-top", "0%")

        }
        else {
            $("#BirthAnniReportDiv").html('');
            $("#BirthAnniReportDiv").html('No Data');
            $("#BirthAnniReportDiv").css("text-align", "center")
            $("#BirthAnniReportDiv").css("padding-top", "10%")
        }

    }

}



