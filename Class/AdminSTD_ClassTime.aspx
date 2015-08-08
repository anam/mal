<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master"  CodeFile="AdminSTD_ClassTime.aspx.cs" Inherits="AdminSTD_ClassTime" Title="STD_ClassTime Insert/Update By Admin" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="content-box">
<div class="header">
<h3>Insert / Update ClassTime</h3>
</div>
<div class="inner-form">
<!-- error and information messages -->
  	<dl>
    <dt>
     <asp:Label ID="lblClassTimeName" runat="server" Text="Class Time Name: ">
    </asp:Label>
     </dt>
    <dd>
        Start time
        <asp:DropDownList ID="ddlStartHour" runat="server">
            <asp:ListItem Value="0">0</asp:ListItem>
            <asp:ListItem Value="1">1</asp:ListItem>
            <asp:ListItem Value="2">2</asp:ListItem>
            <asp:ListItem Value="3">3</asp:ListItem>
            <asp:ListItem Value="4">4</asp:ListItem>
            <asp:ListItem Value="5">5</asp:ListItem>
            <asp:ListItem Value="6">6</asp:ListItem>
            <asp:ListItem Value="7">7</asp:ListItem>
            <asp:ListItem Value="8">8</asp:ListItem>
            <asp:ListItem Value="9">9</asp:ListItem>
            <asp:ListItem Value="10">10</asp:ListItem>
            <asp:ListItem Value="11">11</asp:ListItem>
            <asp:ListItem Value="12">12</asp:ListItem>
        </asp:DropDownList>:
<asp:DropDownList ID="ddlStartMin" runat="server">
        <asp:ListItem Value="00">00</asp:ListItem>
<asp:ListItem Value="05">05</asp:ListItem>
<asp:ListItem Value="10">10</asp:ListItem>
<asp:ListItem Value="15">15</asp:ListItem>
<asp:ListItem Value="20">20</asp:ListItem>
<asp:ListItem Value="25">25</asp:ListItem>
<asp:ListItem Value="30">30</asp:ListItem>
<asp:ListItem Value="35">35</asp:ListItem>
<asp:ListItem Value="40">40</asp:ListItem>
<asp:ListItem Value="45">45</asp:ListItem>
<asp:ListItem Value="50">50</asp:ListItem>
<asp:ListItem Value="55">55</asp:ListItem>
</asp:DropDownList>
&nbsp;
<asp:DropDownList ID="ddlStartAMPM" runat="server">
            <asp:ListItem Value="AM">AM</asp:ListItem>
            <asp:ListItem Value="PM">PM</asp:ListItem>
        </asp:DropDownList>
End time
        <asp:DropDownList ID="ddlEndHour" runat="server">
            <asp:ListItem Value="0">0</asp:ListItem>
            <asp:ListItem Value="1">1</asp:ListItem>
            <asp:ListItem Value="2">2</asp:ListItem>
            <asp:ListItem Value="3">3</asp:ListItem>
            <asp:ListItem Value="4">4</asp:ListItem>
            <asp:ListItem Value="5">5</asp:ListItem>
            <asp:ListItem Value="6">6</asp:ListItem>
            <asp:ListItem Value="7">7</asp:ListItem>
            <asp:ListItem Value="8">8</asp:ListItem>
            <asp:ListItem Value="9">9</asp:ListItem>
            <asp:ListItem Value="10">10</asp:ListItem>
            <asp:ListItem Value="11">11</asp:ListItem>
            <asp:ListItem Value="12">12</asp:ListItem>
        </asp:DropDownList>:
<asp:DropDownList ID="ddlEndMin" runat="server">
        <asp:ListItem Value="00">00</asp:ListItem>
