<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminHR_Employee.aspx.cs" Inherits="AdminHR_Employee" Title="Add Employee" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
    <script type="text/javascript" src="sliding.form.js"></script>
    <style type="text/css">
        #contenttab
        {
            /*margin: 15px;*/
            margin: 0px 0 15px;
            text-align: center;
            width: 800px;
            position: relative;
            height: 100%;
        }
        #wrapper
        {
            -moz-box-shadow: 0px 0px 3px #aaa;
            -webkit-box-shadow: 0px 0px 3px #aaa;
            box-shadow: 0px 0px 3px #aaa;
            -moz-border-radius: 10px;
            -webkit-border-radius: 10px;
            border-radius: 10px;
            border: 2px solid #fff;
            background-color: #f9f9f9;
            width: 800px;
            overflow: hidden;
        }
        #steps .tab-title
        {
            background-color: #F0F0F0;
            border-bottom: 1px solid #FFFFFF;
            border-top: 1px solid #D9D9D9;
            color: #666666;
            float: left;
            font-size: 24px;
            line-height: 28px;
            font-weight: bold;
            margin: 10px 0;
            padding: 5px 0 5px 10px;
            text-align: left;
            text-shadow: 1px 1px 1px #FFFFFF;
            width: 790px;
        }
        span.reference
        {
            position: fixed;
            left: 5px;
            top: 5px;
            font-size: 10px;
            text-shadow: 1px 1px 1px #fff;
        }
        span.reference a
        {
            color: #555;
            text-decoration: none;
            text-transform: uppercase;
        }
        span.reference a:hover
        {
            color: #000;
        }
        h1
        {
            color: #ccc;
            font-size: 36px;
            text-shadow: 1px 1px 1px #fff;
            padding: 20px;
        }
        #steps
        {
            width: 800px; /*height:320px;*/
            overflow: hidden;
        }
        .step
        {
            float: left;
            width: 800px; /*height:320px;*/
        }
        #navigation
        {
            /*height: 45px;*/
            overflow: hidden;
            background-color: #e9e9e9;
            border-top: 1px solid #fff;
            -moz-border-radius: 0px 0px 10px 10px;
            -webkit-border-bottom-left-radius: 10px;
            -webkit-border-bottom-right-radius: 10px;
            border-bottom-left-radius: 10px;
            border-bottom-right-radius: 10px;
        }
        #navigation ul
        {
            list-style: none;
            float: left;
            margin-left: 9px;
        }
        #navigation ul li
        {
            float: left;
            border-right: 1px solid #ccc;
            border-left: 1px solid #ccc;
            position: relative;
            margin: 0px 1px;
        }
        #navigation ul li a
        {
            display: block;
            height: 45px;
            background-color: #444;
            color: #777;
            outline: none;
            font-weight: bold;
            text-decoration: none;
            line-height: 45px;
            padding: 0px 5px;
            border-right: 1px solid #fff;
            border-left: 1px solid #fff;
            background: #f0f0f0;
            background: -webkit-gradient(
        linear,
        left bottom,
        left top,
        color-stop(0.09, rgb(240,240,240)),
        color-stop(0.55, rgb(227,227,227)),
        color-stop(0.78, rgb(240,240,240))
        );
            background: -moz-linear-gradient(
        center bottom,
        rgb(240,240,240) 9%,
        rgb(227,227,227) 55%,
        rgb(240,240,240) 78%
        );
        }
        #navigation ul li a:hover, #navigation ul li.selected a
        {
            background: #d8d8d8;
            color: #666;
            text-shadow: 1px 1px 1px #fff;
        }
        /*span.checked
        {
            background: transparent url(images/checked.png) no-repeat top left;
            position: absolute;
            top: 0px;
            left: 1px;
            width: 20px;
            height: 20px;
        }
        span.error
        {
            background: transparent url(images/error.png) no-repeat top left;
            position: absolute;
            top: 0px;
            left: 1px;
            width: 20px;
            height: 20px;
        }*/
        #steps form fieldset
        {
            border: none;
            padding-bottom: 20px;
        }
        #steps form legend
        {
            text-align: left;
            background-color: #f0f0f0;
            color: #666;
            font-size: 24px;
            text-shadow: 1px 1px 1px #fff;
            font-weight: bold;
            float: left;
            width: 590px;
            padding: 5px 0px 5px 10px;
            margin: 10px 0px;
            border-bottom: 1px solid #fff;
            border-top: 1px solid #d9d9d9;
        }
        #steps form p
        {
            float: left;
            clear: both;
            margin: 5px 0px;
            background-color: #f4f4f4;
            border: 1px solid #fff;
            width: 400px;
            padding: 10px;
            margin-left: 100px;
            -moz-border-radius: 5px;
            -webkit-border-radius: 5px;
            border-radius: 5px;
            -moz-box-shadow: 0px 0px 3px #aaa;
            -webkit-box-shadow: 0px 0px 3px #aaa;
            box-shadow: 0px 0px 3px #aaa;
        }
        #steps form p label
        {
            width: 160px;
            float: left;
            text-align: right;
            margin-right: 15px;
            line-height: 26px;
            color: #666;
            text-shadow: 1px 1px 1px #fff;
            font-weight: bold;
        }
        #steps form input:not([type=radio]), #steps form textarea, #steps form select
        {
            background: #ffffff;
            border: 1px solid #ddd;
            -moz-border-radius: 3px;
            -webkit-border-radius: 3px;
            border-radius: 3px;
            outline: none;
            padding: 5px;
            width: 200px;
            float: left;
        }
        #steps form input:focus
        {
            -moz-box-shadow: 0px 0px 3px #aaa;
            -webkit-box-shadow: 0px 0px 3px #aaa;
            box-shadow: 0px 0px 3px #aaa;
            background-color: #FFFEEF;
        }
        #steps form p.submit
        {
            background: none;
            border: none;
            -moz-box-shadow: none;
            -webkit-box-shadow: none;
            box-shadow: none;
        }
        #steps form button
        {
            border: none;
            outline: none;
            -moz-border-radius: 10px;
            -webkit-border-radius: 10px;
            border-radius: 10px;
            color: #ffffff;
            display: block;
            cursor: pointer;
            margin: 0px auto;
            clear: both;
            padding: 7px 25px;
            text-shadow: 0 1px 1px #777;
            font-weight: bold;
            font-family: "Century Gothic" , Helvetica, sans-serif;
            font-size: 22px;
            -moz-box-shadow: 0px 0px 3px #aaa;
            -webkit-box-shadow: 0px 0px 3px #aaa;
            box-shadow: 0px 0px 3px #aaa;
            background: #4797ED;
        }
        #steps form button:hover
        {
            background: #d8d8d8;
            color: #666;
            text-shadow: 1px 1px 1px #fff;
        }
        .msgClass
        {
            width: 100%;
            display: block;
            line-height: 14px;
            font-size: 12px;
            color: green;
            text-align: left;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            /*
            number of fieldsets
            */
            var fieldsetCount = $('#Form1').children().length;

            /*
            current position of fieldset / navigation link
            */
            var current = 1;

            /*
            sum and save the widths of each one of the fieldsets
            set the final sum as the total width of the steps element
            */
            var stepsWidth = 0;
            var widths = new Array();
            $('#steps .step').each(function (i) {
                var $step = $(this);
                widths[i] = stepsWidth;
                stepsWidth += $step.width();
            });
            $('#steps').width(stepsWidth);

            /*
            to avoid problems in IE, focus the first input of the form
            */
            $('#Form1').children(':first').find(':input:first').focus();

            /*
            show the navigation bar
            */
            $('#navigation').show();

            /*
            when clicking on a navigation link
            the form slides to the corresponding fieldset
            */
            $('#navigation a').bind('click', function (e) {
                var $this = $(this);
                var prev = current;
                $this.closest('ul').find('li').removeClass('selected');
                $this.parent().addClass('selected');
                /*
                we store the position of the link
                in the current variable
                */
                current = $this.parent().index() + 1;
                /*
                animate / slide to the next or to the corresponding
                fieldset. The order of the links in the navigation
                is the order of the fieldsets.
                Also, after sliding, we trigger the focus on the first
                input element of the new fieldset
                If we clicked on the last link (confirmation), then we validate
                all the fieldsets, otherwise we validate the previous one
                before the form slided
                */
                $('#steps').stop().animate({
                    marginLeft: '-' + widths[current - 1] + 'px'
                }, 500, function () {
                    if (current == fieldsetCount)
                        validateSteps();
                    else
                        validateStep(prev);
                    $('#Form1').children(':nth-child(' + parseInt(current) + ')').find(':input:first').focus();
                });
                e.preventDefault();
            });

            /*
            clicking on the tab (on the last input of each fieldset), makes the form
            slide to the next step
            */
            $('#formElem > fieldset').each(function () {
                var $fieldset = $(this);
                $fieldset.children(':last').find(':input').keydown(function (e) {
                    if (e.which == 9) {
                        $('#navigation li:nth-child(' + (parseInt(current) + 1) + ') a').click();
                        /* force the blur for validation */
                        $(this).blur();
                        e.preventDefault();
                    }
                });
            });

            /*
            validates errors on all the fieldsets
            records if the form has errors in $('#formElem').data()
            */
            //            function validateSteps() {
            //                var FormErrors = false;
            //                for (var i = 1; i < fieldsetCount; ++i) {
            //                    var error = validateStep(i);
            //                    if (error == -1)
            //                        FormErrors = true;
            //                }
            //                $('#formElem').data('errors', FormErrors);
            //            }

            /*
            validates one fieldset
            and returns -1 if errors found, or 1 if not
            */
            //            function validateStep(step) {
            //                if (step == fieldsetCount) return;

            //                var error = 1;
            //                var hasError = false;
            //                $('#formElem').children(':nth-child(' + parseInt(step) + ')').find(':input:not(button)').each(function () {
            //                    var $this = $(this);
            //                    var valueLength = jQuery.trim($this.val()).length;

            //                    if (valueLength == '') {
            //                        hasError = true;
            //                        $this.css('background-color', '#FFEDEF');
            //                    }
            //                    else
            //                        $this.css('background-color', '#FFFFFF');
            //                });
            //                var $link = $('#navigation li:nth-child(' + parseInt(step) + ') a');
            //                $link.parent().find('.error,.checked').remove();

            //                var valclass = 'checked';
            //                if (hasError) {
            //                    error = -1;
            //                    valclass = 'error';
            //                }
            //                $('<span class="' + valclass + '"></span>').insertAfter($link);

            //                return error;
            //            }

            /*
            if there are errors don't allow the user to submit
            */
            //            $('#registerButton').bind('click', function () {
            //                if ($('#formElem').data('errors')) {
            //                    alert('Please correct the errors in the Form');
            //                    return false;
            //                }
           //           });
           );
                 function checkFileExtension(elem) {
        var filePath = elem.value;

        if (filePath.indexOf('.') == -1)
            return false;

        var validExtensions = new Array();
        var ext = filePath.substring(filePath.lastIndexOf('.') + 1).toLowerCase();
        //Add valid extentions in this array
        validExtensions[0] = 'txt';
        validExtensions[1] = 'pdf';
        validExtensions[2] = 'doc';
        validExtensions[3] = 'docx';
        //validExtensions[2] = 'gif';

        for (var i = 0; i < validExtensions.length; i++) {
            if (ext == validExtensions[i])
                return true;
        }
      

        alert('The file extension ' + ext.toUpperCase() + ' is not allowed!. Only allow (.txt,.pdf,.doc,.docx) extension Docfile.');
        elem.value = "";
        return false;
        }

    </script>
    <link rel="stylesheet" type="text/css" href="../App_Themes/CoffeyGreen/css/grid.css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:HiddenField ID="hfLoggedInUserID" runat="server" />
    <div class="content-box">
        <div class="header">
            <h3 id="headerH3Name" runat="server">
                Add Employee</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt></dt>
                <dd>
                    <asp:Label runat="server" ID="lblError" Text=""></asp:Label>
                </dd>
                <dt>
                    <asp:Label ID="lblEmployeeName" runat="server" Text="Employee Name: ">
                    </asp:Label>
                    <asp:RequiredFieldValidator ID="rfvEmployeeName" runat="server" SetFocusOnError="true"
                        Display="Dynamic" ControlToValidate="txtEmployeeName" ErrorMessage="Emaployee name is not empty"
                        Text="*" ForeColor="Red" ValidationGroup="basicEmployeeGroup"></asp:RequiredFieldValidator>
                </dt>
                <dd>
                    <asp:TextBox ID="txtEmployeeName" class="txt large-input" runat="server" Text="">
                    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="Label2" runat="server" Text="Short Code(For Routine): ">
                    </asp:Label>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" SetFocusOnError="true"
                        Display="Dynamic" ControlToValidate="txtNickName" ErrorMessage="Nick name is not empty"
                        Text="*" ForeColor="Red" ValidationGroup="basicEmployeeGroup"></asp:RequiredFieldValidator>--%>
                </dt>
                <dd>
                    <asp:TextBox ID="txtNickName" class="txt large-input" runat="server" Text="NA">
                    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="Label3" runat="server" Text="Name Detail(For Routine): ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtNickNameDetail" class="txt large-input" runat="server" Text="NA">
                    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label runat="server" ID="lblEmailaddress" Text="Email Address :"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" SetFocusOnError="true"
                        Display="Dynamic" ControlToValidate="txtEmailAddress" ErrorMessage="Emaployee name is not empty"
                        Text="*" ForeColor="Red" ValidationGroup="basicEmployeeGroup"></asp:RequiredFieldValidator>
                </dt>
                <dd>
                    <asp:TextBox ID="txtEmailAddress" class="txt large-input" runat="server" Text="">
                    </asp:TextBox></dd>
                <dt>
                    <asp:Label runat="server" ID="lblTmpMobile" Text="Mobile #:"></asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtTmpMobile" class="txt large-input" runat="server" Text="01">
                    </asp:TextBox></dd>
                <dt>
                    <asp:Label runat="server" ID="lblTmpSalary" Text="Salary:"></asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtTmpSalary" class="txt large-input" runat="server" Text="0">
                    </asp:TextBox></dd>
                <dt>
                    <asp:Label ID="lblUserID" runat="server" Text="Employee ID : ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtUserID" class="txt large-input" runat="server" Text="">
                    </asp:TextBox>
                    <asp:HiddenField ID="hfEmployeeID" runat="server" />
                </dd>
                <dt>
                    <asp:Label ID="lblEmployeeType" runat="server" Text="Employee Type: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlEmployeerType" class="txt meduim-input" runat="server">
                        <%--<asp:ListItem Value="Permanent">Permanent</asp:ListItem>
                        <asp:ListItem Value="PartTime">Part Time</asp:ListItem>--%>
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="Label5" runat="server" Text="Department: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlDepartment" runat="server" class="txt meduim-input" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlDepartment_OnSelectedIndexChanged">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblDesignationID" runat="server" Text="Designation: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlDesignationID" runat="server" class="txt meduim-input">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblEmployeeRank" runat="server" Text="Employee Rank: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlRank" runat="server" class="txt meduim-input">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblFathersName" runat="server" Text="Fathers Name: ">
                    </asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" SetFocusOnError="true"
                        Display="Dynamic" ControlToValidate="txtFathersName" ErrorMessage="Emaployee name is not empty"
                        Text="*" ForeColor="Red" ValidationGroup="basicEmployeeGroup"></asp:RequiredFieldValidator>
                </dt>
                <dd>
                    <asp:TextBox ID="txtFathersName" class="txt large-input" runat="server" Text="">
                    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblMothersName" runat="server" Text="Mothers Name: ">
                    </asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" SetFocusOnError="true"
                        Display="Dynamic" ControlToValidate="txtMothersName" ErrorMessage="Emaployee name is not empty"
                        Text="*" ForeColor="Red" ValidationGroup="basicEmployeeGroup"></asp:RequiredFieldValidator>
                </dt>
                <dd>
                    <asp:TextBox ID="txtMothersName" class="txt large-input" runat="server" Text="">
                    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblSpouseName" runat="server" Text="Spouse Name: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtSpouseName" class="txt large-input" runat="server" Text="">
                    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblDateOfBirth" runat="server" Text="Date Of Birth: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtDateOfBirth" class="txt large-input" runat="server" Text="">
                    </asp:TextBox>
                    <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="calendarDateOfBirth" runat="server"
                        TargetControlID="txtDateOfBirth">
                    </ajaxToolkit:CalendarExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" SetFocusOnError="true"
                        Display="Dynamic" ControlToValidate="txtDateOfBirth" ErrorMessage="DOB is not empty"
                        Text="*" ForeColor="Red" ValidationGroup="basicEmployeeGroup"></asp:RequiredFieldValidator>
                </dd>
                <dt>
                    <asp:Label ID="lblPlaceOfBirth" runat="server" Text="Place Of Birth: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtPlaceOfBirth" class="txt large-input" runat="server" Text="">
                    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblBloodGroupID" runat="server" Text="Blood Group: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlBloodGroupID" runat="server" class="txt meduim-input">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblGenderID" runat="server" Text="Gender: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlGenderID" runat="server" class="txt meduim-input">
                        <asp:ListItem Value="M">Male</asp:ListItem>
                        <asp:ListItem Value="F">Female</asp:ListItem>
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblReligionID" runat="server" Text="Religion: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlReligionID" runat="server" class="txt meduim-input">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblMaritualStatusID" runat="server" Text="Marital Status: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlMaritualStatusID" runat="server" class="txt meduim-input">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblNationalityID" runat="server" Text="Nationality: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlNationalityID" runat="server">
                    </asp:DropDownList>
                </dd>
                <%--<dt>
                    <asp:Label ID="lblPhoto" runat="server" Text="Photo: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:FileUpload ID="fileEmployerPhoto" runat="server" />
                    <asp:Image ID="imgEmployeerImage" runat="server" Height="110px" Width="110" />
                    <asp:HiddenField ID="hdnEmployeerImage" runat="server" />
                </dd>--%>
                <dt>
                    <asp:Label ID="lblAddress" runat="server" Text="Address: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtAddress" class="txt large-input" runat="server" Text="">
                    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="Label1" runat="server" Text="Joining Date: ">
                    </asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" SetFocusOnError="true"
                        Display="Dynamic" ControlToValidate="txtJoiningDate" ErrorMessage="Joining Date is not empty"
                        Text="*" ForeColor="Red" ValidationGroup="basicEmployeeGroup"></asp:RequiredFieldValidator>
                </dt>
                <dd>
                    <asp:TextBox ID="txtJoiningDate" class="txt large-input" runat="server" Text="">
                    </asp:TextBox>
                    <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="CalendarExtender4" runat="server"
                        TargetControlID="txtJoiningDate">
                    </ajaxToolkit:CalendarExtender>
                </dd>
                <dt>
                    <asp:Label ID="lblFlag" runat="server" Text="Employee Status: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:RadioButtonList ID="radFlag" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True">Active</asp:ListItem>
                        <asp:ListItem>Inactive</asp:ListItem>
                    </asp:RadioButtonList>
                </dd>
                <dt><span style="margin-top: 40px; display: block;">
                    <asp:Label ID="lblPhoto" runat="server" Text="Photo: ">
                    </asp:Label>
                </span></dt>
                <dd>
                    <table>
                        <tr>
                            <td>
                                <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" width="405" height="190"
                                    id="FlashID" title="banner">
                                    <param name="movie" value="WebcamResources/save_picture.swf" />
                                    <param name="quality" value="high" />
                                    <param name="wmode" value="opaque" />
                                    <param name="swfversion" value="8.0.35.0" />
                                    <!-- This param tag prompts users with Flash Player 6.0 r65 and higher to download the latest version of Flash Player. Delete it if you don’t want users to see the prompt. -->
                                    <param name="expressinstall" value="Scripts/expressInstall.swf" />
                                    <!-- Next object tag is for non-IE browsers. So hide it from IE using IECC. -->
                                    <!--[if !IE]>-->
                                    <object type="application/x-shockwave-flash" data="WebcamResources/save_picture.swf"
                                        width="405" height="190">
                                        <!--<![endif]-->
                                        <param name="quality" value="high" />
                                        <param name="wmode" value="opaque" />
                                        <param name="swfversion" value="8.0.35.0" />
                                        <param name="expressinstall" value="Scripts/expressInstall.swf" />
                                        <!-- The browser displays the following alternative content for users with Flash Player 6.0 and older. -->
                                        <div>
                                            <h4>
                                                Content on this page requires a newer version of Adobe Flash Player.</h4>
                                            <p>
                                                <a href="http://www.adobe.com/go/getflashplayer">
                                                    <img src="http://www.adobe.com/images/shared/download_buttons/get_flash_player.gif"
                                                        alt="Get Adobe Flash player" width="112" height="33" /></a></p>
                                        </div>
                                        <!--[if !IE]>-->
                                    </object>
                                    <!--<![endif]-->
                                </object>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span style="margin-top: 40px; width: 55%; float: left;">
                                    <asp:FileUpload ID="fileEmployerPhoto" runat="server" OnLoad="fileEmployerPhoto_OnPreRender" />
                                    <asp:Button ID="showImage" runat="server" Text="Show" Visible="false" OnClick="showImage_OnClick" />
                                </span><span style="width: 200px; height: 150px; float: left">
                                    <asp:Image ID="imgEmployeerImage" runat="server" Height="150px" Width="200px" />
                                    <asp:HiddenField ID="hdnEmployeerImage" runat="server" />
                                </span>
                            </td>
                        </tr>
                    </table>
                </dd>
                <dt></dt>
                <dd>
                    <asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Add" ValidationGroup="basicEmployeeGroup"
                        CausesValidation="true" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnUpdate" class="button button-blue" runat="server" Text="Update"
                        ValidationGroup="basicEmployeeGroup" CausesValidation="true" OnClick="btnUpdate_Click"
                        Visible="false" />
                </dd>
            </dl>
        </div>
    </div>
    <div class="content-box" runat="server" id="div2">
        <div class="header">
            <h3>
                Work Schecule</h3>
        </div>
        <div style="width: 97%; margin: 0 auto; overflow: hidden;">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                Day
                            </td>
                            <td>
                                Start Time
                            </td>
                            <td style="padding-left: 50px;">
                                End Time
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:HiddenField ID="hfEmployeeScheduleID" runat="server" />
                                <asp:DropDownList ID="ddlClassDay" CssClass="cssSexList" runat="server">
                                    <asp:ListItem>Saturday</asp:ListItem>
                                    <asp:ListItem>Sunday</asp:ListItem>
                                    <asp:ListItem>Monday</asp:ListItem>
                                    <asp:ListItem>Tuesday</asp:ListItem>
                                    <asp:ListItem>Wednesday</asp:ListItem>
                                    <asp:ListItem>Thrusday</asp:ListItem>
                                    <asp:ListItem>Friday</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlStartHour" CssClass="cssSexList" runat="server">
                                    <asp:ListItem Value="00" Text="00"></asp:ListItem>
                                    <asp:ListItem Value="01" Text="01"></asp:ListItem>
                                    <asp:ListItem Value="02" Text="02"></asp:ListItem>
                                    <asp:ListItem Value="03" Text="03"></asp:ListItem>
                                    <asp:ListItem Value="04" Text="04"></asp:ListItem>
                                    <asp:ListItem Value="05" Text="05"></asp:ListItem>
                                    <asp:ListItem Value="06" Text="06"></asp:ListItem>
                                    <asp:ListItem Value="07" Text="07"></asp:ListItem>
                                    <asp:ListItem Value="08" Text="08"></asp:ListItem>
                                    <asp:ListItem Value="09" Text="09"></asp:ListItem>
                                    <asp:ListItem Value="10" Text="10"></asp:ListItem>
                                    <asp:ListItem Value="11" Text="11"></asp:ListItem>
                                    <asp:ListItem Value="12" Text="12"></asp:ListItem>
                                </asp:DropDownList>
                                :
                                <asp:DropDownList ID="ddlStartMin" CssClass="cssSexList" runat="server">
                                    <asp:ListItem>00</asp:ListItem>
                                    <asp:ListItem>05</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>15</asp:ListItem>
                                    <asp:ListItem>20</asp:ListItem>
                                    <asp:ListItem>25</asp:ListItem>
                                    <asp:ListItem>30</asp:ListItem>
                                    <asp:ListItem>35</asp:ListItem>
                                    <asp:ListItem>40</asp:ListItem>
                                    <asp:ListItem>45</asp:ListItem>
                                    <asp:ListItem>50</asp:ListItem>
                                    <asp:ListItem>55</asp:ListItem>
                                </asp:DropDownList>
                                -
                                <asp:DropDownList ID="ddlStartTT" CssClass="cssSexList" runat="server">
                                    <asp:ListItem>AM</asp:ListItem>
                                    <asp:ListItem>PM</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="padding-left: 50px;">
                                <asp:DropDownList ID="ddlEndHour" CssClass="cssSexList" runat="server">
                                    <asp:ListItem Value="00" Text="00"></asp:ListItem>
                                    <asp:ListItem Value="01" Text="01"></asp:ListItem>
                                    <asp:ListItem Value="02" Text="02"></asp:ListItem>
                                    <asp:ListItem Value="03" Text="03"></asp:ListItem>
                                    <asp:ListItem Value="04" Text="04"></asp:ListItem>
                                    <asp:ListItem Value="05" Text="05"></asp:ListItem>
                                    <asp:ListItem Value="06" Text="06"></asp:ListItem>
                                    <asp:ListItem Value="07" Text="07"></asp:ListItem>
                                    <asp:ListItem Value="08" Text="08"></asp:ListItem>
                                    <asp:ListItem Value="09" Text="09"></asp:ListItem>
                                    <asp:ListItem Value="10" Text="10"></asp:ListItem>
                                    <asp:ListItem Value="11" Text="11"></asp:ListItem>
                                    <asp:ListItem Value="12" Text="12"></asp:ListItem>
                                </asp:DropDownList>
                                :
                                <asp:DropDownList ID="ddlEndMin" CssClass="cssSexList" runat="server">
                                    <asp:ListItem>00</asp:ListItem>
                                    <asp:ListItem>05</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>15</asp:ListItem>
                                    <asp:ListItem>20</asp:ListItem>
                                    <asp:ListItem>25</asp:ListItem>
                                    <asp:ListItem>30</asp:ListItem>
                                    <asp:ListItem>35</asp:ListItem>
                                    <asp:ListItem>40</asp:ListItem>
                                    <asp:ListItem>45</asp:ListItem>
                                    <asp:ListItem>50</asp:ListItem>
                                    <asp:ListItem>55</asp:ListItem>
                                </asp:DropDownList>
                                -
                                <asp:DropDownList ID="ddlEndTT" CssClass="cssSexList" runat="server">
                                    <asp:ListItem>AM</asp:ListItem>
                                    <asp:ListItem>PM</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td colspan="2">
                                <asp:Button ID="btnAddEmployeeSchedule" class="button button-blue" Visible="false"
                                    runat="server" Text="Add" OnClick="btnAddEmployeeSchedule_Click" />
                                <asp:Button ID="btnUpdateEmployeeSchedule" class="button button-blue" runat="server"
                                    Visible="false" Text="Update" OnClick="btnUpdateEmployeeSchedule_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:GridView ID="gvEmployeeSchedule" runat="server" AutoGenerateColumns="false"
                                    CssClass="tabel_input">
                                    <HeaderStyle CssClass="heading" />
                                    <RowStyle CssClass="row" />
                                    <AlternatingRowStyle CssClass="altrow" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="ClassDayID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblClassDayID" runat="server" Text='<%#Eval("ClassDay") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="StartTime">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStartTime" runat="server" Text='<%#Eval("StartTime") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="EndTime">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEndTime" runat="server" Text='<%#Eval("EndTime") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:ImageButton runat="server" ID="lbSelectEmployeeSchedule" CommandArgument='<%#Eval("EmployeeScheduleID") %>'
                                                    OnClick="lbSelectEmployeeSchedule_Click" AlternateText="Edit" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete" Visible="false">
                                            <ItemTemplate>
                                                <asp:ImageButton runat="server" ID="lbDeleteEmployeeSchedule" CommandArgument='<%#Eval("EmployeeScheduleID") %>'
                                                    OnClientClick="return confirm('Are You Sure, You Want To Delete?')" AlternateText="Delete"
                                                    OnClick="lbDeleteEmployeeSchedule_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="content-box" runat="server" id="divPersonalDoucument">
        <div class="header">
            <h3>
                Personal Documents</h3>
        </div>
        <div style="width: 97%; margin: 0 auto; overflow: hidden;">
            <asp:HiddenField ID="hdnOtherDocumentsID" runat="server" Value="" />
            <div style="width: 100%; overflow: hidden; margin: 4px 0;">
                <label style="width: 156px; line-height: 20px; float: left; font-size: 13px;">
                    Document Type:</label>
                <span style="float: left; width: 591px;">
                    <%--<asp:TextBox ID="txtBoxNo" runat="server" CssClass="txt large-input" Text=""></asp:TextBox>--%>
                    <span style="float: left; width: 150px; height: 20px;">
                        <asp:DropDownList ID="ddlDocumentType" runat="server">
                            <asp:ListItem Value="ED">Educational Docs</asp:ListItem>
                            <asp:ListItem Value="JEL">Job Experiance Letter</asp:ListItem>
                        </asp:DropDownList>
                    </span></span>
            </div>
            <div style="width: 100%; overflow: hidden; margin: 4px 0;">
                <label style="width: 156px; line-height: 20px; float: left; font-size: 13px;">
                    Document Name:</label>
                <span style="float: left; width: 591px;">
                    <%--<asp:TextBox ID="TextBox1" runat="server" CssClass="txt large-input" Text=""></asp:TextBox>--%>
                    <span style="float: left; width: 505px;">
                        <asp:FileUpload ID="uplFile" runat="server" Width="90%" /></span>
                    <asp:Label ID="docFileloaction" runat="server" Visible="false"></asp:Label>
                </span>
            </div>
            <div style="width: 100%; overflow: hidden; margin: 4px 0;">
                <div style="width: 480px; float: right;">
                    <asp:Label ID="lblOtherDocumentsMessage" CssClass="msgClass" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div style="width: 50%; overflow: hidden; margin: 4px auto;">
                <asp:Button ID="Button1" class="button button-blue" runat="server" Text="Add" OnClick="btnAddOtherDocuments_Click" />
            </div>
        </div>
    </div>
    <div id="contenttab" runat="server">
        <div id="wrapper">
            <div id="steps">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnAddContact" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnUpdateContacts" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnAddChildrenInfo" EventName="Click" />
                        <%--<asp:AsyncPostBackTrigger ControlID = "btnUpdateChildrenInfo" EventName ="Click" />--%>
                        <asp:AsyncPostBackTrigger ControlID="btnAddJobExperience" EventName="Click" />
                        <%--<asp:AsyncPostBackTrigger ControlID = "btnUpdateJobExperience" EventName = "Click" />--%>
                        <asp:AsyncPostBackTrigger ControlID="btnAddBank" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnUpdateBank" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnAddWorkingDaysShifting" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnUpdateWorkingDaysShifting" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="ddlAdjustmentGroup" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlSalaryTaxPackageID" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlBenifitPackage" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlPackage" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="radSalaryRules" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="btnAddEducationalBackground" EventName="Click" />
                    </Triggers>
                    <ContentTemplate>
                        <div id="formElem" name="formElem">
                            <fieldset class="step">
                                <div class="tab-title">
                                    Contacts</div>
                                <asp:HiddenField ID="hdnContactsID" runat="server" Value="" />
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Current Address:</label>
                                    <span style="display: inline;">
                                        <asp:TextBox ID="txtCurrentAddress" class="txt medium-input" runat="server" Text="">
                                        </asp:TextBox></span>
                                </div>
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Permanent Address:</label>
                                    <span style="display: inline;">
                                        <asp:TextBox ID="txtPermanentAddress" class="txt medium-input" runat="server" Text="">
                                        </asp:TextBox></span>
                                </div>
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Telephone:</label>
                                    <span style="display: inline;">
                                        <asp:TextBox ID="txtTelephone" class="txt medium-input" runat="server" Text="">
                                        </asp:TextBox></span>
                                </div>
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Mobile:</label>
                                    <span style="display: inline;">
                                        <asp:TextBox ID="txtMobile" class="txt medium-input" runat="server" Text="">
                                        </asp:TextBox></span>
                                </div>
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Email:</label>
                                    <span style="display: inline;">
                                        <asp:TextBox ID="txtEmail" class="txt medium-input" runat="server" Text="">
                                        </asp:TextBox></span>
                                </div>
                                <div style="margin: 4px 0 8px 0; width: 98%; float: left;">
                                    <div style="width: 480px; float: right;">
                                        <asp:Label ID="lblContactMsg" CssClass="msgClass" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div style="margin: 4px 0;">
                                    <asp:Button ID="btnAddContact" class="button button-blue" runat="server" Text="Add"
                                        OnClick="btnAddContact_Click" />
                                    <asp:Button ID="btnUpdateContacts" class="button button-blue" runat="server" Text="Update"
                                        OnClick="btnUpdateContacts_click" />
                                </div>
                            </fieldset>
                            <fieldset class="step">
                                <div class="tab-title">
                                    Children Info</div>
                                <asp:HiddenField ID="hdnChildrenInfoID" runat="server" Value="" />
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Children Name:</label>
                                    <span style="display: inline;">
                                        <asp:TextBox ID="txtChildrenInfoName" class="txt medium-input" runat="server" Text="">
                                        </asp:TextBox></span>
                                </div>
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Children Date Of Birth:</label>
                                    <span style="display: inline;">
                                        <asp:TextBox ID="txtChildrenDateOfBirth" class="txt medium-input" runat="server"
                                            Text="">
                                        </asp:TextBox></span>
                                    <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="CalendarExtender1" runat="server"
                                        TargetControlID="txtChildrenDateOfBirth">
                                    </ajaxToolkit:CalendarExtender>
                                </div>
                                <div style="margin: 4px 0 12px 0; width: 100%; float: left;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Sex:</label>
                                    <div style="float: left; width: 570px;">
                                        <span style="float: left; margin-left: 90px;">
                                            <asp:DropDownList ID="ddlSex" CssClass="cssSexList" runat="server">
                                                <asp:ListItem Value="M">Male</asp:ListItem>
                                                <asp:ListItem Value="F">Female</asp:ListItem>
                                            </asp:DropDownList>
                                        </span>
                                    </div>
                                </div>
                                <div style="margin: 4px 0 12px 0; width: 98%; float: left;">
                                    <div style="width: 480px; float: right;">
                                        <asp:Label ID="lblMsg" CssClass="msgClass" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div style="margin: 4px 0;">
                                    <asp:Button ID="btnAddChildrenInfo" class="button button-blue" runat="server" Text="Add"
                                        OnClick="btnAddChildrenInfo_Click" />
                                    <%--<asp:Button ID="btnUpdateChildrenInfo" runat="server" Text="Update" OnClick="btnUpdateChildrenInfo_click" />--%>
                                </div>
                                <div style="margin: 4px 0;">
                                    <div class="tab-title">
                                        View Children Info</div>
                                </div>
                                <div style="margin: 4px 0; overflow: hidden; width: 100%;">
                                    <div style="width: 100%; display: block;">
                                        <div style="width: 98%; overflow: hidden; margin: 0 auto;">
                                            <asp:GridView ID="gvHR_ChildrenInfo" Width="100%" class="gridCss" runat="server"
                                                AutoGenerateColumns="false" CssClass="tabel_input">
                                                <HeaderStyle CssClass="heading" />
                                                <RowStyle CssClass="row" />
                                                <AlternatingRowStyle CssClass="altrow" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Children Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblChildrenName" runat="server" Text='<%#Eval("ChildrenInfoName") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="children Date Of Birth">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblchildrenDateOfBirth" runat="server" Text='<%#Eval("childrenDateOfBirth") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="sex">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblsex" runat="server" Text='<%#Eval("sex") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <asp:ImageButton runat="server" CommandName="EditChildren" ID="lblSelectChildren"
                                                                CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' AlternateText="Edit"
                                                                OnClick="lblSelectChildren_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:ImageButton runat="server" CommandName="DeleteChildren" ID="lblChildrenDelete"
                                                                CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' OnClick="lblChildrenDelete_Click"
                                                                AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </fieldset>
                            <fieldset class="step">
                                <div class="tab-title">
                                    Job Experience</div>
                                <asp:HiddenField ID="hdnJobExperienceID" runat="server" Value="" />
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Organization:</label>
                                    <span style="display: inline;">
                                        <asp:TextBox ID="txtOrganization" class="txt medium-input" runat="server" Text="">
                                        </asp:TextBox></span>
                                </div>
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Position:</label>
                                    <span style="display: inline;">
                                        <asp:TextBox ID="txtPosition" class="txt medium-input" runat="server" Text="">
                                        </asp:TextBox></span>
                                </div>
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Year Start:</label>
                                    <span style="display: inline;">
                                        <asp:TextBox ID="txtYearStart" class="txt medium-input" runat="server" Text="">
                                        </asp:TextBox></span>
                                    <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="CalendarExtender2" runat="server"
                                        TargetControlID="txtYearStart">
                                    </ajaxToolkit:CalendarExtender>
                                </div>
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Year End:</label>
                                    <span style="display: inline;">
                                        <asp:TextBox ID="txtYearEnd" class="txt medium-input" runat="server" Text="">
                                        </asp:TextBox></span>
                                    <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="CalendarExtender3" runat="server"
                                        TargetControlID="txtYearEnd">
                                    </ajaxToolkit:CalendarExtender>
                                </div>
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Reason For Leaving:</label>
                                    <span style="display: inline;">
                                        <asp:TextBox ID="txtReasonForLeaving" class="txt medium-input" runat="server" Text="">
                                        </asp:TextBox></span>
                                </div>
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Contact Person:</label>
                                    <span style="display: inline;">
                                        <asp:TextBox ID="txtContactPerson" class="txt medium-input" runat="server" Text="">
                                        </asp:TextBox></span>
                                </div>
                                <div style="margin: 4px 0 8px 0; width: 98%; float: left;">
                                    <div style="width: 480px; float: right;">
                                        <asp:Label ID="lblJobExperienceMsg" CssClass="msgClass" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div style="margin: 4px 0;">
                                    <asp:Button ID="btnAddJobExperience" class="button button-blue" runat="server" Text="Add"
                                        OnClick="btnAddJobExperience_Click" />
                                    <%--<asp:Button ID="btnUpdateJobExperience" runat="server" Text="Update" OnClick="btnUpdateJobExperience_Click" />--%>
                                </div>
                                <div style="margin: 4px 0;">
                                    <div class="tab-title">
                                        Job Experience Info</div>
                                </div>
                                <div style="margin: 4px 0; overflow: hidden; width: 100%;">
                                    <div style="width: 100%; display: block;">
                                        <div style="width: 98%; overflow: hidden; margin: 0 auto;">
                                            <asp:GridView ID="gvHR_JobExperience" Width="100%" class="gridCss" runat="server"
                                                AutoGenerateColumns="false" CssClass="tabel_input">
                                                <HeaderStyle CssClass="heading" />
                                                <RowStyle CssClass="row" />
                                                <AlternatingRowStyle CssClass="altrow" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Organization Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblOrganizationName" runat="server" Text='<%#Eval("organizationName") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Position">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPosition" runat="server" Text='<%#Eval("designation") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Year Start">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblYearStart" runat="server" Text='<%#Eval("dateStart").Equals(DateTime.MinValue) ? "" : Eval("dateStart","{0:dd-MMM-yyyy}")%>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Year End">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblYearEnd" runat="server" Text='<%#Eval("dateEnds").Equals(DateTime.MinValue) ? "" : Eval("dateEnds","{0:dd-MMM-yyyy}")%>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Reason For Leaving">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblReasonForLeaving" runat="server" Text='<%#Eval("reasionForLeaving") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Contact Person">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblContactPerson" runat="server" Text='<%#Eval("contact") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <asp:ImageButton runat="server" ID="lblSelectJobExperience" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'
                                                                AlternateText="Edit" OnClick="lblSelectJobExperience_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:ImageButton runat="server" ID="lblDeleteJobExperience" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'
                                                                OnClick="lblDeleteJobExperience_Click" AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </fieldset>
                            <%--<fieldset class="step">
                                <div class="tab-title">
                                    Job Posting</div>
                                <asp:HiddenField ID="hdnJobPostingID" runat="server" Value="" />
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Department:</label>
                                    <div style="float: left; width: 570px;">
                                        <span style="float: left; margin-left: 90px;">
                                            <asp:DropDownList ID="ddlDepartmentID" runat="server">
                                            </asp:DropDownList>
                                        </span>
                                    </div>
                                </div>
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Designation:</label>
                                    <div style="float: left; width: 570px;">
                                        <span style="float: left; margin-left: 90px;">
                                            <asp:DropDownList ID="ddlDesignation1ID" runat="server">
                                            </asp:DropDownList>
                                        </span>
                                    </div>
                                </div>
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Join Date:</label>
                                    <span style="display: inline;">
                                        <asp:TextBox ID="txtJoinDate" class="txt medium-input" runat="server" Text="">
                                        </asp:TextBox></span>
                                    <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="CalendarExtender4" runat="server" TargetControlID="txtJoinDate">
                                    </ajaxToolkit:CalendarExtender>
                                </div>
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        End Date:</label>
                                    <span style="display: inline;">
                                        <asp:TextBox ID="txtEndDate" class="txt medium-input" runat="server" Text="">
                                        </asp:TextBox></span>
                                    <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="CalendarExtender5" runat="server" TargetControlID="txtEndDate">
                                    </ajaxToolkit:CalendarExtender>
                                </div>
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Posting Status:</label>
                                    <span style="display: inline;">
                                        <asp:TextBox ID="txtPostingStatus" class="txt medium-input" runat="server" Text="">
                                        </asp:TextBox></span>
                                </div>
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Job Location:</label>
                                    <span style="display: inline;">
                                        <asp:TextBox ID="txtJobLocation" class="txt medium-input" runat="server" Text="">
                                        </asp:TextBox></span>
                                </div>
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Supervisor:</label>
                                    <div style="float: left; width: 570px;">
                                        <span style="float: left; margin-left: 90px;">
                                            <asp:DropDownList ID="ddlSupervisorID" runat="server">
                                            </asp:DropDownList>
                                        </span>
                                    </div>
                                </div>
                                <div style="margin: 4px 0 8px 0; width: 98%; float: left;">
                                    <div style="width: 480px; float: right;">
                                        <asp:Label ID="lblJobpostingMsg" CssClass="msgClass" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div style="margin: 4px 0; display: block;">
                                    <asp:Button ID="btnAddJobPosting" runat="server" Text="Add" OnClick="btnAddJobPosting_Click" />
                                    <asp:Button ID="btnUpdateJobPosting" runat="server" Text="Update" OnClick="btnUpdateJobPosting_Click" />
                                </div>
                            </fieldset>--%>
                            <fieldset class="step">
                                <div class="tab-title">
                                    Attendence Rules</div>
                                <asp:HiddenField runat="server" ID="hdnAttendanceRulesID" Value="" />
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Rules:</label>
                                    <span style="display: inline;">
                                        <asp:TextBox ID="txtRules" class="txt medium-input" runat="server" Text="">
                                        </asp:TextBox></span>
                                </div>
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Time:</label>
                                    <div style="float: left; width: 570px;">
                                        <span style="float: left; margin-left: 90px;">
                                            <asp:DropDownList ID="ddlTime" runat="server">
                                                <asp:ListItem>00</asp:ListItem>
                                                <asp:ListItem>05</asp:ListItem>
                                                <asp:ListItem>10</asp:ListItem>
                                                <asp:ListItem>15</asp:ListItem>
                                                <asp:ListItem>20</asp:ListItem>
                                                <asp:ListItem>25</asp:ListItem>
                                                <asp:ListItem>30</asp:ListItem>
                                                <asp:ListItem>35</asp:ListItem>
                                                <asp:ListItem>40</asp:ListItem>
                                                <asp:ListItem>45</asp:ListItem>
                                                <asp:ListItem>50</asp:ListItem>
                                                <asp:ListItem>55</asp:ListItem>
                                            </asp:DropDownList>
                                            &nbsp;Min </span>
                                    </div>
                                </div>
                                <div style="margin: 4px 0 8px 0; width: 98%; float: left;">
                                    <div style="width: 480px; float: right;">
                                        <asp:Label ID="lblAttendendRulesMsg" CssClass="msgClass" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div style="margin: 4px 0 4px 350px; float: left;">
                                    <asp:Button ID="btnAddAttendenceRules" class="button button-blue" runat="server"
                                        Text="Add" OnClick="btnAddAttendenceRules_Click" />
                                    <asp:Button ID="btnUpdateAttendenceRules" class="button button-blue" runat="server"
                                        Text="Update" OnClick="btnUpdateAttendenceRules_Click" />
                                </div>
                            </fieldset>
                            <fieldset class="step">
                                <div class="tab-title">
                                    Working Days Shifting</div>
                                <asp:HiddenField ID="hdnWorkingDaysShiftingID" runat="server" Value="" />
                                <div style="float: left; width: 100%;">
                                    <div style="width: 80%; overflow: hidden; margin: 4px 0 10px 116px; display: none;">
                                        <table>
                                            <colgroup>
                                                <col width="15%" />
                                                <col width="15%" />
                                                <col width="15%" />
                                                <col width="15%" />
                                                <col width="15%" />
                                                <col width="15%" />
                                                <col width="15%" />
                                            </colgroup>
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox runat="server" ID="chkSaturday" Text="Saturday" />
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox runat="server" ID="chkSunday" Text="Sunday" />
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox runat="server" ID="chkMonday" Text="Monday" />
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox runat="server" ID="chkTuesday" Text="Tuesday" />
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox runat="server" ID="chkWednesday" Text="Wednesday" />
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox runat="server" ID="chkThrusday" Text="Thrusday" />
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox runat="server" ID="chkFriday" Text="Friday" />
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                    <div style="margin: 4px 0; display: none;">
                                        <label style="width: 220px; float: left; text-align: right;">
                                            Shift Start Time:</label>
                                        <div style="width: 420px; float: left; margin: 4px 0 4px 85px;">
                                            <span style="float: left; width: 50px; height: 20px;">
                                                <asp:DropDownList ID="ddltime_hoursStart" CssClass="cssSexList" runat="server">
                                                    <%--onselectedindexchanged="ddltime_hoursStart_SelectedIndexChanged"--%>
                                                    <asp:ListItem>00</asp:ListItem>
                                                    <asp:ListItem>01</asp:ListItem>
                                                    <asp:ListItem>02</asp:ListItem>
                                                    <asp:ListItem>03</asp:ListItem>
                                                    <asp:ListItem>04</asp:ListItem>
                                                    <asp:ListItem>05</asp:ListItem>
                                                    <asp:ListItem>06</asp:ListItem>
                                                    <asp:ListItem>07</asp:ListItem>
                                                    <asp:ListItem>08</asp:ListItem>
                                                    <asp:ListItem>09</asp:ListItem>
                                                    <asp:ListItem>10</asp:ListItem>
                                                    <asp:ListItem>11</asp:ListItem>
                                                    <asp:ListItem>12</asp:ListItem>
                                                    <asp:ListItem>13</asp:ListItem>
                                                    <asp:ListItem>14</asp:ListItem>
                                                    <asp:ListItem>15</asp:ListItem>
                                                    <asp:ListItem>16</asp:ListItem>
                                                    <asp:ListItem>17</asp:ListItem>
                                                    <asp:ListItem>18</asp:ListItem>
                                                    <asp:ListItem>19</asp:ListItem>
                                                    <asp:ListItem>20</asp:ListItem>
                                                    <asp:ListItem>21</asp:ListItem>
                                                    <asp:ListItem>22</asp:ListItem>
                                                    <asp:ListItem>23</asp:ListItem>
                                                </asp:DropDownList>
                                            </span><span style="float: left; width: 50px; height: 20px;">
                                                <asp:DropDownList ID="ddltime_minstart" CssClass="cssSexList" runat="server">
                                                    <asp:ListItem>00</asp:ListItem>
                                                    <asp:ListItem>05</asp:ListItem>
                                                    <asp:ListItem>10</asp:ListItem>
                                                    <asp:ListItem>15</asp:ListItem>
                                                    <asp:ListItem>20</asp:ListItem>
                                                    <asp:ListItem>25</asp:ListItem>
                                                    <asp:ListItem>30</asp:ListItem>
                                                    <asp:ListItem>35</asp:ListItem>
                                                    <asp:ListItem>40</asp:ListItem>
                                                    <asp:ListItem>45</asp:ListItem>
                                                    <asp:ListItem>50</asp:ListItem>
                                                    <asp:ListItem>55</asp:ListItem>
                                                </asp:DropDownList>
                                            </span>
                                        </div>
                                    </div>
                                    <div style="margin: 4px 0; display: none;">
                                        <label style="width: 220px; float: left; text-align: right;">
                                            Shift End Time:</label>
                                        <div style="width: 420px; float: left; margin: 4px 0 4px 85px;">
                                            <span style="float: left; width: 50px; height: 20px;">
                                                <asp:DropDownList ID="ddltime_hoursEnd" CssClass="cssSexList" runat="server">
                                                    <asp:ListItem>00</asp:ListItem>
                                                    <asp:ListItem>01</asp:ListItem>
                                                    <asp:ListItem>02</asp:ListItem>
                                                    <asp:ListItem>03</asp:ListItem>
                                                    <asp:ListItem>04</asp:ListItem>
                                                    <asp:ListItem>05</asp:ListItem>
                                                    <asp:ListItem>06</asp:ListItem>
                                                    <asp:ListItem>07</asp:ListItem>
                                                    <asp:ListItem>08</asp:ListItem>
                                                    <asp:ListItem>09</asp:ListItem>
                                                    <asp:ListItem>10</asp:ListItem>
                                                    <asp:ListItem>11</asp:ListItem>
                                                    <asp:ListItem>12</asp:ListItem>
                                                    <asp:ListItem>13</asp:ListItem>
                                                    <asp:ListItem>14</asp:ListItem>
                                                    <asp:ListItem>15</asp:ListItem>
                                                    <asp:ListItem>16</asp:ListItem>
                                                    <asp:ListItem>17</asp:ListItem>
                                                    <asp:ListItem>18</asp:ListItem>
                                                    <asp:ListItem>19</asp:ListItem>
                                                    <asp:ListItem>20</asp:ListItem>
                                                    <asp:ListItem>21</asp:ListItem>
                                                    <asp:ListItem>22</asp:ListItem>
                                                    <asp:ListItem>23</asp:ListItem>
                                                </asp:DropDownList>
                                            </span><span style="float: left; width: 50px; height: 20px;">
                                                <asp:DropDownList ID="ddltime_minEnd" CssClass="cssSexList" runat="server">
                                                    <asp:ListItem>00</asp:ListItem>
                                                    <asp:ListItem>05</asp:ListItem>
                                                    <asp:ListItem>10</asp:ListItem>
                                                    <asp:ListItem>15</asp:ListItem>
                                                    <asp:ListItem>20</asp:ListItem>
                                                    <asp:ListItem>25</asp:ListItem>
                                                    <asp:ListItem>30</asp:ListItem>
                                                    <asp:ListItem>35</asp:ListItem>
                                                    <asp:ListItem>40</asp:ListItem>
                                                    <asp:ListItem>45</asp:ListItem>
                                                    <asp:ListItem>50</asp:ListItem>
                                                    <asp:ListItem>55</asp:ListItem>
                                                </asp:DropDownList>
                                            </span>
                                        </div>
                                    </div>
                                    <div style="margin: 4px 0; display: none;">
                                        <label style="width: 220px; float: left; text-align: right;">
                                            Description:</label>
                                        <span style="display: inline;">
                                            <asp:TextBox ID="txtDescription" class="txt medium-input" runat="server" Text=""
                                                TextMode="MultiLine">
                                            </asp:TextBox></span>
                                    </div>
                                    <div style="margin: 4px 0 8px 0; width: 98%; float: left; display: none;">
                                        <div style="width: 480px; float: right;">
                                            <asp:Label ID="lblDaysShiftingMessage" CssClass="msgClass" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <div style="margin: 4px 0; display: none;">
                                        <asp:Button ID="btnAddWorkingDaysShifting" class="button button-blue" runat="server"
                                            Text="Add" OnClick="btnAddWorkingDaysShifting_Click" />
                                        <asp:Button ID="btnUpdateWorkingDaysShifting" class="button button-blue" runat="server"
                                            Text="Update" OnClick="btnUpdateWorkingDaysShifting_Click" />
                                    </div>
                                </div>
                            </fieldset>
                            <fieldset class="step">
                                <div class="tab-title">
                                    Bank Info</div>
                                <asp:HiddenField ID="hdnBankID" runat="server" Value="" />
                                <%--<div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Employee:</label>
                                    <div style="float: left; width: 570px;">
                                        <span style="float: left; margin-left: 90px; margin-bottom: 10px;">
                                            <asp:DropDownList ID="ddlEmployeeID" runat="server">
                                            </asp:DropDownList>
                                        </span>
                                    </div>
                                </div>--%>
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Bank Account Name:</label>
                                    <span style="display: inline;">
                                        <asp:TextBox ID="txtBankAccountName" class="txt medium-input" runat="server" Text="">
                                        </asp:TextBox></span>
                                </div>
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Bank Account No:</label>
                                    <span style="display: inline;">
                                        <asp:TextBox ID="txtBankAccountNo" class="txt medium-input" runat="server" Text="">
                                        </asp:TextBox></span>
                                </div>
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Bank Name:</label>
                                    <span style="display: inline;">
                                        <asp:TextBox ID="txtBankName" class="txt medium-input" runat="server" Text="">
                                        </asp:TextBox></span>
                                </div>
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Bank Address:</label>
                                    <span style="display: inline;">
                                        <asp:TextBox ID="txtBankAddress" class="txt medium-input" runat="server" Text="">
                                        </asp:TextBox></span>
                                </div>
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Bank Telephone:</label>
                                    <span style="display: inline;">
                                        <asp:TextBox ID="txtBankTelephone" class="txt medium-input" runat="server" Text="">
                                        </asp:TextBox></span>
                                </div>
                                <div style="margin: 4px 0 8px 0; width: 98%; float: left;">
                                    <div style="width: 480px; float: right;">
                                        <asp:Label ID="lblBankMsg" CssClass="msgClass" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div style="margin: 4px 0; display: block;">
                                    <asp:Button ID="btnAddBank" class="button button-blue" runat="server" Text="Add"
                                        OnClick="btnAddBank_Click" />
                                    <asp:Button ID="btnUpdateBank" class="button button-blue" runat="server" Text="Update"
                                        OnClick="btnUpdateBank_Click" />
                                </div>
                            </fieldset>
                            <fieldset class="step">
                                <div class="tab-title">
                                    Educational Background</div>
                                <asp:HiddenField ID="hdnEducationBackground" runat="server" Value="" />
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Year:</label>
                                    <span style="display: inline;">
                                        <asp:TextBox ID="txtYear" class="txt medium-input" runat="server" Text="">
                                        </asp:TextBox></span>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="ftbeEducationYear" runat="server" FilterMode="ValidChars"
                                        FilterType="Numbers" ValidChars="0123456789" TargetControlID="txtYear">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                    <%--<ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="CalendarExtender6" runat="server" TargetControlID="txtYear">
                                    </ajaxToolkit:CalendarExtender>--%>
                                </div>
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Board/University:</label>
                                    <span style="display: inline;">
                                        <asp:TextBox ID="txtBoardUniversity" class="txt medium-input" runat="server" Text="">
                                        </asp:TextBox></span>
                                </div>
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Education Group:</label>
                                    <span style="display: inline;">
                                        <asp:TextBox ID="txtEducationGroup" class="txt medium-input" runat="server" Text="">
                                        </asp:TextBox></span>
                                </div>
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Major:</label>
                                    <span style="display: inline;">
                                        <asp:TextBox ID="txtMajor" class="txt medium-input" runat="server" Text="">
                                        </asp:TextBox></span>
                                </div>
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Result System:</label>
                                    <div style="float: left; width: 570px;">
                                        <span style="float: left; margin-left: 90px; margin-bottom: 5px;">
                                            <asp:DropDownList ID="ddlReaultSystemID" runat="server">
                                                <asp:ListItem Value="1">Grading Sytem</asp:ListItem>
                                                <asp:ListItem Value="2">Division System</asp:ListItem>
                                            </asp:DropDownList>
                                        </span>
                                    </div>
                                </div>
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Degree:</label>
                                    <span style="display: inline;">
                                        <asp:TextBox ID="txtDegree" class="txt medium-input" runat="server" Text="">
                                        </asp:TextBox></span>
                                </div>
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Result:</label>
                                    <span style="display: inline;">
                                        <asp:TextBox ID="txtResult" class="txt medium-input" runat="server" Text="">
                                        </asp:TextBox></span>
                                </div>
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Score:</label>
                                    <span style="display: inline;">
                                        <asp:TextBox ID="txtScore" class="txt medium-input" runat="server" Text="">
                                        </asp:TextBox></span>
                                </div>
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Out Of:</label>
                                    <span style="display: inline;">
                                        <asp:TextBox ID="txtOutOf" class="txt medium-input" runat="server" Text="">
                                        </asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                            FilterMode="ValidChars" ValidChars="0123456789" TargetControlID="txtOutOf">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </span>
                                </div>
                                <div style="margin: 4px 0 8px 0; width: 98%; float: left;">
                                    <div style="width: 480px; float: right;">
                                        <asp:Label ID="lblEducationalMsg" CssClass="msgClass" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div style="margin: 4px 0; display: block;">
                                    <asp:Button ID="btnAddEducationalBackground" class="button button-blue" runat="server"
                                        Text="Add" OnClick="btnAddEducationalBackground_Click" />
                                    <%--<asp:Button ID="btnUpdateEducationalBackground" runat="server" Text="Update" OnClick="btnUpdateEducationalBackground_Click" />--%>
                                </div>
                                <div style="margin: 4px 0;">
                                    <div class="tab-title">
                                        Educational Background Info</div>
                                </div>
                                <div style="margin: 4px 0; overflow: hidden; width: 100%;">
                                    <div style="width: 100%; display: block;">
                                        <div style="width: 98%; overflow: hidden; margin: 0 auto;">
                                            <asp:GridView ID="gv_educationalBackground" Width="100%" class="gridCss" runat="server"
                                                AutoGenerateColumns="false" CssClass="tabel_input">
                                                <HeaderStyle CssClass="heading" />
                                                <RowStyle CssClass="row" />
                                                <AlternatingRowStyle CssClass="altrow" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Year">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblYear" runat="server" Text='<%#Eval("year") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Board/University">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblBoardUniversity" runat="server" Text='<%#Eval("boardUniversity") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Education Group">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEducationGroup" runat="server" Text='<%#Eval("educationGroup") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Major">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblMajor" runat="server" Text='<%#Eval("major") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Reasult System">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblResultSystem" runat="server" Text='<%#Eval("reaultSystemID") =="1"? "Grading":"Division" %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Degree">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDegree" runat="server" Text='<%#Eval("degree") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Result">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblResult" runat="server" Text='<%#Eval("result") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Score">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblScore" runat="server" Text='<%#Eval("score") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Out Of">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbloutOf" runat="server" Text='<%#Eval("outOf") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Update">
                                                        <ItemTemplate>
                                                            <asp:ImageButton runat="server" ID="lblSelectEducational" CommandArgument='<%#((GridViewRow) Container).RowIndex %>'
                                                                AlternateText="Edit" OnClick="lblSelectEducational_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:ImageButton runat="server" ID="lblDeleteEducational" CommandArgument='<%#((GridViewRow) Container).RowIndex %>'
                                                                OnClick="lblDeleteEducational_Click" AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </fieldset>
                            <fieldset class="step">
                                <div class="tab-title">
                                    Employee Salary</div>
                                <asp:HiddenField runat="server" ID="hdnEmployeeSalaryID" Value="" />
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        <span id="empSalary"><span class="style11">*</span>Select Types</span></label>
                                    <span style="float: left; width: 480px; margin-left: 90px;">
                                        <asp:RadioButtonList ID="radIsGross" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="Basic">Basic</asp:ListItem>
                                            <asp:ListItem Value="Gross">Gross</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </span>
                                </div>
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Amount</label>
                                    <span style="display: inline;">
                                        <asp:TextBox ID="txtAmount" class="txt medium-input" runat="server" Text="" OnTextChanged="txtAmount_TextChanged"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                            FilterMode="ValidChars" ValidChars="0123456789." TargetControlID="txtAmount">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </span>
                                </div>
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        <span id="Span1"><span class="style11">*</span>Select Rules</span></label>
                                    <span style="float: left; width: 480px; margin-left: 90px;">
                                        <asp:RadioButtonList ID="radSalaryRules" runat="server" RepeatDirection="Horizontal"
                                            AutoPostBack="True" OnSelectedIndexChanged="radSalaryRules_SelectedIndexChanged">
                                            <asp:ListItem Value="True" Selected="True">Custom</asp:ListItem>
                                            <asp:ListItem Value="False">Package</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </span>
                                </div>
                                <div style="margin: 4px 0;">
                                    <div style="width: 790px; float: left;">
                                        <div style="width: 480px; float: left; margin-left: 310px; text-align: left;">
                                            <asp:DropDownList ID="ddlPackage" Visible="false" runat="server" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlPackage_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div style="margin: 4px 0; overflow: hidden; width: 100%;">
                                    <div style="width: 100%; display: block;">
                                        <div style="width: 95%; margin: 0 auto;" runat="server" id="div1" visible="true">
                                            <asp:GridView ID="gridViewPackageAndPackageRules" Width="100%" class="gridCss" runat="server"
                                                AutoGenerateColumns="false" CssClass="tabel_input">
                                                <HeaderStyle CssClass="heading" />
                                                <RowStyle CssClass="row" />
                                                <AlternatingRowStyle CssClass="altrow" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkPackageRulesID" runat="server"></asp:CheckBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Package Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPackageRulesID" runat="server" Text='<%#Eval("PackageRulesID") %>'
                                                                Visible="false">
                                                            </asp:Label>
                                                            <asp:Label ID="lblPackageName" runat="server" Text='<%#Eval("PackageName") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Package Rules Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPackageRulesName" runat="server" Text='<%#Eval("PackageRulesName") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Rules Value">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRulesValue" runat="server" Text='<%#Eval("RulesValue") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Rules Operator">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRulesOperator" runat="server" Text='<%#Eval("RulesOperator") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                                <div style="margin: 4px 0;">
                                    <div class="tab-title">
                                        Salary Rules</div>
                                </div>
                                <div style="margin: 4px 0; overflow: hidden; width: 100%;">
                                    <div style="width: 100%; display: block;">
                                        <div style="width: 740px; float: left; margin-left: 20px;">
                                            <asp:GridView ID="gvHR_PackageRules" Width="100%" class="gridCss" runat="server"
                                                AutoGenerateColumns="false" CssClass="tabel_input">
                                                <HeaderStyle CssClass="heading" />
                                                <RowStyle CssClass="row" />
                                                <AlternatingRowStyle CssClass="altrow" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Rules Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPackageRulesID" runat="server" Text='<%#Eval("PackageRulesID") %>'
                                                                Visible="false">
                                                            </asp:Label>
                                                            <asp:Label ID="lblPackageRulesName" runat="server" Text='<%#Eval("PackageRulesName") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Value">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRulesValue" runat="server" Text='<%#Eval("RulesValue") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Formula">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRulesOperator" runat="server" Text='<%#Eval("RulesOperator") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        <div style="margin: 4px 0 8px 0; width: 98%; float: left;">
                                            <div style="width: 480px; float: right;">
                                                <asp:Label ID="lblSalaryMsg" CssClass="msgClass" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div style="margin: 4px 0 4px 0; width: 790px; float: left;">
                                            <asp:Button ID="btnSaveEmployeeSalary" class="button button-blue" runat="server"
                                                Text="Save" OnClick="btnSaveEmployeeSalary_Click" />
                                            <asp:Button ID="btnUpdateEmployeeSalary" class="button button-blue" runat="server"
                                                Text="Update" Visible="false" OnClick="btnUpdateEmployeeSalary_Click" />
                                        </div>
                                    </div>
                                </div>
                            </fieldset>
                            <fieldset class="step">
                                <div class="tab-title">
                                    Lunch Rule
                                </div>
                                <asp:HiddenField ID="hdnLunchRuleID" runat="server" Value="" />
                                <div style="float: left; width: 100%;">
                                    <div style="margin: 4px 0;">
                                        <label style="width: 220px; float: left; text-align: right;">
                                            Lunch Time Start:</label>
                                        <div style="width: 420px; float: left; margin: 4px 0 4px 85px;">
                                            <span style="float: left; width: 50px; height: 20px;">
                                                <asp:DropDownList ID="ddlLunchTimeStartHour" CssClass="cssSexList" runat="server">
                                                    <%--onselectedindexchanged="ddltime_hoursStart_SelectedIndexChanged"--%>
                                                    <asp:ListItem>00</asp:ListItem>
                                                    <asp:ListItem>01</asp:ListItem>
                                                    <asp:ListItem>02</asp:ListItem>
                                                    <asp:ListItem>03</asp:ListItem>
                                                    <asp:ListItem>04</asp:ListItem>
                                                    <asp:ListItem>05</asp:ListItem>
                                                    <asp:ListItem>06</asp:ListItem>
                                                    <asp:ListItem>07</asp:ListItem>
                                                    <asp:ListItem>08</asp:ListItem>
                                                    <asp:ListItem>09</asp:ListItem>
                                                    <asp:ListItem>10</asp:ListItem>
                                                    <asp:ListItem>11</asp:ListItem>
                                                    <asp:ListItem>12</asp:ListItem>
                                                    <asp:ListItem>13</asp:ListItem>
                                                    <asp:ListItem>14</asp:ListItem>
                                                    <asp:ListItem>15</asp:ListItem>
                                                    <asp:ListItem>16</asp:ListItem>
                                                    <asp:ListItem>17</asp:ListItem>
                                                    <asp:ListItem>18</asp:ListItem>
                                                    <asp:ListItem>19</asp:ListItem>
                                                    <asp:ListItem>20</asp:ListItem>
                                                    <asp:ListItem>21</asp:ListItem>
                                                    <asp:ListItem>22</asp:ListItem>
                                                    <asp:ListItem>23</asp:ListItem>
                                                </asp:DropDownList>
                                            </span><span style="float: left; width: 50px; height: 20px;">
                                                <asp:DropDownList ID="ddlLunchTimeStartMinute" CssClass="cssSexList" runat="server">
                                                    <asp:ListItem>00</asp:ListItem>
                                                    <asp:ListItem>05</asp:ListItem>
                                                    <asp:ListItem>10</asp:ListItem>
                                                    <asp:ListItem>15</asp:ListItem>
                                                    <asp:ListItem>20</asp:ListItem>
                                                    <asp:ListItem>25</asp:ListItem>
                                                    <asp:ListItem>30</asp:ListItem>
                                                    <asp:ListItem>35</asp:ListItem>
                                                    <asp:ListItem>40</asp:ListItem>
                                                    <asp:ListItem>45</asp:ListItem>
                                                    <asp:ListItem>50</asp:ListItem>
                                                    <asp:ListItem>55</asp:ListItem>
                                                </asp:DropDownList>
                                            </span>
                                        </div>
                                    </div>
                                    <div style="margin: 4px 0;">
                                        <label style="width: 220px; float: left; text-align: right;">
                                            Lunch Time End:</label>
                                        <div style="width: 420px; float: left; margin: 4px 0 4px 85px;">
                                            <span style="float: left; width: 50px; height: 20px;">
                                                <asp:DropDownList ID="ddlLunchTimeEndHour" CssClass="cssSexList" runat="server">
                                                    <%--onselectedindexchanged="ddltime_hoursStart_SelectedIndexChanged"--%>
                                                    <asp:ListItem>00</asp:ListItem>
                                                    <asp:ListItem>01</asp:ListItem>
                                                    <asp:ListItem>02</asp:ListItem>
                                                    <asp:ListItem>03</asp:ListItem>
                                                    <asp:ListItem>04</asp:ListItem>
                                                    <asp:ListItem>05</asp:ListItem>
                                                    <asp:ListItem>06</asp:ListItem>
                                                    <asp:ListItem>07</asp:ListItem>
                                                    <asp:ListItem>08</asp:ListItem>
                                                    <asp:ListItem>09</asp:ListItem>
                                                    <asp:ListItem>10</asp:ListItem>
                                                    <asp:ListItem>11</asp:ListItem>
                                                    <asp:ListItem>12</asp:ListItem>
                                                    <asp:ListItem>13</asp:ListItem>
                                                    <asp:ListItem>14</asp:ListItem>
                                                    <asp:ListItem>15</asp:ListItem>
                                                    <asp:ListItem>16</asp:ListItem>
                                                    <asp:ListItem>17</asp:ListItem>
                                                    <asp:ListItem>18</asp:ListItem>
                                                    <asp:ListItem>19</asp:ListItem>
                                                    <asp:ListItem>20</asp:ListItem>
                                                    <asp:ListItem>21</asp:ListItem>
                                                    <asp:ListItem>22</asp:ListItem>
                                                    <asp:ListItem>23</asp:ListItem>
                                                </asp:DropDownList>
                                            </span><span style="float: left; width: 50px; height: 20px;">
                                                <asp:DropDownList ID="ddlLunchTimeEndMinute" CssClass="cssSexList" runat="server">
                                                    <asp:ListItem>00</asp:ListItem>
                                                    <asp:ListItem>05</asp:ListItem>
                                                    <asp:ListItem>10</asp:ListItem>
                                                    <asp:ListItem>15</asp:ListItem>
                                                    <asp:ListItem>20</asp:ListItem>
                                                    <asp:ListItem>25</asp:ListItem>
                                                    <asp:ListItem>30</asp:ListItem>
                                                    <asp:ListItem>35</asp:ListItem>
                                                    <asp:ListItem>40</asp:ListItem>
                                                    <asp:ListItem>45</asp:ListItem>
                                                    <asp:ListItem>50</asp:ListItem>
                                                    <asp:ListItem>55</asp:ListItem>
                                                </asp:DropDownList>
                                            </span>
                                        </div>
                                    </div>
                                    <div style="margin: 4px 0;">
                                        <label style="width: 220px; float: left; text-align: right;">
                                            Lunch Flexible Time Mins:</label>
                                        <div style="width: 420px; float: left; margin: 4px 0 4px 85px;">
                                            <%--<span style="float: left; width: 50px; height: 20px;">
                                                <asp:DropDownList ID="DropDownList1" CssClass="cssSexList" runat="server">
                                                    
                                                    <asp:ListItem>00</asp:ListItem>
                                                    <asp:ListItem>01</asp:ListItem>
                                                    <asp:ListItem>02</asp:ListItem>
                                                    <asp:ListItem>03</asp:ListItem>
                                                    <asp:ListItem>04</asp:ListItem>
                                                    <asp:ListItem>05</asp:ListItem>
                                                    <asp:ListItem>06</asp:ListItem>
                                                    <asp:ListItem>07</asp:ListItem>
                                                    <asp:ListItem>08</asp:ListItem>
                                                    <asp:ListItem>09</asp:ListItem>
                                                    <asp:ListItem>10</asp:ListItem>
                                                    <asp:ListItem>11</asp:ListItem>
                                                    <asp:ListItem>12</asp:ListItem>
                                                    <asp:ListItem>13</asp:ListItem>
                                                    <asp:ListItem>14</asp:ListItem>
                                                    <asp:ListItem>15</asp:ListItem>
                                                    <asp:ListItem>16</asp:ListItem>
                                                    <asp:ListItem>17</asp:ListItem>
                                                    <asp:ListItem>18</asp:ListItem>
                                                    <asp:ListItem>19</asp:ListItem>
                                                    <asp:ListItem>20</asp:ListItem>
                                                    <asp:ListItem>21</asp:ListItem>
                                                    <asp:ListItem>22</asp:ListItem>
                                                    <asp:ListItem>23</asp:ListItem>
                                                </asp:DropDownList>
                                            </span>--%>
                                            <span style="float: left; width: 50px; height: 20px;">
                                                <asp:DropDownList ID="ddlLunchFlexibleTimeMins" CssClass="cssSexList" runat="server">
                                                    <asp:ListItem>00</asp:ListItem>
                                                    <asp:ListItem>05</asp:ListItem>
                                                    <asp:ListItem>10</asp:ListItem>
                                                    <asp:ListItem>15</asp:ListItem>
                                                    <asp:ListItem>20</asp:ListItem>
                                                    <asp:ListItem>25</asp:ListItem>
                                                    <asp:ListItem>30</asp:ListItem>
                                                    <asp:ListItem>35</asp:ListItem>
                                                    <asp:ListItem>40</asp:ListItem>
                                                    <asp:ListItem>45</asp:ListItem>
                                                    <asp:ListItem>50</asp:ListItem>
                                                    <asp:ListItem>55</asp:ListItem>
                                                </asp:DropDownList>
                                            </span>
                                        </div>
                                    </div>
                                    <div style="margin: 4px 0;">
                                        <label style="width: 220px; float: left; text-align: right;">
                                            Lunch Flag:</label>
                                        <div style="width: 420px; float: left; margin: 4px 0 4px 85px;">
                                            <span style="display: inline;">
                                                <asp:RadioButtonList ID="radLunchFlag" runat="server" RepeatDirection="Horizontal"
                                                    TextAlign="Left">
                                                    <asp:ListItem Value="True">Allowed</asp:ListItem>
                                                    <asp:ListItem Value="False">Not Allowed</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </span>
                                        </div>
                                    </div>
                                    <div style="margin: 4px 0 8px 0; width: 98%; float: left;">
                                        <div style="width: 480px; float: right;">
                                            <asp:Label ID="lblLunchMsg" CssClass="msgClass" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <div style="margin: 4px 0 4px 0; width: 790px; float: left;">
                                        <asp:Button ID="btnAddLunchRule" class="button button-blue" runat="server" Text="Add"
                                            OnClick="btnAddLunchRule_Click" />
                                    </div>
                                </div>
                            </fieldset>
                            <fieldset class="step">
                                <div class="tab-title">
                                    Provident Fund Contribution</div>
                                <asp:HiddenField ID="hdnProvidentFundContributionID" runat="server" Value="" />
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Provident Fund percentage :</label>
                                    <div style="float: left; width: 570px;">
                                        <span style="float: left; margin-left: 90px; margin-bottom: 10px;">
                                            <asp:DropDownList ID="ddlProvidentfundPercentage" runat="server">
                                            </asp:DropDownList>
                                            or Security Money
                                            <asp:TextBox ID="txtSecurityMoney" class="txt small-input" Text="0" runat="server"></asp:TextBox>
                                        </span>
                                    </div>
                                </div>
                                <%--<asp:HiddenField runat="server" ID="HiddenField2" Value="" />--%>
                                <%--<div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Employee:</label>
                                    <div style="float: left; width: 570px;">
                                        <span style="float: left; margin-left: 90px; margin-bottom: 5px;">
                                            <asp:DropDownList ID="ddlProvidenedFundEmployeeID" runat="server">
                                            </asp:DropDownList>
                                        </span>
                                    </div>
                                </div>--%>
                                <div style="width: 99%; float: left; margin: 4px 0;">
                                    <div style="width: 95%; overflow: hidden; margin: 0 auto;">
                                    </div>
                                </div>
                                <div style="margin: 4px 0 8px 0; width: 98%; float: left;">
                                    <div style="width: 480px; float: right;">
                                        <asp:Label ID="lblProvidenedFundMsg" CssClass="msgClass" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div style="margin: 4px 0 4px 350px; float: left;">
                                    <asp:Button ID="btnAddProvidenedFund" class="button button-blue" runat="server" Text="Add"
                                        OnClick="btnAddProvidenedFund_Click" />
                                    <asp:Button ID="btnUpdateProvidenedFund" class="button button-blue" runat="server"
                                        Visible="false" Text="Update" OnClick="btnUpdateProvidenedFund_Click" />
                                </div>
                            </fieldset>
                            <fieldset class="step">
                                <div class="tab-title">
                                    Benefit Rules</div>
                                <%--<asp:HiddenField ID="HiddenField2" runat="server" Value="" />--%>
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Benefit Package Name:</label>
                                    <span style="display: inline;">
                                        <asp:DropDownList ID="ddlBenifitPackage" class="txt medium-input" runat="server"
                                            OnSelectedIndexChanged="ddlBenifitPackage_SelectedIndexChanged" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </span>
                                </div>
                                <div style="margin: 4px 0 8px 0; width: 98%; float: left;">
                                    <div style="width: 480px; float: right;">
                                        <asp:Label ID="lblBenifitMsg" CssClass="msgClass" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div style="margin: 4px 0;">
                                    <asp:Button ID="btnAddBenifitRules" class="button button-blue" runat="server" Text="Add"
                                        OnClick="btnAddBenifitRules_Click" />
                                    <%--<asp:Button ID="Button2" runat="server" Text="Update" />--%>
                                </div>
                                <div style="width: 99%; float: left; margin: 4px 0;">
                                    <div style="width: 95%; overflow: hidden; margin: 0 auto;">
                                        <asp:GridView ID="gvHR_BenefitPackage" Width="100%" class="gridCss" runat="server"
                                            AutoGenerateColumns="false" CssClass="tabel_input">
                                            <HeaderStyle CssClass="heading" />
                                            <RowStyle CssClass="row" />
                                            <AlternatingRowStyle CssClass="altrow" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Benefit Package Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBenefitPackageName" runat="server" Text='<%#Eval("BenifitPackageName") %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Benefit Times Year">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTaxPackageValue" runat="server" Text='<%#Eval("BenifitTimesYear") %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Benefit Formula">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBenefitFormula" runat="server" Text='<%#Eval("BebifitFormula") %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Is Respect to Gross">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblIsRespecttoGross" runat="server" Text='<%#Eval("isGrossBenifit") %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--<asp:TemplateField HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <asp:ImageButton runat="server"  CommandName ="EditChildren"  ID="lblSelectBenefit" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'
                                                                AlternateText="Edit" OnClick="lblSelectBenefit_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:ImageButton runat="server" CommandName="DeleteChildren" ID="lblDeleteBenefit"
                                                            CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' OnClick="lblDeleteBenefit_Click"
                                                            AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </fieldset>
                            <fieldset class="step">
                                <div class="tab-title">
                                    Salary Tax Package</div>
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Salary Tax Package:</label>
                                    <div style="float: left; width: 570px;">
                                        <span style="float: left; margin-left: 90px; margin-bottom: 10px;">
                                            <asp:DropDownList ID="ddlSalaryTaxPackageID" runat="server" OnSelectedIndexChanged="ddlSalaryTaxPackageID_SelectedIndexChanged"
                                                AutoPostBack="True">
                                            </asp:DropDownList>
                                        </span>
                                    </div>
                                </div>
                                <div style="margin: 4px 0 8px 0; width: 98%; float: left;">
                                    <div style="width: 480px; float: right;">
                                        <asp:Label ID="lblTaxRulesMsg" CssClass="msgClass" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div style="margin: 4px 0;">
                                    <asp:Button ID="btnAddSalaryTax" class="button button-blue" runat="server" Text="Add"
                                        OnClick="btnAddSalaryTax_Click" />
                                </div>
                                <div style="width: 99%; float: left; margin: 4px 0;">
                                    <div style="width: 95%; overflow: hidden; margin: 0 auto;">
                                        <asp:GridView ID="gvHR_SalaryTaxPackage" Width="100%" class="gridCss" runat="server"
                                            AutoGenerateColumns="false" CssClass="tabel_input">
                                            <HeaderStyle CssClass="heading" />
                                            <RowStyle CssClass="row" />
                                            <AlternatingRowStyle CssClass="altrow" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Salary Tax Package Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTaxPackageName" runat="server" Text='<%#Eval("SalaryTaxPackagePackageName") %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Salary Tax Package Value">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTaxPackageValue" runat="server" Text='<%#Eval("SalaryTaxPackageFormula") %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </fieldset>
                            <fieldset class="step">
                                <div class="tab-title">
                                    Salary Adjustment List Rules</div>
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Group Name:</label>
                                    <div style="float: left; width: 570px;">
                                        <span style="float: left; margin-left: 90px; margin-bottom: 10px;">
                                            <asp:DropDownList ID="ddlAdjustmentGroup" runat="server" OnSelectedIndexChanged="ddlAdjustmentGroup_SelectedIndexChanged"
                                                AutoPostBack="True">
                                            </asp:DropDownList>
                                        </span>
                                    </div>
                                </div>
                                <div style="width: 98%; float: left; margin: 4px 0;">
                                    <div style="width: 95%; overflow: hidden; margin: 0 auto;">
                                        <asp:GridView ID="gvHR_AdjustmentList" Width="100%" class="gridCss" runat="server"
                                            AutoGenerateColumns="false" CssClass="tabel_input">
                                            <HeaderStyle CssClass="heading" />
                                            <RowStyle CssClass="row" />
                                            <AlternatingRowStyle CssClass="altrow" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Adjustment Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAdjustmentName" runat="server" Text='<%#Eval("Name") %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Adjustment Value">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAdjustmentValue" runat="server" Text='<%#Eval("Value") %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                                <div style="margin: 4px 0 8px 0; width: 98%; float: left;">
                                    <div style="width: 480px; float: right;">
                                        <asp:Label ID="lblSalaryAdjustmentGroupMsg" CssClass="msgClass" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div style="margin: 4px 0;">
                                    <asp:Button ID="btnSalaryAdjustmentListRules" class="button button-blue" runat="server"
                                        Text="Add" OnClick="btnSalaryAdjustmentListRules_Click" />
                                </div>
                            </fieldset>
                            <fieldset class="step">
                                <div class="tab-title">
                                    Salary Increment Rules</div>
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Salary Increment Package:</label>
                                    <div style="float: left; width: 570px;">
                                        <span style="float: left; margin-left: 90px; margin-bottom: 5px;">
                                            <asp:DropDownList ID="ddlSalaryIncrementPackageID" runat="server">
                                            </asp:DropDownList>
                                        </span>
                                    </div>
                                </div>
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Year:</label>
                                    <span style="display: inline;">
                                        <asp:TextBox ID="txtSalaryYear" class="txt medium-input" runat="server" Text="">
                                        </asp:TextBox></span>
                                </div>
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Month:</label>
                                    <span style="display: inline;">
                                        <asp:TextBox ID="txtMonth" class="txt medium-input" runat="server" Text="">
                                        </asp:TextBox></span>
                                </div>
                                <div style="margin: 4px 0 8px 0; width: 98%; float: left;">
                                    <div style="width: 480px; float: right;">
                                        <asp:Label ID="lblSalaryIncrementMsg" CssClass="msgClass" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div style="margin: 4px 0; display: block;">
                                    <asp:Button ID="btnAddSalaryIncrement" class="button button-blue" runat="server"
                                        Text="Add" OnClick="btnAddSalaryIncrement_Click" />
                                    <%--<asp:Button ID="Button4" runat="server" Text="Update" OnClick="btnUpdateJobPosting_Click" />--%>
                                </div>
                            </fieldset>
                            <fieldset class="step">
                                <div class="tab-title">
                                    Overtime Package Rule</div>
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        <span id="Span2">Overtime Flag</span></label>
                                    <span style="float: left; width: 480px; margin-left: 90px;">
                                        <asp:RadioButtonList ID="radOverTimeFlag" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="True" Selected="True">Active</asp:ListItem>
                                            <asp:ListItem Value="False">InActive</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </span>
                                </div>
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Over Time Package:</label>
                                    <div style="float: left; width: 570px;">
                                        <span style="float: left; margin-left: 90px; margin-bottom: 10px;">
                                            <asp:DropDownList ID="ddlOverTimePackID" runat="server">
                                            </asp:DropDownList>
                                        </span>
                                    </div>
                                </div>
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Over Time Taka Per Hour:</label>
                                    <span style="display: inline;">
                                        <asp:TextBox ID="txtOverTimeTakaPerHour" class="txt medium-input" runat="server"
                                            Text="">
                                        </asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="ftbeOverTimeTaka" runat="server" FilterMode="ValidChars"
                                            TargetControlID="txtOverTimeTakaPerHour" ValidChars="0123456789.">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </span>
                                </div>
                                <div style="margin: 4px 0;">
                                    <label style="width: 220px; float: left; text-align: right;">
                                        Monthly Total Hour:</label>
                                    <span style="display: inline;">
                                        <asp:TextBox ID="txtMonthlyTotalHour" class="txt medium-input" runat="server" Text="">
                                        </asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                            FilterMode="ValidChars" TargetControlID="txtMonthlyTotalHour" ValidChars="0123456789.">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </span>
                                </div>
                                <div style="margin: 4px 0 8px 0; width: 98%; float: left;">
                                    <div style="width: 480px; float: right;">
                                        <asp:Label ID="lblOvertimePackageRuleMsg" CssClass="msgClass" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div style="margin: 4px 0; display: block;">
                                    <asp:Button ID="btnAddOvertimePackageRule" runat="server" Text="Add" OnClick="btnAddOvertimePackageRule_Click" />
                                </div>
                            </fieldset>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div id="navigation" style="display: none;">
                <ul>
                    <li class="selected"><a href="#">Contact</a> </li>
                    <li><a href="#">Children Info</a> </li>
                    <li><a href="#">Job Experience</a> </li>
                    <%--<li><a href="#">Job Posting</a> </li>--%>
                    <li><a href="#">Attendence Rules</a> </li>
                    <li><a href="#">Working Days Shifting</a> </li>
                    <li><a href="#">Bank Info</a> </li>
                    <li><a href="#">Educational Background</a> </li>
                    <li><a href="#">Employee Salary</a> </li>
                    <li><a href="#">Lunch Rule</a> </li>
                    <li><a href="#">Providened Fund Contribution</a> </li>
                    <li><a href="#">Benefit Rule</a> </li>
                    <li><a href="#">Salary Tax Package</a> </li>
                    <li><a href="#">Salary Adjustment List Rules</a> </li>
                    <li><a href="#">Salary Increment Rules</a> </li>
                    <li><a href="#">Overtime Package Rule</a> </li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>
