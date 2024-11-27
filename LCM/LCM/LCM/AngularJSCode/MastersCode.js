var myApp = angular.module("myApp", ['ngFileUpload', 'toaster', 'ngAnimate', 'datatables']);

myApp.controller("myCtrl", function ($scope, $http, $timeout, $filter, $window, $location, Upload, toaster, GetEmployeeSession) {
    // App variable to show the confirm response
    $scope.search = $window.location.search
        .split(/[&||?]/)
        .filter(function (x) { return x.indexOf("=") > -1; })
        .map(function (x) { return x.split(/=/); })
        .map(function (x) {
            x[1] = x[1].replace(/\+/g, " ");
            return x;
        })
        .reduce(function (acc, current) {
            acc[current[0]] = current[1];
            return acc;
        }, {});

    $scope.data = {};
    $scope.login = {};

    $scope.UploadFiles = function (files) {
        $scope.SelectedFiles = files;
        if ($scope.SelectedFiles && $scope.SelectedFiles.length) {
            Upload.upload({
                url: '/Cases/Upload/',
                data: {
                    files: $scope.SelectedFiles
                }
            }).then(function (response) {
                $timeout(function () {
                    $scope.Result = response.data;
                    
                });
            }, function (response) {
                if (response.status > 0) {
                    var errorMsg = response.status + ': ' + response.data;
                    alert(errorMsg);
                }
            }, function (evt) {
                var element = angular.element(document.querySelector('#dvProgress'));
                $scope.Progress = Math.min(100, parseInt(100.0 * evt.loaded / evt.total));
                element.html('<div style="width: ' + $scope.Progress + '%">' + $scope.Progress + '%</div>');
            });
        }
    };

    //----->Login<-------//
    $scope.LoadLoginPage = function () {
        var url = $window.location.href;
        if ($scope.search.CandidateId != null) {
            $scope.login.txtusername = $scope.search.CandidateId;
        }
        if (url == "https://localhost:44309/Login" || url == "http://localhost:48976/LOGIN" ) {
            $("#logo").attr("src", "~/Content/Assets/images/123.png");
            $("#logo").css({ 'width': '196px'});
            //logo.Src = "/123.png";
           // logo.Style.Add("width", "196px");
        }
        else {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
        }
    };

    $scope.Login = function () {
        $scope.getLogin = {};
        //string empiddec = Encrypt(txtusername.Text);
        //string sss = Encrypt(txtpassword.Text);
        //bl = new BlEmployee();
        //PRPSetup p = new PRPSetup();
        $scope.getLogin.ID = $scope.login.txtusername;
        $scope.getLogin.name = $scope.login.txtpassword;
        //if (Request.Browser.IsMobileDevice == true) {
        //    p.Active = "1";
        //}
        //else {
        //    p.Active = "0";
        //}
        $http({
            method: "POST",
            url: "/Dashboard/LoginCheck",
            data: JSON.stringify($scope.getLogin)
        }).then(function (response) {
            $scope.chkLogin = response.data;
            var cnt = $scope.chkLogin.length - 1;
            angular.forEach($scope.chkLogin, function (val, key) {
                if (key==0) {
                    if (val.Response==-1) {
                        $scope.login.txtusername = "";
                        $scope.login.txtpassword = "";
                    }
                    else {
                        if (cnt>0) {
                            $window.location.href = '/Dashboard/Index';
                        }
                    }
                }

            });


        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });

    };

    $scope.forget = function () {

    };

    $scope.btnSuggestion = function () {

    };

    //----->End<---------//



    $scope.PrintDIV = function () {
        var contents = document.getElementById("dvContents").innerHTML;
        var body = document.getElementsByTagName("BODY")[0];

        //Create a dynamic IFRAME.
        var frame1 = document.createElement("IFRAME");
        frame1.name = "frame1";
        frame1.setAttribute("style", "position:absolute;top:-1000000px");
        body.appendChild(frame1);

        //Create a Frame Document.
        var frameDoc = frame1.contentWindow ? frame1.contentWindow : frame1.contentDocument.document ? frame1.contentDocument.document : frame1.contentDocument;
        frameDoc.document.open();

        //Create a new HTML document.
        frameDoc.document.write('<html><head><title>Print Contents</title>');
        frameDoc.document.write('</head><body>');

        //Append the external CSS file.

        frameDoc.document.write('<link href="../Content/PrintOut.css" rel="stylesheet" type="text/css" />');

        //Append the DIV contents.
        frameDoc.document.write(contents);
        frameDoc.document.write('</body></html>');
        frameDoc.document.close();

        $window.setTimeout(function () {
            $window.frames["frame1"].focus();
            $window.frames["frame1"].print();
            body.removeChild(frame1);
        }, 500);
    };

    $scope.dateFormat = 'MM/dd/yyyy';

    $scope.mySplit = function (string, nb) {
        var array = string.toString().split("-");
        return array[nb];
    };

    $scope.Get_AllDays = function () {
        $http({
            method: "GET",
            url: "/Dept/Get_AllDay"
        }).then(function (response) {
            $scope.AllDays = response.data;
        }, function () {
            alert("Error Occur");
        });
    };

    $scope.Get_AllMonth = function () {
        $http({
            method: "GET",
            url: "/Dept/Get_AllMonth"
        }).then(function (response) {
            $scope.AllMM = response.data;
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });
    };

    $scope.Get_AllDeptt = function () {
        $http({
            method: "GET",
            url: "/Dept/Get_AllDeptt"
        }).then(function (response) {
            $scope.dept = response.data;
            $scope.MakeDatatable($("#user_table"));
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });
    };

    $scope.showdiv = function () {
        //$scope.ddlcasetype = "";
        //$scope.fillingnum = "";
        //$scope.fillingdate = "";
        //$scope.regnum = "";
        //$scope.regdt = "";
        //$scope.cnrnum = "";
        //$scope.ddlPetitioner = "";
        //$scope.ddlPetitioner_Advocate = "";
        //$scope.ddlRespondent = "";
        //$scope.ddlRespondent_Advocate = "";
        //$scope.ddlJudge = "";
        //$scope.ddlUnderAct = "";
        //$scope.ddlUnderSection = "";
        //$scope.ddlStageofCase = "";
        //$scope.ddlcourtcity = "";
        //$scope.summ = "";
        //$scope.caseamt = "";


        $http({
            method: "GET",
            url: "/Dept/get_Session_ID"
        }).then(function (response) {
            $scope.bindemp = response.data;
            angular.forEach($scope.bindemp, function (val, key) {
                $scope.dEMpresponsible = val.id;
            });

        }, function () {
            alert("Error Occur");
        });
        $("#divgy").show();
        $("#signinmodal").show();
    };

    $scope.getUserID = function () {
        $http({
            method: "GET",
            url: "/Dept/get_Session_ID"
        }).then(function (response) {
            $scope.bindemp = response.data;
            angular.forEach($scope.bindemp, function (val, key) {
                $scope.userID = val.id;
            });

        }, function () {
            alert("Error Occur");
        });
    };

    $scope.Get_AllFrequency = function () {
        $http({
            method: "GET",
            url: "/Dept/Get_AllFrequency"
        }).then(function (response) {
            $scope.frequency = response.data;
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });
    };

    $scope.Get_AllCompany = function () {
        $http({
            method: "GET",
            url: "/Dept/Get_AllCompany"
        }).then(function (response) {
            $scope.company = response.data;
            $scope.MakeDatatable($("#user_table"));
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });
    };

    $scope.GET_ALL_EMP = function () {
        $http({
            method: "GET",
            url: "/Dept/GET_ALL_EMP"
        }).then(function (response) {
            $scope.empsec = response.data;
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });
    };

    $scope.Get_AllUnitByCompany = function () {
        $http({
            method: "GET",
            url: "/Dept/Get_AllUnitByCompany"
        }).then(function (response) {
            $scope.unit = response.data;
            $scope.MakeDatatable($("#user_table"));
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });
    };

    $scope.Get_UnitById = function () {
        $scope.Employee = {};
        $scope.Employee.Emp_Name = "text";
        $scope.Employee.Emp_City = $scope.ddlcompany;
        $scope.Employee.Emp_Age = "1";
        $http({
            method: "POST",
            url: "/Dept/Get_UnitById",
            data: JSON.stringify($scope.Employee)
        }).then(function (response) {
            $scope.unitbyid = response.data;
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });
    };

    $scope.Get_VPL_complianceDashboard_Detail_with_color = function () {
        $scope.Employe = {};
        $scope.Employe.color = GetParam('color');
        $http({
            method: "POST",
            url: "/ComplianceMaster/Get_VPL_complianceDashboard_Detail_with_color",
            datatype: "json",
            data: JSON.stringify($scope.Employe)
        }).then(function (response) {
            $scope.MyOrders = response.data;
            $scope.MakeDatatable($("#user_table"));
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });
    };

    $scope.Get_VPL_Compliance_Master_Detail_withfrequency = function () {
        $http({
            method: "GET",
            url: "/ComplianceMaster/Get_VPL_Compliance_Master_Detail_withfrequency"
        }).then(function (response) {
            $scope.Compiance_with_freq = response.data;
            $scope.MakeDatatable($("#compliance_ins"));
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });
    };

    $scope.VPL_Compliance_InfoRequired = function () {
        $scope.Employe = {};
        $scope.Employe.CID = GetParam('CID');

        $http({
            method: "post",
            url: "/ComplianceMaster/VPL_Compliance_InfoRequired",
            datatype: "json",
            data: JSON.stringify($scope.Employe)
        }).then(function (response) {
            $scope.empinfo = response.data;
            $scope.MakeDatatable($("#tblEmpInfo"));
        });
    };

    $scope.getDivColor = function (colorIndex) {
        switch (colorIndex) {
            case 1: return '#03A9F4';
            case 2: return '#CDDC39';
            case 3: return '#a172f5';
            case 4: return '#F44336';
            default: return '#03A9F4';
        }
    };

    $scope.getCaseColor = function (textup) {
        if (textup == "Total Cases") {
            return '#03A9F4';
        }
        else if (textup == "Total Unattended Case") {
            return '#CDDC39';
        }
        else if (textup == "Total Disposed Cases") {
            return '#a172f5';
        }
        else if (textup == "Company Law ") {
            return '#F44336';
        }
        else if (textup == "IBC") {
            return '#a172f7';
        }
        else if (textup == "SARFAESI, ACT") {
            return '#a372f5';
        }
    }

    $scope.Insert_Compliance_Alert_required = function () {
        $scope.Alert = {};
        $scope.Alert.CID = GetParam('CID');
        $scope.Alert.EmpID = $scope.mySplit($scope.empname, 0);
        $http({
            method: "post",
            url: "/ComplianceMaster/Insert_Compliance_Alert_required",
            datatype: "json",
            data: JSON.stringify($scope.Alert)
        }).then(function (response) {
            $('#tblAddEmployee').DataTable().clear().destroy();
            $scope.VPL_Compliance_AlertTo_Detail();
            alert(response.data);
            $scope.empname = "";
        })
    }

    $scope.Insert_Compliance_Info_required = function () {
        $scope.Alert = {};
        $scope.Alert.CID = GetParam('CID');
        $scope.Alert.EmpID = $scope.mySplit($scope.empnameInfo, 0);
        $http({
            method: "post",
            url: "/ComplianceMaster/Insert_Compliance_Info_required",
            datatype: "json",
            data: JSON.stringify($scope.Alert)
        }).then(function (response) {
            $('#tblEmpInfo').DataTable().clear().destroy();
            $scope.VPL_Compliance_InfoRequired();
            alert(response.data);
            $scope.empnameInfo = "";
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });

    }

    $scope.del_Compliance_Info_required = function (info) {
        $scope.Alert = {};
        $scope.Alert.TransID = info.TransID;
        $http({
            method: "post",
            url: "/ComplianceMaster/del_Compliance_Info_required",
            datatype: "json",
            data: JSON.stringify($scope.Alert)
        }).then(function (response) {
            $('#tblEmpInfo').DataTable().clear().destroy();
            $scope.VPL_Compliance_InfoRequired();
            alert(response.data);
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });

    }

    $scope.del_Compliance_Alert_required = function (Aler) {
        $scope.Alert = {};
        $scope.Alert.TransID = Aler.TransID;
        $http({
            method: "post",
            url: "/ComplianceMaster/del_Compliance_Alert_required",
            datatype: "json",
            data: JSON.stringify($scope.Alert)
        }).then(function (response) {
            $('#tblAddEmployee').DataTable().clear().destroy();
            $scope.VPL_Compliance_AlertTo_Detail();
            alert(response.data);
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });

    }


    $scope.Get_VPL_complianceDashboard = function () {
        $http({
            method: "GET",
            url: "/ComplianceMaster/Get_VPL_complianceDashboard"
        }).then(function (response) {
            $scope.dashbord = response.data;
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });
    };

    $scope.Get_DashboardUndatedCase = function () {
        $http({
            method: "GET",
            url: "/LegalCases/Get_DashboardUndatedCase"
        }).then(function (response) {
            $scope.Legal_dashboard = response.data;
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });
    };

    $scope.Vw_DashboardUndatedCase_Details_With_TextUp = function () {
        $scope.Employe = {};
        $scope.Employe.textup = GetParam('textup');
        $http({
            method: "POST",
            url: "/LegalCases/Vw_DashboardUndatedCase_Details_With_TextUp",
            datatype: "json",
            data: JSON.stringify($scope.Employe)
        }).then(function (response) {
            $scope.Legalcases = response.data;
            $scope.MakeDatatable($("#user_table"));
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });
    };



    $scope.Get_VPL_Compliance_Master_Detail_BYID = function () {

        $scope.combyid = {};
        $scope.combyid.CID = GetParam('CID');

        $http({
            method: "post",
            url: "/ComplianceMaster/VPL_Compliancebyid",
            datatype: "json",
            data: JSON.stringify($scope.combyid)
        }).then(function (response) {
            $scope.cominfo = response.data;
            $scope.MakeDatatable($("#user-tbl"));
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        })
    };
    $scope.Get_VPL_Compliance_Scheduling_Detail_BYCID = function () {

        $scope.combyid = {};
        $scope.combyid.CID = GetParam('CID');

        $http({
            method: "post",
            url: "/ComplianceMaster/Get_VPL_Compliance_Scheduling_Detail_BYCID",
            datatype: "json",
            data: JSON.stringify($scope.combyid)
        }).then(function (response) {
            $scope.comschinfo = response.data;
            $scope.MakeDatatable($("#sch_detail"));
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });

    };

    $scope.VPL_Compliance_AlertTo_Detail = function () {
        $scope.Employe = {};
        $scope.Employe.CID = GetParam('CID');
        $http({
            method: "post",
            url: "/ComplianceMaster/VPL_Compliance_AlertTo_Detail",
            datatype: "json",
            data: JSON.stringify($scope.Employe)
        }).then(function (response) {
            $scope.alertinfo = response.data;
            $scope.MakeDatatable($("#tblAddEmployee"));
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });
    };

    $scope.VPLCompliance_All_Staff_Detail = function () {
        $http({
            method: "get",
            url: "/ComplianceMaster/VPLCompliance_All_Staff_Detail"
        }).then(function (response) {
            $scope.Emp_Staff_List = response.data;
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });
    };

    $scope.InsertCompliance = function () {
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action == "Submit") {
            $scope.compliance = {};
            $scope.compliance.DeptID = $scope.ddldept;
            $scope.compliance.CompanyID = $scope.ddlcompany;
            $scope.compliance.UnitID = $scope.ddlunit;
            $scope.compliance.Name = $scope.com_name;
            $scope.compliance.Frequency = $scope.ddlfrequency;
            $scope.compliance.Deadline = new Date($scope.lastdate);
            $scope.compliance.Alertbefore = $scope.alertbefore;
            $scope.compliance.Regulate_For = $scope.ngregulfor;
            $scope.compliance.Regulate_Ref = $scope.ngregulrefer;
            $scope.compliance.CrBy = $scope.dEMpresponsible;
            $scope.compliance_responsible = {};
            $scope.compliance_responsible.EmpID = $scope.dEMpresponsible;
            $http({
                method: "post",
                url: "/ComplianceMaster/Insert_Compliance",
                datatype: "json",
                data: JSON.stringify($scope.compliance, $scope.compliance_responsible)
            }).then(function (response) {
                $scope.compliance = {};
                $scope.compliance.CID = response.data;
                $scope.compliance.Frequency = $scope.ddlfrequency;
                $scope.compliance.DeptID = $scope.ddlday;
                $scope.compliance.CompanyID = $scope.ddlmonth;
                $scope.compliance.UnitID = $scope.ddlday2;
                $scope.compliance.Name = $scope.ddlmonth2;
                $scope.compliance.Regulate_Ref = $scope.ddlday3;
                $scope.compliance.Isactive = $scope.ddlmonth3;

                $scope.compliance.Alertbefore = $scope.ddlday3;
                $scope.compliance.CrIP = $scope.ddlmonth3;

                $scope.compliance.CrDate =  $scope.fixeddate;
                $http({
                    method: "post",
                    url: "/ComplianceMaster/Insert_Frequency_Details",
                    datatype: "json",
                    data: JSON.stringify($scope.compliance)
                }).then(function (response) {
                    $scope.Get_VPL_Compliance_Master_Detail();
                    $('#compliance_ins').DataTable().clear().destroy();
                    $scope.Get_VPL_Compliance_Master_Detail_withfrequency();
                    alert("Compliance has added successfully.");
                }, function (jqxhr, settings, exception) {
                    if (jqxhr != null)
                        alert(jqxhr.data);
                });
                //$scope.com_name = "";
                //$scope.lastdate = "";
                //$scope.alertbefore = "";
            }, function (jqxhr, settings, exception) {
                if (jqxhr != null)
                    alert(jqxhr.data);
            });
        } else {
            $scope.compliance = {};
            $scope.compliance.CID = document.getElementById("CID_").value;
            $scope.compliance.DeptID = $scope.ddldept;
            $scope.compliance.CompanyID = $scope.ddlcompany;
            $scope.compliance.UnitID = $scope.ddlunit;
            $scope.compliance.Name = $scope.com_name;
            $scope.compliance.Frequency = $scope.ddlfrequency;
            $scope.compliance.Deadline = new Date( $scope.lastdate).DateInYYYYMMDD;
            $scope.compliance.Alertbefore = $scope.alertbefore;
            $scope.compliance.Regulate_For = $scope.ngregulfor;
            $scope.compliance.Regulate_Ref = $scope.ngregulrefer;
            $scope.compliance.CrBy = $scope.dEMpresponsible;
            $scope.compliance_responsible = {};
            $scope.compliance_responsible.EmpID = $scope.dEMpresponsible;
            $http({
                method: "post",
                url: "/ComplianceMaster/Update_Compliance",
                datatype: "json",
                data: JSON.stringify($scope.compliance, $scope.compliance_responsible)
            }).then(function (response) {
                $scope.compliance = {};
                $scope.compliance.CID = document.getElementById("CID_").value;

                $scope.compliance.Frequency = $scope.ddlfrequency;
                $scope.compliance.DeptID = $scope.ddlday;
                $scope.compliance.CompanyID = $scope.ddlmonth;
                $scope.compliance.UnitID = $scope.ddlday2;
                $scope.compliance.Name = $scope.ddlmonth2;
                $scope.compliance.Regulate_Ref = $scope.ddlday3;
                $scope.compliance.Isactive = $scope.ddlmonth3;

                $scope.compliance.Alertbefore = $scope.ddlday3;
                $scope.compliance.CrIP = $scope.ddlmonth3;

                $scope.compliance.CrDate = $scope.fixeddate;
                $http({
                    method: "post",
                    url: "/ComplianceMaster/Insert_Frequency_Details",
                    datatype: "json",
                    data: JSON.stringify($scope.compliance)
                }).then(function (response) {


                }, function (jqxhr, settings, exception) {
                    if (jqxhr != null)
                        alert(jqxhr.data);
                });

                $scope.Get_VPL_Compliance_Master_Detail();
                alert(response.data);
                hidediv();
                $scope.ddldept = "";
                $scope.ddlfrequency = "";
                $scope.lastdate = "";
                $scope.alertbefore = "";
                $scope.ngregulfor = "";
                $scope.ngregulrefer = "";
                $scope.dEMpresponsible = "";
                $scope.lastdate = "";
                $scope.alertbefore = "";
            }, function (jqxhr, settings, exception) {
                if (jqxhr != null)
                    alert(jqxhr.data);
            });
        }
        hidediv();
    }

    $scope.UpdateCompliance = function (com) {
        $scope.compliance_pp = {};
        $scope.compliance_pp.Deadline = com.complinace_Master_WithFreq.Deadlinea;
        $scope.compliance_pp.Deadline = new Date($scope.compliance_pp.Deadline).DateInYYYYMMDD;

        document.getElementById("CID_").value = com.complinace_Master_WithFreq.CID;
        $scope.ddldept = com.complinace_Master_WithFreq.DeptID;
        $scope.ddlcompany = com.complinace_Master_WithFreq.CompanyID;
        $scope.Get_UnitById();
        $scope.ddlunit = com.complinace_Master_WithFreq.UnitID;
        $scope.com_name = com.complinace_Master_WithFreq.Name;
        $scope.Get_AllFrequency();

        $scope.ddlfrequency = com.complinace_Master_WithFreq.Frequency;
        $scope.lastdate = $scope.compliance_pp.Deadline;
        $scope.alertbefore = com.complinace_Master_WithFreq.Alertbefore;
        $scope.ngregulfor = com.complinace_Master_WithFreq.Regulate_For;
        $scope.ngregulrefer = com.complinace_Master_WithFreq.Regulate_Ref;
        $scope.dEMpresponsible = com.complinace_Master_WithFreq.responsiblemep;
        var totcnt = com.complinace_Master_WithFreq_detail.length;
        debugger
        var start = 0;
        if (com.complinace_Master_WithFreq.Frequency == '1') {
            if (com.complinace_Master_WithFreq_detail.length > 0) {
                $scope.ddlday = com.complinace_Master_WithFreq_detail[0].DD;
            }
        }
        else if (com.complinace_Master_WithFreq.Frequency == '2') {

            if (com.complinace_Master_WithFreq_detail.length > 0) {
                $scope.ddlday = com.complinace_Master_WithFreq_detail[0].DD;
                $scope.ddlmonth = com.complinace_Master_WithFreq_detail[0].MM;
            }
            if (com.complinace_Master_WithFreq_detail.length > 1) {
                $scope.ddlday2 = com.complinace_Master_WithFreq_detail[1].DD;
                $scope.ddlmonth2 = com.complinace_Master_WithFreq_detail[1].MM;
            }
            if (com.complinace_Master_WithFreq_detail.length > 2) {
                $scope.ddlday3 = com.complinace_Master_WithFreq_detail[2].DD;
                $scope.ddlmonth3 = com.complinace_Master_WithFreq_detail[2].MM;
            }
            if (com.complinace_Master_WithFreq_detail.length > 3) {
                $scope.ddlday4 = com.complinace_Master_WithFreq_detail[3].DD;
                $scope.ddlmonth4 = com.complinace_Master_WithFreq_detail[3].MM;
            }
        }
        else if (com.complinace_Master_WithFreq.Frequency == '3') {

            if (com.complinace_Master_WithFreq_detail.length = 1) {
                $scope.ddlday = com.complinace_Master_WithFreq_detail[0].DD;
                $scope.ddlmonth = com.complinace_Master_WithFreq_detail[0].MM;
            }
            if (com.complinace_Master_WithFreq_detail.length = 2) {
                $scope.ddlday2 = com.complinace_Master_WithFreq_detail[1].DD;
                $scope.ddlmonth2 = com.complinace_Master_WithFreq_detail[1].MM;
            }
        }
        else if (com.complinace_Master_WithFreq.Frequency == '4') {

            if (com.complinace_Master_WithFreq_detail.length = 1) {
                $scope.ddlday = com.complinace_Master_WithFreq_detail[0].DD;
                $scope.ddlmonth = com.complinace_Master_WithFreq_detail[0].MM;
            }
        }
        else if (com.complinace_Master_WithFreq.Frequency == '5') {
            $scope.fixeddate = new Date(com.complinace_Master_WithFreq_detail[0].fixeddate);
        }

        $scope.showdiv();
        document.getElementById("btnSave").setAttribute("value", "Update");
        document.getElementById("btnSave").className = "btn btn-warning";
    }


    $scope.delete_Compliance = function (Aler) {
        $scope.Alerts = {};
        $scope.Alerts.CID = Aler.complinace_Master_WithFreq.CID
        $http({
            method: "post",
            url: "/ComplianceMaster/delete_Compliance",
            datatype: "json",
            data: JSON.stringify($scope.Alerts)
        }).then(function (response) {
            $('#user_table').DataTable().clear().destroy();
            $scope.Get_VPL_Compliance_Master_Detail();
            $('#compliance_ins').DataTable().clear().destroy();
            $scope.Get_VPL_Compliance_Master_Detail_withfrequency();
            alert(response.data);
        });
    }

    $scope.Get_VPL_Compliance_Master_Detail = function () {

        $http({
            method: "get",
            url: "/ComplianceMaster/Get_VPL_Compliance_Master_Detail"
        }).then(function (response) {
            //  $scope.compliances = response.data;
            $scope.MyOrders = response.data;
            $scope.MakeDatatable($("#user_table"));           
        }, function () {
            alert("Error Occur");
        })

    };



    //-----------Legal case Logic----------------
    $scope.GetCaseTypelIst = function () {
        $http({
            method: "GET",
            url: "/Cases/GetCaseTypelIst"
        }).then(function (response) {
            $scope.CaseTypelIst = response.data;
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });
    };

    $scope.GetPurposeMasterlist = function (com) {
        $scope.purpose = com;
        $scope.purpose.ID = com.ID;
        $http({
            method: "POST",
            url: "/Cases/GetPurposeMasterlist",
            datatype: "json",
            data: JSON.stringify($scope.purpose)
        }).then(function (response) {
            $scope.PurposeMasterlist = response.data;
        $}, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });
    };

    $scope.Getresponsibleperson = function () {
        $http({
            method: "GET",
            url: "/Cases/Getresponsibleperson"
        }).then(function (response) {
            $scope.resEmpList = response.data;
            $scope.ddlresponsibleperson = $("#userID").val();
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });
    };



    $scope.GetPetitioner_Cum_RespondentlIst_P = function () {
        $http({
            method: "GET",
            url: "/Cases/GetPetitioner_Cum_RespondentlIst_P"
        }).then(function (response) {
            $scope.petitioner_P = response.data;
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });
    };

    $scope.GetPetitioner_Cum_RespondentlIst_A = function () {
        $http({
            method: "GET",
            url: "/Cases/GetPetitioner_Cum_RespondentlIst_A"
        }).then(function (response) {
            $scope.petitioner_A = response.data;
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });
    };

    $scope.GetJudgeMasterList = function () {
        $http({
            method: "GET",
            url: "/Cases/GetJudgeMasterList"
        }).then(function (response) {
            $scope.JudgeMasterList = response.data;
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });
    };

    $scope.GetUnderActmasterlIst = function () {
        $http({
            method: "GET",
            url: "/Cases/GetUnderActmasterlIst"
        }).then(function (response) {
            $scope.UnderActmasterlIst = response.data;
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });
    };

    $scope.GetUnderSectionmasterlIst = function () {
        $http({
            method: "GET",
            url: "/Cases/GetUnderSectionmasterlIst"
        }).then(function (response) {
            $scope.UnderSectionmasterlIst = response.data;
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });
    };

    $scope.GetStageofCasemasterlIst = function () {
        $http({
            method: "GET",
            url: "/Cases/GetStageofCasemasterlIst"
        }).then(function (response) {
            $scope.StageofCasemasterlIst = response.data;
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });
    };

    $scope.GetCourtCityList = function () {
        $http({
            method: "GET",
            url: "/Cases/GetCourtCityList"
        }).then(function (response) {
            $scope.CourtCityList = response.data;
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });
    };

    $scope.case_Responsibility = function () {
        $http({
            method: "GET",
            url: "/Cases/case_Responsibility"
        }).then(function (response) {
            $scope.case_response = response.data;
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });
    };

    //--------- Case Header ----------- //
    $scope.GetCaseHeaderlIst = function () {
        $scope.Cases = {};
        $scope.Cases.TransID = GetParam('CaseID');
        $scope.Cases.EmpID = GetParam('EMpid');
        $http({
            method: "POST",
            url: "/Cases/GetCaseHeaderlIst",
            datatype: "json",
            data: JSON.stringify($scope.Cases)
        }).then(function (response) {
            $scope.CaseHeaderl = response.data;
            $scope.MakeDatatable($("#user_table"));
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });
    };
    // -------------End----------------//

    $scope.GetSession = function () {
        $http({
            method: 'POST',
            url: "/Dept/get_Session_ID",
            data: {},
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
        }).success(function (response) {
            return response.data;
        });
    };

    $scope.LogOut = function () {
        $http({
            method: 'GET',
            url: "/Dashboard/Logout_Session"
        }).then(function (response) {
            if (response.data == "Closed") {
                $window.location.href = "";
                $window.location.href ="http://192.168.101.236/Working/Login.aspx";                
            }
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });
    }


    //---CaseDetail Flow Code--------//
    $scope.CaseDetailFlowLoad = function () {
        var CaseID = $scope.search.CaseID;
        $scope.userauth();
        $scope.bindddl();
        $scope.bindtextboxes(CaseID);
        $scope.bindorders();

        //$scope.GetSession().then(function (result) {
        //    $scope.sess = result.data;
        //    angular.forEach($scope.sess, function (val, key) {
        //        $scope.userID = val.id;
        //    });
        //    //$scope.getUserID();
           

        //}, function (jqxhr, settings, exception) {
        //    if (jqxhr != null)
        //        alert(jqxhr.data);
        //});
    };
    
    $scope.userauth = function () {
        GetEmployeeSession.checkSession().then(function (data) {
            $scope.userID = data[0].id;
            $scope.auth = {};
            $scope.auth.Active = "0";
            $scope.auth.Crby = $scope.userID;
            var CaseID = $scope.search.CaseID; //Used for get Request QueryString value
            $scope.auth.CaseId = CaseID;
            $scope.GetCaseStatusByEmpid($scope.auth);
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });
    };

    $scope.GetCaseStatusByEmpid = function (com) {
        var str;
        $scope.Employe = com;
        $http({
            method: "POST",
            url: "/Cases/GetCaseStatusByEmpid",
            datatype: "json",
            data: JSON.stringify($scope.Employe)
        }).then(function (response) {
            var st = response.data;
            if (st == "1") {
                $scope.userstatus = "1";
                $scope.userAccess = true;
                //$("#lnkdocument").show();
                //$("#lnkclosecase").show();
                //$("#bteditbtnmeeting").show();
            }
            else {
                $scope.userstatus = "0";
                $scope.userAccess = false;
                //$("#lnkdocument").hide();
                //$("#lnkclosecase").hide();
                //$("#bteditbtnmeeting").hide();
            }
            var A1 = $("#lblhear").text();
            var lblBP = $("#lblBP").text();
            if ($scope.userstatus == "1") {
                if (lblBP = "") {
                    $scope.userAccess = false;
                    $scope.addDetail = true;
                    //$("#LinkButton1").hide();
                    //$("#lnkdel").hide();
                    $("#lblhear").text("");
                }
                else {
                    $scope.userAccess = true;
                    //$("#LinkButton1").show();
                    //$("#lnkdel").show();
                    $scope.addDetail = true;
                }
            }
            else {
                $scope.userAccess = false;
                $scope.addDetail =false;
                //$("#LinkButton1").hide();
                //$("#lnkdel").hide();                
                //$("#lnkaddDetail").hide();
            }



            $scope.MakeDatatable($("#user_table"));
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });
    };

    $scope.bindddl = function () {
        $scope.drop = {};
        $scope.drop.ID = "0";
        $scope.GetPurposeMasterlist($scope.drop);
        $scope.GetJudgeMasterList();
        $scope.GetStageofCasemasterlIst();
        $scope.GetCourtCityList();
        $scope.Getresponsibleperson();
    };

    $scope.bindtextboxes = function (CaseID) {
        $scope.Cases = {};
        $scope.Cases.TransID = CaseID;  // GetParam('CaseID');
        $http({
            method: "POST",
            url: "/Cases/GetCaseHeaderlIst",
            datatype: "json",
            data: JSON.stringify($scope.Cases)
        }).then(function (response) {
            $scope.CaseHeaderl = response.data;
            angular.forEach($scope.CaseHeaderl, function (val, key) {
            if (key == 0) {
                $scope.casename1 = val.JudgeName;  //  $("#casename1").text(val.JudgeName);
                $scope.casename2 = val.JudgeName;
                $scope.casesummary = "Registration No: " + val.RegistrationNumber;
                $scope.ddlJudge=val.Judge;
                $scope.ddlStageofCase=val.StageofCase;
                $scope.ddlcourtcity=val.CourtNo;
                $scope.bindHostory();
                }
            });            
            $scope.MakeDatatable($("#user_table"));
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });
    };

    $scope.bindorders = function () {
        var CaseID = $scope.search.CaseID;
        $scope.order = {};
        $scope.order.ID = CaseID;  //  GetParam('CaseID');
        $scope.order.type = "1";
        $scope.GetCase_Hearing_Orderlist($scope.order);
    };
 

    $scope.GetCase_Hearing_Orderlist = function (com) {
        $scope.Employe = com;
        $scope.Employe.TransID = GetParam('CaseID');
        $scope.Employe.type = "1";// GetParam('type');
        $http({
            method: "POST",
            url: "/Cases/GetCase_Hearing_Orderlist",
            datatype: "json",
            data: JSON.stringify($scope.Employe)
        }).then(function (response) {
            $scope.caseOrderlist = response.data;
            $scope.MakeDatatable($("#tblorder"));
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });
    };

    $scope.GetCaseStatuslIst = function (com) {
        $scope.Employe = com;
        if (com != undefined && com != null) {
            $http({
                method: "POST",
                url: "/Cases/GetCase_Hearing_HistorylIst",
                datatype: "json",
                data: JSON.stringify($scope.Employe)
            }).then(function (response) {
                $scope.repcasestatus = response.data;
                $scope.MakeDatatable($("#user_table"));
            }, function (jqxhr, settings, exception) {
                if (jqxhr != null)
                    alert(jqxhr.data);
            });
        };
    };

    $scope.GetDocumenttypelIst = function () {
        $scope.Employe = {};
        $scope.Employe.CaseId = GetParam('CaseId');
        $http({
            method: "POST",
            url: "/Cases/GetDocumenttypelIst",
            datatype: "json",
            data: JSON.stringify($scope.Employe)
        }).then(function (response) {
            $scope.doctypeList = response.data;
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });
    };

    $scope.InsertCase = function () {
        $scope.case = {};
        $scope.case.CaseType = $scope.ddlcasetype;
        $scope.case.FilingNumber = $scope.fillingnum;
        $scope.case.FilingDate = $scope.fillingdate;
        $scope.case.RegistrationNumber = $scope.regnum;
        $scope.case.RegistrationDate = $scope.regdt;
        $scope.case.CNRNumber = $scope.cnrnum;
        $scope.case.Petitioner = $scope.ddlPetitioner;
        $scope.case.Petitioner_Advocate = $scope.ddlPetitioner_Advocate;
        $scope.case.Respondent = $scope.ddlRespondent;
        $scope.case.Respondent_Advocate = $scope.ddlRespondent_Advocate;
        $scope.case.Judge = $scope.ddlJudge;
        $scope.case.UnderAct = $scope.ddlUnderAct;
        $scope.case.UnderSection = $scope.ddlUnderSection;
        $scope.case.StageofCase = $scope.ddlStageofCase;
        $scope.case.CourtNo = $scope.ddlcourtcity;
        // $scope.case.crby = Session["userid"].ToString();
        $scope.case.Casesummary = $scope.summ;
        $scope.case.caseamount = $scope.caseamt;
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action == "Submit") {
            $scope.case.TransID = "0";
            $scope.case.type = "1";
            $http({
                method: "POST",
                url: "/LegalCases/Insert_Case",
                datatype: "json",
                data: JSON.stringify($scope.case)
            }).then(function (response) {
                alert(response.data);
                hidediv();
                $scope.ddlcasetype = "";
                $scope.fillingnum = "";
                $scope.fillingdate = "";
                $scope.regnum = "";
                $scope.regdt = "";
                $scope.cnrnum = "";
                $scope.ddlPetitioner = "";
                $scope.ddlPetitioner_Advocate = "";
                $scope.ddlRespondent = "";
                $scope.ddlRespondent_Advocate = "";
                $scope.ddlJudge = "";
                $scope.ddlUnderAct = "";
                $scope.ddlUnderSection = "";
                $scope.ddlStageofCase = "";
                $scope.ddlcourtcity = "";
                $scope.summ = "";
                $scope.caseamt = "";
            });
        }
        else {
            $scope.case.TransID = document.getElementById("CaseID").value;;
            $scope.case.type = "2";
            $http({
                method: "POST",
                url: "/LegalCases/Update_Case",
                datatype: "json",
                data: JSON.stringify($scope.case)
            }).then(function (response) {
                alert(response.data);
                hidediv();
                $scope.ddlcasetype = "";
                $scope.fillingnum = "";
                $scope.fillingdate = "";
                $scope.regnum = "";
                $scope.regdt = "";
                $scope.cnrnum = "";
                $scope.ddlPetitioner = "";
                $scope.ddlPetitioner_Advocate = "";
                $scope.ddlRespondent = "";
                $scope.ddlRespondent_Advocate = "";
                $scope.ddlJudge = "";
                $scope.ddlUnderAct = "";
                $scope.ddlUnderSection = "";
                $scope.ddlStageofCase = "";
                $scope.ddlcourtcity = "";
                $scope.summ = "";
                $scope.caseamt = "";
            });
        }
    };

    $scope.UpdateCase = function (com) {
        $scope.showdiv();
        document.getElementById("CaseID").value = com.TransID;
        $scope.ddlcasetype = com.CaseType;
        $scope.fillingnum = com.FilingNumber;
        $scope.fillingdate = com.FilingDate;
        $scope.regnum = com.RegistrationNumber;
        $scope.regdt = com.RegistrationDate;
        $scope.cnrnum = com.CNRNumber;
        $scope.ddlPetitioner = com.Petitioner;
        $scope.ddlPetitioner_Advocate = com.Petitioner_Advocate;
        $scope.ddlRespondent = com.Respondent;
        $scope.ddlRespondent_Advocate = com.Respondent_Advocate;
        $scope.ddlJudge = com.Judge;
        $scope.ddlUnderAct = com.UnderAct;
        $scope.ddlUnderSection = com.UnderSection;
        $scope.ddlStageofCase = com.StageofCase;
        $scope.ddlcourtcity = com.CourtNo;
        $scope.summ = com.Casesummary;
        $scope.caseamt = com.caseamount;
        document.getElementById("btnSave").setAttribute("value", "Update");
        document.getElementById("btnSave").className = "btn btn-warning";
    };

    $scope.deleteCase = function (com) {
        if ($window.confirm("Do you want to continue?"))
            $scope.result = "Yes";
        else
            $scope.result = "No";
        alert($scope.result);
    };

    //Case History //
    $scope.showCaseHistoryDiv = function () {
        if (angular.isDefined($scope.ddlJudge)) {
            delete $scope.ddlJudge;
        }
        $scope.data.businessdate = "";
        $scope.data.nexthearingdate = "";
        if (angular.isDefined($scope.data.ddlBusinesspurpose)) {
            delete $scope.data.ddlBusinesspurpose;
        }
        if (angular.isDefined($scope.data.ddlhearingpurpose)) {
            delete $scope.data.ddlhearingpurpose;
        }        
        $scope.data.Remarks = "";
        if (angular.isDefined($scope.ddlStageofCase)) {
            delete $scope.ddlStageofCase;
        }
        if (angular.isDefined($scope.ddlcourtcity)) {
            delete $scope.ddlcourtcity;
        }
        if (angular.isDefined($scope.ddlresponsibleperson)) {
            delete $scope.ddlresponsibleperson;
        }
    };


    $scope.InsertCaseHistory = function () {
        $scope.caseHistory = {};
        $scope.caseHistory.JudgeId = $scope.ddlJudge;   // $scope.ddlJudge;
        $scope.caseHistory.BusinesDate = DateInYYYYMMDD($scope.data.businessdate);
        $scope.caseHistory.HearingDate = DateInYYYYMMDD($scope.data.nexthearingdate);
        $scope.caseHistory.BusinessPurpose = $scope.data.ddlBusinesspurpose;
        $scope.caseHistory.HearingPurpose = $scope.data.ddlHearingpurpose;
        $scope.caseHistory.Remarks = $scope.data.Remarks;
        $scope.caseHistory.StageofCase = $scope.ddlStageofCase;
        $scope.caseHistory.CourtNumber = $scope.ddlcourtcity;
        $scope.caseHistory.ResponsiblePerson = $scope.ddlresponsibleperson;
        $scope.caseHistory.Crby = $("#userID").val();
        $scope.caseHistory.CaseId = $scope.search.CaseID;  // Request.QueryString["CaseID"].ToString();
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action == "Save") {
            $scope.caseHistory.Case_Hearing_HistoryID = "0";
            $scope.caseHistory.type = "1";
        }
        else {
            $scope.caseHistory.Case_Hearing_HistoryID = document.getElementById("Case_Hearing_HistoryID_").value;
            $scope.caseHistory.type = "2";
            document.getElementById("btnSave").setAttribute("value", "Save");
            document.getElementById("btnSave").className = "btn btn-primary";
        }
        if ($scope.caseHistory != undefined || $scope.caseHistory != null) {
            $http({
                method: "POST",
                url: "/Master/AllinOneCase_Hearing_History",
                data: JSON.stringify($scope.caseHistory)
            }).then(function (response) {
                $('#user_table').DataTable().clear().destroy();
                toaster.success({ title: "Success", body: response.data });
                $scope.bindHostory();
                $scope.bindTransfer();
                $("#divgy").hide();
                $("#signinmodal").hide();

            }, function (jqxhr, settings, exception) {
                if (jqxhr != null)
                    alert(jqxhr.data);
            });
        }
    };

    $scope.UpdateCaseHistory = function (com) {
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action == "Save") {
            $scope.caseHistory = {};
            document.getElementById("Case_Hearing_HistoryID_").value = com.Case_Hearing_HistoryID;
            $scope.caseHistory.TransID = com.Case_Hearing_HistoryID;
            $scope.caseHistory.type = "1";
            //$scope.getUpdatedCase_Hearing_HistorylIst($scope.caseHistory);
            $http({
                method: "POST",
                url: "/Cases/GetCase_Hearing_HistorylIst",
                datatype: "json",
                data: JSON.stringify($scope.caseHistory)
            }).then(function (response) {
                angular.forEach(response.data, function (val, key) {
                    if (key == 0) {
                        $scope.ddlJudge = val.JudgeId;
                        $scope.data.businessdate = val.BusinesDate;
                        $scope.data.nexthearingdate = val.HearingDate;
                        $scope.data.ddlBusinesspurpose = val.BusinessPurpose;
                        $scope.data.ddlhearingpurpose = val.HearingPurpose;
                        $scope.data.Remarks = val.Remarks;
                        $scope.ddlStageofCase = val.StageofCase;
                        $scope.ddlcourtcity = val.CourtNumber;
                        $scope.ddlresponsibleperson = val.ResponsiblePerson;
                        document.getElementById("btnSave").setAttribute("value", "Update");
                        document.getElementById("btnSave").className = "btn btn-warning";
                        $("#divgy").show();
                        $("#signinmodal").show();
                    }
                });
            }, function (jqxhr, settings, exception) {
                if (jqxhr != null)
                    alert(jqxhr.data);
            });
        }
    };

    //$scope.getUpdatedCase_Hearing_HistorylIst = function (com) {
    //    $scope.Employe = com;
    //    $http({
    //        method: "POST",
    //        url: "/Cases/GetCase_Hearing_HistorylIst",
    //        datatype: "json",
    //        data: JSON.stringify($scope.Employe)
    //    }).then(function (response) {
    //        angular.forEach(response.data, function (val, key) {
    //            if (key == 0) {
    //                $scope.ddlJudge = val.JudgeId;
    //                $scope.data.businessdate = val.BusinesDate;
    //                $scope.data.nexthearingdate = val.HearingDate;
    //                $scope.data.ddlBusinesspurpose = val.BusinessPurpose;
    //                $scope.data.ddlhearingpurpose = val.HearingPurpose;
    //                $scope.data.Remarks = val.Remarks;
    //                $scope.ddlStageofCase = val.StageofCase;
    //                $scope.ddlcourtcity = val.CourtNumber;
    //                $scope.ddlresponsibleperson = val.ResponsiblePerson;
    //                document.getElementById("btnSave").setAttribute("value", "Update");
    //                document.getElementById("btnSave").className = "btn btn-warning";
    //                $("#divgy").show();
    //                $("#signinmodal").show();
    //            }
    //        });
    //    }, function (jqxhr, settings, exception) {
    //        if (jqxhr != null)
    //            alert(jqxhr.data);
    //    });
    //};

    $scope.DeleteCaseHistory = function (com) {
        if ($window.confirm("Do you want to continue?")) {
            $scope.case = {};
            document.getElementById("Case_Hearing_HistoryID_").value = com.Case_Hearing_HistoryID;
            $scope.case.TransID = com.Case_Hearing_HistoryID;
            $scope.case.type = "1";
            $http({
                method: "POST",
                url: "/Cases/GetCase_Hearing_HistorylIst",
                datatype: "json",
                data: JSON.stringify($scope.case)
            }).then(function (response) {
                angular.forEach(response.data, function (val, key) {
                    if (key == 0) {
                        $scope.caseHistory = {};
                        $scope.caseHistory.JudgeId = val.JudgeId;
                        $scope.caseHistory.BusinesDate = DateInYYYYMMDD(val.BusinesDate);
                        $scope.caseHistory.HearingDate = DateInYYYYMMDD(val.HearingDate);
                        $scope.caseHistory.BusinessPurpose = val.BusinessPurpose;
                        $scope.caseHistory.HearingPurpose = val.HearingPurpose;
                        $scope.caseHistory.Remarks = val.Remarks;
                        $scope.caseHistory.StageofCase = val.StageofCase;
                        $scope.caseHistory.CourtNumber = val.CourtNumber;
                        $scope.caseHistory.ResponsiblePerson = val.ResponsiblePerson;
                        $scope.caseHistory.Crby = $("#userID").val();
                        $scope.caseHistory.CaseId = $scope.search.CaseID;  // Request.QueryString["CaseID"].ToString();
                        $scope.caseHistory.Case_Hearing_HistoryID = val.Case_Hearing_HistoryID;
                        $scope.caseHistory.type = "-1";
                        $http({
                            method: "POST",
                            url: "/Master/AllinOneCase_Hearing_History",
                            data: JSON.stringify($scope.caseHistory)
                        }).then(function (response) {
                            $('#user_table').DataTable().clear().destroy();
                            toaster.success({ title: "Success", body: response.data });
                            $scope.bindHostory();
                        }, function (jqxhr, settings, exception) {
                            if (jqxhr != null)
                                alert(jqxhr.data);
                        });

                    }
                });
            }, function (jqxhr, settings, exception) {
                if (jqxhr != null)
                    alert(jqxhr.data);
            });
        };
    };
    // End //




    $scope.checkErr = function (businessdate, nexthearingdate) {
        $scope.errMessage = '';
        var curDate = new Date();
        if (new Date(businessdate) > new Date(nexthearingdate)) {
            $scope.errMessage = 'End Date should be greater than start date';
            return false;
        }
        if (new Date(businessdate) < curDate) {
            $scope.errMessage = 'Start date should be greater than current date.';
            return false;
        }
    };


    $scope.bindTransfer = function () {
        $scope.transfer = {};
        var CaseID = $scope.search.CaseID;
        $scope.transfer.ID = CaseID;  // document.getElementById("CaseID").value;
        $scope.transfer.type = "1";
        $scope.GetCase_Transfer_Courts_Logs_List($scope.transfer);
    };

    $scope.GetCase_Transfer_Courts_Logs_List = function (com) {
        $scope.transfer = com;
        //$scope.transfer.ID = com.ID;
        //$scope.transfer.type = com.type;
        $http({
            method: "POST",
            url: "/Cases/GetCase_Transfer_Courts_Logs_List",
            datatype: "json",
            data: JSON.stringify($scope.transfer)
        }).then(function (response) {
            $scope.reptransfer = response.data;
            $scope.MakeDatatable($("$tblCaseTransfer"));
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });
    };



    $scope.bindHostory = function () {
        var KeepGoing = true;
        $scope.case = {};
        var CaseID = $scope.search.CaseID; //Used for get Request QueryString value
        $scope.case.TransID = CaseID;   //  GetParam('CaseID'); // document.getElementById("CaseID").value;
        $scope.case.type = "0";
        $scope.GetCaseHistoryList($scope.case);
        $scope.bindTransfer();
        $scope.Order = {};
        $scope.Order.TransID = CaseID;   // GetParam('CaseID');
        $scope.Order.type = "2";
        $scope.GetCaseStatuslIst($scope.Order);
    };




    $scope.GetCaseHistoryList = function (com) {
        $scope.Employe = com;
        $http({
            method: "POST",
            url: "/Cases/GetCase_Hearing_HistorylIst",
            datatype: "json",
            data: JSON.stringify($scope.Employe)
        }).then(function (response) {
            $scope.repHistoryofcase = response.data;
            var cnt = $scope.repHistoryofcase.length - 1;
            angular.forEach($scope.repHistoryofcase, function (val, key) {
                if (cnt == key) {
                    $scope.data.businessdate = val.BusinesDate;
                }
                if (cnt > 1) {
                    if (key == 0) {
                        $scope.ddlJudge = val.Judge;
                        $scope.ddlStageofCase = val.StageofCase;
                        $scope.ddlcourtcity = val.CourtNumber;
                        $scope.data.businessdate = val.HearingDate;
                        $scope.data.ddlBusinesspurpose = val.HearingPurpose;
                    }
                }
            })
            $scope.MakeDatatable($("#tblcaseHistory"));
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });
    };
    //End//

    //History Order//
    $scope.hideOrderDetailDiv = function () {
        $("#modelorder").hide();
        $("#divgy").hide();
    };


    $scope.AddOrderDetail = function (com) {
        document.getElementById("uporderfile").value="";
        $scope.existorderfile = "";
        $scope.data.ttxtorderdetail = "";
        document.getElementById("Case_Hearing_HistoryID_").value = com.Case_Hearing_HistoryID;
        $("#modelorder").show();
        $("#divgy").show();
    };

    $scope.InsertOrderDetail = function () {
        var files = (isEmpty(document.getElementById("uporderfile").files[0])) ? "" : document.getElementById("uporderfile").files[0];
        var existorderfile = (isEmpty($scope.existorderfile)) ? "" : $scope.existorderfile;
        if (files != "" || existorderfile != "") {
            var formData = new FormData();
            formData.append("Image", existorderfile);
            formData.append("file", files);
            $http({
                method: 'POST',
                url: "/Master/UploadOrderFile",
                processData: false,
                contentType: false,
                data: formData,
                headers: { 'Content-Type': undefined },
                transformRequest: angular.identity,
            }).then(function (response, status, headers, config) {
                $scope.result = response.data;
                if ($scope.result.Response == 1) {
                    $scope.CaseOrder = {};
                    $scope.CaseOrder.Case_Hearing_HistoryID = document.getElementById("Case_Hearing_HistoryID_").value;
                    $scope.CaseOrder.OrderDetail = $scope.data.ttxtorderdetail;
                    $scope.CaseOrder.crby = $("#userID").val();
                    $scope.CaseOrder.fileO = $scope.result.Image;
                    var Action = document.getElementById("btaddorder").getAttribute("value");
                    if (Action == "Save") {
                        $scope.CaseOrder.Case_Hearing_Orderid = "0";
                        $scope.CaseOrder.type = "1";
                    }
                    else {
                        $scope.CaseOrder.Case_Hearing_Orderid = document.getElementById("Case_Hearing_Orderid_").value;
                        $scope.CaseOrder.type = "2";
                        document.getElementById("btaddorder").setAttribute("value", "Save");
                        document.getElementById("btaddorder").className = "btn btn-primary";
                    }
                    if ($scope.CaseOrder != undefined || $scope.CaseOrder != null) {
                        $http({
                            method: "POST",
                            url: "/Master/AllinOneCase_Hearing_Order",
                            data: JSON.stringify($scope.CaseOrder)
                        }).then(function (success) {
                            $('#user_table').DataTable().clear().destroy();
                            $scope.bindorders();
                            toaster.success({ title: "Success", body: success.data });
                            $("#divgy").hide();
                            $("#modelorder").hide();
                        }, function (jqxhr, settings, exception) {
                            if (jqxhr != null)
                                alert(jqxhr.data);
                        });
                    }
                }
                else {
                    toaster.error({ title: "Error", body: $scope.result.ResponseMsg });
                }
            }, function (jqxhr, settings, exception) {
                if (jqxhr != null)
                    alert(jqxhr.data);
            });
        }
    };

    $scope.UpdateCaseOrder = function (com) {
        var Action = document.getElementById("btaddorder").getAttribute("value");
        $scope.caseOrder = {};
        $scope.caseOrder.ID = com.Case_Hearing_Orderid;
        $scope.caseOrder.type = "0";
        $http({
            method: "POST",
            url: "/Cases/GetCase_Hearing_Orderlist",
            datatype: "json",
            data: JSON.stringify($scope.caseOrder)
        }).then(function (response) {
            $scope.order = response.data;
            angular.forEach($scope.order, function (val, key) {
                if (key == 0) {
                    document.getElementById("Case_Hearing_Orderid_").value = val.Case_Hearing_Orderid;
                    document.getElementById("Case_Hearing_HistoryID_").value = val.Case_Hearing_HistoryID;
                    $scope.order = val.OrderDetail;
                    $scope.data.ttxtorderdetail = val.OrderDetail;
                    $scope.existorderfile = val.fileO;
                    document.getElementById("btaddorder").setAttribute("value", "Update");
                    document.getElementById("btaddorder").className = "btn btn-warning";
                    $("#divgy").show();
                    $("#modelorder").show();
                }
            });

        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });
    };

    $scope.DeleteCaseOrder = function (com) {
        $scope.caseOrder = {};
        $scope.caseOrder.Case_Hearing_Orderid = com.Case_Hearing_Orderid;
        $scope.caseOrder.type = "-1";
        if ($scope.caseOrder != undefined || $scope.caseOrder != null) {
            $http({
                method: "POST",
                url: "/Master/AllinOneCase_Hearing_Order",
                data: JSON.stringify($scope.caseOrder)
            }).then(function (success) {
                $('#user_table').DataTable().clear().destroy();
                $scope.bindorders();
                $("#divgy").hide();
                $("#modelorder").hide();
                $scope.order = {};
                $scope.order.Image = com.fileO;

                    $http({
                        method: "POST",
                        url: "/Master/DeleteFile",
                        data: JSON.stringify($scope.order)
                    }).then(function (response) {
                        if (response.data.Response==1) {
                           // alert(response.ResponseMsg);
                            toaster.success({ title: "Success", body: success.data });
                        }
                        else {
                            toaster.error({ title: "Error", body: response.data.ResponseMsg });
                        }
                    }, function (error) { alert(error.data); });
            }, function (jqxhr, settings, exception) {
                if (jqxhr != null)
                    alert(jqxhr.data);
            });
        }
    };

    $scope.closecase = function () {
        $scope.case = {};
        $scope.case.TransID = $scope.search.CaseID;
        $scope.case.type = "40";
        $http({
            method: "POST",
            url: "/Cases/AllinOneCaseHeader",
            datatype: "json",
            data: JSON.stringify($scope.case)
        }).then(function (response) {
            toaster.success({ title: "Success", body: response.data });
        });
    };


    //end//

    //Case Report //
    $scope.LoadGetCaseHeaderSearchTable = function () {
        $scope.BindCourtCityList();
        $scope.bindReportGrid();
    };

    $scope.bindReportGrid = function () {
        $scope.caseReport = {};
        $scope.caseReport.from = (isEmpty($scope.data.txtfromdate)) ? "" : $scope.data.txtfromdate;
        $scope.caseReport.To = (isEmpty($scope.data.txttodate)) ? "" : $scope.data.txttodate;
        $scope.caseReport.CourtNo = (isEmpty($scope.data.ddlcourt)) ? 0 : $scope.data.ddlcourt;
        if ($scope.caseReport != undefined || $scope.caseReport != null) {
            $http({
                method: "POST",
                url: "/Cases/GetCaseHeaderSearchTable",
                data: JSON.stringify($scope.caseReport)
            }).then(function (success) {
                $scope.caseReportlist = success.data;
                $('#user_table').DataTable().clear().destroy();
                $scope.MakeDatatable($("#user_table"));
            }, function (jqxhr, settings, exception) {
                if (jqxhr != null)
                    alert(jqxhr.data);
            });
        }
    };
    // End //

    // <-------- Case Search --------> //
    $scope.LoadGetCaseSearchTable = function () {
        $scope.BindCaseTypeList();

        $scope.Petitioner = {};
        $scope.Petitioner.Petitioner_Cum_RespondentID = "0";
        $scope.GetPetitioner_Cum_RespondentlIst($scope.Petitioner);

        $scope.BindCaseSearchGrid();
    };

    $scope.BindCaseSearchGrid = function () {
        $scope.CaseSearch = {};
        $scope.CaseSearch.TransID = "0";
        $scope.CaseSearch.CaseType = $scope.data.ddlcasetype;
        $scope.CaseSearch.FilingNumber = "";
        $scope.CaseSearch.FilingDate = "";
        $scope.CaseSearch.RegistrationNumber = "";
        $scope.CaseSearch.RegistrationDate = "";
        $scope.CaseSearch.CNRNumber = "";
        $scope.CaseSearch.Petitioner = $scope.data.ddlPetitioner;
        $scope.CaseSearch.Petitioner_Advocate = "0";
        $scope.CaseSearch.Respondent = "0";
        $scope.CaseSearch.Respondent_Advocate = "0";
        $scope.CaseSearch.Judge = "0";
        $scope.CaseSearch.UnderAct = "0";
        $scope.CaseSearch.UnderSection = "0";
        $scope.CaseSearch.StageofCase = "0";
        $scope.CaseSearch.CourtNo = "0";
        $scope.CaseSearch.Crby = "0";
        $scope.CaseSearch.from = (isEmpty($scope.data.txtfromdate)) ? "" : $scope.data.txtfromdate;
        $scope.CaseSearch.To = (isEmpty($scope.data.txttodate)) ? "" : $scope.data.txttodate;

        if ($scope.CaseSearch != undefined || $scope.CaseSearch != null) {
            $http({
                method: "POST",
                url: "/Cases/GetCaseHeaderSearch",
                data: JSON.stringify($scope.CaseSearch)
            }).then(function (success) {
                $scope.caseSearchlist = success.data;
                $('#user_table').DataTable().clear().destroy();
                $scope.MakeDatatable($("#user_table"));
            }, function (jqxhr, settings, exception) {
                if (jqxhr != null)
                    alert(jqxhr.data);
            });
        }
    };


    // <------------ End ------------> //
    $scope.word = /^[a-z]+[a-z0-9._]+@[a-z]+\.[a-z.]{2,5}$/;

    // Advocate Master //
    $scope.ShowPetitioner_Cum_Respondent_ShowDiv = function () {
        $scope.FullName = "";
        $scope.Relation = "";
        $scope.Empid = "";
        $scope.Address = "";
        $scope.contactno = "";
        $scope.emailid = "";
        $("#divgy").show();
        $("#signinmodal").show();
    };



    $scope.LoadPetitioner_Cum_Respondent = function () {
        var menuID = $scope.search.MenuID; 
        if (menuID != "14") {
            $scope.t1 = "Advocate Master";
            $scope.t2 = "Advocate Master";
            $scope.t3 = "Advocate Master";
            $scope.IsRelVisible = false;
        }
        else {
            $scope.t1 = "Petitioner Cum Responent";
            $scope.t2 = "Petitioner Cum Responent";
            $scope.t3 = "Petitioner Cum Responent";
            $scope.IsRelVisible = true;
        }
        $scope.bindPetitioner_Cum_Respondent();

    };

    $scope.bindPetitioner_Cum_Respondent = function () {
        $scope.Petitioner_Cum_Respondent = {};
        $scope.Petitioner_Cum_Respondent.Petitioner_Cum_RespondentID = "0";
        var menuID = $scope.search.MenuID; 
        if (menuID=="14") {
            $scope.Petitioner_Cum_Respondent.Ptype = "P";
        }
        else {
            $scope.Petitioner_Cum_Respondent.Ptype = "A";
        }
        $scope.GetPetitioner_Cum_RespondentlIst($scope.Petitioner_Cum_Respondent);
    };

    $scope.GetPetitioner_Cum_RespondentlIst = function (com) {
        $scope.advocate = com;
        $http({
            method: "POST",
            url: "/Master/GetPetitioner_Cum_RespondentlIst",
            datatype: "json",
            data: JSON.stringify($scope.advocate)
        }).then(function (response) {
            $scope.Petitioner_Cum_RespondentlIst = response.data;
            $scope.MakeDatatable($("#user_table"));
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });
    };


    $scope.InsertPetitioner_Cum_Respondent = function () {
        $scope.Petitioner_Cum_Respondent = {};
        //MenuID get by QueryString
        if ($scope.search.MenuID == "14") { $scope.Petitioner_Cum_Respondent.Ptype = "P"; } else { $scope.Petitioner_Cum_Respondent.Ptype = "A"; }
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action == "Submit") {
            $scope.Petitioner_Cum_Respondent.Petitioner_Cum_RespondentID = "0";
            $scope.Petitioner_Cum_Respondent.Fullname = $scope.Fullname;
            $scope.Petitioner_Cum_Respondent.Relation = $scope.Relation;
            $scope.Petitioner_Cum_Respondent.Empid = $scope.Empid;
            $scope.Petitioner_Cum_Respondent.Address = $scope.Address;
            $scope.Petitioner_Cum_Respondent.contactno = $scope.contactno;
            $scope.Petitioner_Cum_Respondent.emailid = $scope.emailid;
            $scope.Petitioner_Cum_Respondent.type = "1";
        }
        else {
            $scope.Petitioner_Cum_Respondent.Petitioner_Cum_RespondentID = document.getElementById("Petitioner_Cum_RespondentID_").value;
            $scope.Petitioner_Cum_Respondent.Fullname = $scope.Fullname;
            $scope.Petitioner_Cum_Respondent.Relation = $scope.Relation;
            $scope.Petitioner_Cum_Respondent.Empid = $scope.Empid;
            $scope.Petitioner_Cum_Respondent.Address = $scope.Address;
            $scope.Petitioner_Cum_Respondent.contactno = $scope.contactno;
            $scope.Petitioner_Cum_Respondent.emailid = $scope.emailid;
            $scope.Petitioner_Cum_Respondent.type = "2";
            document.getElementById("btnSave").setAttribute("value", "Submit");
            document.getElementById("btnSave").className = "btn btn-primary";
        }
        if ($scope.Petitioner_Cum_Respondent != undefined || $scope.Petitioner_Cum_Respondent != null) {
            $http({
                method: "POST",
                url: "/Master/AllinOnePetitioner_Cum_Respondent",
                data: JSON.stringify($scope.Petitioner_Cum_Respondent)
            }).then(function (response) {
                $('#user_table').DataTable().clear().destroy();
                $scope.LoadPetitioner_Cum_Respondent();
                toaster.success({ title: "Success", body: response.data });

                $("#divgy").hide();
                $("#signinmodal").hide();
            }, function (jqxhr, settings, exception) {
                if (jqxhr != null)
                    alert(jqxhr.data);
            });
        }
    };

    $scope.UpdatePetitioner_Cum_Respondent = function (com) {
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action == "Submit") {
            document.getElementById("Petitioner_Cum_RespondentID_").value = com.Petitioner_Cum_RespondentID;
            $scope.FullName = com.Fullname;
            $scope.Relation = com.Relation;
            $scope.Empid = com.Empid;
            $scope.Address = com.Address;
            $scope.contactno = com.contactno;
            $scope.emailid = com.emailid;
            document.getElementById("btnSave").setAttribute("value", "Update");
            document.getElementById("btnSave").className = "btn btn-warning";
            $("#divgy").show();
            $("#signinmodal").show();
        }
    };

    $scope.deletePetitioner_Cum_Respondent = function (com) {
        if ($window.confirm("Do you want to continue?")) {
            $scope.Petitioner_Cum_Respondent = {};
            $scope.Petitioner_Cum_Respondent.Petitioner_Cum_RespondentID = com.Petitioner_Cum_RespondentID;
            $scope.Petitioner_Cum_Respondent.type = "-1";
            $http({
                method: "POST",
                url: "/Master/AllinOnePetitioner_Cum_Respondent",
                data: JSON.stringify($scope.Petitioner_Cum_Respondent)
            }).then(function (response) {
                $('#user_table').DataTable().clear().destroy();
                $scope.LoadPetitioner_Cum_Respondent();
                toaster.success({ title: "Success", body: response.data });
            }, function (jqxhr, settings, exception) {
                if (jqxhr != null)
                    alert(jqxhr.data);
            });
        };
    };
    // End //

    $scope.setVisible = function (colNum, colVal) {
        if (colVal)
            $scope.showColumn[colNum] = true;
        return colVal;
    };


    //Case Type //
    $scope.CaseTypeList_ShowDiv = function () {
        $scope.CaseTypeName = "";
        $scope.CaseTypeShort = "";
        $("#divgy").show();
        $("#signinmodal").show();
    };

    $scope.BindCaseTypeList = function () {
        $scope.casetype = {};
        $scope.casetype.CaseId = "0";
        $scope.GetCaseTypelIstwithParameter($scope.casetype);
    }


    $scope.GetCaseTypelIstwithParameter = function (com) {
        $scope.caseType = com;
        $http({
            method: "POST",
            url: "/Master/GetCaseTypelIstwithParameter",
            datatype: "json",
            data: JSON.stringify($scope.caseType)
        }).then(function (response) {
            $scope.caseTypeListNew = response.data;
            $scope.MakeDatatable($("#user_table"));
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });
    };

    $scope.InsertCaseType = function () {
        $scope.caseType = {};
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action == "Submit") {
            $scope.caseType.CaseId = "0";
            $scope.caseType.CaseTypeName = $scope.CaseTypeName;
            $scope.caseType.CaseTypeShort = $scope.CaseTypeShort;
            $scope.caseType.type = "1";
        }
        else {
            $scope.caseType.CaseId = document.getElementById("CaseId_").value;
            $scope.caseType.CaseTypeName = $scope.CaseTypeName;
            $scope.caseType.CaseTypeShort = $scope.CaseTypeShort;
            $scope.caseType.type = "2";
            document.getElementById("btnSave").setAttribute("value", "Submit");
            document.getElementById("btnSave").className = "btn btn-primary";
        }
        if ($scope.caseType != undefined || $scope.caseType != null) {
            $http({
                method: "POST",
                url: "/Master/AllinOneCaseTypeMaster",
                data: JSON.stringify($scope.caseType)
            }).then(function (response) {
                $('#user_table').DataTable().clear().destroy();
                $scope.BindCaseTypeList();
                toaster.success({ title: "Success", body: response.data });
                $("#divgy").hide();
                $("#signinmodal").hide();
            }, function (jqxhr, settings, exception) {
                if (jqxhr != null)
                    alert(jqxhr.data);
            });
        }
    };

    $scope.UpdateCaseType = function (com) {
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action == "Submit") {
            document.getElementById("CaseId_").value = com.CaseId;
            $scope.CaseTypeName = com.CaseTypeName;
            $scope.CaseTypeShort = com.CaseTypeShort;
            document.getElementById("btnSave").setAttribute("value", "Update");
            document.getElementById("btnSave").className = "btn btn-warning";
            $("#divgy").show();
            $("#signinmodal").show();
        }
    };

    $scope.deleteCaseType = function (com) {
        if ($window.confirm("Do you want to continue?")) {
            $scope.caseType = {};
            $scope.caseType.CaseId = com.CaseId;
            $scope.caseType.type = "-1";
            $http({
                method: "POST",
                url: "/Master/AllinOneCaseTypeMaster",
                data: JSON.stringify($scope.caseType)
            }).then(function (response) {
                $('#user_table').DataTable().clear().destroy();
                $scope.BindCaseTypeList();
                toaster.success({ title: "Success", body: response.data });
            }, function (jqxhr, settings, exception) {
                if (jqxhr != null)
                    alert(jqxhr.data);
            });
        };
    };
    //End//

    //City Master//
    $scope.CourtCityList_ShowDiv = function () {
        $scope.City = "";
        $("#divgy").show();
        $("#signinmodal").show();
    };

    $scope.BindCourtCityList = function () {
        $scope.city = {};
        $scope.city.CityID = "0";
        $scope.GetCourtCityListwithParameter($scope.city);
    }

    $scope.GetCourtCityListwithParameter = function (com) {
        $scope.city = com;
        $http({
            method: "POST",
            url: "/Master/GetCourtCityListwithParameter",
            datatype: "json",
            data: JSON.stringify($scope.city)
        }).then(function (response) {
            $scope.courtcityList = response.data;
            $scope.MakeDatatable($("#user_table"));
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });
    };

    $scope.InsertCourtCity = function () {
        $scope.CourtCity = {};
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action == "Submit") {
            $scope.CourtCity.CityID = "0";
            $scope.CourtCity.City = $scope.City;
            $scope.CourtCity.type = "1";
        }
        else {
            $scope.CourtCity.CityID = document.getElementById("CityID_").value;
            $scope.CourtCity.City = $scope.City;
            $scope.CourtCity.type = "2";
            document.getElementById("btnSave").setAttribute("value", "Submit");
            document.getElementById("btnSave").className = "btn btn-primary";
        }
        if ($scope.CourtCity != undefined || $scope.CourtCity != null) {
            $http({
                method: "POST",
                url: "/Master/AllinOneCourtCity",
                data: JSON.stringify($scope.CourtCity)
            }).then(function (response) {
                $('#user_table').DataTable().clear().destroy();
                $scope.BindCourtCityList();
                toaster.success({ title: "Success", body: response.data });
                $("#divgy").hide();
                $("#signinmodal").hide();
            }, function (jqxhr, settings, exception) {
                if (jqxhr != null)
                    alert(jqxhr.data);
            });
        }
    };

    $scope.UpdateCourtCity = function (com) {
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action == "Submit") {
            document.getElementById("CityID_").value = com.CityID;
            $scope.City = com.City;
            document.getElementById("btnSave").setAttribute("value", "Update");
            document.getElementById("btnSave").className = "btn btn-warning";
            $("#divgy").show();
            $("#signinmodal").show();
        }
    };

    $scope.deleteCourtCity = function (com) {
        if ($window.confirm("Do you want to continue?")) {
            $scope.CourtCity = {};
            $scope.CourtCity.CityID = com.CityID;
            $scope.CourtCity.type = "-1";
            $http({
                method: "POST",
                url: "/Master/AllinOneCourtCity",
                data: JSON.stringify($scope.CourtCity)
            }).then(function (response) {
                $('#user_table').DataTable().clear().destroy();
                $scope.BindCourtCityList();
                toaster.success({ title: "Success", body: response.data });
            }, function (jqxhr, settings, exception) {
                if (jqxhr != null)
                    alert(jqxhr.data);
            });
        };
    };
    //End//

    //Document Type//
    $scope.DocumentTypeList_ShowDiv = function () {
        $scope.UnderActName = "";
        $("#divgy").show();
        $("#signinmodal").show();
    };

    $scope.BindDocumentTypeList = function () {
        $scope.doctype = {};
        $scope.doctype.CaseId = "0";
        $scope.GetDocumenttypelIstwithParameter($scope.doctype);
    }

    $scope.GetDocumenttypelIstwithParameter = function (com) {
        $scope.doctype = com;
        $http({
            method: "POST",
            url: "/Master/GetDocumenttypelIstwithParameter",
            datatype: "json",
            data: JSON.stringify($scope.doctype)
        }).then(function (response) {
            $scope.documenttypeList = response.data;
            $scope.MakeDatatable($("#user_table"));
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });
    };

    $scope.InsertDocumentType = function () {
        $scope.DocumentType = {};
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action == "Submit") {
            $scope.DocumentType.UnderActID = "0";
            $scope.DocumentType.UnderActName = $scope.UnderActName;
            $scope.DocumentType.type = "1";
        }
        else {
            $scope.DocumentType.UnderActID = document.getElementById("UnderActID_").value;
            $scope.DocumentType.UnderActName = $scope.UnderActName;
            $scope.DocumentType.type = "2";
            document.getElementById("btnSave").setAttribute("value", "Submit");
            document.getElementById("btnSave").className = "btn btn-primary";
        }
        if ($scope.DocumentType != undefined || $scope.DocumentType != null) {
            $http({
                method: "POST",
                url: "/Master/AllinOneDocumenttype",
                data: JSON.stringify($scope.DocumentType)
            }).then(function (response) {
                $('#user_table').DataTable().clear().destroy();
                $scope.BindDocumentTypeList();
                toaster.success({ title: "Success", body: response.data });
                $("#divgy").hide();
                $("#signinmodal").hide();
            }, function (jqxhr, settings, exception) {
                if (jqxhr != null)
                    alert(jqxhr.data);
            });
        }
    };

    $scope.UpdateDocumentType = function (com) {
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action == "Submit") {
            document.getElementById("UnderActID_").value = com.UnderActID;
            $scope.UnderActName = com.UnderActName;
            document.getElementById("btnSave").setAttribute("value", "Update");
            document.getElementById("btnSave").className = "btn btn-warning";
            $("#divgy").show();
            $("#signinmodal").show();
        }
    };

    $scope.deleteDocumentType = function (com) {
        if ($window.confirm("Do you want to continue?")) {
            $scope.DocumentType = {};
            $scope.DocumentType.UnderActID = com.UnderActID;
            $scope.DocumentType.type = "-1";
            $http({
                method: "POST",
                url: "/Master/AllinOneDocumenttype",
                data: JSON.stringify($scope.DocumentType)
            }).then(function (response) {
                //var index = $scope.documenttypeList.indexOf(com);
                //$scope.documenttypeList.splice(index, 1); 
                $('#user_table').DataTable().clear().destroy();
                $scope.BindDocumentTypeList();
                toaster.success({ title: "Success", body: response.data });
            }, function (jqxhr, settings, exception) {
                if (jqxhr != null)
                    alert(jqxhr.data);
            });
        };
    };

    //End//
    //Judge Master//
    $scope.JudgeList_ShowDiv = function () {
        $scope.JudgeName = "";
        $("#divgy").show();
        $("#signinmodal").show();
    };

    $scope.BindJudgeList = function () {
        $scope.judge = {};
        $scope.judge.JudgeId = "0";
        $scope.GetJudgeMasterListwithParameter($scope.judge);
    }

    $scope.GetJudgeMasterListwithParameter = function (com) {
        $scope.doctype = com;
        $http({
            method: "POST",
            url: "/Master/GetJudgeMasterListwithParameter",
            datatype: "json",
            data: JSON.stringify($scope.doctype)
        }).then(function (response) {
            $scope.judgeList = response.data;
            $scope.MakeDatatable($("#user_table"));
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });
    };

    $scope.InsertJudge = function () {
        $scope.Judge = {};
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action == "Submit") {
            $scope.Judge.JudgeId = "0";
            $scope.Judge.JudgeName = $scope.JudgeName;
            $scope.Judge.type = "1";
        }
        else {
            $scope.Judge.JudgeId = document.getElementById("JudgeId_").value;
            $scope.Judge.JudgeName = $scope.JudgeName;
            $scope.Judge.type = "2";
            document.getElementById("btnSave").setAttribute("value", "Submit");
            document.getElementById("btnSave").className = "btn btn-primary";
        }
        if ($scope.Judge != undefined || $scope.Judge != null) {
            $http({
                method: "POST",
                url: "/Master/AllinOneJudgeMasterMaster",
                data: JSON.stringify($scope.Judge)
            }).then(function (response) {
                $('#user_table').DataTable().clear().destroy();
                $scope.BindJudgeList();
                toaster.success({ title: "Success", body: response.data });
                $("#divgy").hide();
                $("#signinmodal").hide();
            }, function (jqxhr, settings, exception) {
                if (jqxhr != null)
                    alert(jqxhr.data);
            });
        }
    };

    $scope.UpdateJudge = function (com) {
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action == "Submit") {
            document.getElementById("JudgeId_").value = com.JudgeId;
            $scope.JudgeName = com.JudgeName;
            document.getElementById("btnSave").setAttribute("value", "Update");
            document.getElementById("btnSave").className = "btn btn-warning";
            $("#divgy").show();
            $("#signinmodal").show();
        }
    };

    $scope.deleteJudge = function (com) {
        if ($window.confirm("Do you want to continue?")) {
            $scope.judge = {};
            $scope.judge.JudgeId = com.JudgeId;
            $scope.judge.type = "-1";
            $http({
                method: "POST",
                url: "/Master/AllinOneJudgeMasterMaster",
                data: JSON.stringify($scope.judge)
            }).then(function (response) {
                // $('#user_table').dataTable().fnDestroy();
                $('#user_table').DataTable().clear().destroy();
                $scope.BindJudgeList();
                toaster.success({ title: "Success", body: response.data });
            }, function (jqxhr, settings, exception) {
                if (jqxhr != null)
                    alert(jqxhr.data);
            });
        };
    };
    //End//

    //Purpose Master//
    $scope.PurposeList_ShowDiv = function () {
        $scope.BusinessPurpose = "";
        $("#divgy").show();
        $("#signinmodal").show();
    };

    $scope.BindPurposeList = function () {
        $scope.Purpose = {};
        $scope.Purpose.ID = "0";
        $scope.GetPurposeMasterlistwithParameter($scope.Purpose);
    }

    $scope.GetPurposeMasterlistwithParameter = function (com) {
        $scope.doctype = com;
        $http({
            method: "POST",
            url: "/Master/GetPurposeMasterlistwithParameter",
            datatype: "json",
            data: JSON.stringify($scope.doctype)
        }).then(function (response) {
            $scope.purposeList = response.data;
            $scope.MakeDatatable($("#user_table"));
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });
    };

    $scope.InsertPurpose = function () {
        $scope.purpose = {};
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action == "Submit") {
            $scope.purpose.ID = "0";
            $scope.purpose.BusinessPurpose = $scope.BusinessPurpose;
            $scope.purpose.type = "1";
        }
        else {
            $scope.purpose.ID = document.getElementById("CaseId_").value;
            $scope.purpose.BusinessPurpose = $scope.BusinessPurpose;
            $scope.purpose.type = "2";
            document.getElementById("btnSave").setAttribute("value", "Submit");
            document.getElementById("btnSave").className = "btn btn-primary";
        }
        if ($scope.purpose != undefined || $scope.purpose != null) {
            $http({
                method: "POST",
                url: "/Master/AllinOnePurposeMaster",
                data: JSON.stringify($scope.purpose)
            }).then(function (response) {
                $('#user_table').DataTable().clear().destroy();
                $scope.BindPurposeList();
                toaster.success({ title: "Success", body: response.data });
                $("#divgy").hide();
                $("#signinmodal").hide();
            }, function (jqxhr, settings, exception) {
                if (jqxhr != null)
                    alert(jqxhr.data);
            });
        }
    };

    $scope.UpdatePurpose = function (com) {
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action == "Submit") {
            document.getElementById("CaseId_").value = com.CaseId;
            $scope.BusinessPurpose = com.BusinessPurpose;
            document.getElementById("btnSave").setAttribute("value", "Update");
            document.getElementById("btnSave").className = "btn btn-warning";
            $("#divgy").show();
            $("#signinmodal").show();
        }
    };

    $scope.deletePurpose = function (com) {
        if ($window.confirm("Do you want to continue?")) {
            $scope.purpose = {};
            $scope.purpose.ID = com.CaseId;
            $scope.purpose.type = "-1";
            $http({
                method: "POST",
                url: "/Master/AllinOnePurposeMaster",
                data: JSON.stringify($scope.purpose)
            }).then(function (response) {
                // $('#user_table').dataTable().fnDestroy();
                $('#user_table').DataTable().clear().destroy();
                $scope.BindPurposeList();
                toaster.success({ title: "Success", body: response.data });
            }, function (jqxhr, settings, exception) {
                if (jqxhr != null)
                    alert(jqxhr.data);
            });
        };
    };
    //End//

    //Stage of Case Master//
    $scope.StageofCaseList_ShowDiv = function () {
        $scope.StageofCaseName = "";
        $scope.StageofCaseDesc = "";
        $("#divgy").show();
        $("#signinmodal").show();
    };

    $scope.BindStageofCaseList = function () {
        $scope.stageofCase = {};
        $scope.stageofCase.CaseId = "0";
        $scope.GetStageofCasemasterlIstwithParameter($scope.stageofCase);
    }

    $scope.GetStageofCasemasterlIstwithParameter = function (com) {
        $scope.doctype = com;
        $http({
            method: "POST",
            url: "/Master/GetStageofCasemasterlIstwithParameter",
            datatype: "json",
            data: JSON.stringify($scope.doctype)
        }).then(function (response) {
            $scope.stageofcaseList = response.data;
            $scope.MakeDatatable($("#user_table"));
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });
    };

    $scope.InsertStageofCase = function () {
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action == "Submit") {
            $scope.stageofcase = {};
            $scope.stageofcase.StageofCaseID = "0";
            $scope.stageofcase.StageofCaseName = $scope.StageofCaseName;
            $scope.stageofcase.StageofCaseDesc = $scope.StageofCaseDesc;
            $scope.stageofcase.type = "1";
        }
        else {
            $scope.stageofcase = {};
            $scope.stageofcase.StageofCaseID = document.getElementById("StageofCaseID_").value;
            $scope.stageofcase.StageofCaseName = $scope.StageofCaseName;
            $scope.stageofcase.StageofCaseDesc = $scope.StageofCaseDesc;
            $scope.stageofcase.type = "2";
            document.getElementById("btnSave").setAttribute("value", "Submit");
            document.getElementById("btnSave").className = "btn btn-primary";

        }
        if ($scope.stageofcase != undefined || $scope.stageofcase != null) {
            $http({
                method: "POST",
                url: "/Master/AllinOneStageofCasemaster",
                data: JSON.stringify($scope.stageofcase)
            }).then(function (response) {
                $('#user_table').DataTable().clear().destroy();
                $scope.BindStageofCaseList();
                toaster.success({ title: "Success", body: response.data });
                $scope.StageofCaseName = "";
                $scope.StageofCaseDesc = "";
                $("#divgy").hide();
                $("#signinmodal").hide();
            }, function (jqxhr, settings, exception) {
                if (jqxhr != null)
                    alert(jqxhr.data);
            });
        }
    };

    $scope.UpdateStageofCase = function (com) {
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action == "Submit") {
            document.getElementById("StageofCaseID_").value = com.StageofCaseID;
            $scope.StageofCaseName = com.StageofCaseName;
            $scope.StageofCaseDesc = com.StageofCaseDesc;
            document.getElementById("btnSave").setAttribute("value", "Update");
            document.getElementById("btnSave").className = "btn btn-warning";
            $("#divgy").show();
            $("#signinmodal").show();
        }
    };

    $scope.deleteStageofCase = function (com) {
        if ($window.confirm("Do you want to continue?")) {
            $scope.stageofcase = {};
            $scope.stageofcase.StageofCaseID = com.StageofCaseID;
            $scope.stageofcase.type = "-1";
            $http({
                method: "POST",
                url: "/Master/AllinOneStageofCasemaster",
                data: JSON.stringify($scope.stageofcase)
            }).then(function (response) {
                // $('#user_table').dataTable().fnDestroy();
                $('#user_table').DataTable().clear().destroy();
                $scope.BindStageofCaseList();
                toaster.success({ title: "Success", body: response.data });
            }, function (jqxhr, settings, exception) {
                if (jqxhr != null)
                    alert(jqxhr.data);
            });
        };
    };
    //End//

    //UnderAct Master//
    $scope.showUnderActDiv = function () {
        $scope.UnderActName="";
        $scope.UnderActDesc = "";
        $("#divgy").show();
        $("#signinmodal").show();
    };


    $scope.BindUnderActList = function () {
        $scope.UnderAct = {};
        $scope.UnderAct.CaseId = "0";
        $scope.GetUnderActmasterlIstwithParameter($scope.UnderAct);
    }

    $scope.GetUnderActmasterlIstwithParameter = function (com) {
        $scope.doctype = com;
        $http({
            method: "POST",
            url: "/Master/GetUnderActmasterlIstwithParameter",
            datatype: "json",
            data: JSON.stringify($scope.doctype)
        }).then(function (response) {
            $scope.underActList = response.data;
            $scope.MakeDatatable($("#user_table"));
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });
    };

    $scope.InsertUnderAct = function () {
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action == "Submit") {
            $scope.UnderAct = {};
            $scope.UnderAct.UnderActID = "0";
            $scope.UnderAct.UnderActName = $scope.UnderActName;
            $scope.UnderAct.UnderActDesc = $scope.UnderActDesc;
            $scope.UnderAct.type = "1";
        }
        else {
            $scope.UnderAct = {};
            $scope.UnderAct.UnderActID = document.getElementById("UnderActID_").value;
            $scope.UnderAct.UnderActName = $scope.UnderActName;
            $scope.UnderAct.UnderActDesc = $scope.UnderActDesc;
            $scope.UnderAct.type = "2";
            document.getElementById("btnSave").setAttribute("value", "Submit");
            document.getElementById("btnSave").className = "btn btn-primary";

        }
        if ($scope.UnderAct != undefined || $scope.UnderAct != null) {
            $http({
                method: "POST",
                url: "/Master/AllinOneUnderActmaster",
                data: JSON.stringify($scope.UnderAct)
            }).then(function (response) {
                //   $('#user_table').dataTable().fnDestroy();
                $('#user_table').DataTable().clear().destroy();
                $scope.BindUnderActList();
                toaster.success({ title: "Success", body: response.data });
                $("#divgy").hide();
                $("#signinmodal").hide();
            }, function (jqxhr, settings, exception) {
                if (jqxhr != null)
                    alert(jqxhr.data);
            });
        }
    };

    $scope.UpdateUnderAct = function (com) {
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action == "Submit") {
           document.getElementById("UnderActID_").value = com.UnderActID;
            $scope.UnderActName = com.UnderActName;
            $scope.UnderActDesc = com.UnderActDesc;
            document.getElementById("btnSave").setAttribute("value", "Update");
            document.getElementById("btnSave").className = "btn btn-warning";
            $("#divgy").show();
            $("#signinmodal").show();
        }
    };

    $scope.deleteUnderAct = function (com) {
        if ($window.confirm("Do you want to continue?")) {
            $scope.underAct = {};
            $scope.underAct.UnderActID = com.UnderActID;
            $scope.underAct.type = "-1";
            $http({
                method: "POST",
                url: "/Master/AllinOneUnderActmaster",
                data: JSON.stringify($scope.underAct)
            }).then(function (response) {
               // $('#user_table').dataTable().fnDestroy();
                $('#user_table').DataTable().clear().destroy();
                $scope.BindUnderActList();
                toaster.success({ title: "Success", body: response.data });
            }, function (jqxhr, settings, exception) {
                if (jqxhr != null)
                    alert(jqxhr.data);
            });
        };
    };
    //End//

    //UnderSection Master//
    $scope.showUnderSectionDiv = function () {
        $scope.UnderSectionName = "";
        $scope.UnderSectionDesc = "";
        $("#divgy").show();
        $("#signinmodal").show();
    };


    $scope.BindUnderSectionList = function () {
        $scope.UnderSect = {};
        $scope.UnderSect.CaseId = "0";
        $scope.GetUnderSectionmasterlIstwithParameter($scope.UnderSect);
    }

    $scope.GetUnderSectionmasterlIstwithParameter = function (com) {
        $scope.doctype = com;
        $http({
            method: "POST",
            url: "/Master/GetUnderSectionmasterlIstwithParameter",
            datatype: "json",
            data: JSON.stringify($scope.doctype)
        }).then(function (response) {
            $scope.underSectionList = response.data;
            $scope.MakeDatatable($("#user_table"));
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });
    };

    $scope.InsertUnderSection = function () {
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action == "Submit") {
            $scope.UnderSection = {};
            $scope.UnderSection.UnderSectionID = "0";
            $scope.UnderSection.UnderSectionName = $scope.UnderSectionName;
            $scope.UnderSection.UnderSectionDesc = $scope.UnderSectionDesc;
            $scope.UnderSection.type = "1";
        }
        else {
            $scope.UnderSection = {};
            $scope.UnderSection.UnderSectionID = document.getElementById("UnderSectionID_").value;
            $scope.UnderSection.UnderSectionName = $scope.UnderSectionName;
            $scope.UnderSection.UnderSectionDesc = $scope.UnderSectionDesc;
            $scope.UnderSection.type = "2";
            document.getElementById("btnSave").setAttribute("value", "Submit");
            document.getElementById("btnSave").className = "btn btn-primary";
        }
        if ($scope.UnderSection != undefined || $scope.UnderSection != null) {
            $http({
                method: "POST",
                url: "/Master/AllinOneUnderSectionmaster",
                data: JSON.stringify($scope.UnderSection)
            }).then(function (response) {
                $('#user_table').DataTable().clear().destroy();
                $scope.BindUnderSectionList();
                //alert(response.data);
                toaster.success({ title: "Success", body: response.data });
                $("#divgy").hide();
                $("#signinmodal").hide();
            }, function (jqxhr, settings, exception) {
                if (jqxhr != null)
                    alert(jqxhr.data);
            });
        }
    };


    $scope.UpdateUnderSectionRec = function (com) {
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action == "Submit") {
            document.getElementById("UnderSectionID_").value = com.UnderSectionID;
            $scope.UnderSectionName = com.UnderSectionName;
            $scope.UnderSectionDesc = com.UnderSectionDesc;
            document.getElementById("btnSave").setAttribute("value", "Update");
            document.getElementById("btnSave").className = "btn btn-warning";
            $("#divgy").show();
            $("#signinmodal").show();
        }

    };


    $scope.deleteUnderSectionRec = function (com) {
        if ($window.confirm("Do you want to continue?")) {
            $scope.UnderSection = {};
            $scope.UnderSection.UnderSectionID = com.UnderSectionID;
            $scope.UnderSection.type = "-1";
            $http({
                method: "POST",
                url: "/Master/AllinOneUnderSectionmaster",
                data: JSON.stringify($scope.UnderSection)
            }).then(function (response) {
                // $('#user_table').dataTable().fnDestroy();
                $('#user_table').DataTable().clear().destroy();
                $scope.BindUnderSectionList();
                toaster.success({ title: "Success", body: response.data });
            }, function (jqxhr, settings, exception) {
                    if (jqxhr != null)
                        //toaster.error("Error", "An Error found, Try again...");
                    alert(jqxhr.data);
            });
        };
    };
    //-----End--------//

    //------Case Document ----------//
    $scope.showCaseDocumentDiv = function () {
        if (angular.isDefined($scope.ddldtype)) {
            delete $scope.ddldtype;
        }
        $scope.Udate = "";
        $scope.upfile = "";
        $scope.existfile = "";
        $("#divgy").show();
        $("#signinmodal").show();
    };


    $scope.LoadCaseDocument = function () {
        $scope.GetDocumenttypelIst();
        $scope.CaseDocument_bindrep();
    };

    $scope.CaseDocument_bindrep = function () {
        $scope.CaseDocument = {};
        $scope.CaseDocument.did = $scope.search.CaseID;  //Query String
        $scope.CaseDocument.type = "1";
        $scope.GetCaseDocumentslIstwithParameter($scope.CaseDocument);
    };


    $scope.GetCaseDocumentslIstwithParameter = function (com) {
        $scope.CaseDocuments = com;
        $http({
            method: "POST",
            url: "/Master/GetCaseDocumentslIstwithParameter",
            datatype: "json",
            data: JSON.stringify($scope.CaseDocuments)
        }).then(function (response) {
            $scope.casedocList = response.data;
            $scope.MakeDatatable($("#user_table"));
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });
    };

            

    $scope.bindCaseDocumenttextboxes = function (com) {
        $scope.CaseDocument = {};
        $scope.CaseDocument.did = com.did;
        $scope.CaseDocument.type = "0";
        $http({
            method: "POST",
            url: "/Master/GetCaseDocumentslIstwithParameter",
            datatype: "json",
            data: JSON.stringify($scope.CaseDocument)
        }).then(function (response) {
            angular.forEach(response.data, function (val, key) {
                if (key==0) {
                    $scope.ddldtype = val.Dtype;
                    $scope.Udate = val.Udate;
                    $scope.existfile = val.document;
                    document.getElementById("image_").value = val.Document;
                    document.getElementById("btnSave").setAttribute("value", "Update");
                    document.getElementById("btnSave").className = "btn btn-warning";
                    $("#divgy").show();
                    $("#signinmodal").show();
                }
            });
        }, function (jqxhr, settings, exception) {
            if (jqxhr != null)
                alert(jqxhr.data);
        });
    };

    $scope.InsertCaseDocument = function () {
        var files = (isEmpty(document.getElementById("upfile").files[0])) ? "" : document.getElementById("upfile").files[0];
        var existfile = (isEmpty($scope.existfile)) ? "" : $scope.existfile;
        if (files != "" || existfile != "") {
            var filetypes = $scope.ddldtype + $scope.Udate;
            var formData = new FormData();
            formData.append("filetype", filetypes);
            formData.append("Image", existfile);
            formData.append("file", files);
            $http({
                method: 'POST',
                url: "/Master/UploadFile",
                processData: false,
                contentType: false,
                data: formData,
                headers: { 'Content-Type': undefined },
                transformRequest: angular.identity,
            }).then(function (response, status, headers, config) {
                $scope.result = response.data;
                if ($scope.result.Response == 1) {
                    $scope.CaseDocument = {};
                    $scope.CaseDocument.Dtype = $scope.ddldtype;
                    $scope.CaseDocument.Document = $scope.result.Image;
                    $scope.CaseDocument.Udate = DateInYYYYMMDD($scope.Udate.trim()); //  $scope.Udate;
                    $scope.CaseDocument.crby = $("#userID").val();
                    $scope.CaseDocument.CaseId = $scope.search.CaseID;  // document.getElementById("CaseId_").value;
                    var Action = document.getElementById("btnSave").getAttribute("value");
                    if (Action == "Submit") {
                        $scope.CaseDocument.did = "0";
                        $scope.CaseDocument.type = "1";
                    }
                    else {
                        $scope.CaseDocument.did = document.getElementById("did_").value;
                        $scope.CaseDocument.type = "2";
                        document.getElementById("btnSave").setAttribute("value", "Submit");
                        document.getElementById("btnSave").className = "btn btn-primary";
                    }
                    if ($scope.CaseDocument != undefined || $scope.CaseDocument != null) {
                        $http({
                            method: "POST",
                            url: "/Master/AllinOneCaseDocuments",
                            data: JSON.stringify($scope.CaseDocument)
                        }).then(function (success) {
                            $('#user_table').DataTable().clear().destroy();
                            $scope.CaseDocument_bindrep();
                            toaster.success({ title: "Success", body: success.data });
                            $("#divgy").hide();
                            $("#signinmodal").hide();
                        }, function (jqxhr, settings, exception) {
                            if (jqxhr != null)
                                alert(jqxhr.data);
                        });
                    }
                }
                else {
                    toaster.error({ title: "Error", body: $scope.result.ResponseMsg });
                }

                //alert("success!");
            }, function (jqxhr, settings, exception) {
                if (jqxhr != null)
                    alert(jqxhr.data);
            });
        }
        else {
            toaster.error({ title: "Error", body: 'Please select a file for Uplading' });
            }
    }



    $scope.EditCaseDocument = function (com) {
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action == "Submit") {
            document.getElementById("did_").value = com.did;
            $scope.bindCaseDocumenttextboxes(com);
       }
    };

    $scope.deleteCaseDocument = function (com) {
        if ($window.confirm("Do you want to continue?")) {
            document.getElementById("did_").value = com.did;
            $scope.CaseDocument = {};
            $scope.CaseDocument.Dtype = com.Dtype;
            $scope.CaseDocument.Document = com.document;
            $scope.CaseDocument.Udate = DateInYYYYMMDD(com.Udate.trim()); //  $scope.Udate;
            $scope.CaseDocument.crby = $("#userID").val();;
            $scope.CaseDocument.CaseId = $scope.search.CaseID;  // document.getElementById("CaseId_").value;
            $scope.CaseDocument.did = com.did;
            $scope.CaseDocument.type = "-1";
            $http({
                method: "POST",
                url: "/Master/AllinOneCaseDocuments",
                data: JSON.stringify($scope.CaseDocument)
            }).then(function (response) {
                $('#user_table').DataTable().clear().destroy();
                $scope.CaseDocument_bindrep();
                toaster.success({ title: "Success", body: response.data });
            }, function (jqxhr, settings, exception) {
                if (jqxhr != null)
                    //toaster.error("Error", "An Error found, Try again...");
                    alert(jqxhr.data);
            });
        };
    };

    //----------End-----------------//



    //-------Datable Formation--------//
    $scope.MakeDatatable = function (userid) {
        angular.element(document).ready(function () {
            //$("#user_table").removeAttr("width").DataTable({
            userid.removeAttr("width").DataTable({
                destroy: true,
                "language": {
                    "emptyTable": "No Data Found"
                },
                "fixedColumns": {
                    "leftColumns": "2"
                },
                "scrollY": "300",
                "scrollX": "true",
                "columnDefs": [
                    {
                        "width": "20%",
                        "targets": "0"
                    }
                ]
            });
        });
    };
    //---------------end--------------//

    //$scope.isLoading = function () {
    //    return $http.pendingRequests.length > 0;
    //};


    function DateInYYYYMMDD(date) {
        var dateOut = date.split(/[/,-]/); //  (/[!,?,/,-,.]/);  //    .toString().split("/").split("-");
        var resultDate = new Date(dateOut[2] + "/" + dateOut[1] + "/" + dateOut[0]);
        return resultDate; 
    };

    function isEmpty(val) {
        if (val === undefined)
            return true;
        if (typeof (val) == 'function' || typeof (val) == 'number' || typeof (val) == 'boolean' || Object.prototype.toString.call(val) === '[object Date]')
            return false;
        if (val == null || val.length === 0) // null or 0 length array
            return true;
        if (typeof (val) == "object") {
            // empty object
            var r = true;
            for (var f in val)
                r = false;
            return r;
        }
        return false;
    }




    function ConvertDate(date) {
        var parsedDate = new Date(parseInt(date.substr(6)));
        var newDate = new Date(parsedDate);
        var month = ('0' + (newDate.getMonth() + 1)).slice(-2);
        var day = ('0' + newDate.getDate()).slice(-2);
        var year = newDate.getFullYear();
        return day + "-" + month + "-" + year;
    };

});

