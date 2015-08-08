<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master"  CodeFile="AdminHR_Documents.aspx.cs" Inherits="AdminHR_Documents" Title="HR_Documents Insert/Update By Admin" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 <script type="text/javascript" language="javascript">
     function checkFileExtension(elem) {
         var filePath = elem.value;

         if (filePath.indexOf('.') == -1)
             return false;

         var validExtensions = new Array();
         var ext = filePath.substring(filePath.lastIndexOf('.') + 1).toLowerCase();
         //Add valid extentions in this array
         validExtensions[0] = 'txt';
         validExtensions[1] = 'pdf';
         //validExtensions[2] = 'gif';

         for (var i = 0; i < validExtensions.length; i++) {
             if (ext == validExtensions[i])
                 return true;
         }

         alert('The file extension ' + ext.toUpperCase() + ' is not allowed!. Only allow (.txt,.pdf) extension Docfile.');
         elem.value = "";
         return false;
     }
        
    </script>
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="content-box">
<div class="header">
<h3>Insert /UpdateHR_Documents</h3>
</div>
<div class="inner-form">
<!-- error and information messages -->
  	<dl>
  
    <dt>
     <asp:Label ID="lblCvDocs" runat="server" Text="Cv Docs: ">
    </asp:Label>
     </dt>
    <dd>
     <%--<asp:TextBox ID="txtCvDocs" class="txt large-input" runat="server" Text="">
    </asp:TextBox>--%>
    <asp:FileUpload ID="uplFile" runat="server" Width="90%" onchange="checkFileExtension(this);" />
     </dd>
    <dt>
     <asp:Label ID="lblJobAgreement" runat="server" Text="Job Agreement: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtJobAgreement" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
 <dt></dt>
 <dd>
<asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Add" OnClick="btnAdd_Click" />
<asp:Button ID="btnUpdate" class="button button-blue" runat="server" Text="Update" OnClick="btnUpdate_Click" Visible="false" />
 </dd>
 </dl></div>
 </div>
 </asp:Content>

