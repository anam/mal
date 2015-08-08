<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminHR_SalaryIncrementPackage.aspx.cs" Inherits="AdminHR_SalaryIncrementPackage"
    Title="Salary Increment Package" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Salary Increment Package</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="lblSalaryIncrementPackageName" runat="server" Text="Increment Package Name: "> </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtSalaryIncrementPackageName" class="txt large-input" runat="server"
                        Text=""></asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblSalaryIncrementFormula" runat="server" Text="Salary Increment Value(%): "></asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtSalaryIncrementFormula" class="txt large-input" runat="server"
                        Text=""></asp:TextBox>
                </dd>
                <dt></dt>
                <dd>
                    <label></label></dd>
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