<asp:ListItem Value="05">05</asp:ListItem>
<asp:ListItem Value="10">10</asp:ListItem>
<asp:ListItem Value="15">15</asp:ListItem>
<asp:ListItem Value="20">20</asp:ListItem>
<asp:ListItem Value="25">25</asp:ListItem>
<asp:ListItem Value="30">30</asp:ListItem>
<asp:ListItem Value="35">35</asp:ListItem>
<asp:ListItem Value="40">40</asp:ListItem>
<asp:ListItem Value="45">45</asp:ListItem>
<asp:ListItem Value="50">50</asp:ListItem>
<asp:ListItem Value="55">55</asp:ListItem>
</asp:DropDownList>
&nbsp;
<asp:DropDownList ID="ddlEndAMPM" runat="server">
            <asp:ListItem Value="AM">AM</asp:ListItem>
            <asp:ListItem Value="PM">PM</asp:ListItem>
        </asp:DropDownList>

     <asp:TextBox ID="txtClassTimeName" Visible="false" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt style="display:none;">
     <asp:Label ID="lblDuration" runat="server" Text="Duration: ">
    </asp:Label>
     </dt>
    <dd style="display:none;">
     <asp:TextBox ID="txtDuration" class="txt large-input" runat="server" Text="0">
    </asp:TextBox>
     </dd>
    <dt >
     <asp:Label ID="lblOrder" runat="server" Text="Order: ">
    </asp:Label>
     </dt>
    <dd >
     <asp:TextBox ID="txtOrder" class="txt large-input" runat="server" Text="0">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblClassTimeGroupID" runat="server" Text="Class Time Group: ">
    </asp:Label>
     </dt>
    <dd >
    <asp:DropDownList ID="ddlClassTimeGroupID" runat="server">
     </asp:DropDownList>
     </dd>
    <dt style="display:none;">
     <asp:Label ID="lblStartTime" runat="server" Text="Start Time: ">
    </asp:Label>
     </dt>
    <dd style="display:none;">
     <asp:TextBox ID="txtStartTime" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt style="display:none;">
     <asp:Label ID="lblEndTime" runat="server" Text="End Time: ">
    </asp:Label>
     </dt>
    <dd style="display:none;">
     <asp:TextBox ID="txtEndTime" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt style="display:none;">
     <asp:Label ID="lblExtraField1" runat="server" Text="Extra Field 1: ">
    </asp:Label>
     </dt>
    <dd style="display:none;">
     <asp:TextBox ID="txtExtraField1" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt style="display:none;">
     <asp:Label ID="lblExtraField2" runat="server" Text="Extra Field 2: ">
    </asp:Label>
     </dt>
    <dd style="display:none;">
     <asp:TextBox ID="txtExtraField2" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt style="display:none;">
     <asp:Label ID="lblExtraField3" runat="server" Text="Extra Field 3: ">
    </asp:Label>
     </dt>
    <dd style="display:none;">
     <asp:TextBox ID="txtExtraField3" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt style="display:none;">
     <asp:Label ID="lblExtraField4" runat="server" Text="Extra Field 4: ">
    </asp:Label>
     </dt>
    <dd style="display:none;">
     <asp:TextBox ID="txtExtraField4" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt style="display:none;">
     <asp:Label ID="lblExtraField5" runat="server" Text="Extra Field 5: ">
    </asp:Label>
     </dt>
    <dd style="display:none;">
     <asp:TextBox ID="txtExtraField5" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblRowStatusID" runat="server" Text="Row Status: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlRowStatusID" runat="server">
     </asp:DropDownList>
     </dd>
 <dt></dt>
 <dd>
<asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Add" OnClick="btnAdd_Click" />
<asp:Button ID="btnUpdate" class="button button-blue" runat="server" Text="Update" OnClick="btnUpdate_Click" Visible="false" />
    <div id="divNewRoutineTimeGourp" runat="server" visible="false">
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
         <%--OR Enter the New Time Set--%> 
    <asp:TextBox ID="txtNewTimeGroupName" runat="server" class="txt medium-input" Visible="false"></asp:TextBox>
    <br />
<asp:Button ID="Button1" class="button button-blue" runat="server" Text="Add with New Time Group" OnClick="btnAddWithNewTimeGroup_Click" />

    </div>
 </dd>
 </dl></div>
 </div>
 </asp:Content>

