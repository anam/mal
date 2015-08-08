<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminSTD_Subject.aspx.cs" Inherits="AdminSTD_Subject" Title="Subject" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Subject</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="lblCourseID" runat="server" Text="Course: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlCourseID" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblSubjectName" runat="server" Text="Subject Name: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtSubjectName" class="txt medium-input" runat="server" Text="">
                         </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblPassMark" runat="server" Text="Pass Mark(%): ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtPassMark" class="txt medium-input" runat="server" Text="60">
                         </asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="ajfe" runat="server" TargetControlID="txtPassMark"
                        FilterType="Numbers">
                    </ajaxToolkit:FilteredTextBoxExtender>
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
