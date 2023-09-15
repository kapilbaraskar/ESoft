// Call the dataTables jQuery plugin
$(document).ready(function() {
    //$('#dataTable').DataTable();
    $('#dataTable').DataTable({
        dom: 'Bfrtip',
        buttons: [
           'copyHtml5','excelHtml5','csvHtml5','pdfHtml5'

            //'copy', 'csv', 'excel', 'pdf', 'print'
        ]
    });

    //display_grid(resultdata, datatableProp_Json, DisplayGridDivId);
   
});

var getdatatableProp_Json, DisplayGridDivId, Controlername, Methodname, querystr, value, query, operator, query_data, called_method, Cascaded_called_method, checkRadioQ, DataTable_Property;  // Add some globle var to get data
//var datatableProp_Json = JSON.parse('{"scrollX":true,"excelPdf":true,"rightalign":true,"targets":[-1,-2],"className":"dt-body-right","HasLeftfixedColumns":true,"HasRightfixedColumns":true,"RightfixedColumns":1,"LeftfixedColumns":1}');
var datatableProp_Json = JSON.parse('{"scrollX":true,"excelPdf":true,"rightalign":true,"targets":[-1,-2],"className":"dt-body-right"}')

DisplayGridDivId = 'display_grid'
var resultdata = [
    {
        "TA_Name": "SAI ",
        "Booking_Id": "MFM100",
        "ta_id": "T0002454",
        "booking_sr_no": "3975",
        "service_id": "1670",
        "TotalServices": "1",
        "Total_Amount": "207272",
        "Booking_Date": "03-10-2022",
        "Travel_Date": "06-10-2022",
        "TA_Requisition_No": "MFM100",
        "Rezmytrip_status": "Pending",
        "Customer_name": "Sandip Chaniyara",
        "company_status": "Pending",
        "payment_status": "N",
        "vouchered_status": "N",
        "invoice_status": "N",
        "payment_received_flag": "N",
        "no_of_pax": "2",
        "payment_received_pending": "N",
        "Due_Amount": "207272.00",
        "IndemnityBond": "",
        "Checkout_Date": "11-Oct-22 12:00:00 AM",
        "Formated_Checkout_Date": "11-10-2022",
        "RoomNight": "5",
        "SendConfirmToTA_Status": "False"
    },
    {
        "TA_Name": "SAI ",
        "Booking_Id": "MQ199",
        "ta_id": "T0002454",
        "booking_sr_no": "3954",
        "service_id": "1681",
        "TotalServices": "1",
        "Total_Amount": "2265",
        "Booking_Date": "03-09-2022",
        "Travel_Date": "05-09-2022",
        "TA_Requisition_No": "MQ199",
        "Rezmytrip_status": "Confirmed",
        "Customer_name": "Sandip Chaniyara",
        "company_status": "Confirmed",
        "payment_status": "N",
        "vouchered_status": "N",
        "invoice_status": "N",
        "payment_received_flag": "N",
        "no_of_pax": "3",
        "payment_received_pending": "Y",
        "Due_Amount": "265.00",
        "IndemnityBond": "",
        "Checkout_Date": "08-Sep-22 12:00:00 AM",
        "Formated_Checkout_Date": "08-09-2022",
        "RoomNight": "3",
        "SendConfirmToTA_Status": "True"
    },
    {
        "TA_Name": "SANDIPAGENCY",
        "Booking_Id": "MFM99",
        "ta_id": "T0002457",
        "booking_sr_no": "3973",
        "service_id": "1647",
        "TotalServices": "1",
        "Total_Amount": "7559",
        "Booking_Date": "05-09-2022",
        "Travel_Date": "05-09-2022",
        "TA_Requisition_No": "MFM99",
        "Rezmytrip_status": "Pending",
        "Customer_name": "Urvashi Joshi",
        "company_status": "Pending",
        "payment_status": "N",
        "vouchered_status": "N",
        "invoice_status": "N",
        "payment_received_flag": "N",
        "no_of_pax": "6",
        "payment_received_pending": "N",
        "Due_Amount": "7559.00",
        "IndemnityBond": "",
        "Checkout_Date": "09-Sep-22 12:00:00 AM",
        "Formated_Checkout_Date": "09-09-2022",
        "RoomNight": "8",
        "SendConfirmToTA_Status": "False"
    },
    {
        "TA_Name": "MOSAM TOURS",
        "Booking_Id": "MQ198",
        "ta_id": "T0002466",
        "booking_sr_no": "3947",
        "service_id": "1668",
        "TotalServices": "1",
        "Total_Amount": "217",
        "Booking_Date": "02-09-2022",
        "Travel_Date": "06-09-2022",
        "TA_Requisition_No": "MQ198",
        "Rezmytrip_status": "Confirmed",
        "Customer_name": "Urvashi Joshi",
        "company_status": "Confirmed",
        "payment_status": "N",
        "vouchered_status": "N",
        "invoice_status": "N",
        "payment_received_flag": "N",
        "no_of_pax": "3",
        "payment_received_pending": "N",
        "Due_Amount": "217.00",
        "IndemnityBond": "",
        "Checkout_Date": "10-Sep-22 12:00:00 AM",
        "Formated_Checkout_Date": "10-09-2022",
        "RoomNight": "4",
        "SendConfirmToTA_Status": "True"
    },
    {
        "TA_Name": "SAI ",
        "Booking_Id": "MFM97",
        "ta_id": "T0002454",
        "booking_sr_no": "3971",
        "service_id": "1647",
        "TotalServices": "1",
        "Total_Amount": "1540",
        "Booking_Date": "05-09-2022",
        "Travel_Date": "06-09-2022",
        "TA_Requisition_No": "MFM97",
        "Rezmytrip_status": "Pending",
        "Customer_name": "Sandip Chaniyara",
        "company_status": "Pending",
        "payment_status": "N",
        "vouchered_status": "N",
        "invoice_status": "N",
        "payment_received_flag": "N",
        "no_of_pax": "2",
        "payment_received_pending": "N",
        "Due_Amount": "1540.00",
        "IndemnityBond": "",
        "Checkout_Date": "09-Sep-22 12:00:00 AM",
        "Formated_Checkout_Date": "09-09-2022",
        "RoomNight": "3",
        "SendConfirmToTA_Status": "False"
    },
    {
        "TA_Name": "SANDIPAGENCY",
        "Booking_Id": "MFM96",
        "ta_id": "T0002457",
        "booking_sr_no": "3970",
        "service_id": "1647",
        "TotalServices": "1",
        "Total_Amount": "6529",
        "Booking_Date": "05-09-2022",
        "Travel_Date": "05-09-2022",
        "TA_Requisition_No": "MFM96",
        "Rezmytrip_status": "Pending",
        "Customer_name": "Urvashi Joshi",
        "company_status": "Pending",
        "payment_status": "N",
        "vouchered_status": "N",
        "invoice_status": "N",
        "payment_received_flag": "N",
        "no_of_pax": "5",
        "payment_received_pending": "N",
        "Due_Amount": "6529.00",
        "IndemnityBond": "",
        "Checkout_Date": "09-Sep-22 12:00:00 AM",
        "Formated_Checkout_Date": "09-09-2022",
        "RoomNight": "8",
        "SendConfirmToTA_Status": "False"
    },
    {
        "TA_Name": "SAI ",
        "Booking_Id": "MFM95",
        "ta_id": "T0002454",
        "booking_sr_no": "3969",
        "service_id": "1647",
        "TotalServices": "1",
        "Total_Amount": "1540",
        "Booking_Date": "05-09-2022",
        "Travel_Date": "07-09-2022",
        "TA_Requisition_No": "MFM95",
        "Rezmytrip_status": "Pending",
        "Customer_name": "Sandip Chaniyara",
        "company_status": "Pending",
        "payment_status": "N",
        "vouchered_status": "N",
        "invoice_status": "N",
        "payment_received_flag": "N",
        "no_of_pax": "2",
        "payment_received_pending": "N",
        "Due_Amount": "1540.00",
        "IndemnityBond": "",
        "Checkout_Date": "10-Sep-22 12:00:00 AM",
        "Formated_Checkout_Date": "10-09-2022",
        "RoomNight": "3",
        "SendConfirmToTA_Status": "False"
    },
    {
        "TA_Name": "SANDIPAGENCY",
        "Booking_Id": "MFM85",
        "ta_id": "T0002457",
        "booking_sr_no": "3958",
        "service_id": "1647",
        "TotalServices": "1",
        "Total_Amount": "4857",
        "Booking_Date": "03-09-2022",
        "Travel_Date": "09-09-2022",
        "TA_Requisition_No": "MFM85",
        "Rezmytrip_status": "Confirmed",
        "Customer_name": "Urvashi Joshi",
        "company_status": "Confirmed",
        "payment_status": "N",
        "vouchered_status": "N",
        "invoice_status": "N",
        "payment_received_flag": "N",
        "no_of_pax": "6",
        "payment_received_pending": "N",
        "Due_Amount": "4857.00",
        "IndemnityBond": "",
        "Checkout_Date": "13-Sep-22 12:00:00 AM",
        "Formated_Checkout_Date": "13-09-2022",
        "RoomNight": "8",
        "SendConfirmToTA_Status": "True"
    },
    {
        "TA_Name": "SAI ",
        "Booking_Id": "MFM82",
        "ta_id": "T0002454",
        "booking_sr_no": "3955",
        "service_id": "1647",
        "TotalServices": "2",
        "Total_Amount": "7618",
        "Booking_Date": "03-09-2022",
        "Travel_Date": "09-09-2022",
        "TA_Requisition_No": "MFM82",
        "Rezmytrip_status": "Confirmed",
        "Customer_name": "sandip patel",
        "company_status": "Confirmed",
        "payment_status": "Y",
        "vouchered_status": "N",
        "invoice_status": "N",
        "payment_received_flag": "N",
        "no_of_pax": "6",
        "payment_received_pending": "Y",
        "Due_Amount": "0.00",
        "IndemnityBond": "",
        "Checkout_Date": "13-Sep-22 12:00:00 AM",
        "Formated_Checkout_Date": "13-09-2022",
        "RoomNight": "8",
        "SendConfirmToTA_Status": "True"
    },
    {
        "TA_Name": "SAI ",
        "Booking_Id": "MFM81",
        "ta_id": "T0002454",
        "booking_sr_no": "3953",
        "service_id": "1647",
        "TotalServices": "1",
        "Total_Amount": "3821",
        "Booking_Date": "03-09-2022",
        "Travel_Date": "06-09-2022",
        "TA_Requisition_No": "MFM81",
        "Rezmytrip_status": "Pending",
        "Customer_name": "sandip patel",
        "company_status": "Pending",
        "payment_status": "N",
        "vouchered_status": "N",
        "invoice_status": "N",
        "payment_received_flag": "N",
        "no_of_pax": "4",
        "payment_received_pending": "N",
        "Due_Amount": "3821.00",
        "IndemnityBond": "",
        "Checkout_Date": "10-Sep-22 12:00:00 AM",
        "Formated_Checkout_Date": "10-09-2022",
        "RoomNight": "4",
        "SendConfirmToTA_Status": "True"
    },
    {
        "TA_Name": "SAI ",
        "Booking_Id": "MFM79",
        "ta_id": "T0002454",
        "booking_sr_no": "3951",
        "service_id": "1647",
        "TotalServices": "1",
        "Total_Amount": "3416",
        "Booking_Date": "02-09-2022",
        "Travel_Date": "06-09-2022",
        "TA_Requisition_No": "MFM79",
        "Rezmytrip_status": "Pending",
        "Customer_name": "Sandip Chaniyara",
        "company_status": "Pending",
        "payment_status": "N",
        "vouchered_status": "N",
        "invoice_status": "N",
        "payment_received_flag": "N",
        "no_of_pax": "6",
        "payment_received_pending": "N",
        "Due_Amount": "3416.00",
        "IndemnityBond": "",
        "Checkout_Date": "09-Sep-22 12:00:00 AM",
        "Formated_Checkout_Date": "09-09-2022",
        "RoomNight": "6",
        "SendConfirmToTA_Status": "False"
    },
    {
        "TA_Name": "SAI ",
        "Booking_Id": "MFM78",
        "ta_id": "T0002454",
        "booking_sr_no": "3950",
        "service_id": "1647",
        "TotalServices": "1",
        "Total_Amount": "3080",
        "Booking_Date": "02-09-2022",
        "Travel_Date": "05-09-2022",
        "TA_Requisition_No": "MFM78",
        "Rezmytrip_status": "Pending",
        "Customer_name": "Sandip Chaniyara",
        "company_status": "Pending",
        "payment_status": "N",
        "vouchered_status": "N",
        "invoice_status": "N",
        "payment_received_flag": "N",
        "no_of_pax": "4",
        "payment_received_pending": "N",
        "Due_Amount": "3080.00",
        "IndemnityBond": "",
        "Checkout_Date": "08-Sep-22 12:00:00 AM",
        "Formated_Checkout_Date": "08-09-2022",
        "RoomNight": "6",
        "SendConfirmToTA_Status": "False"
    },
    {
        "TA_Name": "SANDIPAGENCY",
        "Booking_Id": "MFM75",
        "ta_id": "T0002457",
        "booking_sr_no": "3946",
        "service_id": "1647",
        "TotalServices": "1",
        "Total_Amount": "2179",
        "Booking_Date": "02-09-2022",
        "Travel_Date": "02-09-2022",
        "TA_Requisition_No": "MFM75",
        "Rezmytrip_status": "Pending",
        "Customer_name": "Urvashi Joshi",
        "company_status": "Pending",
        "payment_status": "N",
        "vouchered_status": "N",
        "invoice_status": "N",
        "payment_received_flag": "N",
        "no_of_pax": "4",
        "payment_received_pending": "N",
        "Due_Amount": "2179.00",
        "IndemnityBond": "",
        "Checkout_Date": "05-Sep-22 12:00:00 AM",
        "Formated_Checkout_Date": "05-09-2022",
        "RoomNight": "3",
        "SendConfirmToTA_Status": "False"
    }

]



