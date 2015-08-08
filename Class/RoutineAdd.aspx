<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="RoutineAdd.aspx.cs" Inherits="AdminSTD_RoutineTime" Title="Add /Update Routine" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        
    <div class="content-box">
        <div class="header">
            <h3>
                Add /Update Routine</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="lblRoutineID" runat="server" Text="Routine: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlRoutineID" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblRoomID" runat="server" Text="Room: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlRoomID" runat="server">
                    </asp:DropDownList>
                </dd>
                <%-- <dt>
     <asp:Label ID="lblClassID" runat="server" Text="Class: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlClassID" runat="server">
     </asp:DropDownList>
     </dd>
    <dt>
     <asp:Label ID="lblSubjectID" runat="server" Text="Subject: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlSubjectID" runat="server">
     </asp:DropDownList>
     </dd>--%>
                <dt>
                    <asp:Label ID="lblClassSubjectEmployeeID" runat="server" Text="Class-Subject-Teacher: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlClassSubjectEmployeeID" runat="server">
                    </asp:DropDownList>
                </dd>
                <%--<dt>
     <asp:Label ID="lblEmployeeID" runat="server" Text="Employee: ">
    </asp:Label>
     </dt>

    <dd>
    <asp:DropDownList ID="ddlEmployeeID" runat="server">
     </asp:DropDownList>
     </dd>--%>
                <dt>
                    <asp:Label ID="lblClassDayID" runat="server" Text="Class Day: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlClassDayID" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblClassTimeID" runat="server" Text="Class Time: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlClassTimeID" runat="server">
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
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
