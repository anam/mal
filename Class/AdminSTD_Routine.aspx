<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminSTD_Routine.aspx.cs" Inherits="AdminSTD_Routine" Title="Class Routine" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Class Routine</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="lblRoutineName" runat="server" Text="Routine of: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlCampus" runat="server" >
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblStartDate" runat="server" Text="Start Date: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtStartDate" class="txt small-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblEndDate" runat="server" Text="End Date: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtEndDate" class="txt small-input" runat="server" Text="">
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
