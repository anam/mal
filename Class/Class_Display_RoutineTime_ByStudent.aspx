<%@ Page Language="C#" MasterPageFile="~/Site2Column.master" AutoEventWireup="true"
    CodeFile="Class_Display_RoutineTime_ByStudent.aspx.cs" Inherits="Class_Class_Display_RoutineTime_ByValues" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Tabular Routine BY :
                <asp:Label ID="lblParamName" runat="server"></asp:Label></h3>
        </div>
        <div class="inner-form-search">
           
            <dl>
                <dt>
                    <asp:Label ID="lblStudent" runat="server" Text="Student: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtStudent" runat="server" 
                        Text="96B72550-3649-45C6-A1F5-0474A77F4FA" Width="210px"></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>
                   
                </dt>
                <dd>
                   <asp:Button ID="btnShowRoutine" runat="server" Width="129px" 
                        Text="Generate Routine" class="button button-blue" 
                        onclick="btnShowRoutine_Click"  />
                  &nbsp;&nbsp; 
                    <asp:Button ID="btnPrint" runat="server" Width="129px" 
                        Text="Print" class="button button-blue" onclick="btnPrint_Click" />                       
                </dd>
            </dl>
        </div>
        <div class="inner-content" id="dvAddRoutine" runat="server">

        </div>
    </div>
</asp:Content>
