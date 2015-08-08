<%@ Page Title="Add/Update Account Voucher" Language="C#" MasterPageFile="~/Site2Column.master" AutoEventWireup="true"
    CodeFile="AccountVoucher.aspx.cs" Inherits="Accounting_AccountVoucher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="content-box">
        <div class="header">
            <h3>
                Add/Update Account Voucher</h3>
        </div>
        <div class="inner-form">
            <fieldset id="Fieldset4" runat="server" style="border: 1px solid #FEC212; margin-bottom: 10px;
                padding-bottom: 20px; padding-left: 15px">
                <legend style="font-size: 20px; color: #DB0200; text-align: justify; line-height: 43px;
                    margin-left: 10px; font-style: italic; text-transform: capitalize; font-family: Arial, Helvetica, sans-serif;
                    font-weight: bold;">Voucher Information</legend>
                <!-- error and information messages -->
                <dl>
                    <dt>
                        <asp:Label ID="lblVoucherNo" runat="server" Text="Voucher No: ">
    </asp:Label>                   
                    </dt>
                    <dd>
                        <asp:TextBox ID="txtVoucherNo" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                    </dd>
                    <dt>
                        <asp:Label ID="lblHeadID" runat="server" Text="Head: ">
    </asp:Label>
                    </dt>
                    <dd>
                        <asp:DropDownList ID="ddlHeadID" runat="server">
                        </asp:DropDownList>
                    </dd>
                    <dt>
                        <asp:Label ID="lblDebitOrCredit" runat="server" Text="Debit Or Credit: ">
    </asp:Label>
                    </dt>
                    <dd>
                        <asp:TextBox ID="txtDebitOrCredit" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                    </dd>
                    <dt>
                        <asp:Label ID="lblFromTo" runat="server" Text="From To: ">
    </asp:Label>
                    </dt>
                    <dd>
                        <asp:TextBox ID="txtFromTo" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                    </dd>
                     <dt>
                        <asp:Label ID="lblAmount" runat="server" Text="Amount: ">
    </asp:Label>
                    </dt>
                    <dd>
                        <asp:TextBox ID="txtAmount" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                    </dd>
                    <dt>
                        <asp:Label ID="lblOnAccountOf" runat="server" Text="On Account Of: ">
    </asp:Label>
                    </dt>
                    <dd>
                        <asp:TextBox ID="txtOnAccountOf" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                    </dd>
                    <dt>
                        <asp:Label ID="lblInWord" runat="server" Text="In Word: ">
    </asp:Label>
                    </dt>
                    <dd>
                        <asp:TextBox ID="txtInWord" TextMode="MultiLine" class="txt textarea" runat="server"
                            Text="">
    </asp:TextBox>
                    </dd>
                    <dt>
                        <asp:Label ID="lblIsApproved" runat="server" Text="Is Approved: ">
    </asp:Label>
                    </dt>
                    <dd>
                        <asp:RadioButtonList ID="radIsApproved" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem>True</asp:ListItem>
                            <asp:ListItem>False</asp:ListItem>
                        </asp:RadioButtonList>
                    </dd>
                    <dt>
                        <asp:Label ID="lblApprovalDate" runat="server" Text="Approval Date: ">
    </asp:Label>
                    </dt>
                    <dd>
                        <asp:TextBox ID="txtApprovalDate" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                    </dd>
                    <dt>
                        <asp:Label ID="lblVoucherDate" runat="server" Text="Voucher Date: ">
    </asp:Label>
                    </dt>
                    <dd>
                        <asp:TextBox ID="txtVoucherDate" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                    </dd>
                    <dt>
                        <asp:Label ID="lblVouscherRowStatusID" runat="server" Text="Row Status: ">
    </asp:Label>
                    </dt>
                    <dd>
                        <asp:DropDownList ID="ddlVouscherRowStatusID" runat="server">
                        </asp:DropDownList>
                    </dd>
                    <dt>
                        <asp:Label ID="lblRemarks" runat="server" Text="Remarks: ">
    </asp:Label>
                    </dt>
                    <dd>
                        <asp:TextBox ID="txtRemarks" TextMode="MultiLine" class="txt textarea" runat="server"
                            Text="">
    </asp:TextBox>
                    </dd>
                    <dt></dt>
                    <dd>
                    </dd>
                </dl>
            </fieldset>
        </div>
        <div class="inner-form">
            <fieldset id="Fieldset1" runat="server" style="border: 1px solid #FEC212; margin-bottom: 10px;
                padding-bottom: 20px; padding-left: 15px">
                <legend style="font-size: 20px; color: #DB0200; text-align: justify; line-height: 43px;
                    margin-left: 10px; font-style: italic; text-transform: capitalize; font-family: Arial, Helvetica, sans-serif;
                    font-weight: bold;">Voucher Item Information</legend>
                <!-- error and information messages -->
                <!-- error and information messages -->
                <dl>
                    <dt>
                        <asp:Label ID="lblVoucherIteamName" runat="server" Text="Voucher Iteam Name: ">
    </asp:Label>
                    </dt>
                    <dd>
                        <asp:TextBox ID="txtVoucherIteamName" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                    </dd>
                    
                    <dt>
                        <asp:Label ID="lblIteamCode" runat="server" Text="Iteam Code: ">
    </asp:Label>
                    </dt>
                    <dd>
                        <asp:TextBox ID="txtIteamCode" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                    </dd>
                    <dt>
                        <asp:Label ID="lblDescription" runat="server" Text="Description: ">
    </asp:Label>
                    </dt>
                    <dd>
                        <asp:TextBox ID="txtDescription" TextMode="MultiLine" class="txt textarea" runat="server"
                            Text="">
    </asp:TextBox>
                    </dd>
                    <dt>
                        <asp:Label ID="lblUnitPrice" runat="server" Text="Unit Price: ">
    </asp:Label>
                    </dt>
                    <dd>
                        <asp:TextBox ID="txtUnitPrice" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                    </dd>
                    <dt>
                        <asp:Label ID="lblQuantity" runat="server" Text="Quantity: ">
    </asp:Label>
                    </dt>
                    <dd>
                        <asp:TextBox ID="txtQuantity" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                    </dd>
                    <dt>
                        <asp:Label ID="lblVoucherItemRowStatus" runat="server" Text="Row Status: ">
    </asp:Label>
                    </dt>
                    <dd>
                        <asp:DropDownList ID="ddlVoucherItemRowStatus" runat="server">
                        </asp:DropDownList>
                    </dd>
                    <dt></dt>
                    <dd>
                        <asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Add" OnClick="btnAdd_Click" />
                        <asp:Button ID="btnUpdate" class="button button-blue" runat="server" Text="Update"
                        OnClick="btnUpdate_Click"  />
                    </dd>
                </dl>
            </fieldset>
        </div>
        <div class="inner-content">
            <fieldset id="Fieldset2" runat="server" style="border: 1px solid #FEC212; margin-bottom: 10px;
                padding-bottom: 20px; padding-left: 15px">
                <legend style="font-size: 20px; color: #DB0200; text-align: justify; line-height: 43px;
                    margin-left: 10px; font-style: italic; text-transform: capitalize; font-family: Arial, Helvetica, sans-serif;
                    font-weight: bold;">Voucher Item Display</legend>
                <!-- error and information messages -->
                <asp:GridView ID="gvACC_VoucherIteam" class="gridCss" runat="server" AutoGenerateColumns="false"
                    CssClass="gridCss">
                    <Columns>
                        <asp:TemplateField HeaderText="Voucher Iteam">
                            <ItemTemplate>
                                <asp:Label ID="lblVoucherIteamID" runat="server" Text=' <%# Container.DataItemIndex + 1 %>'>
 
 	                            </asp:Label>
                                
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Voucher Iteam Name">
                            <ItemTemplate>
                                <asp:Label ID="lblVoucherIteamName" runat="server" Text='<%#Eval("VoucherIteamName") %>'>
 	 </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                        <asp:TemplateField HeaderText="Iteam Code">
                            <ItemTemplate>
                                <asp:Label ID="lblIteamCode" runat="server" Text='<%#Eval("IteamCode") %>'>
 	 </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description">
                            <ItemTemplate>
                                <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description") %>'>
 	 </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Unit Price">
                            <ItemTemplate>
                                <asp:Label ID="lblUnitPrice" runat="server" Text='<%#Eval("UnitPrice") %>'>
 	 </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quantity">
                            <ItemTemplate>
                                <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("Quantity") %>'>
 	 </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Update Date">
                            <ItemTemplate>
                                <asp:Label ID="lblUpdateDate" runat="server" Text='<%#Eval("UpdateDate") %>'>
 	 </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Row Status">
                            <ItemTemplate>
                                <asp:Label ID="lblRowStatusID" runat="server" Text='<%#Eval("RowStatus") %>'>
 	 </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="lbSelect" CommandArgument='<%#Eval("VoucherIteamID") %>'
                                    AlternateText="Edit" OnClick="lbSelect_Click" ToolTip="Edit" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                                <asp:ImageButton runat="server" ID="lbDelete" ToolTip="Delete" CommandArgument='<%#Eval("VoucherIteamID") %>'
                                    OnClick="lbDelete_Click" AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                
            </fieldset>

            <table>
               <tr>
                    <td>
                        <asp:Button ID="btnSubmit" class="button button-blue" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    </td>
               </tr>
            </table>
        </div>
    </div>
</asp:Content>
