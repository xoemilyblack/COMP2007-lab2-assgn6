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
    public partial class departments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetDepartments();
            }
        }
        protected void GetDepartments()
        {
            using (comp2007Entities db = new comp2007Entities())
            {
                var Departments = from d in db.Departments
                                  select d;

                //bind results 
                grdDepartments.DataSource = Departments.ToList();
                grdDepartments.DataBind();
            }
        }
        protected void grdDepartments_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //store the row clicked
            Int32 selectedRow = e.RowIndex;

            //get the selected StudentID 
            Int32 DepartmentID = Convert.ToInt32(grdDepartments.DataKeys[selectedRow].Values["DepartmentID"]);

            //using EF to remove selected student
            using (comp2007Entities db = new comp2007Entities())
            {
                Department d = (from objD in db.Departments where objD.DepartmentID == DepartmentID select objD).FirstOrDefault();
                db.Departments.Remove(d);
                db.SaveChanges();
            }
            //refresh grid
            GetDepartments();
        }
       
        }
    }