myApp.directive("datepicker", function () {
    function link(scope, element, attrs, controller) {
        // CALL THE "datepicker()" METHOD USING THE "element" OBJECT.
        element.datepicker({
            onSelect: function (dt) {
                scope.$apply(function () {
                    // UPDATE THE VIEW VALUE WITH THE SELECTED DATE.
                    controller.$setViewValue(dt);
                });
            },
            dateFormat: "dd-mm-yy",     // SET THE FORMAT.
            changeMonth: true,
            changeYear: true,
            yearRange: '1950:2100',
            inline: true,
            showAnim: 'fadeIn',
            beforeShow: function (input, inst) {
                var rect = input.getBoundingClientRect();
                setTimeout(function () {
                    inst.dpDiv.css({ top: rect.top + 40, left: rect.left + 0 });
                }, 0);
            },
            showButtonPanel: true,
            onClose: function (e) {
            var ev = window.event;
            if (ev.srcElement.innerHTML == 'Clear')
                this.value = "";
            },
            closeText: 'Clear',
        });
    }
    return {
        require: 'ngModel',
        link: link
    };
});

myApp.directive('myTarget', function () {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            var href = element.href;
            if (true) {  // replace with your condition
                element.attr("target", "_blank");
            }
        }
    };
});

myApp.directive('fileUpload', function () {
    return {
        scope: true,        //create a new scope
        link: function (scope, el, attrs) {
            el.bind('change', function (event) {
                var files = event.target.files;
                //iterate files since 'multiple' may be specified on the element
                for (var i = 0; i < files.length; i++) {
                    //emit event upward
                    scope.$emit("fileSelected", { file: files[i] });
                }
            });
        }
    };
});



