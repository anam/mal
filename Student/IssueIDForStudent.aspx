<%@ Page Title="Student ID Card" Language="C#" MasterPageFile="~/Site2Column.master" AutoEventWireup="true" CodeFile="IssueIDForStudent.aspx.cs" Inherits="HR_DefaultHR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<script type="text/javascript">
    var win = null;
    function printIt(printThis) {
        win = window.open();
        self.focus();
        win.document.open();
        win.document.write('<' + 'html' + '><' + 'head' + '><' + 'style' + '>');
        win.document.write('body, td { font-family: Verdana; font-size: 10pt;}');
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
                <dt>
                    Student IDs :<br />
                    <span style="font-size: 8px;">IDs seperated by (,)</span>
                </dt>
                <dd>
                    <asp:TextBox ID="txtStudentIDs" runat="server" Width="500" Height="100" TextMode="MultiLine"></asp:TextBox>
                </dd>
                <dt>
                    Issue Date
                </dt>
                <dd>
                    <asp:TextBox ID="txtIssueDate" runat="server" ></asp:TextBox>
                    <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="ajcal" runat="server" TargetControlID="txtIssueDate">
                    </ajaxToolkit:CalendarExtender>
                </dd>
                <dt>
                    Valid Date
                </dt>
                <dd>
                    <asp:TextBox ID="txtValidDate" runat="server" ></asp:TextBox>
                    <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="CalendarExtender1" runat="server" TargetControlID="txtValidDate">
                    </ajaxToolkit:CalendarExtender>
                </dd>
                <dt>&nbsp;</dt>
                <dd>
                    <asp:Button ID="btnSearch" runat="server" class="button button-blue" Text="Search" OnClick="btnSearch_Click" />    
                    <a id="a_PrintID" target="_blank" runat="server" class="button button-blue">Print</a>&nbsp;
                   <a href="BackSidePrint.htm" target="_blank" runat="server" class="button button-blue">Print back side</a>
                    <asp:LinkButton ID="lnkPrint" Visible="false" class="button button-blue" Text="Print" runat="server" OnClientClick="javascript:printIt(document.getElementById('printThis').innerHTML);"></asp:LinkButton>                
                </dd>
            </dl>
            (If you can find the ID card in the bellow list that means there is some infomation missing for that student)
            <div id='printThis'>
                <asp:Label ID="lblIDCards" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>

