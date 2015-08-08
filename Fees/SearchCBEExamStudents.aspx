<%@ Page Title="Search CBE Exam" Language="C#" MasterPageFile="~/Site2Column.master"
    AutoEventWireup="true" CodeFile="SearchCBEExamStudents.aspx.cs" Inherits="Student_SearchCBEExamStudents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .tableCss
        {
            text-align: left;
        }
        .txtCss
        {
            width: 300px;
            margin: 2px 0;
            padding: 2px;
            border: 1px solid #ccc;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel ID="upCBESearch" runat="server">
        <ContentTemplate>
            <div class="content-box">
                <div class="header">
                    <h3>
                        Search CBE Exam</h3>
                </div>
                <div class="inner-content" style="width: 98%">
                    <table>
                        <tr>
                            <td>
                                Name:
                            </td>
                            <td>
                                <asp:TextBox ID="txtName" runat="server" CssClass="txtCss" Width="75%"></asp:TextBox>
                            </td>
                            <td>
                                Subject:
                            </td>
                            <td>
                                <asp:TextBox ID="txtSubject" runat="server" CssClass="txtCss" Width="75%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                From Date:
                            </td>
                            <td>
                                <asp:TextBox ID="txtFromDate" runat="server" CssClass="txtCss" Width="75%"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="ajcal" runat="server" TargetControlID="txtFromDate">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                            <td>
                                To Date:
                            </td>
                            <td>
                                <asp:TextBox ID="txtToDate" runat="server" CssClass="txtCss" Width="75%"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="CalendarExtender1" runat="server"
                                    TargetControlID="txtToDate">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="padding-left: 200px">
                                <asp:Button ID="btnSeach" runat="server" class="button button-blue" Text="Search"
                                    OnClick="btnSeach_OnClick" />
                            </td>
                        </tr>
                    </table>
                    <div style="width: 100%; margin: 0px auto; overflow: scroll">
                        <asp:GridView ID="gvCBEExam" runat="server" AutoGenerateColumns="false" CssClass="tabel_input"
                            ShowFooter="true" >
                            <HeaderStyle CssClass="heading" />
                            <RowStyle CssClass="row" />
                            <AlternatingRowStyle CssClass="altrow" />
                            <Columns>
                                <asp:TemplateField HeaderText="Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lbladdDate" runat="server" Text='<%#Eval("AddedDate","{0:dd MMM yyyy}") %>'>
                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDOB" runat="server" Text='<%#Eval("CandidateName") %>'>
                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="RegiNo">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRegiNo" runat="server" Text='<%#Eval("RegiNo") %>'>
                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Mobile">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMobile" runat="server" Text='<%#Eval("Mobile") %>'>
                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email") %>'>
                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Subject">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubject" runat="server" Text='<%#Eval("SubjectTitle") %>'>
                        </asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <span style="font-size: 15px; font-weight: bold">Total </span>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fees">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFees" runat="server" Text='<%#Eval("Fees","{0:0,0.00}") %>'>
                        </asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblTotal" runat="server"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