myApp.directive('uploadFile', ['$parse', function ($parse) {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            var file_uploaded = $parse(attrs.uploadFile);
            element.bind('change', function () {
                scope.$apply(function () {
                    file_uploaded.assign(scope, element[0].files[0]);
                });
            });
        }
    };
}]);

//myApp.directive("compareWithStartDate", function () {
//    return {
//        restrict: "A",
//        require: "?ngModel",
//        link: function (scope, element, attributes, ngModel) {
//            validateEndDate = function (endDate, startDate) {
//                if (endDate && startDate) {
//                    startDate = new Date(startDate);
//                    startDate.setHours(0, 0, 0, 0);
//                    endDate = new Date(endDate);
//                    endDate.setHours(0, 0, 0, 0);
//                    return endDate >= startDate;
//                }
//                else {
//                    return true;
//                }
//            }

//            // use $validators.validation_name to do the validation
//            ngModel.$validators.checkEndDate = function (modelValue) {
//                var startdate = Date.parse(attributes.startDate);
//                var enddate = modelValue;
//                return validateEndDate(enddate, startdate);
//            };

//            // use $observe if we need to keep an eye for changes on a passed value
//            attributes.$observe('startDate', function (value) {
//                var startdate = Date.parse(value);
//                var enddate = Date.parse(ngModel.$viewValue);
//                // use $setValidity method to determine the validation result 
//                // the first parameter is the validation name, this name is the same in ng-message template as well
//                // the second parameter sets the validity (true or false), we can pass a function returning a boolean
//                ngModel.$setValidity("checkEndDate", validateEndDate(enddate, startdate));
//            });
//        }
//    };
//});


