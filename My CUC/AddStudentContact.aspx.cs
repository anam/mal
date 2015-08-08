using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Student_AddStudentContact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ContactTypeIDLoad();

            gvStudentContact.DataSource = STD_ContactManager.GetSTD_ContactsByStudentID(Profile.card_id);

            gvStudentContact.DataBind();
        }
    }

    private void ContactTypeIDLoad()
    {
        try
        {
            DataSet ds = STD_ContactTypeManager.GetDropDownListAllSTD_ContactType();
            ddlContactTypeID.DataValueField = "ContactTypeID";
            ddlContactTypeID.DataTextField = "ContactTypeName";
            ddlContactTypeID.DataSource = ds.Tables[0];
            ddlContactTypeID.DataBind();
            ddlContactTypeID.Items.Insert(0, new ListItem("Select ContactType >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    #region contact
    private void loadcontact(string studentID)
    {

        List<STD_Contact> contacts = new List<STD_Contact>();
        DataSet dscontact = STD_ContactManager.GetSTDContactByStudentID(studentID, true);

        int i = 0;
        foreach (DataRow drcontact in dscontact.Tables[0].Rows)
        {
            STD_Contact sTD_Contact = new STD_Contact();

            sTD_Contact.ContactID = i++;
            sTD_Contact.StudentID = drcontact["StudentID"].ToString();
            sTD_Contact.Name = drcontact["Name"].ToString();
            sTD_Contact.CellNo = drcontact["CellNo"].ToString();
            sTD_Contact.Occupation = drcontact["Occupation"].ToString();
            sTD_Contact.OfficeTel = drcontact["OfficeTel"].ToString();
            sTD_Contact.OfficeAddress = drcontact["OfficeAddress"].ToString();
            sTD_Contact.ContactTypeID = int.Parse(drcontact["ContactTypeID"].ToString());
            sTD_Contact.AddedBy = drcontact["AddedBy"].ToString();
            sTD_Contact.AddedDate = DateTime.Parse(drcontact["AddedDate"].ToString());
            sTD_Contact.ModifiedBy = drcontact["ModifiedBy"].ToString();
            sTD_Contact.ModifiedDate = DateTime.Parse(drcontact["ModifiedDate"].ToString());
            sTD_Contact.RowStatusID = 1;

            contacts.Add(sTD_Contact);
        }

        Session["contacts"] = contacts;

        gvSTD_Contact.DataSource = contacts;
        gvSTD_Contact.DataBind();
    }
    protected void btnContactAdd_Click(object sender, EventArgs e)
    {
        if (Session["contacts"] == null)
        {
            List<STD_Contact> contacts = new List<STD_Contact>();

            STD_Contact sTD_Contact = new STD_Contact();
            //	sTD_Contact.ContactID=  int.Parse(ddlContactID.SelectedValue);
            sTD_Contact.StudentID = Profile.card_id;
            sTD_Contact.Name = txtName.Text;
            sTD_Contact.CellNo = txtCellNo.Text;
            sTD_Contact.Occupation = txtOccupation.Text;
            sTD_Contact.OfficeTel = txtOfficeTel.Text;
            sTD_Contact.OfficeAddress = txtOfficeAddress.Text;
            sTD_Contact.ContactTypeID = int.Parse(ddlContactTypeID.SelectedValue);
            sTD_Contact.AddedBy = Profile.card_id;
            sTD_Contact.AddedDate = DateTime.Now;
            sTD_Contact.ModifiedBy = Profile.card_id;
            sTD_Contact.ModifiedDate = DateTime.Now;
            sTD_Contact.RowStatusID = 1;
            //int resutl = STD_ContactManager.InsertSTD_Contact(STD_Contact);
            //add educational background


            sTD_Contact.ContactID = contacts.Count;

            contacts.Add(sTD_Contact);

            Session["contacts"] = contacts;

            gvSTD_Contact.DataSource = Session["contacts"];
            gvSTD_Contact.DataBind();
        }
        else
        {
            STD_Contact sTD_Contact = new STD_Contact();
            //	sTD_Contact.ContactID=  int.Parse(ddlContactID.SelectedValue);
            sTD_Contact.StudentID = Profile.card_id;
            sTD_Contact.Name = txtName.Text;
            sTD_Contact.CellNo = txtCellNo.Text;
            sTD_Contact.Occupation = txtOccupation.Text;
            sTD_Contact.OfficeTel = txtOfficeTel.Text;
            sTD_Contact.OfficeAddress = txtOfficeAddress.Text;
            sTD_Contact.ContactTypeID = int.Parse(ddlContactTypeID.SelectedValue);
            sTD_Contact.AddedBy = Profile.card_id;
            sTD_Contact.AddedDate = DateTime.Now;
            sTD_Contact.ModifiedBy = Profile.card_id;
            sTD_Contact.ModifiedDate = DateTime.Now;
            //int resutl = STD_ContactManager.InsertSTD_Contact(STD_Contact);
            //add educational background


            sTD_Contact.ContactID = ((List<STD_Contact>)Session["contacts"]).Count;

            ((List<STD_Contact>)Session["contacts"]).Add(sTD_Contact);

            gvSTD_Contact.DataSource = Session["contacts"];
            gvSTD_Contact.DataBind();
        }
    }
    protected void btnContactUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            List<STD_Contact> contacts = new List<STD_Contact>();
            contacts = (List<STD_Contact>)Session["contacts"];

            STD_Contact sTD_Contact = new STD_Contact();
            sTD_Contact.ContactID = int.Parse(hfContactID.Value);
            sTD_Contact.StudentID = hfUserID.Value;
            sTD_Contact.Name = txtName.Text;
            sTD_Contact.CellNo = txtCellNo.Text;
            sTD_Contact.Occupation = txtOccupation.Text;
            sTD_Contact.OfficeTel = txtOfficeTel.Text;
            sTD_Contact.OfficeAddress = txtOfficeAddress.Text;
            sTD_Contact.ContactTypeID = int.Parse(ddlContactTypeID.SelectedValue);
            sTD_Contact.AddedBy = Profile.card_id;
            sTD_Contact.AddedDate = DateTime.Now;
            sTD_Contact.ModifiedBy = Profile.card_id;
            sTD_Contact.ModifiedDate = DateTime.Now;

            contacts[int.Parse(hfContactID.Value)] = sTD_Contact;
            Session["contacts"] = contacts;
            gvSTD_Contact.DataSource = contacts;
            gvSTD_Contact.DataBind();

            btnContactAdd.Visible = true;
            btnContactUpdate.Visible = false;
        }

        catch (Exception ex)
        {
        }
    }

    protected void lbSelectContact_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);

        showSTD_ContactData(id);

        btnContactAdd.Visible = false;
        btnContactUpdate.Visible = true;
    }

    private void showSTD_ContactData(int contactID)
    {
        try
        {
            if (Session["contacts"] != null)
            {
                List<STD_Contact> contacts = new List<STD_Contact>();
                contacts = (List<STD_Contact>)Session["contacts"];

                STD_Contact STD_Contact = new STD_Contact();

                STD_Contact = contacts[contactID];

                STD_Contact sTD_Contact = new STD_Contact();
                sTD_Contact = contacts[contactID];
                hfContactID.Value = contactID.ToString();
                hfUserID.Value = STD_Contact.StudentID == null ? Profile.card_id : STD_Contact.StudentID;
                txtName.Text = sTD_Contact.Name.ToString();
                txtCellNo.Text = sTD_Contact.CellNo.ToString();
                txtOccupation.Text = sTD_Contact.Occupation.ToString();
                txtOfficeTel.Text = sTD_Contact.OfficeTel.ToString();
                txtOfficeAddress.Text = sTD_Contact.OfficeAddress.ToString();
                ddlContactTypeID.SelectedValue = sTD_Contact.ContactTypeID.ToString();
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void lbDeleteContact_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["contacts"] != null)
            {
                List<STD_Contact> contacts = new List<STD_Contact>();
                contacts = (List<STD_Contact>)Session["contacts"];

                ImageButton linkButton = new ImageButton();
                linkButton = (ImageButton)sender;



                contacts.RemoveAt(Convert.ToInt32(linkButton.CommandArgument));
                for (int i = 0; i < contacts.Count; i++)
                {
                    contacts[i].ContactID = i;
                }
                Session["contacts"] = contacts;
                gvSTD_Contact.DataSource = contacts;
                gvSTD_Contact.DataBind();
            }
        }
        catch (Exception ex)
        { }
    }
    #endregion


    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["contacts"] != null)
            {
                List<STD_Contact> contacts = new List<STD_Contact>();
                contacts = (List<STD_Contact>)Session["contacts"];

                foreach (STD_Contact sTD_Contact in contacts)
                {                   
                    STD_ContactManager.InsertSTD_Contact(sTD_Contact);
                }
                contacts.RemoveRange(0, contacts.Count);
                Session["contacts"] = null;

                gvSTD_Contact.DataSource = string.Empty.ToList();
                gvSTD_Contact.DataBind();

                gvStudentContact.DataSource = STD_ContactManager.GetSTD_ContactsByStudentID(Profile.card_id);

                gvStudentContact.DataBind();
            }
        }

        catch (Exception ex)
        {
        }
    }
}