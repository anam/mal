<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminDisplayHR_LeaveType.aspx.cs" Inherits="AdminDisplayHR_EmployerType"
    Title="List of Existing Employee Type" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                List of Existing Leave Type</h3>
        </div>
        <div class="inner-content">
            <div>
                <asp:Button ID="btnAddEmployeeType" runat="server" class="button button-blue" Text="Add Employee Type"
                    OnClick="btnAddEmployeeType_OnClick" />
            </div>
             <asp:GridView ID="gvLeaveType" runat="server" AutoGenerateColumns="false" 
        CssClass="tabel_input">
                <HeaderStyle CssClass="heading" />
                <RowStyle CssClass="row" />
                <AlternatingRowStyle CssClass="altrow" />
            <Columns>
                
                <asp:TemplateField HeaderText="LeaveName">
                    <ItemTemplate>
                        <asp:Label ID="lblLeaveName" runat="server" Text='<%#Eval("LeaveName") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Edit /Delete">
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ID="lbSelect" CommandArgument='<%#Eval("LeaveTypeID") %>'
                                AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                            <asp:ImageButton runat="server" ID="lbDelete" OnClientClick="return confirm('Are You Sure, You Want To Delete?')"
                                CommandArgument='<%#Eval("LeaveTypeID") %>' OnClick="lbDelete_Click"
                                AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                        </ItemTemplate>
                    </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </div>
    </div>
</asp:Content>
