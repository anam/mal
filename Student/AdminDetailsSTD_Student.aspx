<%@ Page Title="Student Details" Language="C#" MasterPageFile="~/Site2Column.master"
    AutoEventWireup="true" CodeFile="AdminDetailsSTD_Student.aspx.cs" Inherits="Student_AdminDetailsSTD_Student" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link rel="stylesheet" type="text/css" href="../App_Themes/CoffeyGreen/css/grid.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="content-box">
        <div class="header">
            <h3>
                Student Details</h3>
        </div>
        <div class="inner-form">
            <div class="basic">
                <dl>
                    <dt></dt>
                    <dd>
                        <asp:Label runat="server" ID="lblError" Text=""></asp:Label>
                    </dd>
                    <dt>Student Name: </dt>
                    <dd>
                        <asp:Label ID="lblStudentName" runat="server" Text="abc">
                    </asp:Label>
                    </dd>
                    <dt>PP Size Photo: </dt>
                    <dd>
                        <asp:Image ID="imgPhoto" runat="server" Width="150px" Height="150px"></asp:Image>&nbsp;
                    </dd>
                    <dt id="dt_StudentCode" runat="server">Student Code: </dt>
                    <dd id="dd_StudentCode" runat="server">
                        <asp:Label ID="lblStudentCode" runat="server" Text=" abc" Font-Size="20px" ForeColor="Red"
                            Font-Bold="true"></asp:Label>
                    </dd>
                    <dt>Present Address: </dt>
                    <dd>
                        <asp:Label ID="lblPresentAddress" runat="server" Text="abc"></asp:Label>
                    </dd>
                    <dt>Permanent Address: </dt>
                    <dd>
                        <asp:Label ID="lblPermanentAddress" runat="server" Text="abc"></asp:Label>
                    </dd>
                    <dt>Telephone: </dt>
                    <dd>
                        <asp:Label ID="lblTelephone" runat="server" Text=""></asp:Label>
                    </dd>
                    <dt>Mobile: </dt>
                    <dd>
                        <asp:Label ID="lblMobile" runat="server" Text=""></asp:Label>
                    </dd>
                    <dt>Email: </dt>
                    <dd>
                        <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                    </dd>
                    <dt>Dateof Birth: </dt>
                    <dd>
                        <asp:Label ID="lblDateofBirth" runat="server" Text=""></asp:Label>
                    </dd>
                    <dt>Passport No: </dt>
                    <dd>
                        <asp:Label ID="lblPassportNo" runat="server" Text=""></asp:Label>
                    </dd>
                    <dt>Sex: </dt>
                    <dd>
                        <asp:Label ID="lblGender" runat="server" Text=""></asp:Label>
                    </dd>
                    <dt>Marital Status: </dt>
                    <dd>
                        <asp:Label ID="lblMaritualStatusID" runat="server" Text=""></asp:Label>
                    </dd>
                    <dt>Batch: </dt>
                    <dd>
                        <asp:Label ID="lblBatch" runat="server" Text=""></asp:Label>
                    </dd>
                    <dt>Religion: </dt>
                    <dd>
                        <asp:Label ID="lblReligionID" runat="server" Text=""></asp:Label>
                    </dd>
                    <dt>Spouse Qualification: </dt>
                    <dd>
                        <asp:Label ID="lblSpouseQualification" runat="server" Text="Not Mentionable"></asp:Label>
                    </dd>
                    <dt>IELTS score: </dt>
                    <dd>
                        <asp:Label ID="lblIELTS" runat="server" Text="0"></asp:Label>
                    </dd>
                    <dt>TOFEL score: </dt>
                    <dd>
                        <asp:Label ID="lblTOFEL" runat="server" Text="0"></asp:Label>
                    </dd>
                    <dt>English Qualification: </dt>
                    <dd>
                        <asp:Label ID="lblEnglishQualification" runat="server" Text=" Not Mentionable"></asp:Label>
                    </dd>
                    <dt>Is Register With ACCA: </dt>
                    <dd>
                        <asp:Label ID="lblIsRegisterWithACCA" runat="server" Text="Not Mentionable"></asp:Label>
                    </dd>
                    <dt>Registration Date: </dt>
                    <dd>
                        <asp:Label ID="lblRegistrationDate" runat="server" Text=""></asp:Label>
                    </dd>
                    <dt>Registration No: </dt>
                    <dd>
                        <asp:Label ID="lblRegistrationNo" runat="server" Text=""></asp:Label>
                    </dd>
                    <dt>Blood Group: </dt>
                    <dd>
                        <asp:Label ID="lblBloodGroup" runat="server" Text=""></asp:Label>
                    </dd>

                    <dt>ID Card: </dt>
                    <dd>
                        <a ID="a_IDCard" runat="server" target="_blank" class="button button-blue" >Print the id Card</a>
                    </dd>

                   <%-- <dt>&nbsp;</dt>
                    <dd> <a id="a_FeesDetails" runat="server" href="../Fees/FeesInstallment.aspx?StudentCode=" target="_blank">Click here to see the details of the fees for this student</a>
                    </dd>--%>
                </dl>
            </div>
        </div>
    </div>
    <div class="content-box">
        <div class="header">
            <h3>
                Educatinal Background</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <asp:GridView ID="gvCOMN_EducatinalBackground" class="gridCss" runat="server" AutoGenerateColumns="false"
                CssClass="tabel_input">
                <HeaderStyle CssClass="heading" />
                <RowStyle CssClass="row" />
                <AlternatingRowStyle CssClass="altrow" />
                <Columns>
                    <asp:TemplateField HeaderText="Year">
                        <ItemTemplate>
                            <asp:Label ID="lblYear" runat="server" Text='<%#Eval("Year") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Board University">
                        <ItemTemplate>
                            <asp:Label ID="lblBoardUniversity" runat="server" Text='<%#Eval("BoardUniversity") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Education Group">
                        <ItemTemplate>
                            <asp:Label ID="lblEducationGroup" runat="server" Text='<%#Eval("EducationGroup") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Major">
                        <ItemTemplate>
                            <asp:Label ID="lblMajor" runat="server" Text='<%#Eval("Major") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Reault System">
                        <ItemTemplate>
                            <asp:Label ID="lblReaultSystemID" runat="server" Text='<%#Eval("ReaultSystemName") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Degree">
                        <ItemTemplate>
                            <asp:Label ID="lblDegree" runat="server" Text='<%#Eval("Degree") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Result">
                        <ItemTemplate>
                            <asp:Label ID="lblResult" runat="server" Text='<%#Eval("Result") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Score">
                        <ItemTemplate>
                            <asp:Label ID="lblScore" runat="server" Text='<%#Eval("Score") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Out Of">
                        <ItemTemplate>
                            <asp:Label ID="lblOutOf" runat="server" Text='<%#Eval("OutOf") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ID="lbSelectEducationalBackGround" CommandArgument='<%#Eval("EducationalBacgroundID") %>'
                                AlternateText="Edit" OnClick="lbSelectEducationalBackGround_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                            <asp:ImageButton runat="server" ID="lbDeleteEducationalBackGround" CommandArgument='<%#Eval("EducationalBacgroundID") %>'
                                OnClick="lbDeleteEducationalBackGround_Click" AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <div class="content-box">
        <div class="header">
            <h3>
                Job Experience</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <asp:GridView ID="gvCOMN_JobExperience" class="gridCss" runat="server" AutoGenerateColumns="false"
                CssClass="tabel_input">
                <HeaderStyle CssClass="heading" />
                <RowStyle CssClass="row" />
                <AlternatingRowStyle CssClass="altrow" />
                <Columns>
                    <asp:TemplateField HeaderText="User">
                        <ItemTemplate>
                            <asp:Label ID="lblUserID" runat="server" Text='<%#Eval("StudentName") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Organization Name">
                        <ItemTemplate>
                            <asp:Label ID="lblOrganizationName" runat="server" Text='<%#Eval("OrganizationName") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Designation">
                        <ItemTemplate>
                            <asp:Label ID="lblDesignationID" runat="server" Text='<%#Eval("Designation") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Natureof Work">
                        <ItemTemplate>
                            <asp:Label ID="lblNatureofWork" runat="server" Text='<%#Eval("NatureofWork") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date Start">
                        <ItemTemplate>
                            <asp:Label ID="lblDateStart" runat="server" Text='<%#Eval("DateStart","{0:dd MMM yyyy}") %>'>
 	                            </asp:Label>
                            <asp:Label ID="lblDateEnds" runat="server" Text='<%#Eval("DateEnds","{0:dd MMM yyyy}") %>'>
 	                                </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Duration">
                        <ItemTemplate>
                            <asp:Label ID="lblDuration" runat="server" Text='<%#Eval("Duration") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Reasion For Leaving">
                        <ItemTemplate>
                            <asp:Label ID="lblReasionForLeaving" runat="server" Text='<%#Eval("ReasionForLeaving") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Contact">
                        <ItemTemplate>
                            <asp:Label ID="lblContact" runat="server" Text='<%#Eval("Contact") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <div class="content-box">
        <div class="header">
            <h3>
                Student Contact Information</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <asp:GridView ID="gvSTD_Contact" class="gridCss" runat="server" AutoGenerateColumns="false"
                CssClass="tabel_input">
                <HeaderStyle CssClass="heading" />
                <RowStyle CssClass="row" />
                <AlternatingRowStyle CssClass="altrow" />
                <Columns>
                    <asp:TemplateField HeaderText="Contact of">
                        <ItemTemplate>
                            <asp:Label ID="lblContactTypeID" runat="server" Text='<%#Eval("ContactTypeName") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cell No">
                        <ItemTemplate>
                            <asp:Label ID="lblCellNo" runat="server" Text='<%#Eval("CellNo") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Occupation">
                        <ItemTemplate>
                            <asp:Label ID="lblOccupation" runat="server" Text='<%#Eval("Occupation") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Office Tel">
                        <ItemTemplate>
                            <asp:Label ID="lblOfficeTel" runat="server" Text='<%#Eval("OfficeTel") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Office Address">
                        <ItemTemplate>
                            <asp:Label ID="lblOfficeAddress" runat="server" Text='<%#Eval("OfficeAddress") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <div class="inner-content">
        <table>
            <tr>
                <td>
                    <asp:Button ID="btnUpdate" class="button button-blue" runat="server" Text="Update"
                        OnClick="btnUpdate_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
