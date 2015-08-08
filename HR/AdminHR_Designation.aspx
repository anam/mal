<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminHR_Designation.aspx.cs" Inherits="AdminHR_Designation" Title="Designation" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Designation</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="lblDesignationName" runat="server" Text="Designation Name: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtDesignationName" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblDepartmentID" runat="server" Text="Department: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlDepartmentID" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblSupervisor" runat="server" Text="Supervisor: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtSupervisor" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblJobResponsibility" runat="server" Text="Job Responsibility: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtJobResponsibility" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
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
