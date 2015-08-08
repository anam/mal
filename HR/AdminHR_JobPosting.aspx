<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminHR_JobPosting.aspx.cs" Inherits="AdminHR_JobPosting" Title="HR_JobPosting Insert/Update By Admin" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Insert /UpdateHR_JobPosting</h3>
        </div>
        <div class="inner-form">
            <asp:ScriptManager ID="sm" runat="server">
            </asp:ScriptManager>
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="lblDepartmentID" runat="server" Text="Department: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlDepartmentID" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblDesignationID" runat="server" Text="Designation: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlDesignationID" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblJoinDate" runat="server" Text="Join Date: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtJoinDate" CssClass="txt small-input" runat="server" Text="">
                    </asp:TextBox>
                    <%--<ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="ajc" runat="server" TargetControlID="txtJoinDate">
                    </ajaxToolkit:CalendarExtender>--%>
                </dd>
                <dt>
                    <asp:Label ID="lblEndDate" runat="server" Text="End Date: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtEndDate" CssClass="txt small-input" runat="server" Text="">
                    </asp:TextBox>
                    <%--<ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="CalendarExtender1" runat="server" TargetControlID="txtEndDate">
                    </ajaxToolkit:CalendarExtender>--%>
                </dd>
                <dt>
                    <asp:Label ID="lblPostingStatus" runat="server" Text="Posting Status: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtPostingStatus" CssClass="txt medium-input" runat="server" Text="">
                    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblJobLocation" runat="server" Text="Job Location: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtJobLocation" CssClass="txt large-input" runat="server" Text="">
                    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblSupervisorID" runat="server" Text="Supervisor: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlSupervisorID" runat="server">
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
