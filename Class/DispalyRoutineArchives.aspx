<%@ Page Language="C#" MasterPageFile="~/Site2Column.master" AutoEventWireup="true"
    CodeFile="DispalyRoutineArchives.aspx.cs" Inherits="Class_Class_Display_RoutineTime_ByValues"
    Title="Search Routine" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
    <div class="content-box">
        <div class="header">
            <h3>
                Routine Archive</h3>
        </div>
        <div class="inner-form-search">
            Date Archived:<asp:DropDownList ID="ddlArchivedDate" runat="server"  AutoPostBack="true"
                onselectedindexchanged="ddlArchivedDate_SelectedIndexChanged">
                </asp:DropDownList>
            <asp:Label ID="lblLinkToprint" runat="server" Text=""></asp:Label>
          </div>  
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
