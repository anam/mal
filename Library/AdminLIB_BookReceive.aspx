<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminLIB_BookReceive.aspx.cs" Inherits="AdminLIB_BookReceive" Title="Libray Book Receive" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Library Book Receive</h3>
        </div>
      <div class="inner-form">
            <!-- error and information messages -->
            <div>
            <asp:Label ID ="messageIssue" runat = "server" ></asp:Label>
            </div>
            <dl>
                <dt>
                    <asp:Label ID="lblBookID" runat="server" Text="Book: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlBookID" runat="server" class="txt medium-input">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblIsStudent" runat="server" Text="Is Student: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:RadioButtonList ID="radIsStudent" runat="server" RepeatDirection="Horizontal"
                        AutoPostBack="true" class="txt medium-input" OnSelectedIndexChanged="radIsStudent_SelectedIndexChanged">
                        <asp:ListItem Selected="True">Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:RadioButtonList>
                </dd>
                <dt>
                    <asp:Label ID="lblIssedToID" runat="server" Text="Issued To: " class="txt medium-input">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlIssedToID" runat="server" class="txt medium-input">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <%--style="display: none;"--%>
                    <asp:Label ID="lblIssueDate" runat="server" Text="Issue Date: ">
                    </asp:Label>
                </dt>
                <dd>
                <%--class="txt large-input"--%>
                    <asp:TextBox ID="txtIssueDate"  runat="server" Text="" class="txt medium-input">
                    </asp:TextBox>
                    <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID = "calIssueDate" runat = "server" Format = "dd MMM yyyy" TargetControlID = "txtIssueDate"></ajaxToolkit:CalendarExtender>
                     <asp:RequiredFieldValidator ID="rfvEmployeeName" runat="server" SetFocusOnError="true"
                        Display="Dynamic" ControlToValidate="txtIssueDate" ErrorMessage="Issue Date is not empty"
                        Text="*" ForeColor="Red" ValidationGroup="bookIssueGroup"></asp:RequiredFieldValidator>
                </dd>
                <dt>
                    <asp:Label ID="lblReturnDate" runat="server" Text="Return Date: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtReturnDate" runat="server" Text="" class="txt medium-input">
                    </asp:TextBox>
                     <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID = "calReturnDate" runat = "server" Format = "dd MMM yyyy" TargetControlID = "txtReturnDate"></ajaxToolkit:CalendarExtender>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" SetFocusOnError="true"
                        Display="Dynamic" ControlToValidate="txtReturnDate" ErrorMessage="Return Date is not empty"
                        Text="*" ForeColor="Red" ValidationGroup="bookIssueGroup"></asp:RequiredFieldValidator>
                </dd>
                <dt></dt>
                <dd>
                    <asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Issue" ValidationGroup ="bookIssueGroup"  OnClick="btnAdd_Click" />
                    <asp:Button ID="btnUpdate" class="button button-blue" runat="server" Text="Update" ValidationGroup ="bookIssueGroup" 
                        OnClick="btnUpdate_Click" Visible="false" />
                </dd>
            </dl>
        </div>
    </div>
    
</asp:Content>
