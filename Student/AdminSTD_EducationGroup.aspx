<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminSTD_EducationGroup.aspx.cs"
    Inherits="AdminSTD_EducationGroup" Title="Add/Update Education Group" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" class="basic" runat="server">
    <div class="content-box">
        <div class="header">
            <h3>
                Add/Update Education Group</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="lblEducationGroupName" runat="server" Text="Education Group Name: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtEducationGroupName" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
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
    </div>
    </form>
</body>
</html>
