<%@ Page Title="" Language="C#" MasterPageFile="~/Site2Column.master" AutoEventWireup="true" CodeFile="IncomeStatement.aspx.cs" Inherits="Accounting_IncomeStatement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<style type="text/css">
    td{text-align:right;border:1px solid black;}
    .Account_Head{text-align:left;width:200px;}
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div class="content-box">
    <div class="header">
        <h3>
            Income Statement
        </h3>            
    </div>
    <div class="inner-form" style="overflow:scroll">
        <dl>
            <dt>From</dt><dd><asp:DropDownList ID="ddlMonthsFrom" runat="server"></asp:DropDownList>&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlYearsFrom" runat="server"></asp:DropDownList></dd>
            <dt>To</dt><dd><asp:DropDownList ID="ddlMonthsTo" runat="server"></asp:DropDownList>&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlYearsTo" runat="server"></asp:DropDownList></dd>
            <dt>&nbsp;</dt><dd><asp:CheckBox ID="chkShowCompanyDevelopmentFund" runat="server" Text="With Company Development Fund?"/></dd>
            <dt>&nbsp;</dt>
            <dd>
                <asp:Button ID="btnSearch" runat="server" Text="Search" onclick="btnSearch_Click" />
                <asp:Label ID="lblPrint" runat="server" Text=""></asp:Label>
            </dd>
            <%--<dt></dt><dd></dd>
            <dt></dt><dd></dd>
            <dt></dt><dd></dd>
            <dt></dt><dd></dd>--%>
        </dl>
        <div>
            <asp:Label ID="lblIncomeStatement" runat="server" Text=""></asp:Label>
            <%--<asp:GridView ID="GridView1" runat="server">
            </asp:GridView>--%>
        </div>
    </div>
</div>

</asp:Content>

