<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminSTD_Course.aspx.cs" Inherits="AdminSTD_Course" Title="Course" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Course</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="lblCourseName" runat="server" Text="Course Name: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtCourseName" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblDescription" runat="server" Text="Description: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtDescription" TextMode="MultiLine" class="txt textarea" runat="server"
                        Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblDuration" runat="server" Text="Duration: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtDuration" class="txt small-input" runat="server" Text="5"> 
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblCost" runat="server" Text="Cost: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtCost" class="txt small-input" runat="server" Text="1000">
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
