<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminHR_AbsentSalaryDiduction.aspx.cs" Inherits="AdminDisplayHR_Bank" Title="HR_Bank Insert/Update By Admin" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        
        
    <div class="content-box">
        <div class="header">
            <h3>
                Absent Salary Insert / Edit</h3>
        </div>
        <div class="inner-content">
            <dl>
                <dt>
                </dt>
                <dd>
                </dd>
            </dl>
            <div class="tableCss">
        <dl>
                <dt>
                    <asp:Label ID="lblEmployeeID" runat="server" Text="EmployeeID: ">
                    </asp:Label>
              </dt>
                <dd>
                    <asp:DropDownList ID="ddlEmployee" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblSalaryOfMonth" runat="server" Text="SalaryOfMonth: ">
                    </asp:Label>
                </dt>
                <dd>
                     <asp:DropDownList ID="ddlMonths" runat="server">
                            </asp:DropDownList>                           
                            &nbsp;&nbsp;
                             <asp:DropDownList ID="ddlYears" runat="server">
                            </asp:DropDownList>
               </dd>
                <dt>
                    <asp:Label ID="lblNoOfDays" runat="server" Text="NoOfDays: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtNoOfDays" runat="server" Text=""  AutoPostBack="true"
                        ontextchanged="txtNoOfDays_TextChanged">
                    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblTotalSalary" runat="server" Text="TotalSalary: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtTotalSalary" runat="server" Text="" Enabled="false">
                    </asp:TextBox>
               </dd>
                <dt>
                    <asp:Label ID="lblSalaryDeduction" runat="server" Text="SalaryDeduction: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtSalaryDeduction" runat="server" Text="">
                    </asp:TextBox>
                </dd>
                
                <dt>
                   &nbsp;
                </dt>
                <dd>
                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" 
                        OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
                </dd>
                </dl>
        
    </div>
        </div>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
