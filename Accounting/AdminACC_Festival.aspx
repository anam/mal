<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminACC_Festival.aspx.cs" Inherits="AdminDisplayHR_Bank" Title="HR_Bank Insert/Update By Admin" %>

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
                    <asp:DropDownList ID="ddlEmployee" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlEmployee_SelectedIndexChanged">
                    </asp:DropDownList>
                </dd>
                <%--<dt>
                    <asp:Label ID="lblSalaryOfMonth" runat="server" Text="SalaryOfMonth: ">
                    </asp:Label>
                </dt>
                <dd>
                     <asp:DropDownList ID="ddlMonths" runat="server">
                            </asp:DropDownList>                           
                            &nbsp;&nbsp;
                             <asp:DropDownList ID="ddlYears" runat="server">
                            </asp:DropDownList>
               </dd>--%>
                <dt>
                    <asp:Label ID="Label1" runat="server" Text="BobousType: ">
                    </asp:Label>
              </dt>
                <dd>
                    <asp:DropDownList ID="ddlBonous" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblNoOfDays" runat="server" Text="Apply %: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtNoOfDays" runat="server" Text="60"  AutoPostBack="true" 
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
                    <asp:Label ID="lblSalaryDeduction" runat="server" Text="Bonous: ">
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
                    <asp:Button ID="btnAdd" runat="server" Text="Pay" OnClick="btnAdd_Click"  class="button button-blue"/>
                    <asp:Button ID="btnUpdate" runat="server" Text="Update"  class="button button-blue"
                        OnClick="btnUpdate_Click" />
                        <a id="a_BounusList" runat="server"  class="button button-blue" target="_blank">Print All Employee Bonus List</a>
                    <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click"  class="button button-blue"/>
                </dd>
                </dl>
        
    </div>
        </div>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
