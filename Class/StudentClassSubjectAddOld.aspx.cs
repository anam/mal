using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
 

public partial class AdminDisplaySTD_ClassStudent : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CourseIDLoad();
        }
    }
    private void CourseIDLoad()
    {
        try
        {
            DataSet ds = STD_CourseManager.GetDropDownListAllSTD_Course();
            ddlCourseID.DataValueField = "CourseID";
            ddlCourseID.DataTextField = "CourseName";
            ddlCourseID.DataSource = ds.Tables[0];
            ddlCourseID.DataBind();
            ddlCourseID.Items.Insert(0, new ListItem("Select Course >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void loadClassSubjectStudentDataBase()
    {

        List<STD_ClassSubjectStudent> ClassSubjectStudents = new List<STD_ClassSubjectStudent>();
       
        DataSet ds = STD_ClassSubjectStudentManager.GetSTD_ClassSubjectStudentByStudentID(hfStudentID.Value);
        
      
        foreach (DataRow dr in ds.Tables[0].Rows)
        {


            STD_ClassSubjectStudent sTD_ClassSubjectStudent = new STD_ClassSubjectStudent();
            sTD_ClassSubjectStudent.ClassSubjectStudentID = int.Parse(dr["ClassSubjectStudentID"].ToString());
            sTD_ClassSubjectStudent.ClassSubjectStudentName = dr["ClassSubjectStudentName"].ToString();
            sTD_ClassSubjectStudent.StudentID = hfStudentID.Value;
            sTD_ClassSubjectStudent.ClassSubjectID = int.Parse(dr["ClassSubjectID"].ToString());
            sTD_ClassSubjectStudent.SubjectID = int.Parse(dr["SubjectID"].ToString());
            sTD_ClassSubjectStudent.ClassID = int.Parse(dr["ClassID"].ToString());
            sTD_ClassSubjectStudent.SubjectName = dr["SubjectName"].ToString();
            sTD_ClassSubjectStudent.ClassName = dr["ClassName"].ToString();
            sTD_ClassSubjectStudent.AddedBy = Profile.card_id;
            sTD_ClassSubjectStudent.AddedDate = DateTime.Now;
            sTD_ClassSubjectStudent.UpdatedBy = Profile.card_id;
            sTD_ClassSubjectStudent.UpdateDate = DateTime.Now;

            //int resutl = STD_ClassSubjectStudentManager.InsertSTD_ClassSubjectStudent(sTD_ClassSubjectStudent);

            ClassSubjectStudents.Add(sTD_ClassSubjectStudent);
        
        }

        Session["ClassSubjectStudents"] = ClassSubjectStudents;

        gvSTD_ClassSubjectStudent.DataSource = ClassSubjectStudents;
        gvSTD_ClassSubjectStudent.DataBind();

    }

    protected void btnVarify_OnClick(object sender, EventArgs e)
    {
        

        STD_Student student = new STD_Student();
        student = STD_StudentManager.GetHR_StudnetByStudentCode(txtStudentCode.Text);

        if (student == null)
        {
            lblMessage.Text = "<br/>There is no Student with this student Id";
        }
        else
        {
            lblMessage.Text = "!!! Valid ID  !!!";
            hfStudentID.Value = student.StudentID;
        }


        loadClassSubjectStudentDataBase();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        try
        {
            //insert the classes which are not assigned for that student
            string classIDsNeedtoAddinDataBase = "";

            hfclassIDs.Value = "";
            DataSet ds = STD_ClassStudentManager.GetSTD_ClassStudentByStudentID(hfStudentID.Value, true);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                hfclassIDs.Value += dr["ClassID"].ToString() + "-";
            }

            List<STD_ClassSubjectStudent> ClassSubjectStudents = new List<STD_ClassSubjectStudent>();
            ClassSubjectStudents = (List<STD_ClassSubjectStudent>)Session["ClassSubjectStudents"];


            foreach (STD_ClassSubjectStudent classSubjectStudent in ClassSubjectStudents)
            {
                if (!hfclassIDs.Value.Contains(classSubjectStudent.ClassID.ToString()))
                {
                    classIDsNeedtoAddinDataBase += classSubjectStudent.ClassID.ToString() + "-";
                }
            }

            if (classIDsNeedtoAddinDataBase != "")
            {
                string[] ids = classIDsNeedtoAddinDataBase.Split('-');
                foreach (string id in ids)
                {
                    if (id != "" && id != "-")
                    {
                        STD_ClassStudent sTD_ClassStudent = new STD_ClassStudent();
                        //	sTD_ClassStudent.ClassStudentID=  int.Parse(ddlClassStudentID.SelectedValue);
                        sTD_ClassStudent.ClassStudentName = "";
                        sTD_ClassStudent.StudentID = hfStudentID.Value;
                        sTD_ClassStudent.ClassID = int.Parse(id);
                        sTD_ClassStudent.AddedBy = Profile.card_id;
                        sTD_ClassStudent.AddedDate = DateTime.Now;
                        sTD_ClassStudent.UpdatedBy = Profile.card_id;
                        sTD_ClassStudent.UpdateDate = DateTime.Now;
                        sTD_ClassStudent.RowStatusID = 1;
                        int resutl = STD_ClassStudentManager.InsertSTD_ClassStudent(sTD_ClassStudent);
                    }
                }
            }

            //Need to add the ClassSubject Student

            //insert the classes which are not assigned for that student
            string classSubjectIDsNeedtoAddinDataBase = "";

            hfclassIDs.Value = "";
            DataSet dsclassSubject = STD_ClassSubjectStudentManager.GetSTD_ClassSubjectStudentByStudentID(hfStudentID.Value);
            foreach (DataRow dr in dsclassSubject.Tables[0].Rows)
            {
                hfclassSubjectIDs.Value += dr["ClassSubjectID"].ToString() + "-";
            }


            foreach (STD_ClassSubjectStudent classSubjectStudent in ClassSubjectStudents)
            {
                if (!hfclassSubjectIDs.Value.Contains(classSubjectStudent.ClassSubjectID.ToString()))
                {
                    classSubjectIDsNeedtoAddinDataBase += classSubjectStudent.ClassSubjectID.ToString() + "-";
                }
            }

            if (classSubjectIDsNeedtoAddinDataBase != "")
            {
                string[] ids = classSubjectIDsNeedtoAddinDataBase.Split('-');
                foreach (string id in ids)
                {
                    if (id != "" && id != "-")
                    {
                        STD_ClassSubjectStudent sTD_ClassSubjectStudent = new STD_ClassSubjectStudent();
                        //	sTD_ClassSubjectStudent.ClassSubjectStudentID=  int.Parse(ddlClassSubjectStudentID.SelectedValue);
                        sTD_ClassSubjectStudent.ClassSubjectStudentName = "";
                        sTD_ClassSubjectStudent.StudentID = hfStudentID.Value;
                        sTD_ClassSubjectStudent.ClassSubjectID = int.Parse(id);
                        sTD_ClassSubjectStudent.AddedBy = Profile.card_id;
                        sTD_ClassSubjectStudent.AddedDate = DateTime.Now;
                        sTD_ClassSubjectStudent.UpdatedBy = Profile.card_id;
                        sTD_ClassSubjectStudent.UpdateDate = DateTime.Now;
                        sTD_ClassSubjectStudent.RowStatusID = 1;

                        int resutl = STD_ClassSubjectStudentManager.InsertSTD_ClassSubjectStudent(sTD_ClassSubjectStudent);
                    }
                }
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void btnLoadSubjecct_Click(object sender, EventArgs e)
    {
        loadSubjet();
    }

    private void loadSubjet()
    {
        try
        {
            ddlSubjectID.Items.Clear();
            ddlClassID.Items.Clear();

            DataSet ds = STD_SubjectManager.GetSTD_SubjectByCourseID(int.Parse(ddlCourseID.SelectedValue));
            ddlSubjectID.DataValueField = "SubjectID";
            ddlSubjectID.DataTextField = "SubjectName";
            ddlSubjectID.DataSource = ds.Tables[0];
            ddlSubjectID.DataBind();
            ddlSubjectID.Items.Insert(0, new ListItem("Select subject >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    
    }
    protected void btnLoadClass_Click(object sender, EventArgs e)
    {
        loadClass();
    }

    private void loadClass()
    {
        try
        {

            ddlClassID.Items.Clear();
            DataSet ds = STD_ClassSubjectManager.GetSTD_ClassSubjectBySubjectID(int.Parse(ddlSubjectID.SelectedValue));
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ListItem item = new ListItem(dr["ClassName"].ToString(), dr["ClassSubjectID"].ToString() + "-" + dr["ClassID"].ToString());
                ddlClassID.Items.Add(item);

            }            
            ddlClassID.Items.Insert(0, new ListItem("Select Class >>", "0-0"));


        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }

    }
    protected void btnAddClass_Click(object sender, EventArgs e)
    {
        //btnVarify_OnClick(this, new EventArgs());
        if (Session["ClassSubjectStudents"] == null)
        {
            List<STD_ClassSubjectStudent> ClassSubjectStudents = new List<STD_ClassSubjectStudent>();

            string[] words = ddlClassID.SelectedValue.Split('-');


            STD_ClassSubjectStudent sTD_ClassSubjectStudent = new STD_ClassSubjectStudent();
            sTD_ClassSubjectStudent.ClassSubjectStudentName = "Need to fix later";
            sTD_ClassSubjectStudent.StudentID = hfStudentID.Value;
            sTD_ClassSubjectStudent.ClassSubjectID = int.Parse(ddlClassID.SelectedValue.Split('-')[0]);
            sTD_ClassSubjectStudent.SubjectID = int.Parse(ddlSubjectID.SelectedValue);
            sTD_ClassSubjectStudent.ClassID = int.Parse(ddlClassID.SelectedValue.Split('-')[1]);
            sTD_ClassSubjectStudent.SubjectName = ddlSubjectID.SelectedItem.Text;
            sTD_ClassSubjectStudent.ClassName = ddlClassID.SelectedItem.Text;
            sTD_ClassSubjectStudent.AddedBy = Profile.card_id;
            sTD_ClassSubjectStudent.AddedDate = DateTime.Now;
            sTD_ClassSubjectStudent.UpdatedBy = Profile.card_id;
            sTD_ClassSubjectStudent.UpdateDate = DateTime.Now;
            sTD_ClassSubjectStudent.RowStatusID = 1;

            sTD_ClassSubjectStudent.ClassSubjectStudentID = ClassSubjectStudents.Count;

            //int resutl = STD_ClassSubjectStudentManager.InsertSTD_ClassSubjectStudent(sTD_ClassSubjectStudent);

            ClassSubjectStudents.Add(sTD_ClassSubjectStudent);
            Session["ClassSubjectStudents"] = ClassSubjectStudents;
            loadClassSubjectStudent();
        }

        else
        {
            string[] words = ddlClassID.SelectedValue.Split('-');


            STD_ClassSubjectStudent sTD_ClassSubjectStudent = new STD_ClassSubjectStudent();
            sTD_ClassSubjectStudent.ClassSubjectStudentName = "Need to fix later";
            sTD_ClassSubjectStudent.StudentID = hfStudentID.Value;
            sTD_ClassSubjectStudent.ClassSubjectID = int.Parse(ddlClassID.SelectedValue.Split('-')[0]);
            sTD_ClassSubjectStudent.SubjectID = int.Parse(ddlSubjectID.SelectedValue);
            sTD_ClassSubjectStudent.ClassID = int.Parse(ddlClassID.SelectedValue.Split('-')[1]);
            sTD_ClassSubjectStudent.SubjectName = ddlSubjectID.SelectedItem.Text;
            sTD_ClassSubjectStudent.ClassName = ddlClassID.SelectedItem.Text;
            sTD_ClassSubjectStudent.AddedBy = Profile.card_id;
            sTD_ClassSubjectStudent.AddedDate = DateTime.Now;
            sTD_ClassSubjectStudent.UpdatedBy = Profile.card_id;
            sTD_ClassSubjectStudent.UpdateDate = DateTime.Now;
            sTD_ClassSubjectStudent.RowStatusID = 1;

            sTD_ClassSubjectStudent.ClassSubjectStudentID = ((List<STD_ClassSubjectStudent>)Session["ClassSubjectStudents"]).Count;
            //int resutl = STD_ClassSubjectStudentManager.InsertSTD_ClassSubjectStudent(sTD_ClassSubjectStudent);

           ((List<STD_ClassSubjectStudent>) Session["ClassSubjectStudents"]).Add(sTD_ClassSubjectStudent);
           Session["ClassSubjectStudents"] = Session["ClassSubjectStudents"];
           loadClassSubjectStudent();
        }
    }

  
    private void showUpdateInfoData(int studentID)
    {
        try
        {
            if (Session["ClassSubjectStudents"] != null)
            {
                List<STD_ClassSubjectStudent> ClassSubjectStudents = new List<STD_ClassSubjectStudent>();
                ClassSubjectStudents = (List<STD_ClassSubjectStudent>)Session["ClassSubjectStudents"];

                STD_ClassSubjectStudent sTD_ClassSubjectStudent = new STD_ClassSubjectStudent();

                sTD_ClassSubjectStudent = ClassSubjectStudents[studentID];

                hfStudentID.Value= sTD_ClassSubjectStudent.StudentID;
                ddlClassID.SelectedValue = sTD_ClassSubjectStudent.ClassSubjectID.ToString()+"-"+sTD_ClassSubjectStudent.ClassID.ToString();                
                ddlSubjectID.SelectedValue= sTD_ClassSubjectStudent.SubjectID.ToString();
                hfClassStudentSubjectID.Value = sTD_ClassSubjectStudent.ClassSubjectStudentID.ToString();
                //ddlClassID.SelectedValue= sTD_ClassSubjectStudent.ClassID.ToString();
                //ddlSubjectID.SelectedItem.Text=sTD_ClassSubjectStudent.SubjectName;
                //ddlClassID.SelectedItem.Text= sTD_ClassSubjectStudent.ClassName; 
            }
        }
        catch (Exception ex)
        {
        }
    }

    private void loadClassSubjectStudent()
    {
        if (Session["ClassSubjectStudents"] != null)
        {
            gvSTD_ClassSubjectStudent.DataSource = Session["ClassSubjectStudents"];
            gvSTD_ClassSubjectStudent.DataBind();

            btnUpdateClass.Visible = false;
            btnAddClass.Visible = true;
        }
    }

    protected void lbSelect_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        showUpdateInfoData(id);

        btnAddClass.Visible = false;
        btnUpdateClass.Visible = true;
    }
    protected void lbDelete_Click(object sender, EventArgs e)
    {
        try
        {
            List<STD_ClassSubjectStudent> ClassSubjectStudents = new List<STD_ClassSubjectStudent>();
            ClassSubjectStudents = (List<STD_ClassSubjectStudent>)Session["ClassSubjectStudents"];

            ImageButton linkButton = new ImageButton();
            linkButton = (ImageButton)sender;

            ClassSubjectStudents.RemoveAt(Convert.ToInt32(linkButton.CommandArgument));
            for (int i = 0; i < ClassSubjectStudents.Count; i++)
            {
                ClassSubjectStudents[i].ClassSubjectStudentID = i;
            }
            Session["ClassSubjectStudents"] = ClassSubjectStudents;
            loadClassSubjectStudent();
        }
        catch (Exception ex)
        { }
    }
    protected void btnUpdateClass_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["ClassSubjectStudents"] != null)
            {
                List<STD_ClassSubjectStudent> ClassSubjectStudents = new List<STD_ClassSubjectStudent>();
                ClassSubjectStudents = (List<STD_ClassSubjectStudent>)Session["ClassSubjectStudents"];

                STD_ClassSubjectStudent sTD_ClassSubjectStudent = new STD_ClassSubjectStudent();
                sTD_ClassSubjectStudent.ClassSubjectStudentName = "Need to fix later";
                sTD_ClassSubjectStudent.StudentID = hfStudentID.Value;
                sTD_ClassSubjectStudent.ClassSubjectStudentID = int.Parse(hfClassStudentSubjectID.Value);
                sTD_ClassSubjectStudent.ClassSubjectID = int.Parse(ddlClassID.SelectedValue.Split('-')[0]);
                sTD_ClassSubjectStudent.SubjectID = int.Parse(ddlSubjectID.SelectedValue);
                sTD_ClassSubjectStudent.ClassID = int.Parse(ddlClassID.SelectedValue.Split('-')[1]);
                sTD_ClassSubjectStudent.SubjectName = ddlSubjectID.SelectedItem.Text;
                sTD_ClassSubjectStudent.ClassName = ddlClassID.SelectedItem.Text;
                sTD_ClassSubjectStudent.AddedBy = Profile.card_id;
                sTD_ClassSubjectStudent.AddedDate = DateTime.Now;
                sTD_ClassSubjectStudent.UpdatedBy = Profile.card_id;
                sTD_ClassSubjectStudent.UpdateDate = DateTime.Now;



                ClassSubjectStudents[int.Parse(hfClassStudentSubjectID.Value)] = sTD_ClassSubjectStudent;
                Session["ClassSubjectStudents"] = ClassSubjectStudents;
                loadClassSubjectStudent();
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void ddlCourseID_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        loadSubjet();
    }
    protected void ddlSubjectID_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        loadClass();
    }
}

