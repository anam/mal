<%@ Page Title="List Of Employee" Language="C#" MasterPageFile="~/Site2Column.master" AutoEventWireup="true"
    CodeFile="HR_EmployeeShortNameEntry.aspx.cs" Inherits="HR_HR_EmployeeShortNameEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="divListOfEmployee" class="content-box">
        <div class="header">
            <h3>
                List Of Employee</h3>
        </div>
        <div class="inner-content">
            <asp:GridView ID="gvHR_Employee" class="gridCss" runat="server" AutoGenerateColumns="false"
                CssClass="tabel_input">
                <HeaderStyle CssClass="heading" />
                <RowStyle CssClass="row" />
                <AlternatingRowStyle CssClass="altrow" />
                <Columns>
                    <asp:TemplateField HeaderText="Emp ID">
                        <ItemTemplate>
                            <asp:Label ID="lblEmployeeNo" runat="server" Text='<%#Eval("EmployeeNo") %>'>
                            </asp:Label>
                            <asp:Label ID="lblEmployeeID" runat="server" Text='<%#Eval("EmployeeID") %>' Visible="false">
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="lblEmployeeName" runat="server" Text='<%#Eval("EmployeeName") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Photo">
                        <ItemTemplate>
                            <asp:Label ID="lblPhoto" Visible="false" runat="server" Text='<%#Eval("Photo")%>'>
                            </asp:Label>
                            <asp:HyperLink runat="server" ID="lblEmployerView" NavigateUrl='<%#String.Format("~/HR/AdminHR_EmployeeDetails.aspx?ID={0}", Eval("EmployeeID"))%>'>
                                <asp:Image runat="server" ID="imgPhoto" ImageUrl='<%#String.Format("~/HR/upload/employeer/{0}", Eval("Photo")) %>' ImageAlign="Middle"
                                    Width="75" Height="75" />
                            </asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Short Name">
                        <ItemTemplate>
                            <asp:TextBox ID="txtShortName" Text='<%#Eval("ExtraField1") %>' runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nick Name">
                        <ItemTemplate>
                            <asp:TextBox ID="txtNickName" Text='<%#Eval("ExtraField2") %>' runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <div style="width:70%; margin:0px auto; margin-top:20px">
                <asp:Button ID="btnUpdate" Text="Update" runat="server" CssClass="button button-blue" OnClick="btnUpdate_OnClick" />
            </div>
        </div>
    </div>
</asp:Content>
