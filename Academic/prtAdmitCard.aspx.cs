using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Academic_prtAdmitCard : System.Web.UI.Page
{


    DataTable dt = new DataTable();
    GridView gv = new GridView();
    int count = 0;
    AcaBLL ObjBll = new AcaBLL();
    AcaBAL ObjBal = new AcaBAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        dt = (DataTable)Session["dt"];
        Repeater1.DataSource = dt;
        Repeater1.DataBind();
    }
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        dt = (DataTable)Session["dt"];
        //code for printing date sheet
        ObjBal.Enroll_No = dt.Rows[e.Item.ItemIndex]["ENROLLMENT_NO"].ToString();
        gv = (GridView)e.Item.FindControl("GridView1");
        gv.DataSource = ObjBll.GetMinorSittingPlan(ObjBal).Tables[0];
        gv.DataBind();
        count++;
        if (count == 2)
        {
            e.Item.Controls.Add(new LiteralControl("<hr style='color:White;page-break-after:always;'/>"));
            count = 0;
        }
    }
}