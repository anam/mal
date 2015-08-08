<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminINV_MRRInfo.aspx.cs" Inherits="AdminINV_MRRInfo" Title="INV_MRRInfo Insert/Update By Admin" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3 id="h3Header" runat="server">
                Add new MRR Information</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <%--<dt>
                    <asp:Label ID="lblCampusID" runat="server" Text="Campus: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlCampusID" runat="server">
                    </asp:DropDownList>
                </dd>--%>
               <%-- <dt>
                    <asp:Label ID="lblMRRInfoMasterID" runat="server" Text="MRR Info Master: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlMRRInfoMasterID" runat="server">
                    </asp:DropDownList>
                </dd>--%>
                <dt>
                    <asp:Label ID="lblMRRCode" runat="server" Text="MRR Code: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtMRRCode" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblIteamID" runat="server" Text="Iteam: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlIteamID" runat="server">
                    </asp:DropDownList>
                </dd>
                <%--<dt>
     <asp:Label ID="lblTagID" runat="server" Text="Tag: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlTagID" runat="server">
     </asp:DropDownList>
     </dd>--%>
                <dt>
                    <asp:Label ID="lblQuantity" runat="server" Text="Quantity: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtQuantity" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="ftbeQuantity" FilterMode="ValidChars" FilterType="Numbers"
                        runat="server" ValidChars="1234567890" TargetControlID="txtQuantity">
                    </ajaxToolkit:FilteredTextBoxExtender>
                </dd>
                <dt>
                    <asp:Label ID="lblMRRAmount" runat="server" Text="MRR Amount: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtMRRAmount" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" FilterMode="ValidChars"
                        FilterType="Custom" runat="server" ValidChars="1234567890." TargetControlID="txtMRRAmount">
                    </ajaxToolkit:FilteredTextBoxExtender>
                </dd>
                <dt>
                    <asp:Label ID="lblSaleAmount" runat="server" Text="Sale Amount: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtSaleAmount" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" FilterMode="ValidChars"
                        FilterType="Custom" runat="server" ValidChars="1234567890." TargetControlID="txtSaleAmount">
                    </ajaxToolkit:FilteredTextBoxExtender>
                </dd>
                <dt>
                    <asp:Label ID="lblMRRDate" runat="server" Text="MRR Date: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtMRRDate" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                    <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="calenderMRRDate"  runat="server"
                        TargetControlID="txtMRRDate">
                    </ajaxToolkit:CalendarExtender>
                </dd>
                <dt>
                    <asp:Label ID="lblStoreID" runat="server" Text="Store: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlStoreID" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt></dt>
                <dd>
                    <asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Add" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnUpdate" class="button button-blue" runat="server" Text="Update"
                        OnClick="btnUpdate_Click" Visible="false" />
                </dd>
            </dl>
        </div>
    </div>
</asp:Content>