//// function to parse date time object into yyyy-mm-dd format string
//Date.prototype.yyyymmdd = function () {
//    var yyyy = this.getFullYear().toString();
//    var mm = (this.getMonth() + 1).toString(); // getMonth() is zero-based         
//    var dd = this.getDate().toString();

//    return yyyy + '-' + (mm[1] ? mm : "0" + mm[0]) + '-' + (dd[1] ? dd : "0" + dd[0]);
//};




myApp.factory('LegalService', function ($http) {
    var Case_Hearing_HistorylIst = function (com) {
        // Angular $http() and then() both return promises themselves
        return $http({ method: "GET", url: '/Cases/GetCase_Hearing_HistorylIst/', data: JSON.stringify(com) }).then(function (result) {
            // What we return here is the data that will be accessible
            // to us after the promise resolves
            return result.data;
        });
    };
    return { Case_Hearing_HistorylIst: Case_Hearing_HistorylIst };
});

myApp.directive('loader', function () {
    return {
        restrict: 'A',
        scope: { cond: '=loader' },
        template: '<span ng-if="isLoading()" class="soft"><span class="fa fa-refresh fa-spin"></span></span>',
        link: function (scope) {
            scope.isLoading = function () {
                var ret = scope.cond === true || (
                    scope.cond &&
                    scope.cond.$$state &&
                    angular.isDefined(scope.cond.$$state.status) &&
                    scope.cond.$$state.status === 0
                );
                return ret;
            }
        }
    };
}); 


myApp.factory('httpRequestInterceptor', ['$Scope', '$location', function ($Scope, $location) {
    return {
        request: function ($config) {
            $('.loader').show();
            return $config;
        },
        response: function ($config) {
            $('.loader').hide();
            return $config;
        },
        responseError: function (response) {
            return response;
        }
    };
}]);

myApp.factory('GetEmployeeSession', function ($http, $q) {
    return {
        checkSession: function () {
            return $http({
                url: "/Dept/get_Session_ID",
                dataType: "json",
                method: "GET",
                data: "{}",
                headers: { "Content-Type": "application/json" }
            }).then(function (resp) {
                if (typeof resp.data === 'object') {
                    return resp.data;
                } else {
                    return $q.reject(response.data);
                }
            }, function (err) {
                return $q.reject(err.data);
            });
        }
    }
});



//myApp.config(['$stateProvider', '$urlRouterProvider', '$httpProvider',
//    function ($stateProvider, $urlRouterProvider, $httpProvider) {
//        $httpProvider.interceptors.push('httpRequestInterceptor');
//    }]);


