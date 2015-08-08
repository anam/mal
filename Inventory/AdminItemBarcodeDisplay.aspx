<%@ Page Language="C#" MasterPageFile="~/Site2Column.master" AutoEventWireup="true"
    CodeFile="AdminItemBarcodeDisplay.aspx.cs" Inherits="AdminItemBarcodeDisplay" Title="Display ItemBarcode By Admin" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
   
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                List of all printed</h3>
        </div>
        <div class="inner-content">
        <asp:GridView ID="gvItemBarcode" runat="server" AutoGenerateColumns="false" CssClass="tabel_input">
        
                <HeaderStyle CssClass="heading" />
                <RowStyle CssClass="row" />
                <AlternatingRowStyle CssClass="altrow" />
            <Columns>
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbSelect" runat="server" CommandArgument='<%#Eval("ItemBarcodeID") %>' OnClick="lbSelect_Click">
                            Print
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SubCategoryID">
                    <ItemTemplate>
                        <asp:Label ID="lblSubCategoryID" runat="server" Text='<%#Eval("SubCategoryID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="NoOfItem">
                    <ItemTemplate>
                        <asp:Label ID="lblNoOfItem" runat="server" Text='<%#Eval("NoOfItem") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:TemplateField HeaderText="BarcodeText">
                    <ItemTemplate>
                        <asp:Label ID="lblBarcodeText" runat="server" Text='<%#Eval("BarcodeText") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="AddedDate">
                    <ItemTemplate>
                        <asp:Label ID="lblAddedDate" runat="server" Text='<%#Eval("AddedDate","{0:dd MMM yyyy}") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("ItemBarcodeID") %>' OnClick="lbDelete_Click">
                            Delete
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>--%>
            </Columns>
        </asp:GridView>
    </div>
    </div>
</asp:Content>
