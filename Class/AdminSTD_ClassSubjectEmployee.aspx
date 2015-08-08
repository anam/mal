<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminSTD_ClassSubjectEmployee.aspx.cs" Inherits="AdminSTD_ClassSubjectEmployee"
    Title="Add/Update Class Subject Employee" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Add/Update Class Subject Employee</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="lblClassSubjectEmployeeName" runat="server" Text="Class Subject Employee Name: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtClassSubjectEmployeeName" class="txt large-input" runat="server"
                        Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblEmployeeID" runat="server" Text="Employee: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlEmployeeID" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblClassSubjectID" runat="server" Text="Class Subject: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlClassSubjectID" runat="server">
                    </asp:DropDownList>
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
