<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UCContact.ascx.cs" Inherits="HR_Control_UCContact" %>
<div style="width: 100%; overflow: hidden; padding-bottom: 25px;">
                <h4 style="width: 100%; line-height: 18px; font-size: 14px; padding-bottom: 2px;
                    color: #5772BD; border-bottom: 1px solid #5772BD;">
                    Contact Information</h4>
                <div style="width: 100%; overflow: hidden; padding: 10px 0;">
                    <table width="100%">
                        <colgroup>
                            <col width="45%" />
                            <col width="10%" />
                            <col width="45%" />
                        </colgroup>
                        <tbody>
                            <tr>
                                <td>
                                    <table>
                                        <colgroup>
                                            <col width="45%"/>
                                            <col width="10%" />
                                            <col width="45%" />
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
                                                  <asp:Label ID="lblContactID"  Visible="false" runat="server" Text=""></asp:Label>
                                                    <asp:Label ID="lblCurrentAddress" CssClass="labelText4" runat="server" Text=""></asp:Label>
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
                                                    <asp:Label ID="lblPermanentAddress" CssClass="labelText4" runat="server" Text=""></asp:Label>
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
                                                    <asp:Label ID="lblTelephone" CssClass="labelText4" runat="server" Text=""></asp:Label>
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
                                                    <asp:Label ID="lblMobile" CssClass="labelText4" runat="server" Text=""></asp:Label>
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
                                                    <asp:Label ID="lblEmail" CssClass="labelText4" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <%--<tr>
                                                <td>
                                                <p>
                                                <asp:Button ID="btnEdit" CssClass="button button-ash" runat="server" Text="Edit" 
                                                        onclick="btnEditContact_Click" />
                                                </p>
                                                
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    
                                                </td>
                                            </tr>--%>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
