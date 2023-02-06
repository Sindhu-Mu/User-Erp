using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HR_SecurityIdCard : System.Web.UI.Page
{
    SecurityBLL ObjBll;
    SecurityBAL ObjBal;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            FillGrid();
        }
    }

    public void Initialize()
    {
        ObjBll = new SecurityBLL();
        ObjBal = new SecurityBAL();
    }

    public void FillGrid()
    {
        //gvSecurity.DataSource = ObjBll.SecurityCardSelect();
        //gvSecurity.DataBind();
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        ObjBal.EMP_CODE = txtCode.Text;
        gvSecurity.DataSource = ObjBll.SecurityCardSelect(ObjBal);
        gvSecurity.DataBind();
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        ObjBal.EMP_CODE = txtCode.Text;
        Session["DataSet"] = ObjBll.SecurityCardSelect(ObjBal);
        Response.Redirect("SecurityCard.aspx");
    }
}