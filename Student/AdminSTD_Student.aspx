<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminSTD_Student.aspx.cs" Inherits="AdminSTD_Student" Title="Add/Update Student" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Add/Update Student</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="lblStudentName" runat="server" Text="Student Name: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtStudentName" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblPPSizePhoto" runat="server" Text="PP Size Photo: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtPPSizePhoto" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblStudentCode" runat="server" Text="Student Code: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtStudentCode" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblPresentAddress" runat="server" Text="Present Address: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtPresentAddress" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblPermanentAddress" runat="server" Text="Permanent Address: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtPermanentAddress" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblTelephone" runat="server" Text="Telephone: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtTelephone" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblMobile" runat="server" Text="Mobile: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtMobile" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblEmail" runat="server" Text="Email: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtEmail" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblDateofBirth" runat="server" Text="Dateof Birth: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtDateofBirth" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblPassportNo" runat="server" Text="Passport No: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtPassportNo" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblGender" runat="server" Text="Gender: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtGender" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblMaritualStatusID" runat="server" Text="Marital Status: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlMaritualStatusID" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblReligionID" runat="server" Text="Religion: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlReligionID" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblSpouseQualification" runat="server" Text="Spouse Qualification: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtSpouseQualification" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblEnglishQualification" runat="server" Text="English Qualification: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtEnglishQualification" class="txt large-input" runat="server"
                        Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblIsRegisterWithACCA" runat="server" Text="Is Register With ACCA: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:RadioButtonList ID="radIsRegisterWithACCA" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>True</asp:ListItem>
                        <asp:ListItem>False</asp:ListItem>
                    </asp:RadioButtonList>
                </dd>
                <dt>
                    <asp:Label ID="lblRegistrationDate" runat="server" Text="Registration Date: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtRegistrationDate" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblRegistrationNo" runat="server" Text="Registration No: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtRegistrationNo" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblBloodGroup" runat="server" Text="Blood Group: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtBloodGroup" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblIELTS" runat="server" Text="IELTS: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtIELTS" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblTOFEL" runat="server" Text="TOFEL: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtTOFEL" class="txt large-input" runat="server" Text="">
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
</asp:Content>
