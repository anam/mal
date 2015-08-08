<%@ Page Title="" Language="C#" MasterPageFile="~/Site2ColumnExternal.master" AutoEventWireup="true"
    CodeFile="OnlineQuestions.aspx.cs" Inherits="Online Questions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="content-box ">
        <div class="header">
            <h3>
                Online Questions</h3>
        </div>
        <!-- Default basic forms -->
        <div class="inner-form">
            <div style="width: 98%; margin: 0 auto; text-align: left; overflow: hidden;">
                <div style="width: 100%; overflow: hidden; padding-bottom: 15px;">
                    <h5 style="width: 100%; line-height: 16px; font-size: 14px; color: #0672CA; padding-bottom: 10px;
                        font-weight: normal;">
                        <asp:Label ID="lblqs1" runat="server" Text="1.Choice the correct(one) answer"></asp:Label>
                    </h5>
                    <ul class="qsList">
                        <li>
                            <asp:RadioButton ID="rdb1" runat="server" CssClass="rdbCss" />
                            <asp:Label ID="lblAns1" runat="server" CssClass="ansCss" Text="This is Answer number 1"></asp:Label>
                        </li>
                        <li>
                            <asp:RadioButton ID="RadioButton1" runat="server" CssClass="rdbCss" />
                            <asp:Label ID="Label1" runat="server" CssClass="ansCss" Text="This is Answer number 1"></asp:Label>
                        </li>
                        <li>
                            <asp:RadioButton ID="RadioButton2" runat="server" CssClass="rdbCss" />
                            <asp:Label ID="Label2" runat="server" CssClass="ansCss" Text="This is Answer number 1"></asp:Label>
                        </li>
                        <li>
                            <asp:RadioButton ID="RadioButton3" runat="server" CssClass="rdbCss" />
                            <asp:Label ID="Label3" runat="server" CssClass="ansCss" Text="This is Answer number 1"></asp:Label>
                        </li>
                    </ul>
                </div>
                <div style="width: 100%; overflow: hidden; padding-bottom: 15px;">
                    <h5 style="width: 100%; line-height: 16px; font-size: 14px; color: #0672CA; padding-bottom: 10px;
                        font-weight: normal;">
                        <asp:Label ID="Label4" runat="server" Text="2.Whice are the correct answers.Please tick those left boxes"></asp:Label>
                    </h5>
                    <ul class="qsList">
                        <li>
                            <asp:CheckBox ID="chkbox1" runat="server" CssClass="chkCss" />
                            <asp:Label ID="Label5" runat="server" CssClass="ansCss" Text="This is Answer number 1"></asp:Label>
                        </li>
                        <li>
                            <asp:CheckBox ID="CheckBox1" runat="server" CssClass="chkCss" />
                            <asp:Label ID="Label6" runat="server" CssClass="ansCss" Text="This is Answer number 1"></asp:Label>
                        </li>
                        <li>
                            <asp:CheckBox ID="CheckBox2" runat="server" CssClass="chkCss" />
                            <asp:Label ID="Label7" runat="server" CssClass="ansCss" Text="This is Answer number 1"></asp:Label>
                        </li>
                        <li>
                            <asp:CheckBox ID="CheckBox3" runat="server" CssClass="chkCss" />
                            <asp:Label ID="Label8" runat="server" CssClass="ansCss" Text="This is Answer number 1"></asp:Label>
                        </li>
                        <li>
                            <asp:CheckBox ID="CheckBox4" runat="server" CssClass="chkCss" />
                            <asp:Label ID="Label22" runat="server" CssClass="ansCss" Text="This is Answer number 1"></asp:Label>
                        </li>
                        <li>
                            <asp:CheckBox ID="CheckBox5" runat="server" CssClass="chkCss" />
                            <asp:Label ID="Label23" runat="server" CssClass="ansCss" Text="This is Answer number 1"></asp:Label>
                        </li>
                    </ul>
                </div>
                <div style="width: 100%; overflow: hidden; padding-bottom: 15px;">
                    <h5 style="width: 100%; line-height: 16px; font-size: 14px; color: #0672CA; padding-bottom: 10px;
                        font-weight: normal;">
                        <asp:Label ID="Label9" runat="server" Text="3.Fill in the following blank"></asp:Label>
                    </h5>
                    <div style="width: 98%; margin: 0 auto; overflow: hidden;">
                        <table>
                            <tr>
                                <td>
                                    1.
                                </td>
                                <td>
                                    <asp:Label ID="Label10" runat="server" Text="Our homeland name is"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtblnk" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label11" runat="server" Text="Dhaka is the capital of Bangladesh."></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    2.
                                </td>
                                <td>
                                    <asp:Label ID="Label12" runat="server" Text="The currency name of Iran is"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label13" runat="server" Text="Iran is a Islamic country."></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    3.
                                </td>
                                <td>
                                    <asp:Label ID="Label14" runat="server" Text="New Delhi is the capital of"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label15" runat="server" Text="Rupi is the currency of India."></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    4.
                                </td>
                                <td>
                                    <asp:Label ID="Label16" runat="server" Text="what is former name of Dhaka"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div style="width: 100%; overflow: hidden; padding-bottom: 15px;">
                    <h5 style="width: 100%; line-height: 16px; font-size: 14px; color: #0672CA; padding-bottom: 10px;
                        font-weight: normal;">
                        <asp:Label ID="Label17" runat="server" Text="4.Read the following Comprehension and write the appropriate answer"></asp:Label>
                    </h5>
                    <div style="width: 98%; margin: 0 auto; padding-bottom: 10px; overflow: hidden;">
                        <asp:Literal ID="ltComprehension" runat="server">
                            There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.
                        </asp:Literal>
                    </div>
                    <div style="width: 95%; margin: 0 auto; overflow: hidden; padding-bottom:10px;">
                        <h5 style="width: 100%; line-height: 16px; font-size: 14px; color: #8A0801; padding-bottom: 10px;
                            font-weight: normal;">
                            <asp:Label ID="Label18" runat="server" Text="1.What is the main theme of the above passage? Write down what you understand."></asp:Label>
                        </h5>
                        <span style="width: 100%; display: block; overflow: hidden;">
                            <asp:TextBox ID="txtAns" runat="server" TextMode="MultiLine" Width="450" Height="25"></asp:TextBox>
                        </span>
                    </div>
                    <div style="width: 95%; margin: 0 auto; overflow: hidden; padding-bottom:10px;">
                        <h5 style="width: 100%; line-height: 16px; font-size: 14px; color: #8A0801; padding-bottom: 10px;
                            font-weight: normal;">
                            <asp:Label ID="Label19" runat="server" Text="2.What is the main theme of the above passage? Write down what you understand."></asp:Label>
                        </h5>
                        <span style="width: 100%; display: block; overflow: hidden;">
                            <asp:TextBox ID="TextBox4" runat="server" TextMode="MultiLine" Width="450" Height="25"></asp:TextBox>
                        </span>
                    </div>
                    <div style="width: 95%; margin: 0 auto; overflow: hidden; padding-bottom:10px;">
                        <h5 style="width: 100%; line-height: 16px; font-size: 14px; color: #8A0801; padding-bottom: 10px;
                            font-weight: normal;">
                            <asp:Label ID="Label20" runat="server" Text="3.What is the main theme of the above passage? Write down what you understand."></asp:Label>
                        </h5>
                        <span style="width: 100%; display: block; overflow: hidden;">
                            <asp:TextBox ID="TextBox5" runat="server" TextMode="MultiLine" Width="450" Height="25"></asp:TextBox>
                        </span>
                    </div>
                    <div style="width: 95%; margin: 0 auto; overflow: hidden; padding-bottom:10px;">
                        <h5 style="width: 100%; line-height: 16px; font-size: 14px; color: #8A0801; padding-bottom: 10px;
                            font-weight: normal;">
                            <asp:Label ID="Label21" runat="server" Text="4.What is the main theme of the above passage? Write down what you understand."></asp:Label>
                        </h5>
                        <span style="width: 100%; display: block; overflow: hidden;">
                            <asp:TextBox ID="TextBox6" runat="server" TextMode="MultiLine" Width="450" Height="25"></asp:TextBox>
                        </span>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
