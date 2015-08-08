<%@ Page Title="Item Issue Entry" Language="C#" MasterPageFile="~/Site2Column.master"
    AutoEventWireup="true" CodeFile="AdminINV_ItemIssueEntryScreen.aspx.cs" Inherits="AdminINV_ItemIssueEntryScreen" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
    <div class="content-box ">

    <div class="header">
            <h3>
                Item Issue Details
            </h3>
        </div>
         <div class="inner-form">
             <div style="width: 100%; overflow: hidden; padding-top: 5px;">
             <asp:HiddenField ID ="hdnIssueMasterID" runat = "server" />
                 <asp:Label ID="lblRemark" runat="server" Text="Remark:" CssClass="targetCss">
                 </asp:Label>
                 <span style="width: 73%; float: right;">
                     <asp:TextBox ID="txtRemark" runat="server" CssClass="targetTxtBox">
                     </asp:TextBox>
                     </span>
             </div>
             <div style="width: 100%; overflow: hidden; padding-top: 5px;">
                 <asp:Label ID="lblIssueDate" runat="server" Text="Issue Date:" CssClass="targetCss"></asp:Label>
                 <span style="width: 73%; float: right;">
                     <asp:TextBox ID="txtIssueDate" runat="server" CssClass="targetTxtBox"></asp:TextBox>
                     <asp:CalendarExtender ID="txtIssueDate_CalendarExtender" runat="server" Enabled="True"
                         TargetControlID="txtIssueDate">
                     </asp:CalendarExtender>
                 </span>
             </div>
         </div>
         <div>
         &nbsp;
         </div>
        <div class="header">
            <h3>
                Item Issue Entry
            </h3>
        </div>
        <div class="inner-form">

        

            <%--<div style="float: right; width: 26%;">
                <asp:DropDownList ID="ddlAdobe" runat="server">
                    <asp:ListItem Selected="True" Value="PDF">Adobe Acrobat (PDF)</asp:ListItem>
                    <asp:ListItem Value="HTML">HTML</asp:ListItem>
                    <asp:ListItem Value="WORD">MS Word</asp:ListItem>
                    <asp:ListItem Value="EXCEL">MS Excel</asp:ListItem>
                </asp:DropDownList>
                <a style="float: right; color: Red; text-decoration: underline;" href="#">Print</a>
            </div>--%>
            <div style="width: 100%; overflow: hidden; padding-top: 5px;">
            <asp:HiddenField ID ="hdnIssueID" runat = "server" />
                <asp:Label ID="lblIssueNo" runat="server" Text="Issue No:" CssClass="targetCss"></asp:Label>
                <span style="width: 73%; float: right;">
                    <asp:TextBox ID="txtIssueNo" runat="server" CssClass="targetTxtBox" ReadOnly="True"
                        Enabled="False"></asp:TextBox>
                </span>
            </div>
            <div style="width: 100%; overflow: hidden;">
                <div style="width: 100%; overflow: hidden; padding-top: 5px;">
                    <asp:Label ID="lblStoreID" runat="server" Text="Store ID:" CssClass="targetCss"></asp:Label>
                    <span style="width: 73%; float: right;">
                        <asp:DropDownList ID="ddlStoreFromID" runat="server" AutoPostBack ="true" OnSelectedIndexChanged ="ddlStoreFromID_OnSelectedIndexChanged">
                        </asp:DropDownList>
                    </span>
                </div>
                
               
                <div style="width: 100%; overflow: hidden; padding-top: 5px;">
                    <asp:Label ID="lblCampus" runat="server" Text="Campus:" CssClass="targetCss"></asp:Label>
                    <span style="width: 73%; float: right;">
                    <asp:Label ID ="lblCampusName" runat ="server" Text =""></asp:Label>
                        <asp:DropDownList ID="ddlCampus" runat="server" Visible ="false">
                        </asp:DropDownList>
                    </span>
                </div>
                <div style="width: 100%; overflow: hidden; padding-top: 5px;">
                    <asp:Label ID="lblTargetID" runat="server" Text="Tag ID:" CssClass="targetCss"></asp:Label>
                    <span style="width: 73%; float: right;">
                        <asp:TextBox ID="txtTagID" runat="server" CssClass="targetTxtBox"></asp:TextBox></span>
                </div>
                <div style="width: 100%; overflow: hidden; padding-top: 5px;">
                    <asp:Label ID="lblItemList" runat="server" Text="Item List:" CssClass="targetCss"></asp:Label>
                    <span style="width: 73%; float: right;">
                        <asp:DropDownList ID="ddlItemList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlItemList_SelectedIndexChanged1">
                        </asp:DropDownList>
                        <asp:TextBox ID="txtAvaQtyCheck" runat="server" CssClass="targetTxtBox" Enabled="False"></asp:TextBox>
                        <asp:Label ID ="lblOnHand" runat = "server" Text =""></asp:Label>
                    </span>
                </div>
                <div style="width: 100%; overflow: hidden; padding-top: 5px;">
                    <asp:Label ID="lblQuantity" runat="server" Text="Quantity:" CssClass="targetCss"></asp:Label>
                    <span style="width: 73%; float: right;">
                        <asp:TextBox ID="txtQty" runat="server" CssClass="targetTxtBox"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID ="ftbeQty" runat ="server" FilterMode = "ValidChars" FilterType = "Numbers" ValidChars="0123456789" TargetControlID = "txtQty"></ajaxToolkit:FilteredTextBoxExtender>
                        <asp:Button ID="lnkbtnSubmitItem" runat="server" Text="Add To Table" CssClass="button button-green"
                            ValidationGroup="contactus" CausesValidation="true" OnClientClick="btnsubmit_onclick"
                            OnClick="lnkbtnSubmitItem_Click" />
                            
                    </span>
                </div>
                <div style="width: 100%; overflow: hidden; padding-top: 5px;">
                <span style="width: 73%; float: right;">
                <asp:Button ID = "btnUpdate" runat ="server" Text = "Update" Visible ="false" CssClass = "button button-green" OnClick = "btnUpdate_OnClick" />
                 </span>
                </div>
                <div>
                    <asp:Label ID="lblMessage" runat="server"></asp:Label><br />
                    <asp:Label ID="lblFinalMessage" runat="server" Text =""></asp:Label>
                </div>
            </div>
        </div>
        <div align="center">
        <asp:HiddenField ID = "hdnTotalQnty" runat = "server" />
            <asp:GridView ID="gvIssue" runat="server" AutoGenerateColumns="False" CellPadding="3"
                Width="690px" Font-Size="12px" OnRowCancelingEdit="gvIssue_RowCancelingEdit"
                GridLines="Vertical" BackColor="White" BorderColor="#999999" BorderStyle="None"
                BorderWidth="1px" ShowFooter="True">
                <RowStyle BackColor="#00CC99" ForeColor="Black" />
                <Columns>
                    <asp:TemplateField HeaderText="SL">
                        <ItemTemplate>
                            <asp:Label ID="Label10" runat="server" Text='<%# "  "+Convert.ToString(Container.DataItemIndex+1)+"." %>'
                                Width="30px"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Item ID">
                        <ItemTemplate>
                            <asp:Label ID="Label11" runat="server" Text='<%# Convert.ToString(DataBinder.Eval(Container.DataItem, "itemcode")) %>'
                                Width="80px" Style="text-align: left"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Item Description ">
                        <FooterTemplate>
                            <%--<asp:LinkButton ID="btnIssueUpdate" runat="server" Font-Bold="True" Font-Size="12px"
                                OnClick="btnIssueUpdate_Click" Width="50px">Update</asp:LinkButton>--%>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label12" runat="server" Text='<%# Convert.ToString(DataBinder.Eval(Container.DataItem, "itemdesc")) %>'
                                Width="300px" Style="text-align: left"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tag ID">
                        <FooterTemplate>
                            <asp:LinkButton ID="LinkFinalUpdate" runat="server" CssClass="button" Height="20px"
                                OnClick="LinkFinalUpdate_Click">Final Update</asp:LinkButton>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label19" runat="server" Text='<%# Convert.ToString(DataBinder.Eval(Container.DataItem, "tagid")) %>'
                                Width="80px" Style="text-align: left"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quantity">
                        <FooterTemplate>
                            <asp:Label ID="gvlblTotalQty" runat="server" Text="Label" Font-Bold="True" Font-Size="12px"
                                ForeColor="Blue" Width="50px" Style="text-align: right"></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="gvtxtQty" runat="server" BorderStyle="None" Style="text-align: right"
                                Text='<%# Convert.ToDouble(DataBinder.Eval(Container.DataItem, "qty")).ToString("#,##0.00;(#,##0.00); ") %>'
                                Width="50px" BackColor="Transparent"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#ffffff" ForeColor="Black" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#ffffff" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#696969" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="#ffffff" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>
