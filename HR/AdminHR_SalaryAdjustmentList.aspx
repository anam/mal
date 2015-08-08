<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminHR_SalaryAdjustmentList.aspx.cs" Inherits="AdminHR_SalaryAdjustmentList"
    Title="Salary Adjustment List" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Salary Adjustment List</h3>
        </div>
        <div>
            <dl>
                <dt>
                    <asp:Label ID="Label1" runat="server" Text="Adjustment Group Name: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtAdjustmentGroupName" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt></dt>
                <dd>
                    <asp:Button ID="btnAddGroup" class="button button-blue" runat="server" Text="Add"
                        OnClick="btnAddGroup_Click" />
                </dd>
            </dl>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="Label2" runat="server" Text="Group Name: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlAdjustmentGroup" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblName" runat="server" Text="Adjustment Name: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtName" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblValue" runat="server" Text="Adjustment Value: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtValue" class="txt large-input" runat="server" Text="">
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
