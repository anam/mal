<%@ Page Title="AttendantSheet" Language="C#" MasterPageFile="~/Site2Column.master"
    AutoEventWireup="true" CodeFile="AttendantSheet_ByValue.aspx.cs" Inherits="Student_AttendantSheet_ByValue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel ID="upAttendant" runat="server">
        <ContentTemplate>
            <div class="content-box">
                <div class="header">
                    <h3>
                        Generate Attendant
                        <asp:Label ID="lblParamName" runat="server"></asp:Label></h3>
                </div>
                <div class="inner-form-search">
                    <dl>
                        <dt>
                            <asp:Label ID="lblClassID" runat="server" Text="Class: ">
                            </asp:Label>
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlClassID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlClassID_OnSelectedIndexChanged">
                            </asp:DropDownList>
                        </dd>
                    </dl>
                    <dl>
                        <dt>
                            <asp:Label ID="lblSubject" runat="server" Text="Subject: ">
                            </asp:Label>
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlSubjectID" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSubjectID_SelectedIndexChanged">
                            </asp:DropDownList>
                        </dd>
                    </dl>
                    <dl>
                        <dt>
                            <asp:Label ID="lblTeacher" runat="server" Text="Teacher: ">
                            </asp:Label>
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlEmployeeID" runat="server">
                            </asp:DropDownList>
                        </dd>
                    </dl>
                    <dl>
                        <dt></dt>
                        <dd>
                            <asp:Button ID="btnShowAttendant" runat="server" Width="140px" Text="Generate Attendant"
                                class="button button-blue" OnClick="btnShowAttendant_Click" />
                        </dd>
                    </dl>
                </div>
                <div style="width: 780px; overflow: scroll;">
                    <asp:Label ID="lblRoutineDisplay" runat="server" Text=""></asp:Label></div>
                <div class="inner-content" id="dvAddRoutine" runat="server">
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
