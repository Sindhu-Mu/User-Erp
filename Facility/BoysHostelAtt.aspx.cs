using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Facility_BoysHostelAtt : System.Web.UI.Page
{
    FacBAL ObjFacBal;
    FacBLL ObjFacbll;
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnShow.Attributes.Add("OnClick", "return validate()");
        Initialize();
        if (!IsPostBack)
        {
            txtDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            Show();
        }
    }
    void Initialize()
    {

        ObjFacBal = new FacBAL();
        ObjFacbll = new FacBLL();
        dt = new DataTable();

    }
    private void Show()
    {
        ObjFacBal.KeyValue = txtDate.Text;
        dt = ObjFacbll.GetHostelStudentDailyAtt(ObjFacBal);
        gridAttendance.DataSource = dt;
        gridAttendance.DataBind();
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        Show();

    }
}