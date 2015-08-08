<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminSTD_Exam.aspx.cs" Inherits="AdminSTD_Exam" Title="Insert /Update Exam" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Insert /Update Exam</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="lblClassID" runat="server" Text="Class: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlClassID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlClassID_OnSelectedIndexChanged">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblSubject" runat="server" Text="Subject: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlSubjectID" runat="server">
                    </asp:DropDownList>
                </dd>
                
                <dt>
                    <asp:Label ID="lblExamTypeID" runat="server" Text="Exam Type: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlExamTypeID" runat="server">
                    </asp:DropDownList>
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
