<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master" CodeFile="AdminHR_ProvidentFundProvisionProcess.aspx.cs" Inherits="AdminHR_ProvidentFundProvisionProcess" Title="Provident Fund Provision Process" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="content-box">
                <div class="header">
                    <h3>
                        Provident Fund Provision Process</h3>
                </div>
                <div class="inner-form">
                    <!-- error and information messages -->
                                                              
                    <div>                        
                             <asp:Button ID="btnPFProvision" runat="server" class="button button-blue"
                            Text="PF Provision upto date" OnClick="btnPFProvision_OnClick" />                                                   
                    </div>
                    <div>
                        <asp:GridView ID="gvPFProvision" Style="font-size: small;" Width="95%"
                            runat="server" AutoGenerateColumns="false"  CssClass="tabel_input"
                            ShowFooter="True">
                            <HeaderStyle CssClass="heading" />
                            <RowStyle CssClass="row" />
                            <AlternatingRowStyle CssClass="altrow" />
                            <FooterStyle CssClass="txtRightDisplay" />
                            <Columns>
                                
                                <asp:TemplateField HeaderText="Employee No" ItemStyle-CssClass ="txtLeftDisplay">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmployeeNo" runat="server" Text='<%#Eval("EmployeeNo") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Employee Name" ItemStyle-CssClass ="txtLeftDisplay">
                                    <ItemTemplate>                                        
                                        <asp:Label ID="lblEmployeeName" runat="server" Text='<%#Eval("EmployeeName") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="ServiceLength" ItemStyle-CssClass ="txtLeftDisplay">
                                    <ItemTemplate>                                        
                                        <asp:Label ID="lblServiceLength" runat="server" Text='<%#Eval("ServiceLength") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="EPF" ItemStyle-CssClass="txtRightDisplay">
                                    <ItemTemplate>                                        
                                        <asp:Label ID="lblEPF" runat="server"  Text='<%#Eval("EPF") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="CPF" ItemStyle-CssClass="txtRightDisplay">
                                    <ItemTemplate>                                        
                                        <asp:Label ID="lblCPF" runat="server"  Text='<%#Eval("CPF") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Total Amount" ItemStyle-CssClass="txtRightDisplay">
                                    <ItemTemplate>                                        
                                        <asp:Label ID="lblTotalAmount" runat="server"   Text='<%#Eval("TotalAmount") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                                                                                
                                <asp:TemplateField HeaderText="Owner Of Fund" ItemStyle-CssClass="txtRightDisplay">
                                    <ItemTemplate>
                                        <asp:Label ID="lblOwnerOfFund" runat="server"  Text='<%#Eval("OwnerOfFund") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <div style="text-align: right; padding-right: 5px;">
                                            <asp:Label ID="lblPFProvisionAmount" runat="server" Font-Bold="True"></asp:Label>
                                        </div>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                                                                                
                            </Columns>
                        </asp:GridView>
                    </div>
                    
                    <div style="width: 100%; padding: 20px 0; overflow: hidden;">
                        <asp:Literal ID="litSummary" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
