<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminHR_WorkingDaysShifting.aspx.cs" Inherits="AdminHR_WorkingDaysShifting"
    Title="HR_WorkingDaysShifting Insert/Update By Admin" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Insert /UpdateHR_WorkingDaysShifting</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <div class="checkbox-form">
                <table>
                    <colgroup>
                        <col width="16%" />
                        <col width="16%" />
                        <col width="16%" />
                        <col width="16%" />
                        <col width="16%" />
                        <col width="16%" />
                    </colgroup>
                    <tbody>
                        <tr>
                            <td>
                                <asp:CheckBox runat="server" ID="chkSaturday" Text="Saturday" />
                            </td>
                            <td>
                                <asp:CheckBox runat="server" ID="chkSunday" Text="Sunday" />
                            </td>
                            <td>
                                <asp:CheckBox runat="server" ID="chkMonday" Text="Monday" />
                            </td>
                            <td>
                                <asp:CheckBox runat="server" ID="chkTuesday" Text="Tuesday" />
                            </td>
                            <td>
                                <asp:CheckBox runat="server" ID="chkWednesday" Text="Wednesday" />
                            </td>
                            <td>
                                <asp:CheckBox runat="server" ID="chkThrusday" Text="Thrusday" />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div style="overflow: hidden; padding-top: 15px;">
                <dl>
                    <dt style="margin-bottom: 4px;">
                        <asp:Label ID="lblShiftStartTime" runat="server" Text="Shift Start Time: ">
                        </asp:Label>
                    </dt>
                    <dd style="margin-bottom: 4px;">
                        <asp:DropDownList ID="ddltime_hoursStart" runat="server">
                            <asp:ListItem>00</asp:ListItem>
                            <asp:ListItem>01</asp:ListItem>
                            <asp:ListItem>02</asp:ListItem>
                            <asp:ListItem>03</asp:ListItem>
                            <asp:ListItem>04</asp:ListItem>
                            <asp:ListItem>05</asp:ListItem>
                            <asp:ListItem>06</asp:ListItem>
                            <asp:ListItem>07</asp:ListItem>
                            <asp:ListItem>08</asp:ListItem>
                            <asp:ListItem>09</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem>12</asp:ListItem>
                            <asp:ListItem>13</asp:ListItem>
                            <asp:ListItem>14</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                            <asp:ListItem>16</asp:ListItem>
                            <asp:ListItem>17</asp:ListItem>
                            <asp:ListItem>18</asp:ListItem>
                            <asp:ListItem>19</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>21</asp:ListItem>
                            <asp:ListItem>22</asp:ListItem>
                            <asp:ListItem>23</asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddltime_minstart" runat="server">
                            <asp:ListItem>00</asp:ListItem>
                            <asp:ListItem>05</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>25</asp:ListItem>
                            <asp:ListItem>30</asp:ListItem>
                            <asp:ListItem>35</asp:ListItem>
                            <asp:ListItem>40</asp:ListItem>
                            <asp:ListItem>45</asp:ListItem>
                            <asp:ListItem>50</asp:ListItem>
                            <asp:ListItem>55</asp:ListItem>
                        </asp:DropDownList>
                    </dd>
                    <dt style="margin-bottom: 4px;">
                        <asp:Label ID="lblShiftEndTime" runat="server" Text="Shift End Time: ">
                        </asp:Label>
                    </dt>
                    <dd style="margin-bottom: 4px;">
                        <asp:DropDownList ID="ddltime_hoursEnd" runat="server">
                            <asp:ListItem>00</asp:ListItem>
                            <asp:ListItem>01</asp:ListItem>
                            <asp:ListItem>02</asp:ListItem>
                            <asp:ListItem>03</asp:ListItem>
                            <asp:ListItem>04</asp:ListItem>
                            <asp:ListItem>05</asp:ListItem>
                            <asp:ListItem>06</asp:ListItem>
                            <asp:ListItem>07</asp:ListItem>
                            <asp:ListItem>08</asp:ListItem>
                            <asp:ListItem>09</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem>12</asp:ListItem>
                            <asp:ListItem>13</asp:ListItem>
                            <asp:ListItem>14</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                            <asp:ListItem>16</asp:ListItem>
                            <asp:ListItem>17</asp:ListItem>
                            <asp:ListItem>18</asp:ListItem>
                            <asp:ListItem>19</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>21</asp:ListItem>
                            <asp:ListItem>22</asp:ListItem>
                            <asp:ListItem>23</asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddltime_minEnd" runat="server">
                            <asp:ListItem>00</asp:ListItem>
                            <asp:ListItem>05</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>25</asp:ListItem>
                            <asp:ListItem>30</asp:ListItem>
                            <asp:ListItem>35</asp:ListItem>
                            <asp:ListItem>40</asp:ListItem>
                            <asp:ListItem>45</asp:ListItem>
                            <asp:ListItem>50</asp:ListItem>
                            <asp:ListItem>55</asp:ListItem>
                        </asp:DropDownList>
                    </dd>
                    <dt>
                        <asp:Label ID="lblDescription" runat="server" Text="Description: ">
                        </asp:Label>
                    </dt>
                    <dd>
                        <asp:TextBox ID="txtDescription" TextMode="MultiLine" class="txt large-input" runat="server"
                            Text=""></asp:TextBox>
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
</asp:Content>
