<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RemarkSearch.ascx.cs"
    Inherits="Control_RemarkSearch" %>
    <div id="divSearch" runat="server">
ID:<asp:TextBox ID="txtID" runat="server"></asp:TextBox>
<asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" /></div>
<asp:GridView ID="gvCOMN_Remark" class="gridCss" runat="server" AutoGenerateColumns="false"
    CssClass="tabel_input">
    <HeaderStyle CssClass="heading" />
    <RowStyle CssClass="row" />
    <AlternatingRowStyle CssClass="altrow" />
    <Columns>
        <%--<asp:TemplateField HeaderText="Remark">
 	 <ItemTemplate>
 	 <asp:Label ID="lblRemarkID" runat="server" Text='<%#Eval("RemarkID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>--%>
        <asp:TemplateField HeaderText="Report">
            <ItemTemplate>
                <asp:Label ID="lblRemarkName" Font-Bold="true" runat="server" Text='<%#Eval("RemarkName") %>'>
 	 </asp:Label>
                <%--</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Remark">
 	 <ItemTemplate>--%>
                <br />
                <asp:Label ID="lblRemark" runat="server" Text='<%#Eval("Remark") %>'>
 	 </asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Remark Date">
            <ItemTemplate>
                <asp:Label ID="lblRemarkDate" runat="server" Text='<%#Eval("RemarkDate","{0:dd MMM yyyy}") %>'>
 	 </asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Who Reported">
            <ItemTemplate>
                <asp:Label ID="lblWhoReported" runat="server" Text='<%#Eval("WhoReported") %>'>
 	 </asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Who Did">
            <ItemTemplate>
                <asp:Label ID="lblWhoDid" runat="server" Text='<%#Eval("WhoDid") %>'>
 	 </asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <%--<asp:TemplateField HeaderText="Extra Field 1">
 	 <ItemTemplate>
 	 <asp:Label ID="lblExtraField1" runat="server" Text='<%#Eval("ExtraField1") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Extra Field 2">
 	 <ItemTemplate>
 	 <asp:Label ID="lblExtraField2" runat="server" Text='<%#Eval("ExtraField2") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Extra Field 3">
 	 <ItemTemplate>
 	 <asp:Label ID="lblExtraField3" runat="server" Text='<%#Eval("ExtraField3") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Extra Field 4">
 	 <ItemTemplate>
 	 <asp:Label ID="lblExtraField4" runat="server" Text='<%#Eval("ExtraField4") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Extra Field 5">
 	 <ItemTemplate>
 	 <asp:Label ID="lblExtraField5" runat="server" Text='<%#Eval("ExtraField5") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Row Status">
 	 <ItemTemplate>
 	 <asp:Label ID="lblRowStatusID" runat="server" Text='<%#Eval("RowStatusID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>--%>
        <asp:TemplateField HeaderText="Delete">
            <ItemTemplate>
                <asp:ImageButton runat="server" ID="lbSelect" CommandArgument='<%#Eval("RemarkID") %>'
                    AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                <asp:ImageButton runat="server" ID="lbDelete" CommandArgument='<%#Eval("RemarkID") %>'
                    OnClick="lbDelete_Click" OnClientClick="return confirm('Are You Sure, You Want To Delete?')"
                    AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<div class="paging" style="display:none;">
    <div class="viewpageinfo">
        <%--View 1 -10 of 13--%>
        Show
    </div>
    <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PageSize_Changed">
        <asp:ListItem Text="100" Value="100" />
        <asp:ListItem Text="250" Value="250" />
        <asp:ListItem Text="500" Value="500" />
    </asp:DropDownList>
    <div class="pagelist">
        <asp:Repeater ID="rptPager" runat="server">
            <ItemTemplate>
                <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                    Enabled='<%# Eval("Enabled") %>' OnClick="Page_Changed"></asp:LinkButton>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
