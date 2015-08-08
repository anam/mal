<%@ Page Title="Employee Basic Data Set-up" Language="C#" MasterPageFile="~/Site2Column.master"
    AutoEventWireup="true" CodeFile="EmpBasicDataSetup.aspx.cs" Inherits="EmpBasicDataSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="content-box">
        <div class="header">
            <h3>
                Employee Basic Data Set-up</h3>
        </div>
        <div class="inner-content">
            <table width="100%" class="gridCss">
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/HR/AdminHR_EmployerType.aspx"
                            Text="Add Employee Type"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/HR/AdminDisplayHR_EmployerType.aspx"
                            Text="View Employee Type"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/HR/AdminHR_Department.aspx"
                            Text="Add Department"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/HR/AdminDisplayHR_Department.aspx"
                            Text="View Department"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/HR/AdminHR_Designation.aspx"
                            Text="Add Designation"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/HR/AdminDisplayHR_Designation.aspx"
                            Text="View Designation"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink15" runat="server" NavigateUrl="~/HR/AdminHR_Rank.aspx"
                            Text="Add Rank"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink16" runat="server" NavigateUrl="~/HR/AdminDisplayHR_Rank.aspx"
                            Text="View Rank"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Common/AdminCOMN_BloodGroup.aspx"
                            Text="Add Blood Group"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/Common/AdminDisplayCOMN_BloodGroup.aspx"
                            Text="View BloodGroup"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/Common/AdminCOMN_Religion.aspx"
                            Text="Add Religion"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="~/Common/AdminDisplayCOMN_Religion.aspx"
                            Text="View Religion"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/Common/AdminCOMN_MaritualStatus.aspx"
                            Text="Add Marital Status"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="~/Common/AdminDisplayCOMN_MaritualStatus.aspx"
                            Text="View Marital Status"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink13" runat="server" NavigateUrl="~/Common/AdminCOMN_Nationality.aspx"
                            Text="Add Nationality"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink14" runat="server" NavigateUrl="~/Common/AdminDisplayCOMN_Nationality.aspx"
                            Text="View Nationality"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink17" runat="server" NavigateUrl="~/HR/AdminHR_ProvidentfundRules.aspx"
                            Text="Add Provident Fund Rules"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink18" runat="server" NavigateUrl="~/HR/AdminDisplayHR_ProvidentfundRules.aspx"
                            Text="View Provident Fund Rules"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink19" runat="server" NavigateUrl="~/HR/AdminHR_Package.aspx"
                            Text="Add Salarly Package"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink20" runat="server" NavigateUrl="~/HR/AdminDisplayHR_Package.aspx"
                            Text="View Salarly Package"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink21" runat="server" NavigateUrl="~/HR/AdminHR_SalaryTaxPackage.aspx"
                            Text="Add Salarly Tax Package"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink22" runat="server" NavigateUrl="~/HR/AdminDisplayHR_SalaryTaxPackage.aspx"
                            Text="View Salarly Tax Package"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink23" runat="server" NavigateUrl="~/HR/AdminHR_BenifitPackage.aspx"
                            Text="Add Benefit Package"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink24" runat="server" NavigateUrl="~/HR/AdminDisplayHR_BenifitPackage.aspx"
                            Text="View Benefit Package"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink25" runat="server" NavigateUrl="~/HR/AdminHR_OverTimePackage.aspx"
                            Text="Add Over Time Package"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink26" runat="server" NavigateUrl="~/HR/AdminDisplayHR_OverTimePackage.aspx"
                            Text="View Over Time Package"></asp:HyperLink>
                    </td>
                </tr>
                <%--<tr>
                <td>  <asp:HyperLink ID="HyperLink27" runat="server" NavigateUrl="~/HR/AdminHR_EmployeeOverTimePackage.aspx"
                            Text="Employee Over Time "></asp:HyperLink></td>
                <td>  <asp:HyperLink ID="HyperLink28" runat="server" NavigateUrl="~/HR/AdminDisplayHR_EmployeeOverTimePackage.aspx"
                            Text="View Employee Over Time"></asp:HyperLink></td>
                </tr>--%>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink29" runat="server" NavigateUrl="~/HR/AdminHR_SalaryIncrementPackage.aspx"
                            Text="Add Salary Increment Package"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink30" runat="server" NavigateUrl="~/HR/AdminDisplayHR_SalaryIncrementPackage.aspx"
                            Text="View Salary Increment Package"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink31" runat="server" NavigateUrl="~/HR/AdminHR_SalaryAdjustmentList.aspx"
                            Text="Add Salary Adjustment List"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink32" runat="server" NavigateUrl="~/HR/AdminDisplayHR_SalaryAdjustmentList.aspx"
                            Text="View Salary Adjustment List"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink27" runat="server" NavigateUrl="~/HR/AdminHR_ProvidentFundSetup.aspx"
                            Text="Add Service Length wise PF Setup"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink28" runat="server" NavigateUrl="~/HR/AdminDisplayHR_ProvidentFundSetup.aspx"
                            Text="View Service Length wise PF Setup"></asp:HyperLink>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
