<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UCEmployeeInfo.ascx.cs"
    Inherits="HR_Control_UCEmployeeInfo" %>
    <style type="text/css">
    .imageEmployee
    {
    	border:1px solid #e3e3e3;
    	padding:3px;
    }
    </style>
<h4 style="width: 100%; line-height: 18px; font-size: 14px; padding-bottom: 2px; margin-bottom:10px;
    color: #5772BD; border-bottom: 1px solid #5772BD;">
    Employee Information</h4>
<table width="100%" border="0" align="center" class="tablefont">
    <tr>
        <td align="right">
            Employee Rank
        </td>
        <td>
            &nbsp;
            <asp:Label ID="lblEmployeeRank" runat="server" Text=""></asp:Label>
        </td>
        <td align="right" valign="top" rowspan="4">
            &nbsp;
        </td>
        <td align="right" valign="top" rowspan="4">
            <%-- ~/App_Themes/CoffeyGreen/images/NoImage.jpg--%>
            <asp:Image runat="server" Height="150px" CssClass="imageEmployee" ImageUrl="" Width="130px" ID="imgEmployee" />
        </td>
    </tr>
    <tr>
        <td width="23%" align="right">
            Department Name
        </td>
        <td width="27%">
            &nbsp;
            <asp:Label ID="lblDepartmentName" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td width="23%" align="right">
            Employee ID
        </td>
        <td width="27%">
            &nbsp;
            <asp:Label ID="lblEmployeeID" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">
            Father's Name
        </td>
        <td>
            &nbsp;
            <asp:Label ID="lblFathersName" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">
            Husband/Wife Name
        </td>
        <td>
            &nbsp;
            <asp:Label ID="lblSpouseName" runat="server" Text=""></asp:Label>
        </td>
        <td align="right" valign="top">
            Mothers Name
        </td>
        <td align="left" valign="top">
            &nbsp;
            <asp:Label ID="lblMothersName" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">
            Date Of Birth
        </td>
        <td>
            &nbsp;
            <asp:Label ID="lblDateOfBirth" runat="server" Text=""></asp:Label>
        </td>
        <td align="right" valign="top">
            Place of Birth
        </td>
        <td align="left" valign="top">
            &nbsp;
            <asp:Label ID="lblPlaceOfBirth" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td height="19" align="right">
            Blood Group
        </td>
        <td>
            &nbsp;<label>
            </label>
            <asp:Label ID="lblBloodGroupName" runat="server" Text=""></asp:Label>
        </td>
        <td align="right" valign="top">
            Gender
        </td>
        <td align="left" valign="top">
            &nbsp;
            <label>
            </label>
            <asp:Label ID="lblGender" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td height="18" align="right">
            Religion
        </td>
        <td>
            &nbsp;
            <asp:Label ID="lblReligionName" runat="server" Text=""></asp:Label>
        </td>
        <td align="right" valign="top">
            Maritual Status
        </td>
        <td align="left" valign="top">
            &nbsp;
            <asp:Label ID="lblMaritualStatusName" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td height="18" align="right">
            Nationality
        </td>
        <td>
            &nbsp;
            <asp:Label ID="lblNationalityName" runat="server" Text=""></asp:Label>
        </td>
        <%--<td align="right" valign="top">
            Photo
        </td>
        <td align="left" valign="top">
            <label>
                &nbsp;
            </label>
            <asp:Label ID="lblPhoto" runat="server" Text=""></asp:Label>
        </td>--%>
    </tr>
    <tr>
        <td align="right">
            Address
        </td>
        <td colspan="3">
            &nbsp;<label>
            </label>
            <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
        </td>
    </tr>
</table>
