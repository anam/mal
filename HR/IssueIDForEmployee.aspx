<%@ Page Title="Human Resource" Language="C#" MasterPageFile="~/Site2Column.master" AutoEventWireup="true" CodeFile="IssueIDForEmployee.aspx.cs" Inherits="HR_DefaultHR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<script type="text/javascript">
    var win = null;
    function printIt(printThis) {
        win = window.open();
        self.focus();
        win.document.open();
        win.document.write('<' + 'html' + '><' + 'head' + '><' + 'style' + '>');
        win.document.write('body,body{padding:0;magine:0;} td { font-family: Verdana; font-size: 10pt;}');
        win.document.write('<' + '/' + 'style' + '><' + '/' + 'head' + '><' + 'body' + '>');
        win.document.write(printThis);
        win.document.write('<' + '/' + 'body' + '><' + '/' + 'html' + '>');
        win.document.close();
        win.print();
        win.close();
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div class="content-box">
        <div class="header">
            <h3>
                Print ID card</h3>
        </div>
        <div class="inner-content" >
            <dl>
                <dt>Teacher IDs :<br />
                    <span style="font-size: 8px;">TeacherIDs seperated by (,)</span></dt>
                <dd>
                    <asp:TextBox ID="txtEmployeeIDs" runat="server" Width="500" Height="100" TextMode="MultiLine"></asp:TextBox></dd>
                </dl>
                
                    or Select Employee
                    <br />
                    <div style="height:300px;overflow:scroll;">
                    
                     <asp:GridView ID="gvEmpoyeeList" runat="server" AutoGenerateColumns="false" CssClass="tabel_input">
                        <HeaderStyle CssClass="heading" />
                        <RowStyle CssClass="row" />
                        <AlternatingRowStyle CssClass="altrow" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" Checked="false"/>
                                    <asp:HiddenField   ID="hfID" runat="server" Value='<%#Eval("ID") %>'/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Department">
                                <ItemTemplate>
                                    <asp:Label ID="lblDepartment" runat="server" Text='<%#Eval("Department") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                            
                            <asp:TemplateField HeaderText="Designation">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmployeeNo" runat="server" Text='<%#Eval("Designation") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Employee Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmployeeName" runat="server" Text='<%#Eval("Name") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                            
                            <asp:TemplateField HeaderText="ID">
                                <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%#Eval("ID") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                           <%-- <asp:TemplateField HeaderText="ID">
                                <ItemTemplate>
                                    <asp:Image runat="server" ID="imgPhoto" ImageUrl='<%#Eval("Photo") %>' ImageAlign="Middle"
                                            Width="65" Height="80" />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            
                            </Columns>
                    </asp:GridView>
                    </div>
               <dl>
                
                <dt></dt>
                <dd>
                    <asp:Button ID="btnSearch" runat="server" class="button button-blue" Text="Search"
                        OnClick="btnSearch_Click" />
                        
                    <asp:LinkButton ID="lnkPrint" Visible="false" class="button button-blue" Text="Print" runat="server" OnClientClick="javascript:printIt(document.getElementById('printThis').innerHTML);"></asp:LinkButton>
                    <a id="a_PrintID" target="_blank" runat="server"  class="button button-blue" >Print</a>&nbsp;
                   <a id="A1" href="BackSidePrint.htm" target="_blank" runat="server" class="button button-blue">Print back side</a>
                </dd>
            </dl>
             (If you can not find the ID card for any employee in the bellow list that means there are some information missing for that employee)
            <div id='printThis'>
                <asp:Label ID="lblIDCards" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>

