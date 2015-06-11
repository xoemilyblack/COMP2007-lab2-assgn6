using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//reference Entity
using System.Web.ModelBinding;
using comp2007_lesson6.Models;

namespace comp2007_lesson6
{
    public partial class students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if loading for first time populate student grid
            if (!IsPostBack)
            {
                GetStudents();
            }
        }
        protected void GetStudents()
        {
            using (comp2007Entities db = new comp2007Entities())
            {
                var Students = from s in db.Students
                               select s;

                //bind results 
                grdStudents.DataSource = Students.ToList();
                grdStudents.DataBind();
            }
        }

        protected void grdStudents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //store the row clicked
            Int32 selectedRow = e.RowIndex;

            //get the selected StudentID 
            Int32 StudentID = Convert.ToInt32(grdStudents.DataKeys[selectedRow].Values["StudentID"]);
            
            //using EF to remove selected student
            using (comp2007Entities db = new comp2007Entities())
            {
                Student s = (from objS in db.Students where objS.StudentID == StudentID select objS).FirstOrDefault();
                db.Students.Remove(s);
                db.SaveChanges();
            }
            //refresh grid
            GetStudents();
        }

    }
}