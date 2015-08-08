<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="DailyAttendence.aspx.cs" Inherits="AdminDisplayHR_Employee"
    Title="Display Employee" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="divListOfEmployee" class="content-box">
                <div class="header">
                    <h3>
                        Attendence</h3>
                </div>
                
                <div class="inner-content" style="width: 97%; overflow: scroll;">

                Empoyee ID<asp:DropDownList ID="ddlAccountingUser" runat="server"></asp:DropDownList>
        <br />
        Time:<asp:TextBox ID="txtInOutTime" runat="server"></asp:TextBox>
        <asp:Button ID="btnLogin" runat="server" Text="Login" 
            onclick="btnLogin_Click" />
                   <br />
                    Date: 
                    <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="ajCal" runat="server" TargetControlID="txtDate">
                                    </ajaxToolkit:CalendarExtender>
                    Empoyee ID<asp:DropDownList ID="ddlEmployee" runat="server"></asp:DropDownList>        
                    
                    <asp:Button ID="btnViewReport" runat="server" Text="View Report" 
                        onclick="btnViewReport_Click" />
                        <asp:GridView ID="gvAttendencePerEmployee" runat="server" AutoGenerateColumns="false"  CssClass="tabel_input">
                        <HeaderStyle CssClass="heading" />
                        <RowStyle CssClass="row" />
                        <AlternatingRowStyle CssClass="altrow" />
                        <Columns>
                            
                            <asp:TemplateField HeaderText="UserID">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserID" runat="server" Text='<%#Eval("UserID") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="InOutTime">
                                <ItemTemplate>
                                    <asp:Label ID="lblInOutTime" runat="server" Text='<%#Eval("InOutTime") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit" Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("AttendenceID") %>'
                                        OnClick="lbDelete_Click">
                                        Delete
                                    </asp:LinkButton>
                                     <asp:LinkButton ID="lbSelect" runat="server" CommandArgument='<%#Eval("AttendenceID") %>'
                                        OnClick="lbSelect_Click">
                                        Select
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                    <asp:GridView ID="gvAttendenceDuration" runat="server" AutoGenerateColumns="false"  CssClass="tabel_input">
                        <HeaderStyle CssClass="heading" />
                        <RowStyle CssClass="row" />
                        <AlternatingRowStyle CssClass="altrow" />
                        <Columns>
                            <asp:TemplateField HeaderText="UserID">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserID" runat="server" Text='<%#Eval("UserIDDisplay") %>'>
                                    </asp:Label>
                                    <asp:HiddenField ID="hfDate" runat="server" Value='<%#Eval("OutTime","{0:yyyy-MM-dd}") %>'/>
                                    <asp:HiddenField ID="hfUserID" runat="server" Value='<%#Eval("UserID") %>'/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserName" runat="server" Text='<%#Eval("UserNameDisplay") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate" runat="server" Text='<%#Eval("DateDisplay") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserI" runat="server" Text='<%#Eval("TotalDuratinDisplay") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="InOutTime">
                                <ItemTemplate>
                                    <asp:Label ID="lblInOutTime" runat="server" Text='<%#Eval("InTime","{0:hh:mm tt}") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Out Time">
                                <ItemTemplate>
                                    <asp:Label ID="lblInOutTime" runat="server"  Text='<%#Eval("OutTime","{0:hh:mm tt}") %>' Visible='<%#Eval("DefaultTimeLabelVisible") %>'>
                                    </asp:Label>
                                    <asp:TextBox ID="txtOutTime" runat="server" ForeColor="Red" Text="06:00 PM" Visible='<%#Eval("DefaultTimeTextBoxVisible") %>' Width="60px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Duration">
                                <ItemTemplate>
                                    <asp:Label ID="lblInOutTime" runat="server" Text='<%#Eval("DurationDisplay") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit" Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("AttendenceID") %>'
                                        OnClick="lbDelete_Click">
                                        Delete
                                    </asp:LinkButton>
                                     <asp:LinkButton ID="lbSelect" runat="server" CommandArgument='<%#Eval("AttendenceID") %>'
                                        OnClick="lbSelect_Click">
                                        Select
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <br />
                    <div align="center">
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" 
                            onclick="btnUpdate_Click" />
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
