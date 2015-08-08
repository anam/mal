using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class HR_SalaryStatement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["Date"] != null)
                {
                    lblDate.Text = Session["Date"].ToString();
                }

                if (Session["packeges"] != null && Session["salaryDetails"] != null)
                {

                    DataTable tblSalary = new DataTable();

                    tblSalary.Columns.Add("EmployeeName");
                    tblSalary.Columns.Add("GrossSalary");
                    tblSalary.Columns.Add("PFAmount");
                    tblSalary.Columns.Add("SecurityAmount");

                    tblSalary.Columns.Add("AdvenceSalary");
                    tblSalary.Columns.Add("DepartmentName");
                    tblSalary.Columns.Add("GrandTotal");

                    tblSalary = (DataTable)Session["salaryDetails"];

                    string packeges = Session["packeges"].ToString();

                    string[] spPackeges = packeges.Split(',');
                    int  index = 1;
                    decimal gross = 0, pfamount = 0, advenceSalary = 0, grandTotal = 0,securityAmount=0;
                    decimal Subgross = 0, Subpfamount = 0, SubadvenceSalary = 0, SubgrandTotal = 0, SubsecurityAmount = 0;

                    string html = "";
                    

                    string LastDepartMent = "";
                    string CurrentDepartMent = "";

                    //foreach (DataRow drRow in tblSalary.Rows)
                        for (int i = 0; i < tblSalary.Rows.Count;i++ )
                        {
                            LastDepartMent = tblSalary.Rows[(i==0?i:i-1)]["DepartmentName"].ToString();
                            CurrentDepartMent = tblSalary.Rows[i]["DepartmentName"].ToString();

                            if (i != 0 && LastDepartMent != CurrentDepartMent)
                            {
                                html += "<tr><td></td><td colspan='5' style='text-align: right; padding-right:15px'>Total Tk</td>";
                                html += "<td style='text-align: right'>" + Subgross.ToString("0,00.00") + "</td><td style='text-align: right'>" + Subpfamount.ToString("0,00.00");
                                html += "</td><td style='text-align: right'>" + SubsecurityAmount.ToString("0,00.00") ;
                                html += "</td><td style='text-align: right'>" + SubadvenceSalary.ToString("0,00.00") + "</td><td style='text-align: right'>" + SubgrandTotal.ToString("0,00.00") + "</td></tr>";
                                html += "</table>";
                            }

                            if (i == 0 || LastDepartMent != CurrentDepartMent)
                            {
                                Subgross = 0; Subpfamount = 0; SubadvenceSalary = 0; SubgrandTotal = 0; SubsecurityAmount = 0;
                                html += "<h2>"+CurrentDepartMent+"</h2><table border='1' cellspacing='0' style='width:98%; float:left; margin:10px'>";

                                html += "<tr bgcolor='#cccccc' style='border:none'>";
                                html += "<td>SI.N</td><td>Employee Name</td><td>Basic 60%</td><td>House Rent 30%</td><td>Medical 5%</td><td>Convance 5%</td><td>Gross</td><td>PFAmount</td><td>Security Amount</td><td>Advance</td><td>GrandTotal</td>";
                                html += "</tr>";
                            }
                            DataRow drRow = tblSalary.NewRow();
                            drRow = tblSalary.Rows[i];
                            
                            if (i % 2 != 0)
                            {
                                html += "<tr  bgcolor='#cccccc' style='border:none'>";
                                html += "<td>" + index.ToString() + "</td>";
                                html += "<td>" + drRow["EmployeeName"].ToString() + "<br/>" + "</td>";

                                if (i < spPackeges.Length)
                                {
                                    string[] spPackege = spPackeges[i].Split(' ');
                                    decimal packege = 0;

                                    for (int j = 0; j < spPackege.Length - 1; j++)
                                    {

                                        html += "<td style='text-align: right'>";
                                        packege = Convert.ToDecimal(spPackege[j].ToString());
                                        html += packege.ToString("0,00") + "</td>";

                                    }
                                }



                                string ads = drRow["AdvenceSalary"].ToString();
                                string gs = drRow["GrossSalary"].ToString();
                                string gt = drRow["GrandTotal"].ToString();
                                string pf = drRow["PFAmount"].ToString();
                                string sa = drRow["SecurityAmount"].ToString();


                                if (gs != "")
                                    Subgross += Convert.ToDecimal(gs);
                                if (pf != "")
                                    Subpfamount += Convert.ToDecimal(pf);
                                if (sa != "") 
                                    SubsecurityAmount += Convert.ToDecimal(sa);
                                if (ads != "")
                                    SubadvenceSalary += Convert.ToDecimal(ads);
                                if (gt != "")
                                    SubgrandTotal += Convert.ToDecimal(gt);

                                if (gs != "")
                                    gross += Convert.ToDecimal(gs);
                                if (pf != "")
                                    pfamount += Convert.ToDecimal(pf);
                                if (sa != "")
                                    securityAmount += Convert.ToDecimal(sa);
                                if (ads != "")
                                    advenceSalary += Convert.ToDecimal(ads);
                                if (gt != "")
                                    grandTotal += Convert.ToDecimal(gt);

                                html += "<td style='text-align: right'>" + drRow["GrossSalary"].ToString() + "</td>";
                                html += "<td style='text-align: right'>" + drRow["PFAmount"].ToString() + "</td>";
                                html += "<td style='text-align: right'>" + drRow["SecurityAmount"].ToString() + "</td>";

                                html += "<td style='text-align: right'>" + drRow["AdvenceSalary"].ToString() + "</td>";
                                html += "<td style='text-align: right'>" + drRow["GrandTotal"].ToString() + "</td>";

                                html += "</tr>";
                                //i++;
                                index++;
                            }
                            else
                            {
                                html += "<tr style='border:none'>";
                                html += "<td>" + index.ToString() + "</td>";
                                html += "<td>" + drRow["EmployeeName"].ToString() + "</td>";

                                if (i < spPackeges.Length)
                                {
                                    string[] spPackege = spPackeges[i].Split(' ');
                                    decimal packege = 0;

                                    for (int j = 0; j < spPackege.Length - 1; j++)
                                    {

                                        html += "<td style='text-align: right'>";
                                        packege = Convert.ToDecimal(spPackege[j].ToString());
                                        html += packege.ToString("0,00") + "</td>";

                                    }
                                }



                                string ads = drRow["AdvenceSalary"].ToString();
                                string gs = drRow["GrossSalary"].ToString();
                                string gt = drRow["GrandTotal"].ToString();
                                string pf = drRow["PFAmount"].ToString();
                                string sa = drRow["SecurityAmount"].ToString();


                                if (gs != "")
                                    Subgross += Convert.ToDecimal(gs);
                                if (pf != "")
                                    Subpfamount += Convert.ToDecimal(pf);
                                if (ads != "")
                                    SubadvenceSalary += Convert.ToDecimal(ads);
                                if (gt != "")
                                    SubgrandTotal += Convert.ToDecimal(gt);
                                if (sa != "")
                                    SubsecurityAmount += Convert.ToDecimal(sa);

                                if (gs != "")
                                    gross += Convert.ToDecimal(gs);
                                if (pf != "")
                                    pfamount += Convert.ToDecimal(pf);
                                if (sa != "")
                                    securityAmount += Convert.ToDecimal(sa); 
                                if (ads != "")
                                    advenceSalary += Convert.ToDecimal(ads);
                                if (gt != "")
                                    grandTotal += Convert.ToDecimal(gt);

                                html += "<td style='text-align: right'>" + drRow["GrossSalary"].ToString() + "</td>";
                                html += "<td style='text-align: right'>" + drRow["PFAmount"].ToString() + "</td>";
                                html += "<td style='text-align: right'>" + drRow["SecurityAmount"].ToString() + "</td>";

                                html += "<td style='text-align: right'>" + drRow["AdvenceSalary"].ToString() + "</td>";
                                html += "<td style='text-align: right'>" + drRow["GrandTotal"].ToString() + "</td>";

                                html += "</tr>";
                                //i++;
                                index++;
                            }

                        }
                   
                    html += "<tr><td></td><td colspan='5' style='text-align: right; padding-right:15px'>Total Tk</td>";
                    html += "<td style='text-align: right'>" + Subgross.ToString("0,00.00") + "</td><td style='text-align: right'>" + Subpfamount.ToString("0,00.00");
                    html += "</td><td style='text-align: right'>" + SubsecurityAmount.ToString("0,00.00");
                    html += "</td><td style='text-align: right'>" + SubadvenceSalary.ToString("0,00.00") + "</td><td style='text-align: right'>" + SubgrandTotal.ToString("0,00.00") + "</td></tr>";
                    html += "</table>";

                    html += "<h2>Total:</h2><table border='1' cellspacing='0' style='width:98%; float:left; margin:10px'>";

                    html += "<tr bgcolor='#cccccc' style='border:none'>";
                    html += "<td></td><td>Gross</td><td>PFAmount</td><td>Security Amount</td><td>Advance</td><td>GrandTotal</td>";
                    html += "</tr>";
                    html += "<tr><td  style='text-align: right; padding-right:15px'>Total Tk</td>";
                    html += "<td style='text-align: right'>" + gross.ToString("0,00") + "</td><td style='text-align: right'>" + pfamount.ToString("0,00");
                    html += "</td><td style='text-align: right'>" + securityAmount.ToString("0,00");
                    html += "</td><td style='text-align: right'>" + advenceSalary.ToString("0,00") + "</td><td style='text-align: right'>" + grandTotal.ToString("0,00") + "</td></tr>";
                    
                    
                    html += "</table>";

                    ltExamSheet.Text = html;
                }
            }
        }

        catch (Exception ex)
        {
        }
    }
}