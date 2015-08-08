<%@ Page Title="Employee Details Information" Language="C#" MasterPageFile="~/Site2Column.master" AutoEventWireup="true"
    CodeFile="AdminHR_EmployeeDetails.aspx.cs" Inherits="HR_AdminHR_EmployeeDetails"%>

<%@ Register Src="Control/UCEmployeeInfo.ascx" TagName="UCEmployeeInfo" TagPrefix="uc1" %>
<%@ Register Src="Control/UCContact.ascx" TagName="UCContact" TagPrefix="uc2" %>
<%@ Register src="../Control/RemarkSearch.ascx" tagname="RemarkSearch" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript">
        window.moveTo(0, 0);

        function ShowHide(id) {
            var targetElement = document.getElementById(id);
            if (targetElement.style.display == 'none')
                targetElement.style.display = '';
            else if (targetElement.style.display == '')
                targetElement.style.display = 'none'

            return false;
        }
        function gotopreview_w_h(str, name, w, h) {
            window.open(str, name, 'status=1,resizable=no,scrollbars=yes , width=' + w + ',height=' + h);
        }
    </script>
    <style type="text/css">
        .style1
        {
            height: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="content-box">
        <div class="header">
            <h3>
                Employee Details Information:
                <asp:Label runat="server" ID="lblEmployeeName" Text=""></asp:Label></h3>
        </div>
        <div class="inner-form">
            <uc1:UCEmployeeInfo ID="UCEmployeeInfo1" runat="server" />
            <uc2:UCContact ID="UCContact1" runat="server" />
            <div id="divEducational" runat="server" style="width: 100%; overflow: hidden; padding-bottom: 25px;">
                <h4 style="width: 100%; line-height: 18px; font-size: 14px; padding-bottom: 2px;
                    color: #5772BD; border-bottom: 1px solid #5772BD;">
                    Education Background</h4>
                <div style="width: 92%; margin: 0 auto; overflow: hidden; padding: 10px 0;">
                    &nbsp;
                    <asp:GridView ID="gvCOMN_EducatinalBackground" class="gridCss" runat="server" AutoGenerateColumns="false"
                        CssClass="gridCss">
                        <Columns>
                            <asp:TemplateField HeaderText="Educational Bacground" Visible="false" HeaderStyle-BackColor="GhostWhite">
                                <ItemTemplate>
                                    <asp:Label ID="lblEducationalBacgroundID" runat="server" Visible="false" Text='<%#Eval("EducationalBacgroundID") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="EmplyoeeID" Visible="false" HeaderStyle-BackColor="GhostWhite">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserID" Visible="false" runat="server" Text='<%#Eval("UserID") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Year" HeaderStyle-BackColor="GhostWhite">
                                <ItemTemplate>
                                    <asp:Label ID="lblYear" runat="server" Text='<%#Eval("Year") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Board University" HeaderStyle-BackColor="GhostWhite">
                                <ItemTemplate>
                                    <asp:Label ID="lblBoardUniversity" runat="server" Text='<%#Eval("BoardUniversity") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Education Group" HeaderStyle-BackColor="GhostWhite">
                                <ItemTemplate>
                                    <asp:Label ID="lblEducationGroup" runat="server" Text='<%#Eval("EducationGroup") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Major" HeaderStyle-BackColor="GhostWhite">
                                <ItemTemplate>
                                    <asp:Label ID="lblMajor" runat="server" Text='<%#Eval("Major") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Reault System" HeaderStyle-BackColor="GhostWhite">
                                <ItemTemplate>
                                    <asp:Label ID="lblReaultSystemID" runat="server" Text='<%#Eval("ReaultSystemID") =="1"? "Grading":"Division"%>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Degree" HeaderStyle-BackColor="GhostWhite">
                                <ItemTemplate>
                                    <asp:Label ID="lblDegree" runat="server" Text='<%#Eval("Degree") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Result" HeaderStyle-BackColor="GhostWhite">
                                <ItemTemplate>
                                    <asp:Label ID="lblResult" runat="server" Text='<%#Eval("Result") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Score" HeaderStyle-BackColor="GhostWhite">
                                <ItemTemplate>
                                    <asp:Label ID="lblScore" runat="server" Text='<%#Eval("Score") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Out Of" HeaderStyle-BackColor="GhostWhite">
                                <ItemTemplate>
                                    <asp:Label ID="lblOutOf" runat="server" Text='<%#Eval("OutOf") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div>
                   <%-- <asp:Button ID="Button1" CssClass="btn3" runat="server" Text="Edit" />--%></div>
            </div>
            <div id="divJobExperience" runat="server" style="width: 100%; overflow: hidden; padding-bottom: 25px;">
                <h4 style="width: 100%; line-height: 18px; font-size: 14px; padding-bottom: 2px;
                    color: #5772BD; border-bottom: 1px solid #5772BD;">
                    Job Experience</h4>
                <div>
                    <asp:GridView ID="gvJobExperience" class="gridCss" GridLines="Vertical" Width="100%"
                        runat="server" ShowHeader="true" AutoGenerateColumns="false" CssClass="gridCss">
                        <Columns>
                            <asp:TemplateField HeaderText="Organization" HeaderStyle-BackColor="GhostWhite">
                                <ItemTemplate>
                                    <asp:Label ID="lblJobExperienceID" Visible="false" runat="server" Text='<%#Eval("JobExperienceID") %>'>   </asp:Label>
                                    <asp:Label ID="lblOrganizationName" runat="server" Text='<%#Eval("OrganizationName")%>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Designation" HeaderStyle-BackColor="GhostWhite">
                                <ItemTemplate>
                                    <asp:Label ID="lblDesignation" runat="server" Text='<%#Eval("Designation") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="NatureofWork" HeaderStyle-BackColor="GhostWhite">
                                <ItemTemplate>
                                    <asp:Label ID="lblNatureofWork" runat="server" Text='<%#Eval("NatureofWork") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DateStart" HeaderStyle-BackColor="GhostWhite">
                                <ItemTemplate>
                                    <asp:Label ID="lblDateStart" runat="server" Text='<%#Eval("DateStart", "{0:dd-MMM-yyyy}") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DateEnds" HeaderStyle-BackColor="GhostWhite">
                                <ItemTemplate>
                                    <asp:Label ID="lblDateEnds" runat="server" Text='<%#Eval("DateEnds","{0:dd-MMM-yyyy}") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Duration" HeaderStyle-BackColor="GhostWhite">
                                <ItemTemplate>
                                    <asp:Label ID="lblDuration" runat="server" Text='<%#Eval("Duration") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ReasionForLeaving" HeaderStyle-BackColor="GhostWhite">
                                <ItemTemplate>
                                    <asp:Label ID="lblReasionForLeaving" runat="server" Text='<%#Eval("ReasionForLeaving") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div>
                  <%--  <asp:Button ID="Button2" CssClass="btn3" runat="server" Text="Edit" />--%>
                </div>
            </div>
            <div id="divPersonalDocument" runat="server" style="width: 100%; overflow: hidden;
                padding-bottom: 25px;">
                <h4 style="width: 100%; line-height: 18px; font-size: 14px; padding-bottom: 2px;
                    color: #5772BD; border-bottom: 1px solid #5772BD;">
                    Personal Documents</h4>
                <div style="width: 92%; margin: 0 auto; overflow: hidden; padding: 10px 0;">
                    <table>
                        <colgroup>
                            <col width="20%" />
                            <col width="25%" />
                            <col width="30%" />
                            <col width="15%" />
                            <col width="8%" />
                        </colgroup>
                        <tr>
                            <td>
                                <asp:Label ID="label46" runat="server" Text="CV"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblCvDocs" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblJobAgreement" runat="server" Text="Job Agreement"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label49" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <p style="margin-top: 10px;">
                                    <%--<asp:Button ID="btnEditDocument" CssClass="button button-ash" runat="server" Text="Edit" />--%>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <div style="padding: 10px; margin-top: 10px; background-color: #e3e3e3">
                                    <asp:GridView ID="gvHR_OthersDocuments" class="gridCss" GridLines="Vertical" Width="100%"
                                        runat="server" ShowHeader="true" AutoGenerateColumns="false" CssClass="gridCss">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Documents Type">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOthersDocumentsID" Visible="false" runat="server" Text='<%#Eval("OthersDocumentsID") %>'>   </asp:Label>
                                                    <asp:Label ID="lblDocumentsType" runat="server" Text='<%#Eval("DocumentsType").ToString()=="ED"?"Educational Document":"Job Experience Letter" %>'>
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Document Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDocumentName" runat="server" Text='<%#Eval("DocumentName") %>'>
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr runat="server" id="trOtherDocuments">
                            <td colspan="4">
                                <p style="margin-top: 10px;">
                                    <%--<asp:Button ID="btnOtherDocuments" CssClass="button button-ash" runat="server" Text="Edit"
                                        OnClick="btnOtherDocuments_Click" />--%>
                                </p>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div id="divPositioningInformation" runat="server" style="width: 100%; overflow: hidden;
                padding-bottom: 25px;">
                <h4 style="width: 100%; line-height: 18px; font-size: 14px; padding-bottom: 2px;
                    color: #5772BD; border-bottom: 1px solid #5772BD;">
                    Positioning Information</h4>
                <div style="width: 92%; margin: 0 auto; overflow: hidden; padding: 10px 0;">
                    <table>
                        <colgroup>
                            <col width="20%" />
                            <col width="30%" />
                            <col width="22%" />
                            <col width="20%" />
                            <col width="8%" />
                        </colgroup>
                        <tr>
                            <td>
                                <asp:Label ID="label54" runat="server" Text="Department"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblDepartment" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label56" runat="server" Text="Designation"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblDesignationName" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="label58" runat="server" Text="Job Location"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblJobLocation" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label60" runat="server" Text="Supervisor"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSupervisorName" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="label62" runat="server" Text="Joining Date"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblJoinDate" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label64" runat="server" Text="Status"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="label66" runat="server" Text="Ending Date"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblEndDate" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label68" runat="server" Text="Posting Date"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblAddedDate" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                               <%-- <asp:Button ID="btnPostingInformation" CssClass="button button-ash" runat="server"
                                    Text="Edit" OnClick="btnPostingInformation_Click" />--%>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div id="divShiftingWorkingDay" runat="server" style="width: 100%; overflow: hidden;
                padding-bottom: 25px;">
                <h4 style="width: 100%; line-height: 18px; font-size: 14px; padding-bottom: 2px;
                    color: #5772BD; border-bottom: 1px solid #5772BD;">
                    Shifting &amp; Working Days</h4>
                <div style="width: 92%; margin: 0 auto; overflow: hidden; padding: 10px 0;">
                    <table>
                        <colgroup>
                            <col width="30%" />
                            <col width="20%" />
                            <col width="30%" />
                            <col width="20%" />
                        </colgroup>
                        <tr>
                            <td>
                                <asp:Label ID="label71" runat="server" Text="Shift Start Time : "></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblShiftStartTime" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label73" runat="server" Text="Shift End Time : "></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbShiftEndTime" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="label75" runat="server" Text="Description"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblDescription" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </div>
                <h5 style="line-height: 16px; font-size: 12px; color: #647DC2; padding-bottom: 5px;">
                    Working Days</h5>
                <table>
                    <colgroup>
                        <col width="3%" />
                        <col width="1%" />
                        <col width="13%" />
                        <col width="3%" />
                        <col width="1%" />
                        <col width="13%" />
                        <col width="3%" />
                        <col width="1%" />
                        <col width="13%" />
                        <col width="3%" />
                        <col width="1%" />
                        <col width="13%" />
                        <col width="3%" />
                        <col width="1%" />
                        <col width="16%" />
                        <col width="3%" />
                        <col width="1%" />
                        <col width="13%" />
                    </colgroup>
                    <tr>
                        <td>
                            <asp:CheckBox runat="server" ID="chkSaturday" Checked='<%#Eval("Saturday")%>' Enabled="false" />
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:Label ID="lbl1" runat="server" Text="Saturday"></asp:Label>
                        </td>
                        <td>
                            <asp:CheckBox runat="server" ID="chkSunday" Checked='<%#Eval("Sunday")%>' Enabled="false" />
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:Label ID="Label77" runat="server" Text="Sunday"></asp:Label>
                        </td>
                        <td>
                            <asp:CheckBox runat="server" ID="chkMonday" Checked='<%#Eval("Monday")%>' Enabled="false" />
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:Label ID="Label78" runat="server" Text="Monday"></asp:Label>
                        </td>
                        <td>
                            <asp:CheckBox runat="server" ID="chkTuesday" Checked='<%#Eval("Tuesday")%>' Enabled="false" />
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:Label ID="Label79" runat="server" Text="Tuesday"></asp:Label>
                        </td>
                        <td>
                            <asp:CheckBox runat="server" ID="chkWednesday" Checked='<%#Eval("Wednesday")%>' Enabled="false" />
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:Label ID="Label80" runat="server" Text="Wednesday"></asp:Label>
                        </td>
                        <td>
                            <asp:CheckBox runat="server" ID="chkThrusday" Checked='<%#Eval("Thrusday")%>' Enabled="false" />
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:Label ID="Label81" runat="server" Text="Thursday"></asp:Label>
                        </td>
                    </tr>
                </table>
                <span style="width: 100%; overflow: hidden; display: block; padding: 4px 0;">
                   <%-- <asp:Button ID="btnEditWorkingDayShifting" runat="server"
                        Text="Edit" CssClass="button button-ash" />--%>
                </span>
            </div>
            <div id="divAttendanceRules" runat="server" style="width: 100%; overflow: hidden;
                padding-bottom: 25px;">
                <h4 style="width: 100%; line-height: 18px; font-size: 14px; padding-bottom: 2px;
                    color: #5772BD; border-bottom: 1px solid #5772BD;">
                    Attendance Rules </h4>
                <div style="width: 92%; margin: 0 auto; overflow: hidden; padding: 10px 0;">
                    <table width="100%">
                        <colgroup>
                            <col width="20%" />
                            <col width="30%" />
                            <col width="20%" />
                            <col width="22%" />
                            <col width="8%" />
                        </colgroup>
                        <tr>
                            <td>
                                <label class="labelText5">
                                    Attendance Rules :
                                </label>
                            </td>
                            <td>
                                <asp:Label ID="lblRules" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <label class="labelText5">
                                    Flexible Time :
                                </label>
                            </td>
                            <td>
                                <asp:Label ID="lblTime" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lblUnit" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                               <%-- <asp:Button ID="btnAttanDanceRules" CssClass="button button-ash" runat="server" Text="Edit" />--%>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div id="divLunchRules" runat="server" style="width: 100%; overflow: hidden; padding-bottom: 25px;">
                <h4 style="width: 100%; line-height: 18px; font-size: 14px; padding-bottom: 2px;
                    color: #5772BD; border-bottom: 1px solid #5772BD;">
                    Lunch Rules</h4>
                <div style="width: 92%; margin: 0 auto; overflow: hidden; padding: 10px 0;">
                    <table width="100%">
                        <colgroup>
                            <col width="20%" />
                            <col width="30%" />
                            <col width="20%" />
                            <col width="22%" />
                            <col width="8%" />
                        </colgroup>
                        <tr>
                            <td>
                                <label class="labelText5">
                                    Lunch Rules :
                                </label>
                            </td>
                            <td>
                                <asp:Label ID="lblLUnchAllowed" runat="server" Text="Not Allowed"></asp:Label>
                            </td>
                            <td>
                                Lunch Start Time :
                            </td>
                            <td>
                                <asp:Label ID="lblLunchStartTimeHours" runat="server" Text=""></asp:Label>
                                :
                                <asp:Label ID="lblLunchStartTimeMins" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                         <td>
                                Lunch End Time :
                            </td>
                            <td>
                                <asp:Label ID="lblLunchEndTimeHours" runat="server" Text=""></asp:Label>
                                :
                                <asp:Label ID="lblLunchEndTimeMins" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                Lunch Flexible Time :
                            </td>
                            <td>
                                <asp:Label ID="lblLunchFlexibleTimeHours" runat="server" Text=""></asp:Label>
                                :
                                <asp:Label ID="lblLunchFlexibleTimeMins" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblLunchTimeAllowed" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                               <%-- <asp:Button runat="server" ID="btnLuncheRules" CssClass="button button-ash" Text="Edit" />--%>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div id="divSalaryRules" runat="server" style="width: 100%; overflow: hidden; padding-bottom: 25px;">
                <h4 style="width: 100%; line-height: 18px; font-size: 14px; padding-bottom: 2px;
                    color: #5772BD; border-bottom: 1px solid #5772BD;">
                    Salary Rules</h4>
                <div style="width: 92%; margin: 0 auto; overflow: hidden; padding: 10px 0;">
                    <div>
                        <dl>
                            <dt style ="width :30%;">
                                <asp:Label ID="lblDefinedSalary" Text="Basic" runat="server"></asp:Label>
                            </dt>
                            <dt style ="width :40%;">
                                <asp:Label ID="lblTotalSalary" Text="Total Salary" runat="server"></asp:Label>
                            </dt>
                        </dl>
                    </div>
                    <div>
                        <asp:GridView ID="gridViewEmployeeSalDetail" runat="server" AutoGenerateColumns="false"
                            Width="50%">
                            <Columns>
                                <asp:TemplateField HeaderText="Description" HeaderStyle-BackColor="GhostWhite">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPackageRulesName" runat="server" Text='<%#Eval("PackageRulesName") %>'>
 	                            </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Rules Value" HeaderStyle-BackColor="GhostWhite">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRulesValue" runat="server" Text='<%#Eval("RulesValue") %>'>
 	                            </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Rules Operator" HeaderStyle-BackColor="GhostWhite">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRulesOperator" runat="server" Text='<%#Eval("RulesOperator") %>'>
 	                            </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Details" HeaderStyle-BackColor="GhostWhite">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPackageID" runat="server" Text='<%#Eval("PackageID") %>'>
 	                            </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <div id="divProvidendFund" runat="server" style="width: 100%; overflow: hidden; padding-bottom: 25px;">
                <h4 style="width: 100%; line-height: 18px; font-size: 14px; padding-bottom: 2px;
                    color: #5772BD; border-bottom: 1px solid #5772BD;">
                    Providend Fund</h4>
                <div style="width: 92%; margin: 0 auto; overflow: hidden; padding: 10px 0;">
                    <table>
                        <colgroup>
                            <col width="25%" />
                            <%--<col width="10%" />--%>
                            <col width="70%" />
                            <col width="5%" />
                        </colgroup>
                        <tr>
                            <td>
                                <label class="labelText5">
                                    Amount : 
                                </label>
                            </td>
                            <td>
                                <asp:Label ID="lblProvidentFundAmount" runat="server" Text="TK"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                              <%--  <asp:Button ID="Button8" CssClass="btn3" runat="server" Text="Edit" />--%>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div id="divOvertimeRules" runat="server" style="width: 100%; overflow: hidden; padding-bottom: 25px;">
                <h4 style="width: 100%; line-height: 18px; font-size: 14px; padding-bottom: 2px;
                    color: #5772BD; border-bottom: 1px solid #5772BD;">
                    Overtime Rules</h4>
                <div style="width: 92%; margin: 0 auto; overflow: hidden; padding: 10px 0;">
                    <table width = "100%">
                        <colgroup>
                            <col width="60" />
                            <%--<col width="10%" />--%>
                            <col width="35%" />
                            <col width="5%" />
                        </colgroup>
                        <tr>
                            <td class="style1">
                                <asp:Label Text = "Overtime Amount (Monthly) :" ID ="lblOverTime" runat = "server"></asp:Label>
                            </td>
                            <td class="style1">
                                <asp:Label ID="lblOverTimeAmountPerMonth" runat="server" Text="Not Allowed"></asp:Label>
                            </td>
                            <td class="style1">
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                                <%--<asp:Button ID="Button9" CssClass="btn3" runat="server" Text="Edit" />--%>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div id="divSalaryIncrement" runat="server" style="width: 100%; overflow: hidden;
                padding-bottom: 25px;">
                <h4 style="width: 100%; line-height: 18px; font-size: 14px; padding-bottom: 2px;
                    color: #5772BD; border-bottom: 1px solid #5772BD;">
                    Salary Increment Rules Setup</h4>
                <div style="width: 92%; margin: 0 auto; overflow: hidden; padding: 10px 0;">
                    <table>
                        <colgroup>
                            <col width="20%" />
                            <%--<col width="10%" />--%>
                            <col width="75%" />
                            <col width="5%" />
                        </colgroup>
                        <tr>
                            <td>
                                <label class="labelText5">
                                    Increment
                                </label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalaryIncrement" runat="server" Text="3000 Tk Effective After 1 Year And 0 Month"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                             <%--   <asp:Button ID="Button10" CssClass="btn3" runat="server" Text="Edit" />--%>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div id="divTaxRules" runat="server" style="width: 100%; overflow: hidden; padding-bottom: 25px;">
                <h4 style="width: 100%; line-height: 18px; font-size: 14px; padding-bottom: 2px;
                    color: #5772BD; border-bottom: 1px solid #5772BD;">
                    Tax Rules Setup</h4>
                <div style="width: 92%; margin: 0 auto; overflow: hidden; padding: 10px 0;">
                    <table>
                        <colgroup>
                            <col width="15%" />
                            <%--<col width="10%" />--%>
                            <col width="80%" />
                            <col width="5%" />
                        </colgroup>
                        <tr>
                            <td>
                                <label class="labelText5">
                                    Tax:
                                </label>
                            </td>
                            <td>
                                <asp:Label ID="lblTaxAmount" runat="server" Text="0.00 Tk"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                              <%--  <asp:Button ID="Button11" CssClass="btn3" runat="server" Text="Edit" />--%>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div id="divBenifitRules" runat="server" style="width: 100%; overflow: hidden; padding-bottom: 25px;">
                <h4 style="width: 100%; line-height: 18px; font-size: 14px; padding-bottom: 2px;
                    color: #5772BD; border-bottom: 1px solid #5772BD;">
                    Benifit Rules</h4>
                <div style="width: 92%; margin: 0 auto; overflow: hidden; padding: 10px 0;">
                    <span style="line-height: 16px; font-weight: bold; width: 75px; display: block; border-bottom: 1px solid #067000;
                        font-size: 12px; color: #067000; margin-bottom: 5px;">Benifit Rules</span>
                    <div>
                        <dl>
                            <dt>
                                <asp:Label ID="lblBenifit" runat="server" Text=" Eid Bonus "> </asp:Label>
                            </dt>
                        </dl>
                    </div>
                </div>
            </div>
            <div id="divSalaryAdjustment" runat="server" style="width: 100%; overflow: hidden;
                padding-bottom: 25px;">
                <h4 style="width: 100%; line-height: 18px; font-size: 14px; padding-bottom: 2px;
                    color: #5772BD; border-bottom: 1px solid #5772BD;">
                    Salary Adjustment Rules Setup</h4>
                <div style="width: 92%; margin: 0 auto; overflow: hidden; padding: 10px 0;">
                    <span style="line-height: 16px; font-weight: bold; width: 140px; display: block;
                        border-bottom: 1px solid #067000; font-size: 12px; color: #067000; margin-bottom: 5px;">
                        Salary Adjustment Lists </span>
                    <div>
                        <asp:GridView ID="gvSalaryAdjustmentList" runat="server" AutoGenerateColumns="false"
                            Width="50%">
                            <Columns>
                                <asp:TemplateField HeaderText="Name" HeaderStyle-BackColor="GhostWhite">
                                    <ItemTemplate>
                                        <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'>
 	                            </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Value" HeaderStyle-BackColor="GhostWhite">
                                    <ItemTemplate>
                                        <asp:Label ID="lblValue" runat="server" Text='<%#Eval("Value") %>'>
 	                            </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <%-- <div id="divLeavesRules" runat="server" style="width: 100%; overflow: hidden; padding-bottom: 25px;">
                <h4 style="width: 100%; line-height: 18px; font-size: 14px; padding-bottom: 2px;
                    color: #5772BD; border-bottom: 1px solid #5772BD;">
                    Leaves Rules</h4>
                <div style="width: 92%; margin: 0 auto; overflow: hidden; padding: 10px 0;">
                    <span style="line-height: 16px; font-weight: bold; width: 70px; display: block; border-bottom: 1px solid #067000;
                        font-size: 12px; color: #067000; margin-bottom: 5px;">Leave Lists </span>
                    <table>
                        <colgroup>
                            <col width="91%" />
                            <col width="9%" />
                        </colgroup>
                        <tr>
                            <td>
                                <asp:Label ID="label107" runat="server" Text="#########"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="Button14" CssClass="btn3" runat="server" Text="Edit" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>--%>
            <div id="divBankAccount" runat="server" style="width: 100%; overflow: hidden; padding-bottom: 25px;">
                <h4 style="width: 100%; line-height: 18px; font-size: 14px; padding-bottom: 2px;
                    color: #5772BD; border-bottom: 1px solid #5772BD;">
                    Bank Account</h4>
                <div style="width: 92%; margin: 0 auto; overflow: hidden; padding: 10px 0;">
                    <table>
                        <colgroup>
                            <col width="5%" />
                            <col width="15%" />
                            <col width="30%" />
                            <col width="15%" />
                            <col width="30%" />
                            <col width="5%" />
                        </colgroup>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <label class="labelText5">
                                    Account No: 
                                </label>
                            </td>
                            <td>
                                <asp:Label ID="lblBankAccountNo" runat="server" Text="######"></asp:Label>
                            </td>
                            <td>
                                <label class="labelText5">
                                    Account Name : 
                                </label>
                            </td>
                            <td>
                                <asp:Label ID="lblAccountName" runat="server" Text="########"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <label class="labelText5">
                                    Bank Name : 
                                </label>
                            </td>
                            <td>
                                <asp:Label ID="lblBankName" runat="server" Text="#########"></asp:Label>
                            </td>
                            <td>
                                <label class="labelText5">
                                    Contact Person : 
                                </label>
                            </td>
                            <td>
                                <asp:Label ID="lblContactPerson" runat="server" Text="########"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <label class="labelText5">
                                    Bank Address : 
                                </label>
                            </td>
                            <td>
                                <asp:Label ID="lblBankAddress" runat="server" Text="#########"></asp:Label>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                                <%--<asp:Button ID="Button15" CssClass="btn3" runat="server" Text="Edit" />--%>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <%--<div id ="divRetirementRules" runat="server" style="width: 100%; overflow: hidden; padding-bottom: 10px;">
                <h4 style="width: 100%; line-height: 18px; font-size: 14px; padding-bottom: 2px;
                    color: #5772BD; border-bottom: 1px solid #5772BD;">
                    Retirement Rules</h4>
                <div style="width: 92%; margin: 0 auto; overflow: hidden; padding: 10px 0;">
                    <span style="line-height: 16px; font-weight: bold; width: 95px; display: block; border-bottom: 1px solid #067000;
                        font-size: 12px; color: #067000; margin-bottom: 5px;">Retirement Lists </span>
                    <table>
                        <colgroup>
                            <col width="91%" />
                            <col width="9%" />
                        </colgroup>
                        <tr>
                            <td>
                                <asp:Label ID="label106" runat="server" Text="#########"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="Button16" CssClass="btn3" runat="server" Text="Edit" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>--%>
            <div style="width: 50%; margin: 0 auto; overflow: hidden;">
                <%--<asp:Button ID="Button17" CssClass="btn5" runat="server" Text="Print" />--%>
            </div>
            <div id="div2" runat="server" style="width: 100%; overflow: hidden;
                padding-bottom: 25px;">
                <h4 style="width: 100%; line-height: 18px; font-size: 14px; padding-bottom: 2px;
                    color: #5772BD; border-bottom: 1px solid #5772BD;">
                    Salary Adjustment Rules Setup</h4>
                <div style="width: 92%; margin: 0 auto; overflow: hidden; padding: 10px 0;">
                    
                    <div>
                       <uc3:RemarkSearch ID="RemarkSearch1" runat="server" />
                    </div>
                </div>
            </div>
            
        </div>
    </div>
</asp:Content>
