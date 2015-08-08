<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminSTD_ExamDetails.aspx.cs" Inherits="AdminSTD_ExamDetails" Title="STD_ExamDetails Insert/Update By Admin" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Insert /UpdateSTD_ExamDetails</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="lblExamID" runat="server" Text="Exam: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlExamID" runat="server">
                    </asp:DropDownList>
                </dd>
                
                <dt>
                    <asp:Label ID="lblExamDetailsName" runat="server" Text="Exam Details Name: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtExamDetailsName" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
     
               <dt>
                    <asp:Label ID="lblTotalMark" runat="server" Text="Total Mark: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtTotalMark" class="txt large-input" runat="server" Text="">
                    </asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="ajfte" runat="server" FilterType="Custom" TargetControlID="txtTotalMark" ValidChars="0123456789.00" InvalidChars="abc">
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
