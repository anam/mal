<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminHR_EmployeeOverTimePackage.aspx.cs" Inherits="AdminHR_EmployeeOverTimePackage" Title="HR_OverTime Insert/Update By Admin" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Insert /UpdateHR_OverTime</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="lblOverTimeFlag" runat="server" Text="Over Time Flag: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:RadioButtonList ID="radOverTimeFlag" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Selected ="True" Value="True">Active</asp:ListItem>
                        <asp:ListItem Value="False">In Active</asp:ListItem>
                    </asp:RadioButtonList>
                </dd>
                <dt>
                    <asp:Label ID="lblOverTimePackID" runat="server" Text="Over Time Pack: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlOverTimePackID" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblOverTimeTakaPerHour" runat="server" Text="Over Time Taka Per Hour: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtOverTimeTakaPerHour" class="txt large-input" runat="server" Text="">
                    </asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterMode="ValidChars"
                                    ValidChars="0123456789." TargetControlID="txtOverTimeTakaPerHour">
                                </ajaxToolkit:FilteredTextBoxExtender>
                </dd>
                <dt>
                    <asp:Label ID="lblMonthlyTotalHour" runat="server" Text="Monthly Total Hour: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtMonthlyTotalHour" class="txt large-input" runat="server" Text="">
                    </asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="ftbMonthlyTotalHour" runat="server" FilterMode="ValidChars"
                                    ValidChars="0123456789" TargetControlID="txtMonthlyTotalHour">
                                </ajaxToolkit:FilteredTextBoxExtender>
                </dd>
                <dt></dt>
                <dd>
                    <asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Add" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnUpdate" class="button button-blue" runat="server" Text="Update"
                        OnClick="btnUpdate_Click" Visible="false" />
                </dd>
            </dl>
        </div>
    </div>
</asp:Content>
