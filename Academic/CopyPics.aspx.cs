using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Academic_CopyPics : System.Web.UI.Page
{
    AcaBAL ObjAcaBal;
    AcaBLL ObjAcaBll;
    DatabaseFunctions databasefunction;
  
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        { }
    }

    void Initialize()
    {
        ObjAcaBal = new AcaBAL();
        ObjAcaBll = new AcaBLL();
        databasefunction = new DatabaseFunctions();

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DataSet ds = ObjAcaBll.form_no(ObjAcaBal);
        var folders = @"D:\EmployeePortal\images\Stuimages\copy2015\";
        if (!Directory.Exists(folders))
        {
            Directory.CreateDirectory(folders);
        }
        else
        {
            Directory.Delete(folders, true);
            Directory.CreateDirectory(folders);
        }
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ////for 2014 batch
            ////try
            ////{
            ////    var a = @"D:\EmployeePortal\images\Stuimages\" + ds.Tables[0].Rows[i]["enrollment_no"].ToString() + ".jpg";
            ////    File.Copy(a, folders + ds.Tables[0].Rows[i][1].ToString() + ".jpg", true);
               
            ////}
            ////catch 
            ////{

            ////    ObjAcaBal.Id = ds.Tables[0].Rows[i]["enrollment_no"].ToString();
            ////       ObjAcaBll.form_no_insert(ObjAcaBal);
            ////}

            try
            {
                var a = @"D:\EmployeePortal\images\Stuimages\2015\" + ds.Tables[0].Rows[i]["form_no"].ToString() + ".jpg";
                File.Copy(a, folders + ds.Tables[0].Rows[i][1].ToString() + ".jpg", true);

            }
            catch
            {

                ObjAcaBal.Id = ds.Tables[0].Rows[i]["form_no"].ToString();
                ObjAcaBll.form_no_insert(ObjAcaBal);
            }
          
        }
    }

    
    }
