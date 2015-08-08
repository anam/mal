<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="Copy of AdminSTD_RoutineTime.aspx.cs" Inherits="AdminSTD_RoutineTime" Title="Class RoutineTime" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Class RoutineTime</h3>
        </div>
        <div class="inner-form">
            <dl>
                <dt>
                    <asp:Label ID="lblRoutineTimeName" runat="server" Text="Routine Time Name: "></asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtRoutineTimeName" class="txt medium-input" runat="server" Text=""></asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblRoomID" runat="server" Text="Room: "></asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlRoomID" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblSubjectID" runat="server" Text="Subject: "></asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlSubjectID" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblEmployeeID" runat="server" Text="Employee: "></asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlEmployeeID" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblClassID" runat="server" Text="Class: "></asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlClassID" runat="server">
                    </asp:DropDownList>
                </dd>
                <%--<dt>
                    <asp:Label ID="lblClassDayID" runat="server" Text="Class Day: "></asp:Label>
                </dt>--%>
                <%--<dd>
                    <asp:DropDownList ID="ddlClassDayID" runat="server">
                    </asp:DropDownList>
                </dd>--%>
                <%--<dt>
                    <asp:Label ID="lblClassTimeID" runat="server" Text="Class Time: "></asp:Label>
                </dt>--%>
                <%--<dd>
                    <asp:DropDownList ID="ddlClassTimeID" runat="server">
                    </asp:DropDownList>
                    
                </dd>--%>
                <dt>Class Day And Time</dt>
                <dd>
                    <asp:GridView ID="gvClassDay" runat="server" AutoGenerateColumns="false" ShowHeader="false"
                        GridLines="None" Width="100%" OnRowDataBound="OnRowDataBound_gvClassDay">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label ID="lblDay" Text='<%#Eval("ClassDayName")%>' runat="server" Font-Bold="true" Font-Size="18px"></asp:Label>
                                    <asp:Label ID="lblDayID" Text='<%#Eval("ClassDayID")%>' runat="server" Visible="false"></asp:Label>
                                    <br />
                                    <asp:CheckBoxList ID="chkClassTime" runat="server" RepeatColumns="3" CellPadding="20"
                                        Width="100%" CellSpacing="10">
                                    </asp:CheckBoxList><br />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </dd>
                <dt>
                    <asp:Label ID="lblRoutineID" runat="server" Text="Routine: "></asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlRoutineID" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label></dt>
                <dd>
                    <asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Add" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnUpdate" class="button button-blue" runat="server" Text="Update"
                        OnClick="btnUpdate_Click" Visible="false" />
                </dd>
            </dl>
        </div>
    </div>
</asp:Content>