//Display Data in Datatable Start -> 22/07/2022
function display_grid(resultdata, datatableProp_Json, DisplayGridDivId) {
    debugger;
    DataTable_Property = datatableProp_Json;
    if (resultdata[0] == '{') {
        objGetData = JSON.parse(result);
    }
    else {
        resultdata;
    }
    var portion = "DetailList" //main div id

    //var section = document.createElement("section");
    //section.className = "content"

    //var section_div = document.createElement("div");
    //section_div.className = "row";
    //section.appendChild(section_div);

    var section_col = document.createElement("div");
    section_col.className = "col-md-12";
    //section_div.appendChild(section_col);

    var section_containarFlu = document.createElement("div");
    section_containarFlu.className = "container-fluid";
    section_col.appendChild(section_containarFlu);

    var section_div_row = document.createElement("div");
    section_div_row.className = "row";

    section_containarFlu.appendChild(section_div_row);

    var detaildiv = document.createElement("div");
    detaildiv.id = portion;
    detaildiv.setAttribute('style', 'width:100%',)
    section_div_row.appendChild(detaildiv);
    //detaildiv.className = "row";

    //Create table
    var tbl = document.createElement("table");
    tbl.id = portion + '_table';
    detaildiv.appendChild(tbl);

    var tbl_attr = document.createAttribute("data-row-count");
    tbl_attr.value = '1';
    tbl.setAttributeNode(tbl_attr)
    tbl.className = "dataTable table table-bordered table-striped table-condensed";

    //create head
    var thead = document.createElement("thead");
    var theadrow = document.createElement("tr");
    theadrow.id = portion + "_headrow";

    //create tbody
    var tbody = document.createElement("tbody");
    tbody.id = portion + '_detail_body';


    //Count number of columns
    var col = [];
    for (var i = 0; i < resultdata.length; i++) {
        for (var key in resultdata[i]) {
            if (col.indexOf(key) === -1) {
                col.push(key);
            }
        }
    }

    //Bind data in thead
    for (var i = 0; i < col.length; i++) {
        var th = document.createElement("th");      // table header.
        th.innerHTML = col[i];
        th.setAttribute('style', 'color:#fff',)
        theadrow.appendChild(th);
    }



    //Bind data in tbody
    for (var i = 0; i < resultdata.length; i++) {
        tr = tbody.insertRow(-1);
        for (var j = 0; j < col.length; j++) {
            var tabCell = tr.insertCell(-1);
            tabCell.innerHTML = resultdata[i][col[j]];
        }
    }

    thead.id = portion + "_tableheader";

    thead.appendChild(theadrow);
    tbl.appendChild(thead);
    tbl.appendChild(tbody);

   
    // $('#' + DisplayGridDivId).html(section);
    $('#' + DisplayGridDivId).html(section_col);

    var obj = new Object();
    obj.scrollX = true;
    //obj.scrollXValue = "scrollX: true";
    obj.scrollY = true;
    //obj.scrollYValue = "scrollY: true";
    obj.scrollCollapse = true;
    obj.HasLeftfixedColumns = true;
    obj.HasRightfixedColumns = true;
    obj.RightfixedColumns = 0;
    obj.LeftfixedColumns = 0;

    obj.rightalign = true;
    obj.targets = 0;
    obj.className = 0;
    obj.valscrollY;
    obj.excelPdf = true;

    //obj.fixedColumnsValue = "'fixedColumns': [{ left: 1 }]";

    //"targets": [-1, -2], "className": "dt-body-right",

    var tableProp = Object(DataTable_Property);
    var objString = "{";

    if (tableProp.scrollX) {
        objString += "\"scrollX\":true,";
    }
    else {
        objString += "\"scrollX\":false,";
    }

    if (tableProp.scrollY) {
        //objString += "\"scrollY\":true,";
        objString += '\"scrollY\":"' + tableProp.valscrollY + '",';

        //var a = tableProp.valscrollY;
        //var px_status = a.includes("px");
        //if (px_status) {
        //    objString += '\"scrollY\":"' + tableProp.valscrollY + '" ';
        //}
        //else {
        //objString += "\"scrollY\":" + tableProp.valscrollY + " ";
        // }
    }
    //else if (tableProp.valscrollY.indexOf("px") == 1) {
    //    objString += "\"scrollY\":'" + tableProp.valscrollY + "' ";

    //}
    else {
        objString += "\"scrollY\":false,";
    }

    if (tableProp.HasLeftfixedColumns && tableProp.HasRightfixedColumns) {
        objString += "\"fixedColumns\": { \"leftColumns\": " + tableProp.LeftfixedColumns + ",\"rightColumns\":" + tableProp.RightfixedColumns + " },";
    }
    else if (tableProp.HasRightfixedColumns) {
        objString += "\"fixedColumns\": { \"rightColumns\":" + tableProp.RightfixedColumns + " },";
    }
    else if (tableProp.HasLeftfixedColumns) {
        objString += "\"fixedColumns\": { \"leftColumns\": " + tableProp.LeftfixedColumns + " },";
    }

    if (tableProp.rightalign) {
        objString += '\"columnDefs\":[{\"targets\": [' + tableProp.targets + '],\"className\":"' + tableProp.className + '"}],';
    }
    else {
        objString += '\"columnDefs\":[{\"targets\": [' + obj.targets + '],\"className\":"' + obj.className + '"}],';
    }

    if (tableProp.excelPdf) {
        //objString += '\"dom\":"Bfrtip",';
       // objString += '\"sDom\": "<"row - fluid"<"span6"B><"span6"f>r>t<"row - fluid"<"span6"i><"span6"p>>",';
        objString += '\"dom\":"Bfrtip",';
       // objString += '\"buttons\": ["excelHtml5",{ \"extend\":\"pdfHtml5\", \"orientation\":\"landscape\", \"pageSize\":\"LEGAL\" }]';
        objString += '\"buttons\": ["excelHtml5","pdfHtml5"]';
    }

    objString += "}";

   // $('#' + portion + '_table').DataTable(JSON.parse(objString));

    $('#' + portion + '_table').DataTable(
        {
            pagingType: 'full_numbers',
            scrollX:true,
            dom: 'Bfrtip',
            buttons: [
               // 'copyHtml5',
                'excelHtml5', 'csvHtml5'
                //, 'pdfHtml5'

                //'copy', 'csv', 'excel', 'pdf', 'print'
            ]
        });

}
// ---------------End----------------
