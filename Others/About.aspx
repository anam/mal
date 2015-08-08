<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site2ColumnStudent.master" AutoEventWireup="true"
    CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
