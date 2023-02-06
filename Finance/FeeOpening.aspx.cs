using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Finance_FeeOpening : System.Web.UI.Page
{
    FillFunctions fillfunction;
    DatabaseFunctions databasefunction;
    QueryFunctions queryfunction;
    SFBAL Objbal;
    SFBLL Objbll;
    SFDAL Objdal;
    DataTable dt;
    double totdemand;

    protected void Page_Load(object sender, EventArgs e)
    {
        initialise();
        if (!IsPostBack)
        { 
        }
    }
    private void initialise()
    {
        fillfunction = new FillFunctions();
        databasefunction = new DatabaseFunctions();
        queryfunction = new QueryFunctions();
        Objbal = new SFBAL();
        Objbll = new SFBLL();
        Objdal = new SFDAL();
        dt = new DataTable();
    }
    private void Show_Detail()
    {
        totdemand = 0;
        Objbal.balEnrollment = txtEnrollment.Text;
        dt = Objbll.StudentOpeningFeeSelect(Objbal).Tables[0];
        gvFees.DataSource = dt;
        gvFees.DataBind();
        foreach (GridViewRow itm in gvFees.Rows)
            totdemand += Convert.ToInt32(dt.Rows[itm.RowIndex]["FD_FEE_AMOUNT"]);
        if (gvFees.Rows.Count > 0)
            gvFees.FooterRow.Cells[2].Text = totdemand.ToString("N2");
        

    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        Student.ShowStudent(txtEnrollment.Text);
        gvFees.DataSource = "";
        gvFees.DataBind();
        Show_Detail();

    }
    protected void gvFees_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvFees.EditIndex = -1;
        Show_Detail();
    }
    protected void gvFees_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvFees.EditIndex = e.NewEditIndex;
        Show_Detail();
    }
    protected void gvFees_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
      double Amount = Convert.ToDouble(((TextBox)gvFees.Rows[e.RowIndex].FindControl("txtAmount")).Text);
      Objbal.balAmount = Amount.ToString();
      Objbal.balTempId = gvFees.DataKeys[e.RowIndex].Value.ToString();
      Objbll.StudentOpeningFeeUpdate(Objbal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Selected fee head Amount Updated.')", true);
        Show_Detail();
        gvFees.EditIndex = -1;
        Show_Detail();
    }
}