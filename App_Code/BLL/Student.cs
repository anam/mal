using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public class Student
{
    public Student()
    {
    }

    public Student
        (
        string s_id,
        string p_id, 
        string s_name, 
        string password, 
        string father_name, 
        string pre_add, 
        string tel, 
        string mob, 
        string email,
        string dob, 
        string gender,
        string r_id,
        string pay_method,
        string total,
        string course_discount,
        string no_installment,
        string prev_payment, 
        string pic_ext,
        string totalPayemt
        )
    {
       
        this.S_id = s_id;
        this.P_id = p_id;
        this.S_name = s_name;
        this.Password = password;
        this.Father_name = father_name;
        this.Pre_add = pre_add;
        this.Tel = tel;
        this.Mob = mob;
        this.Email = email;
        this.Dob = dob;
        this.Gender = gender;
        this.R_id = r_id;
        this.Pay_method = pay_method;
        this.Total = total;
        this.Course_discount = course_discount;
        this.No_installment = no_installment;
        this.Prev_payment = prev_payment;
        this.Pic_ext = pic_ext;
        this.TotalPayemt = totalPayemt;
    }


   
    private string _s_id;
    public string S_id
    {
        get { return _s_id; }
        set { _s_id = value; }
    }

    private string _p_id;
    public string P_id
    {
        get { return _p_id; }
        set { _p_id = value; }
    }

    private string _s_name;
    public string S_name
    {
        get { return _s_name; }
        set { _s_name = value; }
    }

    private string _password;
    public string Password
    {
        get { return _password; }
        set { _password = value; }
    }

    private string _father_name;
    public string Father_name
    {
        get { return _father_name; }
        set { _father_name = value; }
    }

    private string _pre_add;
    public string Pre_add
    {
        get { return _pre_add; }
        set { _pre_add = value; }
    }

    private string _tel;
    public string Tel
    {
        get { return _tel; }
        set { _tel = value; }
    }

    private string _mob;
    public string Mob
    {
        get { return _mob; }
        set { _mob = value; }
    }

    private string _email;
    public string Email
    {
        get { return _email; }
        set { _email = value; }
    }

    private string _dob;
    public string Dob
    {
        get { return _dob; }
        set { _dob = value; }
    }

    private string _gender;
    public string Gender
    {
        get { return _gender; }
        set { _gender = value; }
    }

    private string _r_id;
    public string R_id
    {
        get { return _r_id; }
        set { _r_id = value; }
    }

    private string _pay_method;
    public string Pay_method
    {
        get { return _pay_method; }
        set { _pay_method = value; }
    }

    private string _total;
    public string Total
    {
        get { return _total; }
        set { _total = value; }
    }

    private string _course_discount;
    public string Course_discount
    {
        get { return _course_discount; }
        set { _course_discount = value; }
    }

    private string _no_installment;
    public string No_installment
    {
        get { return _no_installment; }
        set { _no_installment = value; }
    }

    private string _prev_payment;
    public string Prev_payment
    {
        get { return _prev_payment; }
        set { _prev_payment = value; }
    }

    private string _pic_ext;
    public string Pic_ext
    {
        get { return _pic_ext; }
        set { _pic_ext = value; }
    }

    private string _totalPayemt;

    public string TotalPayemt
    {
        get { return _totalPayemt; }
        set { _totalPayemt = value; }
    }
}
