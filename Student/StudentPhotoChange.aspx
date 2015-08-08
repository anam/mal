<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="StudentPhotoChange.aspx.cs" Inherits="StudentRegistration" Title="Student Photo Change" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link rel="stylesheet" type="text/css" href="../App_Themes/CoffeyGreen/css/grid.css" />

    <script type="text/javascript" language="javascript">
        function checkFileExtension(elem) {
            var filePath = elem.value;

            if (filePath.indexOf('.') == -1)
                return false;

            var validExtensions = new Array();
            var ext = filePath.substring(filePath.lastIndexOf('.') + 1).toLowerCase();
            //Add valid extentions in this array
            validExtensions[0] = 'jpg';
            validExtensions[1] = 'png';
            validExtensions[2] = 'gif';

            for (var i = 0; i < validExtensions.length; i++) {
                if (ext == validExtensions[i])
                    return true;
            }

            alert('The file extension ' + ext.toUpperCase() + ' is not allowed!. Only allow (.jpg,.png,.gif) extension images.');
            elem.value = "";
            return false;
        }
        
    </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:HiddenField ID="hfLoggedInUserID" runat="server" />
    <div class="content-box">
        <div class="header">
            <h3>
                Student Photo Change</h3>
        </div>
        <div class="inner-form">
            <dl>
                <dt>
                    <asp:Label runat="server" ID="lblError" Text=""></asp:Label>
                </dt>
            </dl>
            <dl>
                <dt>
                    <asp:Label ID="lblStudentName" runat="server" Text="Student ID: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtID" class="txt small-input" runat="server" Text="">
    </asp:TextBox>
    <br />
                    <asp:Button ID="btnShowCurrentPhoto" runat="server" Text="Show Current photo" 
                        onclick="btnShowCurrentPhoto_Click" />
                        <br />
                    <asp:Image ID="imgCurrentPhoto" runat="server" />
                </dd>
                <dt></dt>
                <dd>
                    <%--<object width="405" height="190">
                        <param name="movie" value="WebcamResources/save_picture.swf">
                        <embed src="WebcamResources/save_picture.swf" width="405" height="190"></embed>
                    </object>--%>
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
                </dd>
                <dt>
                    <asp:Label ID="lblPPSizePhoto" runat="server" Text="PP Size Photo: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:FileUpload ID="uplFile" runat="server" CssClass="file" onchange="checkFileExtension(this);" />
                </dd>
                <dt>
                   
                </dt>
                <dd>
                   
                    <asp:Button ID="btnSavePhoto" runat="server" Text="Save Photo" 
                        onclick="btnSavePhoto_Click"/>
                </dd>
                </dl>
                </div>
                <div class="inner-form" style="display:none;">
            <dl>
                <dt id="dt_StudentCode" runat="server">
                    <asp:Label ID="lblStudentCode" runat="server" Text="Student Code: "></asp:Label>
                </dt>
                <dd id="dd_StudentCode" runat="server">
                    <asp:TextBox ID="txtStudentCode" class="txt large-input" runat="server" Text="" ReadOnly="true"></asp:TextBox>
                <asp:TextBox ID="txtStudentName" class="txt small-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblPresentAddress" runat="server" Text="Present Address: "></asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtPresentAddress" class="txt large-input" TextMode="MultiLine"
                        runat="server" Text=""></asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblPermanentAddress" runat="server" Text="Permanent Address: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtPermanentAddress" class="txt large-input" TextMode="MultiLine"
                        runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblTelephone" runat="server" Text="Telephone: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtTelephone" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblMobile" runat="server" Text="Mobile: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtMobile" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblEmail" runat="server" Text="Email: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtEmail" class="txt large-input" runat="server" Text="">
                    </asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Your Email"
                        Text="*" ControlToValidate="txtEmail" ValidationGroup="addStudent"></asp:RequiredFieldValidator>--%>
                    <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationGroup="addStudent"
                        ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail"
                        ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>
                </dd>
                <dt>
                    <asp:Label ID="lblDateofBirth" runat="server" Text="Dateof Birth: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtDateofBirth" class="txt large-input" runat="server" Text="">
                        </asp:TextBox>
                    <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="ajcal" runat="server" TargetControlID="txtDateofBirth">
                    </ajaxToolkit:CalendarExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Date Of Birth"
                        Text="*" ControlToValidate="txtDateofBirth" ValidationGroup="addStudent"></asp:RequiredFieldValidator>
                </dd>
                <dt>
                    <asp:Label ID="lblPassportNo" runat="server" Text="Passport No: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtPassportNo" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblGender" runat="server" Text="Sex: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtGender" class="txt large-input" runat="server" Text="">
                    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblMaritualStatusID" runat="server" Text="Marital Status: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlMaritualStatusID" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" InitialValue="0"
                        ErrorMessage="Select Marital Status" Text="*" ControlToValidate="ddlMaritualStatusID"
                        ValidationGroup="addStudent"></asp:RequiredFieldValidator>
                </dd>
                <dt>
                    <asp:Label ID="Label1" runat="server" Text="Batch: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlBatchID" runat="server">
                    </asp:DropDownList>
                    <a href="AdminSTD_Batch.aspx" target="_blank">New Batch?</a>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" InitialValue="0" runat="server"
                        ErrorMessage="Select Batch No" Text="*" ControlToValidate="ddlBatchID" ValidationGroup="addStudent"></asp:RequiredFieldValidator>
                </dd>
                <dt>
                    <asp:Label ID="lblReligionID" runat="server" Text="Religion: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlReligionID" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" InitialValue="0" runat="server"
                        ErrorMessage="Select Religion" Text="*" ControlToValidate="ddlReligionID" ValidationGroup="addStudent"></asp:RequiredFieldValidator>
                </dd>
                <dt style="display:none;">
                    <asp:Label ID="lblSpouseQualification" runat="server" Text="Spouse Qualification: ">
    </asp:Label>
                </dt>
                <dd style="display:none;">
                    <asp:TextBox ID="txtSpouseQualification" class="txt large-input" TextMode="MultiLine"
                        runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblIELTS" runat="server" Text="IELTS score: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtIELTS" class="txt large-input" runat="server" Text="0">
                    </asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="txtIELTS"
                        runat="server" FilterType="Custom" ValidChars="0123456789.0" InvalidChars="abc">
                    </ajaxToolkit:FilteredTextBoxExtender>
                </dd>
                <dt>
                    <asp:Label ID="lblTOFEL" runat="server" Text="TOFEL score: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtTOFEL" class="txt large-input" runat="server" Text="0">
    </asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="ajaxf" TargetControlID="txtTOFEL" runat="server"
                        FilterType="Custom" ValidChars="0123456789.0" InvalidChars="abc">
                    </ajaxToolkit:FilteredTextBoxExtender>
                </dd>
                <dt>
                    <asp:Label ID="lblEnglishQualification" runat="server" Text="English Qualification: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtEnglishQualification" class="txt large-input" runat="server"
                        Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblIsRegisterWithACCA" runat="server" Text="Is Register With ACCA: ">
    </asp:Label>
                </dt>
                <asp:UpdatePanel ID="upBasic" runat="server">
                    <ContentTemplate>
                        <dd>
                            <asp:RadioButtonList ID="radIsRegisterWithACCA" runat="server" RepeatDirection="Horizontal"
                                OnSelectedIndexChanged="radIsRegisterWithACCA_OnSelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Value="True">Yes</asp:ListItem>
                                <asp:ListItem Selected="True"  Value="false">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </dd>
                        <asp:Panel ID="pnRegistration" runat="server" Visible="false">
                            <dt>
                                <asp:Label ID="lblRegistrationDate" runat="server" Text="ACCA Registration Date: ">
                    </asp:Label>
                            </dt>
                            <dd>
                                <asp:TextBox ID="txtRegistrationDate" class="txt large-input" runat="server" Text="">
                    </asp:TextBox>
                                <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="clRegi" runat="server" TargetControlID="txtRegistrationDate">
                                </ajaxToolkit:CalendarExtender>
                                <asp:RequiredFieldValidator ID="rfvRegi" runat="server" ErrorMessage="Enter Your Registration Date"
                                    Text="*" ControlToValidate="txtRegistrationDate" ValidationGroup="addStudent"></asp:RequiredFieldValidator>
                            </dd>
                            <dt>
                                <asp:Label ID="lblRegistrationNo" runat="server" Text="Registration No: ">
                    </asp:Label>
                            </dt>
                            <dd>
                                <asp:TextBox ID="txtRegistrationNo" class="txt large-input" runat="server" Text="">
                    </asp:TextBox>
                            </dd>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <dt>
                    <asp:Label ID="lblBloodGroup" runat="server" Text="Blood Group: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtBloodGroup" class="txt large-input" runat="server" Text="">
                    </asp:TextBox>
                </dd>
                <dt></dt>
                <dd>
                </dd>
            </dl>
        </div>
    </div>
    <div class="content-box"  style="display:none;">
        <div class="header">
            <h3>
                Semester Fee</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="Label2" runat="server" Text="Semister Fee: "></asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtSemesterFee" class="txt large-input" runat="server" Text="0"></asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="Label3" runat="server" Text="Program: "></asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlCourseID" runat="server">
                                </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" InitialValue="0" runat="server"
                        ErrorMessage="Select Program" Text="*" ControlToValidate="ddlCourseID" ValidationGroup="addStudent"></asp:RequiredFieldValidator>
                </dd>
            </dl>
        </div>
    </div>
    <asp:UpdatePanel ID="upEducation" runat="server"  style="display:none;">
        <ContentTemplate>
            <div class="content-box">
                <div class="header">
                    <h3>
                        Insert Educatoinal Background</h3>
                </div>
                <div class="inner-form">
                    <!-- error and information messages -->
                    <dl>
                        <dt>
                            <asp:Label ID="lblYear" runat="server" Text="Year: ">
    </asp:Label>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtYear" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                        </dd>
                        <dt>
                            <asp:Label ID="lblBoardUniversity" runat="server" Text="Board University: ">
    </asp:Label>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtBoardUniversity" class="txt large-input" runat="server" Text="">
                    </asp:TextBox>
                        </dd>
                        <dt>
                            <asp:Label ID="lblEducationGroup" runat="server" Text="Education Group: ">
    </asp:Label>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtEducationGroup" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                        </dd>
                        <dt>
                            <asp:Label ID="lblMajor" runat="server" Text="Major: ">
    </asp:Label>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtMajor" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                        </dd>
                        <dt>
                            <asp:Label ID="lblReaultSystemID" runat="server" Text="Result System: ">
    </asp:Label>
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlReaultSystemID" runat="server">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" InitialValue="0"
                                ErrorMessage="Select Result System" Text="*" ControlToValidate="ddlReaultSystemID"
                                ValidationGroup="education"></asp:RequiredFieldValidator>
                        </dd>
                        <dt>
                            <asp:Label ID="lblDegree" runat="server" Text="Degree: ">
    </asp:Label>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtDegree" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                        </dd>
                        <dt>
                            <asp:Label ID="lblResult" runat="server" Text="Result: ">
    </asp:Label>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtResult" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                        </dd>
                        <dt>
                            <asp:Label ID="lblScore" runat="server" Text="Score: ">
                    </asp:Label>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtScore" class="txt large-input" runat="server" Text="">
                    </asp:TextBox>
                            <%--<ajaxToolkit:FilteredTextBoxExtender ID="ajaxs" runat="server" TargetControlID="txtScore"
                                FilterType="Custom" ValidChars="012345679.0123456789" InvalidChars="abc">
                            </ajaxToolkit:FilteredTextBoxExtender>--%>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Enter Score"
                                Text="*" ControlToValidate="txtScore" ValidationGroup="education"></asp:RequiredFieldValidator>--%>
                        </dd>
                        <dt>
                            <asp:Label ID="lblOutOf" runat="server" Text="Out Of: ">
    </asp:Label>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtOutOf" class="txt large-input" runat="server" Text="">
                    </asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                TargetControlID="txtOutOf" FilterType="Custom" ValidChars="012345679.00" InvalidChars="abc">
                            </ajaxToolkit:FilteredTextBoxExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Enter Out Of point "
                                Text="*" ControlToValidate="txtOutOf" ValidationGroup="education"></asp:RequiredFieldValidator>
                        </dd>
                        <dt></dt>
                        <dd>
                            <asp:Button ID="btnEducationalBackgroundAdd" class="button button-blue" CausesValidation="true"
                                ValidationGroup="education" runat="server" Text="Add" OnClick="btnEducationalBackgroundAdd_Click" />
                            <asp:Button ID="btnEducationalBackgroundUpdate" class="button button-blue" CausesValidation="true"
                                ValidationGroup="education" runat="server" Text="Update" Visible="false" OnClick="btnEducationalBackgroundUpdate_Click" />
                            <asp:ValidationSummary ID="v04" runat="server" ShowMessageBox="true" ShowSummary="false"
                                ValidationGroup="education" />
                        </dd>
                    </dl>
                </div>
            </div>
            <div class="content-box">
                <div class="header">
                    <h3>
                        Display Educatinal Background</h3>
                </div>
                <div class="inner-content">
                    <asp:GridView ID="gvCOMN_EducatinalBackground" class="gridCss" runat="server" AutoGenerateColumns="false"
                        CssClass="tabel_input">
                        <HeaderStyle CssClass="heading" />
                        <RowStyle CssClass="row" />
                        <AlternatingRowStyle CssClass="altrow" />
                        <Columns>
                            <%--<asp:TemplateField HeaderText="Educational Bacground">
                        <ItemTemplate>
                            <asp:Label ID="lblEducationalBacgroundID" runat="server" Text='<%#Eval("EducationalBacgroundID") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Year">
                                <ItemTemplate>
                                    <asp:Label ID="lblYear" runat="server" Text='<%#Eval("Year") %>'>
 	 </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Board University">
                                <ItemTemplate>
                                    <asp:Label ID="lblBoardUniversity" runat="server" Text='<%#Eval("BoardUniversity") %>'>
 	 </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Education Group">
                                <ItemTemplate>
                                    <asp:Label ID="lblEducationGroup" runat="server" Text='<%#Eval("EducationGroup") %>'>
 	 </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Major">
                                <ItemTemplate>
                                    <asp:Label ID="lblMajor" runat="server" Text='<%#Eval("Major") %>'>
 	 </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Result System">
                                <ItemTemplate>
                                    <asp:Label ID="lblReaultSystemID" runat="server" Text='<%#Eval("ReaultSystemName") %>'>
 	 </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Degree">
                                <ItemTemplate>
                                    <asp:Label ID="lblDegree" runat="server" Text='<%#Eval("Degree") %>'>
 	 </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Result">
                                <ItemTemplate>
                                    <asp:Label ID="lblResult" runat="server" Text='<%#Eval("Result") %>'>
 	 </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Score">
                                <ItemTemplate>
                                    <asp:Label ID="lblScore" runat="server" Text='<%#Eval("Score") %>'>
 	                        </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Out Of">
                                <ItemTemplate>
                                    <asp:Label ID="lblOutOf" runat="server" Text='<%#Eval("OutOf") %>'>
 	                        </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" ID="lbSelectEducationalBackGround" CommandArgument='<%#Eval("EducationalBacgroundID") %>'
                                        AlternateText="Edit" OnClick="lbSelectEducationalBackGround_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                                    <asp:ImageButton runat="server" ID="lbDeleteEducationalBackGround" CommandArgument='<%#Eval("EducationalBacgroundID") %>'
                                        OnClick="lbDeleteEducationalBackGround_Click" AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="jobExp" runat="server"  style="display:none;">
        <ContentTemplate>
            <div class="content-box">
                <div class="header">
                    <h3>
                        Insert Job Experience</h3>
                </div>
                <div class="inner-form">
                    <!-- error and information messages -->
                    <dl>
                        <dt>
                            <asp:Label ID="lblOrganizationName" runat="server" Text="Organization Name: ">
    </asp:Label>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtOrganizationName" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                        </dd>
                        <dt>
                            <asp:Label ID="lblDesignationID" runat="server" Text="Designation: ">
    </asp:Label>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtDesignation" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                        </dd>
                        <dt>
                            <asp:Label ID="lblNatureofWork" runat="server" Text="Nature of Work: ">
    </asp:Label>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtNatureofWork" TextMode="MultiLine" class="txt large-input" runat="server"
                                Text="">
    </asp:TextBox>
                        </dd>
                        <dt>
                            <asp:Label ID="lblDateStart" runat="server" Text="Date Start: ">
                    </asp:Label>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtDateStart" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                            <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="CalendarExtender2" runat="server" TargetControlID="txtDateStart">
                            </ajaxToolkit:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Enter Start Date "
                                Text="*" ControlToValidate="txtDateStart" ValidationGroup="job"></asp:RequiredFieldValidator>
                        </dd>
                        <dt>
                            <asp:Label ID="lblDateEnds" runat="server" Text="Date Ends: ">
    </asp:Label>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtDateEnds" class="txt large-input" runat="server" Text="">
                    </asp:TextBox>
                            <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="CalendarExtender3" runat="server" TargetControlID="txtDateEnds">
                            </ajaxToolkit:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Enter End Date "
                                Text="*" ControlToValidate="txtDateEnds" ValidationGroup="job"></asp:RequiredFieldValidator>
                        </dd>
                        <dt>
                            <asp:Label ID="lblDuration" runat="server" Text="Duration: ">
                    </asp:Label>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtDuration" class="txt large-input" runat="server" Text="">
                    </asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                TargetControlID="txtDuration" FilterType="Custom" ValidChars="012345679.00" InvalidChars="abc">
                            </ajaxToolkit:FilteredTextBoxExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Enter job duration "
                                Text="*" ControlToValidate="txtDuration" ValidationGroup="job"></asp:RequiredFieldValidator>
                        </dd>
                        <dt>
                            <asp:Label ID="lblReasionForLeaving" runat="server" Text="Reason For Leaving: ">
    </asp:Label>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtReasionForLeaving" TextMode="MultiLine" class="txt large-input"
                                runat="server" Text="">
    </asp:TextBox>
                        </dd>
                        <dt>
                            <asp:Label ID="lblContact" runat="server" Text="Contact: ">
    </asp:Label>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtContact" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                        </dd>
                        <dt></dt>
                        <dd>
                            <asp:Button ID="btnjobExperienceAdd" class="button button-blue" CausesValidation="true"
                                ValidationGroup="job" runat="server" Text="Add" OnClick="btnjobExperienceAdd_Click" />
                            <asp:Button ID="btnjobExperienceUpdate" class="button button-blue" CausesValidation="true"
                                ValidationGroup="job" runat="server" Text="Update" OnClick="btnjobExperienceUpdate_Click"
                                Visible="false" />
                            <asp:ValidationSummary ID="v03" runat="server" ShowMessageBox="true" ShowSummary="false"
                                ValidationGroup="job" />
                        </dd>
                    </dl>
                </div>
            </div>
            <div class="content-box">
                <div class="header">
                    <h3>
                        Display Job Experience</h3>
                </div>
                <div class="inner-content">
                    <asp:GridView ID="gvCOMN_JobExperience" class="gridCss" runat="server" AutoGenerateColumns="false"
                        CssClass="tabel_input">
                        <HeaderStyle CssClass="heading" />
                        <RowStyle CssClass="row" />
                        <AlternatingRowStyle CssClass="altrow" />
                        <Columns>
                            <asp:TemplateField HeaderText="Organization Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblOrganizationName" runat="server" Text='<%#Eval("OrganizationName") %>'>
 	 </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Designation">
                                <ItemTemplate>
                                    <asp:Label ID="lblDesignationID" runat="server" Text='<%#Eval("Designation") %>'>
 	 </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nature of Work">
                                <ItemTemplate>
                                    <asp:Label ID="lblNatureofWork" runat="server" Text='<%#Eval("NatureofWork") %>'>
 	 </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date Start">
                                <ItemTemplate>
                                    <asp:Label ID="lblDateStart" runat="server" Text='<%#Eval("DateStart","{0:dd MMM yyyy}") %>'>
 	                            </asp:Label>
                                    <asp:Label ID="lblDateEnds" runat="server" Text='<%#Eval("DateEnds","{0:dd MMM yyyy}") %>'>
 	                                </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Duration">
                                <ItemTemplate>
                                    <asp:Label ID="lblDuration" runat="server" Text='<%#Eval("Duration") %>'>
 	 </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Reason For Leaving">
                                <ItemTemplate>
                                    <asp:Label ID="lblReasionForLeaving" runat="server" Text='<%#Eval("ReasionForLeaving") %>'>
 	 </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contact">
                                <ItemTemplate>
                                    <asp:Label ID="lblContact" runat="server" Text='<%#Eval("Contact") %>'>
 	 </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" ID="lbSelectjobExperience" CommandArgument='<%#Eval("JobExperienceID") %>'
                                        AlternateText="Edit" OnClick="lbSelectjobExperience_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                                    <asp:ImageButton runat="server" ID="lbDeletejobExperience" CommandArgument='<%#Eval("JobExperienceID") %>'
                                        OnClick="lbDeletejobExperience_Click" AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="upContact" runat="server"  style="display:none;">
        <ContentTemplate>
            <div class="content-box">
                <div class="header">
                    <h3>
                        Insert Student Contact Info</h3>
                </div>
                <div class="inner-form">
                    <!-- error and information messages -->
                    <dl>
                        <dt>
                            <asp:Label ID="lblName" runat="server" Text="Name: ">
    </asp:Label>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtName" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                        </dd>
                        <dt>
                            <asp:Label ID="lblCellNo" runat="server" Text="Cell No: ">
    </asp:Label>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtCellNo" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                        </dd>
                        <dt>
                            <asp:Label ID="lblOccupation" runat="server" Text="Occupation: ">
    </asp:Label>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtOccupation" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                        </dd>
                        <dt>
                            <asp:Label ID="lblOfficeTel" runat="server" Text="Office Tel: ">
    </asp:Label>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtOfficeTel" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                        </dd>
                        <dt>
                            <asp:Label ID="lblOfficeAddress" runat="server" Text="Office Address: ">
    </asp:Label>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtOfficeAddress" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                        </dd>
                        <dt>
                            <asp:Label ID="lblContactTypeID" runat="server" Text="Contact Type: ">
    </asp:Label>
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlContactTypeID" runat="server">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" InitialValue="0"
                                ErrorMessage="Select Contact Type" Text="*" ControlToValidate="ddlContactTypeID"
                                ValidationGroup="contact"></asp:RequiredFieldValidator>
                        </dd>
                        <dt></dt>
                        <dd>
                            <asp:Button ID="btnContactAdd" class="button button-blue" ValidationGroup="contact"
                                CausesValidation="true" runat="server" Text="Add" OnClick="btnContactAdd_Click" />
                            <asp:Button ID="btnContactUpdate" class="button button-blue" ValidationGroup="contact"
                                CausesValidation="true" runat="server" Text="Update" OnClick="btnContactUpdate_Click"
                                Visible="false" />
                            <asp:ValidationSummary ID="v02" runat="server" ShowMessageBox="true" ShowSummary="false"
                                ValidationGroup="contact" />
                        </dd>
                    </dl>
                </div>
            </div>
            <div class="content-box">
                <div class="header">
                    <h3>
                        Display Student Contact</h3>
                </div>
                <div class="inner-content">
                    <asp:GridView ID="gvSTD_Contact" class="gridCss" runat="server" AutoGenerateColumns="false"
                        CssClass="tabel_input">
                        <HeaderStyle CssClass="heading" />
                        <RowStyle CssClass="row" />
                        <AlternatingRowStyle CssClass="altrow" />
                        <Columns>
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'>
 	 </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cell No">
                                <ItemTemplate>
                                    <asp:Label ID="lblCellNo" runat="server" Text='<%#Eval("CellNo") %>'>
 	 </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Occupation">
                                <ItemTemplate>
                                    <asp:Label ID="lblOccupation" runat="server" Text='<%#Eval("Occupation") %>'>
 	 </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Office Tel">
                                <ItemTemplate>
                                    <asp:Label ID="lblOfficeTel" runat="server" Text='<%#Eval("OfficeTel") %>'>
 	 </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Office Address">
                                <ItemTemplate>
                                    <asp:Label ID="lblOfficeAddress" runat="server" Text='<%#Eval("OfficeAddress") %>'>
 	 </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contact Type">
                                <ItemTemplate>
                                    <asp:Label ID="lblContactTypeID" runat="server" Text='<%#Eval("ContactTypeName") %>'>
 	 </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" ID="lbSelectContact" CommandArgument='<%#Eval("ContactID") %>'
                                        AlternateText="Edit" OnClick="lbSelectContact_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                                    <asp:ImageButton runat="server" ID="lbDeleteContact" CommandArgument='<%#Eval("ContactID") %>'
                                        OnClick="lbDeleteContact_Click" AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="inner-content">
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="btnAdd" class="button button-blue" runat="server" CausesValidation="true"
                                    ValidationGroup="addStudent" Text="Save" OnClick="btnAdd_Click" />
                                <asp:Button ID="btnUpdate" class="button button-blue" runat="server" CausesValidation="true"
                                    ValidationGroup="addStudent" Text="Update" OnClick="btnUpdate_Click" Visible="false" />
                                <asp:ValidationSummary ID="vs01" runat="server" ShowMessageBox="true" ShowSummary="false"
                                    ValidationGroup="addStudent" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnAdd" />
            <asp:PostBackTrigger ControlID="btnUpdate" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:HiddenField ID="hfUserID" runat="server" />
    <asp:HiddenField ID="hfEducationalBackgroundID" runat="server" />
    <asp:HiddenField ID="hfjobExperienceID" runat="server" />
    <asp:HiddenField ID="hfLatestSemesterFeesAmount" runat="server" />
    <asp:HiddenField ID="hfLatestSemesterFeesTypeID" runat="server" />
    <asp:HiddenField ID="hfLatestSemesterFeesCourseID" runat="server" />
    <asp:HiddenField ID="hfLatestSemesterFeesID" runat="server" />
    <asp:HiddenField ID="hfContactID" runat="server" />
</asp:Content>
