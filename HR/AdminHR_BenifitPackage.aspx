<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminHR_BenifitPackage.aspx.cs" Inherits="AdminHR_BenifitPackage" Title="Benefit Package" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Benefit Package</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="lblBenifitPackageName" runat="server" Text="Benefit Package Name: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtBenifitPackageName" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblBenifitTimesYear" runat="server" Text="Benefit Times Year: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtBenifitTimesYear" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="ftbBenifitTimesYear" runat="server" FilterMode="ValidChars"
                        ValidChars="0123456789" TargetControlID="txtBenifitTimesYear">
                    </ajaxToolkit:FilteredTextBoxExtender>
                </dd>
                <dt>
                    <asp:Label ID="lblBebifitFormula" runat="server" Text="Benefit Formula(%): ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtBebifitFormula" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="ftbBebifitFormula" runat="server" FilterMode="ValidChars"
                        ValidChars="0123456789." TargetControlID="txtBebifitFormula">
                    </ajaxToolkit:FilteredTextBoxExtender>
                </dd>
                <dt></dt>
                <dd>
                    <asp:CheckBox ID="chkIsRespectGross" class="txt large-input" runat="server" Text="Is Respect to Gross" /> 
                    <%--<asp:RadioButton ID="radIsRespectGross" class="txt large-input" runat="server" Text="Is Respect to Gross">
                    </asp:RadioButton>--%>
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
