<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IDCard.aspx.cs" Inherits="HR_IDCard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        var win = null;
        function printIt(printThis) {
            win = window.open();
            self.focus();
            win.document.open();
            win.document.write('<' + 'html' + '><' + 'head' + '><' + 'style' + '>');
            win.document.write('body, td { font-family: Verdana; font-size: 10pt;},* {margin: 0; padding: 0;} ');
            win.document.write('<' + '/' + 'style' + '><' + '/' + 'head' + '><' + 'body' + '>');
            win.document.write(printThis);
            win.document.write('<' + '/' + 'body' + '><' + '/' + 'html' + '>');
            win.document.close();
            win.print();
            win.close();
        }
    </script>
    <style type="text/css">
    * {margin: 0; padding: 0;}   
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="display:none; background-image: url('images/ID/Admin-front-Page.png');border:1px solid red; font-family: verdana; width: 205px; height: 325px;">
         <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td colspan="3">
                    <div style="border:1px solid Red;margin-top:55px;margin-left:62px;width:77px;height:95px;">
                        <img alt="no Image" src="../App_Themes/CoffeyGreen/images/NoImage.jpg" style="width:77px;height:95px;"/>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <div align="center" style="padding-bottom:-2px;">
                         <span style="font-size:12px;"> 0000000</span>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <div align="center">
                        <span style="font-size: 15px; font-weight: bold;">FirstName LastName</span>
                         <br />   
                         <span style="font-size:11px;"> Designation</span>
                         <br />   
                         <span style="font-size:11px;"> Department</span>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style='border: 0px solid Red; height: 56px; margin-top: 7px; margin-left: 17px; font-weight: bold; font-size: 10px; width: 72px;'>
                    Department
                    <br />
                    Join Date
                    <br />
                    Contact No
                    <br />
                    Blood Group
                    </div>
                </td>
                <td>
                    <div style='border: 0px solid Red; font-size: 10.5px; height: 56px; margin-top: 7px; width: 5px; font-weight: bold; margin-left: 0px;'>
                    :
                    <br />
                    :
                    <br />
                    :
                    <br />
                    :
                    </div>
                </td>
                <td>
                    <div style='border: 0px solid Red; font-size: 10.5px; height: 56px; margin-top: 7px; width: 109px; margin-left: 1px;'>
                    Admin
                    <br />
                    1st July 1999
                    <br />
                    00000-000000
                    <br />
                    O+
                    </div>
                </td>
            </tr>
         </table> 
    </div>
    <div style="display:none; background-image: url('images/ID/Student-Front-Page.png');border:1px solid red; font-family: verdana; height: 205px; width: 325px;">
         <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <div style="border: 1px solid Red; width: 77px; margin-top: 51px; height: 98px; margin-left: 31px;">
                        <img alt="no Image" src="../App_Themes/CoffeyGreen/images/NoImage.jpg" style="width:77px;height:98px;"/>
                    </div>
                </td>
           <td>
                    <div style="border: 0 solid Red;font-weight:bold;font-size: 10px;height: 56px;line-height: 13.5px;margin-left: 12px;margin-top: -7px;width: 76px;">
                    Name
                    <br />
                    Course Name
                    <br />
                    STD ID No
                    <br />
                    Date Of Birth
                    <br />
                    Issue Date
                    <br />
                    Valid Date
                    <br />
                    Contact
                    <br />
                    Sex
                    <br />
                    Blood Group
                    
                    
                    </div>
                </td>
                <td>
                    <div style="border: 0 solid Red; font-size: 10px;height: 56px;line-height: 13.5px;margin-left: 1px;margin-top: -7px;width: 2px;font-weight:bold;">
                    :
                    <br />
                    :
                    <br />
                    :
                    <br />
                    :
                    <br />
                    :
                    <br />
                    :
                    <br />
                    :
                    <br />
                    :
                    <br />
                    :
                    </div>
                </td>
                <td>
                    <div style="border: 0 solid Red;font-size: 10.5px;height: 56px;line-height: 13.5px;margin-left: 4px;margin-top: -4px;width: 130px;">
                    Md. Al Amin Ibrahim
                    <br />
                    FIA
                    <br />
                    00000000
                    <br />
                    1st July 1999
                    <br />
                    1st July 1999
                    <br />
                    1st July 1999
                    <br />
                    00000-000000
                    <br />
                    Male
                    <br />
                    O+
                    
                    </div>
                </td>
            </tr>
         </table> 
    </div>
    <asp:LinkButton ID="lnkPrint" Visible="false"  Text="Print" runat="server" OnClientClick="javascript:printIt(document.getElementById('printThis').innerHTML);"></asp:LinkButton>
                
    <div id='printThis'>
                <asp:Label ID="lblIDCards" runat="server" Text=""></asp:Label>
            </div>
    </form>
</body>
</html>
