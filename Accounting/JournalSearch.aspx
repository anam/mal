<%@ Page Title="Search Journal" Language="C#" MasterPageFile="~/Site2Column.master"
    AutoEventWireup="true" CodeFile="JournalSearch.aspx.cs" Inherits="Accounting_JournalSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link rel="stylesheet" type="text/css" href="../App_Themes/CoffeyGreen/css/grid.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel ID="upSeachJournal" runat="server">
        <ContentTemplate>
            <div class="content-box">
                <div class="header">
                    <h3>
                        Search Journal</h3>
                </div>
                <div class="inner-content">
                    <table width="100%">
                        <colgroup>
                            <col width="10%" />
                            <col width="15%" />
                            <col width="10%" />
                            <col width="15%" />
                            <col width="10%" />
                            <col width="15%" />
                            <col width="10%" />
                        </colgroup>
                        <tr>
                            <td>
                                From :
                            </td>
                            <td>
                                <asp:TextBox ID="txtFromDate" runat="server" CssClass="txt large-input"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="ajcalFrom" runat="server" TargetControlID="txtFromDate">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                            <td>
                                To :
                            </td>
                            <td>
                                <asp:TextBox ID="txtTo" runat="server" CssClass="txt large-input"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="ajcalTo" runat="server" TargetControlID="txtTo">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                            <td>
                                No:
                            </td>
                            <td>
                                <asp:TextBox ID="txtJournalMaster" runat="server" CssClass="txt large-input"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="ajFT" runat="server" FilterType="Numbers"
                                    TargetControlID="txtJournalMaster">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                            <td>
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="button button-blue"
                                    OnClick="btnSearch_OnClick" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="content-box">
                <div class="header">
                    <h3>
                        Search Result</h3>
                </div>
                <div class="inner-content">
                 
                    <asp:GridView ID="gvACC_JournalMaster" class="gridCss" runat="server" AutoGenerateColumns="false"
                        CssClass="tabel_input" OnRowDataBound="JournalMaster_OnRowDataBound">
                        <HeaderStyle CssClass="heading" />
                        <RowStyle CssClass="row" />
                        <AlternatingRowStyle CssClass="altrow" />
                        <Columns>
                            <asp:TemplateField HeaderText="No">
                                <ItemTemplate>
                                    <a href='<%#"VoucherPage.aspx?JournalMasterID=" + Eval("JournalMasterID") %>' target="_blank" style="text-decoration:underline" ><%#Eval("JournalMasterID") %></a>
                                    
                                     <asp:Label ID="lblJournalID" Text='<%#Eval("JournalMasterID") %>' runat="server" Visible="false"></asp:Label>                                   
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate" runat="server" Text='<%#Eval("AddedDate","{0:dd MMM yyyy}") %>'>
 	                        </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <table>
                                        <tr>
                                            <th style="width: 63%; border-right: solid 1px #ccc">
                                                Head Name
                                            </th>
                                            <th style="width: 17%; border-right: solid 1px #ccc">
                                                Debit
                                            </th>
                                            <th style="width: 17%">
                                                Credit
                                            </th>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:GridView ID="gvACC_Journal" class="gridCss" runat="server" AutoGenerateColumns="false"
                                        CssClass="tabel_input" >
                                        <HeaderStyle CssClass="headingInner" />
                                        <RowStyle CssClass="row" />
                                        <AlternatingRowStyle CssClass="altrow" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Head">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblHeadID" runat="server" Text='<%#Eval("HeadName") %>'>
 	                                                            </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Debit">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDebit" runat="server" Text='<%#Eval("Debit") %>'>
 	                                                                </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Credit">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCredit" runat="server" Text='<%#Eval("Credit") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete" Visible="false">
                                <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="lbDelete" CommandArgument='<%#Eval("JournalMasterID") %>'
                                OnClick="lbDelete_Click" AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <div style="color: Red; font-weight: bold">
                                <h2>
                                    Journal Master is not avaiable</h2>
                            </div>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
