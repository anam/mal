<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminDisplayHR_EmpWorkingDayShift.aspx.cs" Inherits="AdminDisplayHR_EmpWorkingDayShift" Title="Employee working time schedual" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Employee working time schedual</h3>
        </div>
        <div class="inner-content">
            <asp:GridView ID="gvWorkDayShift" class="gridCss" runat="server" AutoGenerateColumns="false">
                <HeaderStyle CssClass="heading" />
                <RowStyle CssClass="row" />
                <AlternatingRowStyle CssClass="altrow" />
                <Columns>
                    <asp:TemplateField HeaderText="Day">
                        <ItemTemplate>
                            <asp:Label ID="lblDay" runat="server" Text='<%#Eval("Days") %>'>
 	                        </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Start Time">
                        <ItemTemplate>
                            <asp:Label ID="lblStartTime" runat="server" Text='<%#Eval("StartTime") %>'>
 	                        </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="End Time">
                        <ItemTemplate>
                            <asp:Label ID="lblEndTime" runat="server" Text='<%#Eval("EndTime") %>'>
 	                        </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
