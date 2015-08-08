<%@ Page Title="Teacher Money Receit" Language="C#" MasterPageFile="~/Site2Column.master" AutoEventWireup="true" CodeFile="ViewTeacherMoneyReceit.aspx.cs" Inherits="Accounting_ViewTeacherMoneyReceit" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="content-box">
        <div class="header">
            <h3>Teacher Money Receit</h3>
        </div>
       <div style="width: 98%; margin: 0px auto; min-height: 350px; overflow: scroll">
            <CR:CrystalReportViewer ID="crvTeacherMoneyReceit" runat="server" AutoDataBind="true"
                ToolPanelView="None" HasCrystalLogo="False" />
        </div>
    </div>
</asp:Content>

