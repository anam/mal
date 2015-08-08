<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminHR_OverTimePackage.aspx.cs" Inherits="AdminHR_OverTimePackage"
    Title="Over Time Package" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Over Time Package</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="lblOverTimePackageName" runat="server" Text="Package name: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtOverTimePackageName" class="txt medium-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblOverTimeFormula" runat="server" Text="Over Time value: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtOverTimeFormula" class="txt medium-input" runat="server" Text="">
    </asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="ftbOverTimeFormula" runat="server" FilterMode="ValidChars"
                        ValidChars="0123456789." TargetControlID="txtOverTimeFormula">
                    </ajaxToolkit:FilteredTextBoxExtender>
                </dd>
                <dt></dt>
                <dd>
                    <label>
                        Value will be <1
                    </label>
                </dd>
            </dl>
            <div style="width: 100%; overflow: hidden;">
                <div style="width: 20%; float: right;">
                    <asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Add" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnUpdate" class="button button-blue" runat="server" Text="Update"
                        OnClick="btnUpdate_Click" Visible="false" /></div>
            </div>
        </div>
    </div>
</asp:Content>
