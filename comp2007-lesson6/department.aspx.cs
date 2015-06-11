using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using comp2007_lesson6.Models;
using System.Web.ModelBinding;


namespace comp2007_lesson6
{
    public partial class department : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if save wasn't clicked and we have a studentID in URL
            if ((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                GetDepartment();
            }
           
        }

        protected void GetDepartment()
        {
            Int32 DepartmentID = Convert.ToInt32(Request.QueryString["DepartmentID"]);

            using (comp2007Entities db = new comp2007Entities())
            {
                Department d = (from ObjD in db.Departments where ObjD.DepartmentID == DepartmentID select ObjD).FirstOrDefault();

                if (d != null)
                {
                    //map the student properties to form controls
                    txtName.Text = d.Name;
                    txtBudget.Text = d.Budget.ToString();
                }
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (comp2007Entities db = new comp2007Entities())
            {
                //use the student model to save record
                Department d = new Department();

                Int32 DepartmentID = 0;

                //check query string for an id so we can determine add or update
                if (Request.QueryString["DepartmentID"] != null)
                {
                    DepartmentID = Convert.ToInt32(Request.QueryString["DepartmentID"]);

                    //get the current student from EF
                    d = (from objD in db.Departments where objD.DepartmentID == DepartmentID select objD).FirstOrDefault();
                }
                d.Name = txtName.Text;
                d.Budget = Convert.ToDecimal(txtBudget.Text);
                

                //redirect to updated table of students
                if (DepartmentID == 0)
                {
                    db.Departments.Add(d);
                }
                db.SaveChanges();
                Response.Redirect("departments.aspx");
            }
        }
        
    }
}