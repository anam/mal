<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminHR_Rank.aspx.cs" Inherits="AdminHR_Rank" Title="Rank" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Rank</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="lblRankName" runat="server" Text="Rank Name: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtRankName" class="txt medium-input" runat="server" Text="">
                    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblSeniorityLevel" runat="server" Text="Seniority Level: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtSeniorityLevel" class="txt medium-input" runat="server" Text="">
                    </asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="ftbeSeniorityLevel" runat="server" FilterMode="ValidChars"
                        ValidChars="123456789" TargetControlID="txtSeniorityLevel">
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
