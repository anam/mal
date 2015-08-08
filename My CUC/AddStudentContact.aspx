<%@ Page Title="" Language="C#" MasterPageFile="~/Site2Column.master" AutoEventWireup="true"
    CodeFile="AddStudentContact.aspx.cs" Inherits="Student_AddStudentContact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel ID="upContact" runat="server">
        <ContentTemplate>
            <div class="content-box">
                <div class="header">
                    <h3>
                        Insert Student Contact Info</h3>
                </div>
                <div class="inner-form">
                    <!-- error and information messages -->
                    <dl>
                        <dt>
                            <asp:Label ID="lblName" runat="server" Text="Name: ">
    </asp:Label>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtName" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                        </dd>
                        <dt>
                            <asp:Label ID="lblCellNo" runat="server" Text="Cell No: ">
    </asp:Label>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtCellNo" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                        </dd>
                        <dt>
                            <asp:Label ID="lblOccupation" runat="server" Text="Occupation: ">
    </asp:Label>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtOccupation" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                        </dd>
                        <dt>
                            <asp:Label ID="lblOfficeTel" runat="server" Text="Office Tel: ">
    </asp:Label>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtOfficeTel" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                        </dd>
                        <dt>
                            <asp:Label ID="lblOfficeAddress" runat="server" Text="Office Address: ">
    </asp:Label>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtOfficeAddress" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                        </dd>
                        <dt>
                            <asp:Label ID="lblContactTypeID" runat="server" Text="Contact Type: ">
    </asp:Label>
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlContactTypeID" runat="server">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" InitialValue="0"
                                ErrorMessage="Select Contact Type" Text="*" ControlToValidate="ddlContactTypeID"
                                ValidationGroup="contact"></asp:RequiredFieldValidator>
                        </dd>
                        <dt></dt>
                        <dd>
                            <asp:Button ID="btnContactAdd" class="button button-blue" ValidationGroup="contact"
                                CausesValidation="true" runat="server" Text="Add" OnClick="btnContactAdd_Click" />
                            <asp:Button ID="btnContactUpdate" class="button button-blue" ValidationGroup="contact"
                                CausesValidation="true" runat="server" Text="Update" OnClick="btnContactUpdate_Click"
                                Visible="false" />
                            <asp:ValidationSummary ID="v02" runat="server" ShowMessageBox="true" ShowSummary="false"
                                ValidationGroup="contact" />
                        </dd>
                    </dl>
                </div>
            </div>
            <div class="content-box">
                <div class="header">
                    <h3>
                        Display Student Contact</h3>
                </div>
                <div class="inner-content">
                    <asp:GridView ID="gvSTD_Contact" class="gridCss" runat="server" AutoGenerateColumns="false"
                        CssClass="tabel_input">
                        <HeaderStyle CssClass="heading" />
                        <RowStyle CssClass="row" />
                        <AlternatingRowStyle CssClass="altrow" />
                        <Columns>
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'>
 	 </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cell No">
                                <ItemTemplate>
                                    <asp:Label ID="lblCellNo" runat="server" Text='<%#Eval("CellNo") %>'>
 	 </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Occupation">
                                <ItemTemplate>
                                    <asp:Label ID="lblOccupation" runat="server" Text='<%#Eval("Occupation") %>'>
 	 </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Office Tel">
                                <ItemTemplate>
                                    <asp:Label ID="lblOfficeTel" runat="server" Text='<%#Eval("OfficeTel") %>'>
 	 </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Office Address">
                                <ItemTemplate>
                                    <asp:Label ID="lblOfficeAddress" runat="server" Text='<%#Eval("OfficeAddress") %>'>
 	 </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contact Type">
                                <ItemTemplate>
                                    <asp:Label ID="lblContactTypeID" runat="server" Text='<%#Eval("ContactTypeName") %>'>
 	 </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" ID="lbSelectContact" CommandArgument='<%#Eval("ContactID") %>'
                                        AlternateText="Edit" OnClick="lbSelectContact_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                                    <asp:ImageButton runat="server" ID="lbDeleteContact" CommandArgument='<%#Eval("ContactID") %>'
                                        OnClick="lbDeleteContact_Click" AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="inner-content">
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="btnAdd" class="button button-blue" runat="server" CausesValidation="true"
                                    ValidationGroup="addStudent" Text="Save" OnClick="btnAdd_Click" />
                                <asp:ValidationSummary ID="vs01" runat="server" ShowMessageBox="true" ShowSummary="false"
                                    ValidationGroup="addStudent" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="inner-content">
                    <asp:GridView ID="gvStudentContact" class="gridCss" runat="server" AutoGenerateColumns="false"
                        CssClass="tabel_input">
                        <HeaderStyle CssClass="heading" />
                        <RowStyle CssClass="row" />
                        <AlternatingRowStyle CssClass="altrow" />
                        <Columns>
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'>
 	 </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cell No">
                                <ItemTemplate>
                                    <asp:Label ID="lblCellNo" runat="server" Text='<%#Eval("CellNo") %>'>
 	 </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Occupation">
                                <ItemTemplate>
                                    <asp:Label ID="lblOccupation" runat="server" Text='<%#Eval("Occupation") %>'>
 	 </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Office Tel">
                                <ItemTemplate>
                                    <asp:Label ID="lblOfficeTel" runat="server" Text='<%#Eval("OfficeTel") %>'>
 	 </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Office Address">
                                <ItemTemplate>
                                    <asp:Label ID="lblOfficeAddress" runat="server" Text='<%#Eval("OfficeAddress") %>'>
 	 </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contact Type">
                                <ItemTemplate>
                                    <asp:Label ID="lblContactTypeID" runat="server" Text='<%#Eval("ContactTypeName") %>'>
 	 </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnAdd" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:HiddenField ID="hfContactID" runat="server" />
    <asp:HiddenField ID="hfUserID" runat="server" />
</asp:Content>
