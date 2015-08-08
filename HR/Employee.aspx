<%@ Page Title="" Language="C#" MasterPageFile="~/Site2Column.master" AutoEventWireup="true"
    CodeFile="Employee.aspx.cs" Inherits="Employee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="content-box">
        <div class="header">
            <h3>
                Employee Profile</h3>
        </div>
        <div class="inner-form">
            	<table width="100%" border="0" align="center" class="tablefont">
                          <tr>
                            <td align="right"  >Employee Rank </td>
                            <td >&nbsp;  <asp:Label ID="lblEmployeeRank" runat="server" Text=""></asp:Label> </td>
                            <td align="right" valign="top"   
                                  rowspan="4">
                                &nbsp;</td>
                            <td align="right" valign="top"   
                                  rowspan="4">
                                 <%-- ~/App_Themes/CoffeyGreen/images/NoImage.jpg--%>
                              <asp:Image runat="server" height="130px" ImageUrl="" Width="130px" ID="imgEmployee" />
                              </td>
                          </tr>
                          <tr>
                            <td width="23%" align="right"  >Department Name</td>
                            <td width="27%" >&nbsp;    <asp:Label 
                                    ID="lblDepartmentName" runat="server" Text=""></asp:Label></td>
                          </tr>
                          <tr>
                            <td width="23%" align="right"  >Employee ID </td>
                            <td width="27%" >&nbsp; <asp:Label 
                                    ID="lblEmployeeID" runat="server" Text=""></asp:Label>
                              </td>
                          </tr>
                          <tr>
                            <td align="right"  >Father's Name </td>
                            <td >&nbsp; <asp:Label ID="lblFathersName" 
                                    runat="server" Text=""></asp:Label>
                              </td>
                          </tr>
						   <tr>
                            <td align="right"  >Husband/Wife Name </td>
                            <td >&nbsp; <asp:Label ID="lblSpouseName" 
                                    runat="server" Text=""></asp:Label>
                               </td>
                            <td align="right" valign="top"  >Mothers Name </td>
                            <td align="left" valign="top" >&nbsp; <asp:Label 
                                    ID="lblMothersName" runat="server" Text=""></asp:Label>
                              </td>
                          </tr>

                          <tr>
                            <td align="right"  >Date Of Birth </td>
                            <td >&nbsp; <asp:Label ID="lblDateOfBirth" 
                                    runat="server" Text=""></asp:Label>
                              </td>
                            <td align="right" valign="top"  >Place of Birth </td>
                            <td align="left" valign="top" >&nbsp; <asp:Label 
                                    ID="lblPlaceOfBirth" runat="server" Text=""></asp:Label>
                              </td>
                          </tr>
                          <tr>
                            <td height="19" align="right"  >Blood Group </td>
                            <td >&nbsp;<label> </label><asp:Label 
                                    ID="lblBloodGroupName" runat="server" Text=""></asp:Label>
                              </td>
                            <td align="right" valign="top"  >Gender</td>
                            <td align="left" valign="top" >&nbsp;
                              <label> </label>
                                <asp:Label ID="lblGender" runat="server" Text=""></asp:Label>
                              </td>
                          </tr>
                          <tr>
                            <td height="18" align="right"  >Religion</td>
                            <td >&nbsp; <asp:Label ID="lblReligionName" 
                                    runat="server" Text=""></asp:Label>
                              </td>
                            <td align="right" valign="top"  >Maritual Status </td>
                            <td align="left" valign="top" >&nbsp; <asp:Label 
                                    ID="lblMaritualStatusName" runat="server" Text=""></asp:Label>
                              </td>
                          </tr>
                          <tr>
                            <td height="18" align="right"  >Nationality</td>
                            <td >&nbsp; <asp:Label ID="lblNationalityName" 
                                    runat="server" Text=""></asp:Label>
                              </td>
                            <td align="right" valign="top"  >Photo</td>
                            <td align="left" valign="top" ><label>&nbsp; </label><asp:Label 
                                    ID="lblPhoto" runat="server" Text=""></asp:Label>
                              </td>
                          </tr>
                          <tr>
                            <td align="right"  >Address </td>
                            <td colspan="3" >&nbsp;<label> </label><asp:Label 
                                    ID="lblAddress" runat="server" Text=""></asp:Label>
                              </td>
                          </tr>
						 <%-- <?
						$sql="select * from final_employee_children_info where EMP_SERIAL_ID='".$empid."'";
						$resch=mysql_query($sql);
						$count_ch=mysql_num_rows($resch); 
						if($count_ch > 0)
						{ ?>
						  <tr>
                            <td align="right"  >Children Info</td>
                            <td colspan="3"  class="tablefont">
							<table border="0" cellpadding="1" cellspacing="1" width="100%" style="font-size:12px">
						
						<?  while($chinfo=mysql_fetch_row($resch))
						  	{

									echo "<tr>
									<td><strong> Name: </strong></td><td>".$chinfo[2]."</td>
									<td><strong> Birth Date: </strong></td><td>".$chinfo[3]."</td>
									<td><strong> Sex: </strong></td><td>".$chinfo[4]."</td>
									</tr>";
							}
								?>--%>
								</table>
            <div style="width: 100%; overflow: hidden; padding-bottom: 25px;">
                <h4 style="width: 100%; line-height: 18px; font-size: 14px; padding-bottom: 2px;
                    color: #5772BD; border-bottom: 1px solid #5772BD;">
                    Contact Information</h4>
                <div style="width: 100%; overflow: hidden; padding: 10px 0;">
                    <table>
                        <colgroup>
                            <col width="45%" />
                            <col width="40%" />
                            <col width="14%" />
                        </colgroup>
                        <tbody>
                            <tr>
                                <td>
                                    <table>
                                        <colgroup>
                                            <col width="140px" />
                                            <col width="5px" />
                                            <col width="155px" />
                                        </colgroup>
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <label class="labelText3">
                                                        Current Address</label>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:Label ID="label17" CssClass="labelText4" runat="server" Text="51/1 Narinda Road, Dhaka"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label class="labelText3">
                                                        Parmanent Address</label>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:Label ID="label18" CssClass="labelText4" runat="server" Text="51/1 Narinda Road, Dhaka"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label class="labelText3">
                                                        Telephone</label>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:Label ID="label19" CssClass="labelText4" runat="server" Text="#########"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label class="labelText3">
                                                        Mobile</label>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:Label ID="label21" CssClass="labelText4" runat="server" Text="#########"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label class="labelText3">
                                                        Email</label>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:Label ID="label20" CssClass="labelText4" runat="server" Text="syedamaliha.aca@gmail.com"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnEdit" CssClass="btn3" runat="server" Text="Edit" />
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <div style="width: 100%; overflow: hidden; padding-bottom: 25px;">
                <h4 style="width: 100%; line-height: 18px; font-size: 14px; padding-bottom: 2px;
                    color: #5772BD; border-bottom: 1px solid #5772BD;">
                    Education Background</h4>
                <div style="width: 92%; margin: 0 auto; overflow: hidden; padding: 10px 0;">
                    <table>
                        <colgroup>
                            <col width="5%" />
                            <col width="30%" />
                            <col width="35%" />
                            <col width="10%" />
                            <col width="10%" />
                            <col width="10%" />
                        </colgroup>
                        <thead style="background-color: #EEF3F9;">
                            <tr>
                                <td style="color: #5772BD">
                                    Sl
                                </td>
                                <td style="color: #5772BD">
                                    Degree
                                </td>
                                <td style="color: #5772BD">
                                    Board/University
                                </td>
                                <td style="color: #5772BD">
                                    Year
                                </td>
                                <td style="color: #5772BD">
                                    Result
                                </td>
                                <td style="color: #5772BD">
                                    Score
                                </td>
                            </tr>
                        </thead>
                        <tr>
                            <td>
                                <asp:Label ID="label22" runat="server" Text="#"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label23" runat="server" Text="O'Levels"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label24" runat="server" Text="Edexel"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label25" runat="server" Text="2007"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label26" runat="server" Text="A"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label27" runat="server" Text="A"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="label28" runat="server" Text="#"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label29" runat="server" Text="O'Levels"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label30" runat="server" Text="Edexel"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label31" runat="server" Text="2007"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label32" runat="server" Text="A"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label33" runat="server" Text="A"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="Button1" CssClass="btn3" runat="server" Text="Edit" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div style="width: 100%; overflow: hidden; padding-bottom: 25px;">
                <h4 style="width: 100%; line-height: 18px; font-size: 14px; padding-bottom: 2px;
                    color: #5772BD; border-bottom: 1px solid #5772BD;">
                    Job Experience</h4>
                <div style="width: 92%; margin: 0 auto; overflow: hidden; padding: 10px 0;">
                    <table>
                        <colgroup>
                            <col width="25%" />
                            <col width="15%" />
                            <col width="15%" />
                            <col width="15%" />
                            <col width="20%" />
                            <col width="10%" />
                        </colgroup>
                        <thead style="background-color: #EEF3F9;">
                            <tr>
                                <td style="color: #5772BD">
                                    Organization
                                </td>
                                <td style="color: #5772BD">
                                    Position
                                </td>
                                <td style="color: #5772BD">
                                    Date Start
                                </td>
                                <td style="color: #5772BD">
                                    Date End
                                </td>
                                <td style="color: #5772BD">
                                    Reason For Leaving
                                </td>
                                <td style="color: #5772BD">
                                    Contact
                                </td>
                            </tr>
                        </thead>
                        <tr>
                            <td>
                                <asp:Label ID="label34" runat="server" Text="The Solution Center"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label35" runat="server" Text="Assistant"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label36" runat="server" Text="000-00-00"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label37" runat="server" Text="000-00-00"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label38" runat="server" Text="#"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label39" runat="server" Text="#"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="label40" runat="server" Text="The Solution Center"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label41" runat="server" Text="Assistant"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label42" runat="server" Text="000-00-00"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label43" runat="server" Text="000-00-00"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label44" runat="server" Text="#"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label45" runat="server" Text="#"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="Button2" CssClass="btn3" runat="server" Text="Edit" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div style="width: 100%; overflow: hidden; padding-bottom: 25px;">
                <h4 style="width: 100%; line-height: 18px; font-size: 14px; padding-bottom: 2px;
                    color: #5772BD; border-bottom: 1px solid #5772BD;">
                    Personal Documents</h4>
                <div style="width: 92%; margin: 0 auto; overflow: hidden; padding: 10px 0;">
                    <table>
                        <colgroup>
                            <col width="20%" />
                            <col width="30%" />
                            <col width="22%" />
                            <col width="20%" />
                            <col width="8%" />
                        </colgroup>
                        <tr>
                            <td>
                                <asp:Label ID="label46" runat="server" Text="CV"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label47" runat="server" Text="########"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label48" runat="server" Text="Job Agreement"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label49" runat="server" Text="########"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="label50" runat="server" Text="Educational Docs"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label51" runat="server" Text="########"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label52" runat="server" Text="Job Experience Letter"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label53" runat="server" Text="########"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="Button3" CssClass="btn3" runat="server" Text="Edit" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div style="width: 100%; overflow: hidden; padding-bottom: 25px;">
                <h4 style="width: 100%; line-height: 18px; font-size: 14px; padding-bottom: 2px;
                    color: #5772BD; border-bottom: 1px solid #5772BD;">
                    Positioning Information</h4>
                <div style="width: 92%; margin: 0 auto; overflow: hidden; padding: 10px 0;">
                    <table>
                        <colgroup>
                            <col width="20%" />
                            <col width="30%" />
                            <col width="22%" />
                            <col width="20%" />
                            <col width="8%" />
                        </colgroup>
                        <tr>
                            <td>
                                <asp:Label ID="label54" runat="server" Text="Department"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label55" runat="server" Text="########"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label56" runat="server" Text="Designation"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label57" runat="server" Text="########"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="label58" runat="server" Text="Job Location"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label59" runat="server" Text="########"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label60" runat="server" Text="Supervisor"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label61" runat="server" Text="########"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="label62" runat="server" Text="Joining Date"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label63" runat="server" Text="########"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label64" runat="server" Text="Status"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label65" runat="server" Text="########"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="label66" runat="server" Text="Ending Date"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label67" runat="server" Text="########"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label68" runat="server" Text="Posting Date"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label69" runat="server" Text="########"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="label70" runat="server" Text="Job Responsibility"></asp:Label>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="Button4" CssClass="btn3" runat="server" Text="Edit" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div style="width: 100%; overflow: hidden; padding-bottom: 25px;">
                <h4 style="width: 100%; line-height: 18px; font-size: 14px; padding-bottom: 2px;
                    color: #5772BD; border-bottom: 1px solid #5772BD;">
                    Shifting &amp; Working Days</h4>
                <div style="width: 92%; margin: 0 auto; overflow: hidden; padding: 10px 0;">
                    <table>
                        <colgroup>
                            <col width="30%" />
                            <col width="20%" />
                            <col width="30%" />
                            <col width="20%" />
                        </colgroup>
                        <tr>
                            <td>
                                <asp:Label ID="label71" runat="server" Text="Shift Start Time"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label72" runat="server" Text="########"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label73" runat="server" Text="Shift End Time"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label74" runat="server" Text="########"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="label75" runat="server" Text="Description"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label76" runat="server" Text="############"></asp:Label>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </div>
                <h5 style="line-height: 16px; font-size: 12px; color: #647DC2; padding-bottom: 5px;">
                    Working Days</h5>
                <table>
                    <colgroup>
                        <col width="3%" />
                        <col width="1%" />
                        <col width="13%" />
                        <col width="3%" />
                        <col width="1%" />
                        <col width="13%" />
                        <col width="3%" />
                        <col width="1%" />
                        <col width="13%" />
                        <col width="3%" />
                        <col width="1%" />
                        <col width="13%" />
                        <col width="3%" />
                        <col width="1%" />
                        <col width="16%" />
                        <col width="3%" />
                        <col width="1%" />
                        <col width="13%" />
                    </colgroup>
                    <tr>
                        <td>
                            <asp:CheckBox ID="ckBox1" runat="server" />
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:Label ID="lbl1" runat="server" Text="Saturday"></asp:Label>
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:Label ID="Label77" runat="server" Text="Sunday"></asp:Label>
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBox2" runat="server" />
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:Label ID="Label78" runat="server" Text="Monday"></asp:Label>
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBox3" runat="server" />
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:Label ID="Label79" runat="server" Text="Tuesday"></asp:Label>
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBox4" runat="server" />
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:Label ID="Label80" runat="server" Text="Wednesday"></asp:Label>
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBox5" runat="server" />
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:Label ID="Label81" runat="server" Text="Thursday"></asp:Label>
                        </td>
                    </tr>
                </table>
                <span style="width: 100%; overflow: hidden; display: block; padding: 4px 0;">
                    <asp:Button ID="btnEdit1" runat="server" Text="Edit" CssClass="btn4" /></span>
            </div>
            <div style="width: 100%; overflow: hidden; padding-bottom: 25px;">
                <h4 style="width: 100%; line-height: 18px; font-size: 14px; padding-bottom: 2px;
                    color: #5772BD; border-bottom: 1px solid #5772BD;">
                    Attendance Rules</h4>
                <div style="width: 92%; margin: 0 auto; overflow: hidden; padding: 10px 0;">
                    <table>
                        <colgroup>
                            <col width="20%" />
                            <col width="30%" />
                            <col width="20%" />
                            <col width="22%" />
                            <col width="8%" />
                        </colgroup>
                        <tr>
                            <td>
                                <label class="labelText5">
                                    Attendance Rules
                                </label>
                            </td>
                            <td>
                                <asp:Label ID="label83" runat="server" Text="Regular"></asp:Label>
                            </td>
                            <td>
                                <label class="labelText5">
                                    Flexible Time
                                </label>
                            </td>
                            <td>
                                <asp:Label ID="label85" runat="server" Text="30min"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="Button5" CssClass="btn3" runat="server" Text="Edit" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div style="width: 100%; overflow: hidden; padding-bottom: 25px;">
                <h4 style="width: 100%; line-height: 18px; font-size: 14px; padding-bottom: 2px;
                    color: #5772BD; border-bottom: 1px solid #5772BD;">
                    Lunch Rules</h4>
                <div style="width: 92%; margin: 0 auto; overflow: hidden; padding: 10px 0;">
                    <table>
                        <colgroup>
                            <col width="20%" />
                            <col width="30%" />
                            <col width="20%" />
                            <col width="22%" />
                            <col width="8%" />
                        </colgroup>
                        <tr>
                            <td>
                                <label class="labelText5">
                                    Lunch Rules
                                </label>
                            </td>
                            <td>
                                <asp:Label ID="label82" runat="server" Text="Not Allowed"></asp:Label>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="Button6" CssClass="btn3" runat="server" Text="Edit" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div style="width: 100%; overflow: hidden; padding-bottom: 25px;">
                <h4 style="width: 100%; line-height: 18px; font-size: 14px; padding-bottom: 2px;
                    color: #5772BD; border-bottom: 1px solid #5772BD;">
                    Salary Rules</h4>
                <div style="width: 92%; margin: 0 auto; overflow: hidden; padding: 10px 0;">
                    <table>
                        <colgroup>
                            <col width="12%" />
                            <col width="30%" />
                            <col width="12%" />
                            <col width="40%" />
                            <col width="6%" />
                        </colgroup>
                        <tr>
                            <td>
                                <label class="labelText5">
                                    Salary
                                </label>
                            </td>
                            <td>
                                <asp:Label ID="label84" runat="server" Text="Gross--30000"></asp:Label>
                            </td>
                            <td>
                                <label class="labelText5">
                                    Total Salary
                                </label>
                            </td>
                            <td>
                                <asp:Label ID="label86" runat="server" Text="30000"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <table>
                                    <colgroup>
                                        <col width="40%" />
                                        <col width="60%" />
                                    </colgroup>
                                    <tr>
                                        <td>
                                            <label class="labelText5">
                                                Rules #1
                                            </label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblHouseRent" runat="server" Text="House Rent"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label class="labelText5">
                                                Rules #2
                                            </label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label87" runat="server" Text="Medical Allowances"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label class="labelText5">
                                                Rules #3
                                            </label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label88" runat="server" Text="Transportation"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                            </td>
                            <td>
                                <table>
                                    <colgroup>
                                        <col width="15%" />
                                        <col width="10%" />
                                        <col width="25%" />
                                        <col width="13%" />
                                        <col width="12%" />
                                        <col width="25%" />
                                    </colgroup>
                                    <tr>
                                        <td>
                                            <label class="labelText5">
                                                Ratio
                                            </label>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label89" runat="server" Text="40"></asp:Label>
                                        </td>
                                        <td>
                                            <label class="labelText5">
                                                %
                                            </label>
                                        </td>
                                        <td>
                                            <label class="labelText5">
                                                =
                                            </label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label90" runat="server" Text="27000"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label class="labelText5">
                                                Ratio
                                            </label>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label91" runat="server" Text="1000"></asp:Label>
                                        </td>
                                        <td>
                                            <label class="labelText5">
                                                +
                                            </label>
                                        </td>
                                        <td>
                                            <label class="labelText5">
                                                =
                                            </label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label92" runat="server" Text="1000"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label class="labelText5">
                                                Ratio
                                            </label>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label93" runat="server" Text="2000"></asp:Label>
                                        </td>
                                        <td>
                                            <label class="labelText5">
                                                +
                                            </label>
                                        </td>
                                        <td>
                                            <label class="labelText5">
                                                =
                                            </label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label94" runat="server" Text="2000"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="Button7" CssClass="btn3" runat="server" Text="Edit" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div style="width: 100%; overflow: hidden; padding-bottom: 25px;">
                <h4 style="width: 100%; line-height: 18px; font-size: 14px; padding-bottom: 2px;
                    color: #5772BD; border-bottom: 1px solid #5772BD;">
                    Providend Fund</h4>
                <div style="width: 92%; margin: 0 auto; overflow: hidden; padding: 10px 0;">
                    <table>
                        <colgroup>
                            <col width="10%" />
                            <%--<col width="10%" />--%>
                            <col width="84%" />
                            <col width="6%" />
                        </colgroup>
                        <tr>
                            <td>
                                <label class="labelText5">
                                    Amount
                                </label>
                            </td>
                            <td>
                                <asp:Label ID="label95" runat="server" Text="TK"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="Button8" CssClass="btn3" runat="server" Text="Edit" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div style="width: 100%; overflow: hidden; padding-bottom: 25px;">
                <h4 style="width: 100%; line-height: 18px; font-size: 14px; padding-bottom: 2px;
                    color: #5772BD; border-bottom: 1px solid #5772BD;">
                    Overtime Rules</h4>
                <div style="width: 92%; margin: 0 auto; overflow: hidden; padding: 10px 0;">
                    <table>
                        <colgroup>
                            <col width="10%" />
                            <%--<col width="10%" />--%>
                            <col width="84%" />
                            <col width="6%" />
                        </colgroup>
                        <tr>
                            <td>
                                <label class="labelText5">
                                    Overtime
                                </label>
                            </td>
                            <td>
                                <asp:Label ID="label96" runat="server" Text="Not Allowed"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="Button9" CssClass="btn3" runat="server" Text="Edit" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div style="width: 100%; overflow: hidden; padding-bottom: 25px;">
                <h4 style="width: 100%; line-height: 18px; font-size: 14px; padding-bottom: 2px;
                    color: #5772BD; border-bottom: 1px solid #5772BD;">
                    Salary Increment Rules Setup</h4>
                <div style="width: 92%; margin: 0 auto; overflow: hidden; padding: 10px 0;">
                    <table>
                        <colgroup>
                            <col width="10%" />
                            <%--<col width="10%" />--%>
                            <col width="84%" />
                            <col width="6%" />
                        </colgroup>
                        <tr>
                            <td>
                                <label class="labelText5">
                                    Increment
                                </label>
                            </td>
                            <td>
                                <asp:Label ID="label97" runat="server" Text="3000 Tk Effective After 1 Year And 0 Month"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="Button10" CssClass="btn3" runat="server" Text="Edit" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div style="width: 100%; overflow: hidden; padding-bottom: 25px;">
                <h4 style="width: 100%; line-height: 18px; font-size: 14px; padding-bottom: 2px;
                    color: #5772BD; border-bottom: 1px solid #5772BD;">
                    Tax Rules Setup</h4>
                <div style="width: 92%; margin: 0 auto; overflow: hidden; padding: 10px 0;">
                    <table>
                        <colgroup>
                            <col width="10%" />
                            <%--<col width="10%" />--%>
                            <col width="84%" />
                            <col width="6%" />
                        </colgroup>
                        <tr>
                            <td>
                                <label class="labelText5">
                                    Tax
                                </label>
                            </td>
                            <td>
                                <asp:Label ID="label98" runat="server" Text="0.00 Tk"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="Button11" CssClass="btn3" runat="server" Text="Edit" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div style="width: 100%; overflow: hidden; padding-bottom: 25px;">
                <h4 style="width: 100%; line-height: 18px; font-size: 14px; padding-bottom: 2px;
                    color: #5772BD; border-bottom: 1px solid #5772BD;">
                    Benifit Rules</h4>
                <div style="width: 92%; margin: 0 auto; overflow: hidden; padding: 10px 0;">
                    <span style="line-height: 16px; font-weight: bold; width: 75px; display: block; border-bottom: 1px solid #067000;
                        font-size: 12px; color: #067000; margin-bottom: 5px;">Benifit Rules</span>
                    <table>
                        <colgroup>
                            <col width="3%" />
                            <col width="1%" />
                            <col width="15%" />
                            <col width="52%" />
                            <col width="20%" />
                            <col width="9%" />
                        </colgroup>
                        <tr>
                            <td>
                                <asp:CheckBox ID="CheckBox6" runat="server" />
                            </td>
                            <td>
                            </td>
                            <td>
                                <label class="labelText5">
                                    Eid Bonus
                                </label>
                            </td>
                            <td>
                                <asp:Label ID="label99" runat="server" Text="Effective After 0 Years 6 Months of joining"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="label100" runat="server" Text="Mgmt Decision"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="Button12" CssClass="btn3" runat="server" Text="Edit" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div style="width: 100%; overflow: hidden; padding-bottom: 25px;">
                <h4 style="width: 100%; line-height: 18px; font-size: 14px; padding-bottom: 2px;
                    color: #5772BD; border-bottom: 1px solid #5772BD;">
                    Salary Adjustment Rules Setup</h4>
                <div style="width: 92%; margin: 0 auto; overflow: hidden; padding: 10px 0;">
                    <span style="line-height: 16px; font-weight: bold; width: 140px; display: block;
                        border-bottom: 1px solid #067000; font-size: 12px; color: #067000; margin-bottom: 5px;">
                        Salary Adjustment Lists </span>
                    <table>
                        <colgroup>
                            <col width="91%" />
                            <col width="9%" />
                        </colgroup>
                        <tr>
                            <td>
                                <asp:Label ID="label108" runat="server" Text="#########"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="Button13" CssClass="btn3" runat="server" Text="Edit" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div style="width: 100%; overflow: hidden; padding-bottom: 25px;">
                <h4 style="width: 100%; line-height: 18px; font-size: 14px; padding-bottom: 2px;
                    color: #5772BD; border-bottom: 1px solid #5772BD;">
                    Leaves Rules</h4>
                <div style="width: 92%; margin: 0 auto; overflow: hidden; padding: 10px 0;">
                    <span style="line-height: 16px; font-weight: bold; width: 70px; display: block; border-bottom: 1px solid #067000;
                        font-size: 12px; color: #067000; margin-bottom: 5px;">Leave Lists </span>
                    <table>
                        <colgroup>
                            <col width="91%" />
                            <col width="9%" />
                        </colgroup>
                        <tr>
                            <td>
                                <asp:Label ID="label107" runat="server" Text="#########"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="Button14" CssClass="btn3" runat="server" Text="Edit" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div style="width: 100%; overflow: hidden; padding-bottom: 25px;">
                <h4 style="width: 100%; line-height: 18px; font-size: 14px; padding-bottom: 2px;
                    color: #5772BD; border-bottom: 1px solid #5772BD;">
                    Bank Account</h4>
                <div style="width: 92%; margin: 0 auto; overflow: hidden; padding: 10px 0;">
                    <table>
                        <colgroup>
                            <col width="5%" />
                            <col width="15%" />
                            <col width="30%" />
                            <col width="15%" />
                            <col width="30%" />
                            <col width="5%" />
                        </colgroup>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <label class="labelText5">
                                    Bank Account No
                                </label>
                            </td>
                            <td>
                                <asp:Label ID="label101" runat="server" Text="######"></asp:Label>
                            </td>
                            <td>
                                <label class="labelText5">
                                    Account Name
                                </label>
                            </td>
                            <td>
                                <asp:Label ID="label102" runat="server" Text="########"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <label class="labelText5">
                                    Bank Name
                                </label>
                            </td>
                            <td>
                                <asp:Label ID="label103" runat="server" Text="#########"></asp:Label>
                            </td>
                            <td>
                                <label class="labelText5">
                                    Contact Person
                                </label>
                            </td>
                            <td>
                                <asp:Label ID="label104" runat="server" Text="########"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <label class="labelText5">
                                    Bank Address
                                </label>
                            </td>
                            <td>
                                <asp:Label ID="label105" runat="server" Text="#########"></asp:Label>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="Button15" CssClass="btn3" runat="server" Text="Edit" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div style="width: 100%; overflow: hidden; padding-bottom: 10px;">
                <h4 style="width: 100%; line-height: 18px; font-size: 14px; padding-bottom: 2px;
                    color: #5772BD; border-bottom: 1px solid #5772BD;">
                    Retirement Rules</h4>
                <div style="width: 92%; margin: 0 auto; overflow: hidden; padding: 10px 0;">
                    <span style="line-height: 16px; font-weight: bold; width: 95px; display: block; border-bottom: 1px solid #067000;
                        font-size: 12px; color: #067000; margin-bottom: 5px;">Retirement Lists </span>
                    <table>
                        <colgroup>
                            <col width="91%" />
                            <col width="9%" />
                        </colgroup>
                        <tr>
                            <td>
                                <asp:Label ID="label106" runat="server" Text="#########"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="Button16" CssClass="btn3" runat="server" Text="Edit" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div style="width:50%; margin:0 auto; overflow:hidden;">
                <asp:Button ID="Button17" CssClass="btn5" runat="server" Text="Print" />
            </div>
        </div>
    </div>
</asp:Content>
