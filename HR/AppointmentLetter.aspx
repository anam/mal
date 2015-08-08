<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master"  CodeFile="AppointmentLetter.aspx.cs" Inherits="AdminDisplayHR_JobPosting" Title="Appointment Letter" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 <script type="text/javascript">
     var win = null;
     function printIt(appointmentLetter) {
         win = window.open();
         self.focus();
         win.document.open();
         win.document.write('<' + 'html' + '><' + 'head' + '><' + 'style' + '>');
         win.document.write('body,body{padding-left:30px;padding-right:30px;} td { font-family: Verdana; font-size: 10pt;} p{text-align: justify;}');
         win.document.write('<' + '/' + 'style' + '><' + '/' + 'head' + '><' + 'body' + '>');
         win.document.write(appointmentLetter);
         win.document.write('<' + '/' + 'body' + '><' + '/' + 'html' + '>');
         win.document.close();
         win.print();
         win.close();
     }
    </script>

 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="content-box">
<div class="header">
<h3>Appointment Letter</h3>
</div>
<div class="inner-content">
    <asp:ImageButton ID="lnkPrint" runat="server" Visible="false" OnClientClick="javascript:printIt(document.getElementById('ctl00_MainContent_appointmentLetter').innerHTML);" ImageUrl="../App_Themes/CoffeyGreen/images/print.jpg"/>
	<br />
    <div id="appointmentLetter" runat="server" visible="false">	
        <asp:Label ID="lblPrintedLetter" runat="server" Text=""></asp:Label>
	</div>  
    
      <div id="divInput" style="padding-top:50px;">	
    <p class="MsoNormal" >
        <b><span>Issue Date- 
            <asp:TextBox ID="txtIssueDate" runat="server"></asp:TextBox>
            <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="ajCal" runat="server" TargetControlID="txtIssueDate">
                                    </ajaxToolkit:CalendarExtender>
            
            <o:p></o:p></span></b></p>
    <p class="MsoNormal">
        <span><o:p>&nbsp;</o:p></span></p>
    <p class="MsoNormal">
        <b><span>To,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <o:p></o:p>
        </span></b>
    </p>
    <p class="MsoNormal">
        <b><span>
            <asp:TextBox ID="txtTo" runat="server" TextMode="MultiLine" Height="100px" 
            Width="450px"></asp:TextBox>

        <br />
        Subject: 
            <asp:TextBox ID="txtSubject" runat="server" Width="400px"></asp:TextBox><o:p></o:p></span></b></p>
    <p class="MsoNormal">
        <b><span><o:p>&nbsp;</o:p></span></b></p>
    <p class="MsoNormal">
        <b><span>Dear 
            <asp:TextBox ID="txtDearTo" runat="server" Width="200px"></asp:TextBox>,<o:p></o:p></span></b></p>
    <p class="MsoNormal">
        <asp:TextBox ID="txtP0_1" runat="server"></asp:TextBox><b>
            <asp:TextBox ID="txtDepartment" runat="server" Width="279px"></asp:TextBox> </b>
        <asp:TextBox ID="txtP0_2" runat="server"></asp:TextBox></p>
    <p class="MsoNormal">
        <span><o:p>&nbsp;</o:p></span></p>
    <p class="MsoNormal">
       <asp:TextBox ID="txtP1_1" runat="server" Width="383px"></asp:TextBox><asp:TextBox ID="txtJoiningDate" runat="server"></asp:TextBox>
        <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="CalendarExtender1" runat="server" TargetControlID="txtJoiningDate">
                                    </ajaxToolkit:CalendarExtender>
&nbsp;</b><asp:TextBox ID="txtP1_2" runat="server" Height="20px" Width="427px"></asp:TextBox> <b>
    <asp:TextBox ID="txtSalary" runat="server" Width="234px"></asp:TextBox></b><span> </span>
        <asp:TextBox ID="txtP1_3" runat="server" Height="43px" TextMode="MultiLine" 
            Width="760px"></asp:TextBox> <o:p></o:p>
          </p>
          <p class="MsoNormal">
              <o:p></o:p>
          </p>
          <p class="MsoNormal">
              <o:p></o:p>
          </p>
    <p class="MsoNormal">
        <asp:TextBox ID="txtP2_1" runat="server" Height="16px" Width="573px"></asp:TextBox><b>
            <asp:TextBox ID="txtOfficeTime" runat="server" Width="160px"></asp:TextBox></b>
        <asp:TextBox ID="txtP2_2" runat="server" Height="48px" TextMode="MultiLine" 
            Width="597px"></asp:TextBox></p>
    <p class="MsoNormal">
        <span><o:p>&nbsp;</o:p></span></p>
    <p class="MsoNormal">
        <asp:TextBox ID="txtP3" runat="server" Height="68px" TextMode="MultiLine" 
            Width="754px"></asp:TextBox></p>
    <p class="MsoNormal">
        <span><o:p>&nbsp;</o:p></span></p>
    <p class="MsoNormal">
        <asp:TextBox ID="txtP4" runat="server" Height="71px" TextMode="MultiLine" 
            Width="754px"></asp:TextBox><b> </b><span>&nbsp;</span></p>
    <p class="MsoNormal">
        <span><o:p>&nbsp;</o:p></span></p>
    <p class="MsoNormal">
        <asp:TextBox ID="txtP5" runat="server" Height="56px" TextMode="MultiLine" 
            Width="749px"></asp:TextBox>
        </p>
    <p class="MsoNormal">
        <span><o:p>&nbsp;</o:p></span></p>
    <p class="MsoNormal">
    <asp:TextBox ID="txtP6" runat="server" Width="455px"></asp:TextBox>
        </p>
    <p class="MsoNormal">
        <span><o:p>&nbsp;</o:p></span></p>
    <p class="MsoNormal">
        <b>
            <asp:TextBox ID="txtThanks" runat="server" TextMode="MultiLine" 
            Height="122px" Width="340px"></asp:TextBox>
        </b></p>
          <asp:CheckBox ID="chkSaveIndb" runat="server" Checked="true" Text="Save in Database"/>
          <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
              onclick="btnSubmit_Click" />
	</div>  		
</div>

</div>  

 </asp:Content>

