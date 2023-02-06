using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Inventory_prtGatePass : System.Web.UI.Page
{
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    INVBAL objBal;
    INVBLL objBll;
    DatabaseFunctions databaseFunctions;
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {

        Initialize();
        
        try
        {
            objBal.ID = Request.QueryString[0];
            DataSet ds = objBll.PrintGatePass(objBal);
            if (ds.Tables[0].Rows[0]["PASS_TYPE"].ToString() == "1")
            {
                lblType1.Text = lblType.Text = "Returnable";
                rowRtnDate.Visible = true;
            }
            else {
                lblType1.Text = lblType.Text = "Non-Returnable";
                rowRtnDate.Visible = false;
            }
            if (ds.Tables[0].Rows[0]["CARRY_PERSON_TYPE"].ToString() == "1")
            {
                rowUnivEmp.Visible = true;
                rowDesc.Visible = false;
            }
            else
            {
                rowUnivEmp.Visible = false;
                rowDesc.Visible = true;
            }
            lblName.Text = ds.Tables[0].Rows[0]["NAME"].ToString();
            lblDate.Text = ds.Tables[0].Rows[0]["IN_DT"].ToString();
            lbldesc.Text = ds.Tables[0].Rows[0]["CARRY_PER_DESC"].ToString();
            lblDesignation.Text = ds.Tables[0].Rows[0]["DES_VALUE"].ToString();
            lblDept.Text = ds.Tables[0].Rows[0]["INS"].ToString();           
            lblRtnDate.Text = ds.Tables[0].Rows[0]["RTN_DATE"].ToString();
            lblRecpt.Text = ds.Tables[0].Rows[0]["RECIPNT"].ToString();
            if (ds.Tables[0].Rows[0]["RECP_TYPE"].ToString() == "1")
            {
                row_Ven_Cont.Visible = true;
                lblVen_Mob.Text = ds.Tables[0].Rows[0]["VEN_MOB_NO"].ToString();
            }
            else 
            {
                row_Ven_Cont.Visible = false;
            }
            gvItem.DataSource = ds.Tables[1];
            gvItem.DataBind();
            lblGatePass.Text = ds.Tables[0].Rows[0]["PASS_NUMBER"].ToString();
            lblAuthBy.Text = ds.Tables[0].Rows[0]["AUTH_BY"].ToString();
            lbl_AUTH_MOB.Text = ds.Tables[0].Rows[0]["PHN_NO"].ToString();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    public void Initialize()
    {
        queryFunctions = new QueryFunctions();
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        objBal = new INVBAL();
        objBll = new INVBLL();
        databaseFunctions = new DatabaseFunctions();
        dt = new DataTable();
    }

}