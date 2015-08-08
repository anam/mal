<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminHR_SalaryTaxPackage.aspx.cs" Inherits="AdminHR_SalaryTaxPackage"
    Title="Salary Tax Package" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Salary Tax Package</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="lblSalaryTaxPackageName" runat="server" Text="Salary Tax Package Name: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtSalaryTaxPackageName" class="txt large-input" runat="server"
                        Text="">
                    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblSalaryTaxPackageFormula" runat="server" Text="Salary Tax Value(%): ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtSalaryTaxPackageFormula" class="txt large-input" runat="server"
                        Text="">
                    </asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="ftbSalaryTaxPackageFormula" runat="server"
                        FilterMode="ValidChars" ValidChars="0123456789." TargetControlID="txtSalaryTaxPackageFormula">
                    </ajaxToolkit:FilteredTextBoxExtender>
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
