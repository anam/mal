<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2ColumnCommon.master"
    CodeFile="AdminCOMN_PersonalDocuments.aspx.cs" Inherits="AdminCOMN_PersonalDocuments"
    Title="Personal Documents" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Personal Documents</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="lblUserID" runat="server" Text="User: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlUserID" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblFileName" runat="server" Text="File Name: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtFileName" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblFileLocationUrl" runat="server" Text="File Location Url: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtFileLocationUrl" class="txt large-input" runat="server" Text="">
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
