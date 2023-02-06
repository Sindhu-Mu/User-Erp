using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Common_TodayBirthDay : System.Web.UI.Page
{  
    protected void Page_Load(object sender, EventArgs e)
    {        
        BindGrid();
    }  
    void BindGrid()
    {
        HRBLL ObjHrBll=new HRBLL();
        DLBirthDay.DataSource = ObjHrBll.GetTodaysBirthDay().Tables[0];
        DLBirthDay.DataBind();
    }
}