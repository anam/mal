<%@ Page Title="" Language="C#" MasterPageFile="~/Site2Column.master" AutoEventWireup="true"
    CodeFile="SearchLIB_IssueBook.aspx.cs" Inherits="SearchLIB_Book" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 315px;
        }
        .style2
        {
            width: 176px;
        }
        .style3
        {
            width: 150px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
    <div class="content-box">
        <div class="header">
            <h3>
                Show Book</h3>
        </div>
        <div style="padding-bottom:20px;">
            <table style="width: 100%; height: 31px;">
                <tr>
                    <td class="style41">
                        &nbsp;
                    </td>
                    <td class="style40">
                        &nbsp;
                    </td>
                    <td class="style1" colspan="2">
                        &nbsp;
                        <asp:Label ID="txtMsg" runat="server" ForeColor="#009900"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblPrint" runat="server"></asp:Label>
                    </td>
                    <td class="style21" width="130px">
                        <asp:DropDownList ID="DDPrintOpt" runat="server" Font-Names="Tahoma" Style="font-size: 11px"
                            Width="130px">
                            <asp:ListItem Selected="True" Value="PDF">Adobe Acrobat (PDF)</asp:ListItem>
                            <asp:ListItem Value="HTML">HTML</asp:ListItem>
                            <asp:ListItem Value="WORD">MS Word</asp:ListItem>
                            <asp:ListItem Value="EXCEL">MS Excel</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="style26" align="right">
                        &nbsp;
                    </td>
                    <td>
                        <asp:LinkButton ID="lnkPrint" runat="server" CssClass="button" Font-Size="12px" Height="20px"
                            OnClick="lnkPrint_Click">PRINT</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td class="style41">
                        &nbsp;
                    </td>
                    <td style="text-align:right;">
                        Search String : &nbsp;
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="txtBookSearch" runat="server" Width="200px"></asp:TextBox>

                        <asp:TextBoxWatermarkExtender ID="txtBookSearch_TextBoxWatermarkExtender" 
                            runat="server" Enabled="True" WatermarkText="Book Name,Book ID" TargetControlID="txtBookSearch">
                        </asp:TextBoxWatermarkExtender>

                    </td>
                    <td class="style3">&nbsp;&nbsp;
                        <asp:LinkButton ID="lnkBtnShow" runat="server" BackColor="#336600" ForeColor="White"
                            OnClick="lnkBtnShow_Click" Width="40px">Show</asp:LinkButton>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td class="style21" width="130px" align="center">
                        &nbsp;
                    <asp:Label ID="lbljavascript" runat="server"></asp:Label>
                    </td>
                    <td class="style26" align="right">
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
            <div class="inner-content">
                <asp:GridView ID="gvLIB_Book" runat="server" AutoGenerateColumns="false"
                    CssClass="tabel_input">
                    <HeaderStyle CssClass="heading" />
                    <RowStyle CssClass="row" />
                    <AlternatingRowStyle CssClass="altrow" />
                    <Columns>
                        <asp:TemplateField HeaderText="Book ID">
                            <ItemTemplate>
                                <asp:Label ID="lblBookID" runat="server" Text='<%#Eval("BookID") %>'>
 	                            </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Book Name">
                            <ItemTemplate>
                                <asp:Label ID="lblBookName" runat="server" Text='<%#Eval("BookName") %>'>
 	                            </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>                       
                        <asp:TemplateField HeaderText="Author Name">
                            <ItemTemplate>
                                <asp:Label ID="lblAuthorID" runat="server" Text='<%#Eval("AuthorName") %>'>
 	                            </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Issue Date">
                            <ItemTemplate>
                                <asp:Label ID="lblPublishedYear" runat="server" Text='<%#Eval("IssueDate") %>'>
                                 <%--<asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("BookIssueID") %>' OnClick="lbDelete_Click">Receved</asp:LinkButton> --%>
 	                            </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                
                                 <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("BookIssueID") %>' OnClick="lbDelete_Click">Receive</asp:LinkButton>
 	                           
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        </div>
</asp:Content>
