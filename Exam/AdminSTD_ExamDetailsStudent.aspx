<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminSTD_ExamDetailsStudent.aspx.cs" Inherits="AdminSTD_ExamDetailsStudent"
    Title="STD_ExamDetailsStudent Insert/Update By Admin" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Insert /Update Exam Details Of Students</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="Label1" runat="server" Text="Exam: ">
                        </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlExamID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlExamID_OnSelectedIndexChanged">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblExamDetailsID" runat="server" Text="Exam Details: ">
                        </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlExamDetailsID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlExamDetailsID_OnSelectedIndexChanged">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <%--<asp:Label ID="lblObtainedMark" runat="server" Text="Obtained Mark: ">
    </asp:Label>--%>
                </dt>
                <dd>
                    
                    <asp:GridView ID="gvSTD_Exam" class="gridCss" runat="server" AutoGenerateColumns="false"
                        CssClass="tabel_input">
                        <HeaderStyle CssClass="heading" />
                        <RowStyle CssClass="row" />
                        <AlternatingRowStyle CssClass="altrow" />
                        <Columns>
                            <asp:TemplateField HeaderText="Student Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblStudentName" runat="server" Text='<%#Eval("StudentName") %>'>
 	                                    </asp:Label>
                                    <asp:Label ID="lblSID" runat="server" Text='<%#Eval("StudentID")%>' Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Student Code">
                                <ItemTemplate>
                                    <asp:Label ID="lblStudentCode" runat="server" Text='<%#Eval("StudentCode") %>'>
 	 </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Photo">
                                <ItemTemplate>
                                    <asp:Image ID="imgPhoto" runat="server" ImageUrl='<%#Eval("PPSizePhoto") %>' Width="70px" Height="70px" />
 	
                                </ItemTemplate>
                            </asp:TemplateField>
                           
                            <asp:TemplateField HeaderText="Obtain Marks">
                                <ItemTemplate>
                                   <asp:TextBox ID="txtObtainMark" runat="server" Text='<%#Eval("ObtainedMark")%>' Width="80px"></asp:TextBox>
                                   <ajaxToolkit:FilteredTextBoxExtender ID="ajfte" runat="server" FilterType="Custom" TargetControlID="txtObtainMark" ValidChars="0123456789.00" InvalidChars="abc">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                        </Columns>
                    </asp:GridView>

                    <asp:GridView ID="gvSTD_UpdateExam" class="gridCss" runat="server" AutoGenerateColumns="false" Visible="false"
                        CssClass="tabel_input">
                        <HeaderStyle CssClass="heading" />
                        <RowStyle CssClass="row" />
                        <AlternatingRowStyle CssClass="altrow" />
                        <Columns>
                            <asp:TemplateField HeaderText="Student Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblStudentName" runat="server" Text='<%#Eval("StudentName") %>'>
 	                                    </asp:Label>
                                    <asp:Label ID="lblSID" runat="server" Text='<%#Eval("StudentID")%>' Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Student Code">
                                <ItemTemplate>
                                    <asp:Label ID="lblStudentCode" runat="server" Text='<%#Eval("StudentCode") %>'>
 	 </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Photo">
                                <ItemTemplate>
                                    <asp:Image ID="imgPhoto" runat="server" ImageUrl='<%#Eval("PPSizePhoto") %>' Width="70px" Height="70px" />
 	
                                </ItemTemplate>
                            </asp:TemplateField>
                           
                            <asp:TemplateField HeaderText="Obtain Marks">
                                <ItemTemplate>
                                   <asp:TextBox ID="txtObtainMark" runat="server" Text='<%#Eval("ObtainedMark")%>' Width="80px"></asp:TextBox>
                                   <ajaxToolkit:FilteredTextBoxExtender ID="ajfte" runat="server" FilterType="Custom" TargetControlID="txtObtainMark" ValidChars="0123456789.00" InvalidChars="abc">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                        </Columns>
                    </asp:GridView>

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
