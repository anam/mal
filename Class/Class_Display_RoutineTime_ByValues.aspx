<%@ Page Language="C#" MasterPageFile="~/Site2Column.master" AutoEventWireup="true"
    CodeFile="Class_Display_RoutineTime_ByValues.aspx.cs" Inherits="Class_Class_Display_RoutineTime_ByValues"
    Title="Search Routine" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
    <div class="content-box">
        <div class="header">
            <h3>
                Search Routine BY :
                <asp:Label ID="lblParamName" runat="server"></asp:Label></h3>
        </div>
        <div class="inner-form-search">
            <dl>
                 <dt>
                    <asp:Label ID="Label1" runat="server" Text="Campus: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlCampus" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlCampus_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlRoutineID" runat="server" Visible="false">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblClassID" runat="server" Text="Class: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlClassID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlClassID_OnSelectedIndexChanged">
                    </asp:DropDownList>
                </dd>
            
                <dt>
                    <asp:Label ID="lblSubject" runat="server" Text="Subject: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlSubjectID" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSubjectID_SelectedIndexChanged">
                    </asp:DropDownList>
                </dd>
            
                <dt>
                    <asp:Label ID="lblTeacher" runat="server" Text="Teacher: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlEmployeeID" runat="server">
                    </asp:DropDownList>
                </dd>
            
                <dt>&nbsp;</dt>
                <dd>
                    <asp:Button ID="btnShowRoutine" runat="server" Width="129px" Text="Generate Routine For Edit"
                        class="button button-blue" OnClick="btnShowRoutine_Click" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnPrint" runat="server" Width="129px" Text="Print" class="button button-blue"
                        OnClick="btnPrint_Click" />
                        <asp:Button ID="Button2" runat="server" Width="129px" 
                        Text="Print & Archive" class="button button-blue" onclick="btnPrintnArchive_Click"
                        />
                        <br /><a href="DispalyRoutineArchives.aspx" target="_blank">See Routine Archive</a>
                </dd>
            </dl>
        </div>
        
        <div style="width: 780px; overflow: scroll;">
            <asp:Label ID="lblRoutineDisplay" runat="server" Text=""></asp:Label></div>
        <div class="inner-content" id="dvAddRoutine" runat="server">
        </div>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
