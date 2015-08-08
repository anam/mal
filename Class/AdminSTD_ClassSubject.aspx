<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminSTD_ClassSubject.aspx.cs" Inherits="AdminSTD_ClassSubject" Title="Add/Update Class Subject" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Add/Update Class Subject</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="lblClassSubjectName" runat="server" Text="Class Subject Name: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtClassSubjectName" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblSubjectID" runat="server" Text="Subject: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlSubjectID" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblClassID" runat="server" Text="Class: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlClassID" runat="server">
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
