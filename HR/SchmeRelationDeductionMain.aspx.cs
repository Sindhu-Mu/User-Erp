using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class HR_EPFSchmeRelationDeductionMain : System.Web.UI.Page
{
    FillFunctions fillfunction;
    QueryFunctions QueryFunction;
    CommonFunctions common;
    DataTable dt;
    string Msg;
    HRBLL ObjHrBll;
    HRBAL ObjHrBal;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        saveScheme.Attributes.Add("onclick", "return Scheme()");
        saveDeduction.Attributes.Add("onclick", "return Deduction()");
        saveRelation.Attributes.Add("onclick", "return Relation()");
        if (!IsPostBack)
        {
            ViewState["ID"] = "";
            ViewState["dt"] = dt;
            FillScheme();
            FillRelation();
            FillDeduction();
        }
    }
    private void Initialize()
    {
        fillfunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        common = new CommonFunctions();
        dt = new DataTable();
        ObjHrBll = new HRBLL();
        ObjHrBal = new HRBAL();
    }
    protected void saveScheme_Click1(object sender, EventArgs e)
    {
        ObjHrBal.KeyID = ViewState["ID"].ToString();
        ObjHrBal.Name = txtScheme.Text;
        ObjHrBal.InBy = Session["UserId"].ToString();
        Msg = ObjHrBll.SchemeInsertUpdate(ObjHrBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        common.Clear(this);
        FillScheme();
    }
    private void FillScheme()                            
    {
        dt = ObjHrBll.SchemeInfSelect(ObjHrBal).Tables[0];
        ViewState["dt"] = dt;
        gvScheme.DataSource = dt;
        gvScheme.DataBind();
    }
    private void FillRelation()
    {
        dt = ObjHrBll.RelationInfSelect(ObjHrBal).Tables[0];
        ViewState["dt"] = dt;
        gvRelation.DataSource = dt;
        gvRelation.DataBind();
    }
    private void FillDeduction()
    {
        dt = ObjHrBll.DeductionInfSelect(ObjHrBal).Tables[0];
        ViewState["dt"] = dt;
        gvDeduction.DataSource = dt;
        gvDeduction.DataBind();        
    }
    protected void gvScheme_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            ViewState["ID"] = gvScheme.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            dt = (DataTable)ViewState["dt"];
            DataRow[] dr = dt.Select("SCHM_ID=" + ViewState["ID"].ToString());
            if (dr[0]["STATUS"].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
                return;
            }
            txtScheme.Text = dr[0][1].ToString();
        }
        else
        {
            ObjHrBal.ChangeStatus = e.CommandName;
            ObjHrBal.KeyID = e.CommandArgument.ToString();
            ObjHrBal.SessionUserID = Session["UserId"].ToString();
            Msg = ObjHrBll.SchemeInfModify(ObjHrBal);                                                 
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            common.Clear(this);
            FillScheme();
        }
    }
    protected void saveRelation_Click(object sender, EventArgs e)
    {
        ObjHrBal.KeyID = ViewState["ID"].ToString();
        ObjHrBal.Name = txtRelation.Text;
        ObjHrBal.InBy = Session["UserId"].ToString();
        Msg = ObjHrBll.RelationInsertUpdate(ObjHrBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        common.Clear(this);
        FillRelation();
    }
    protected void gvRelation_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            ViewState["ID"] = gvRelation.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            dt = (DataTable)ViewState["dt"];
            DataRow[] dr = dt.Select("RELATION_ID=" + ViewState["ID"].ToString());
            if (dr[0]["RELATION_STATUS"].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
                return;
            }
            txtRelation.Text = dr[0][1].ToString();
        }
        else
        {
            ObjHrBal.ChangeStatus = e.CommandName;
            ObjHrBal.KeyID = e.CommandArgument.ToString();
            ObjHrBal.SessionUserID = Session["UserId"].ToString();
            Msg = ObjHrBll.RelationInfModify(ObjHrBal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            common.Clear(this);
            FillRelation();
        }
    }    
    protected void saveDeduction_Click(object sender, EventArgs e)
    {
        ObjHrBal.KeyID = ViewState["ID"].ToString();
        ObjHrBal.Name = txtDname.Text;
        ObjHrBal.KeyValue = txtDvalue.Text;
        ObjHrBal.InBy = Session["UserId"].ToString();
        Msg = ObjHrBll.DeductionInsertUpdate(ObjHrBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        common.Clear(this);
        FillDeduction();
    }
    protected void gvDeduction_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            ViewState["ID"] = gvDeduction.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            dt = (DataTable)ViewState["dt"];
            DataRow[] dr = dt.Select("DEDC_ID=" + ViewState["ID"].ToString());
            if (dr[0]["STATUS"].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
                return;
            }
            txtDname.Text = dr[0][1].ToString();
            txtDvalue.Text = dr[0][2].ToString();
        }
        else
        {
            ObjHrBal.ChangeStatus = e.CommandName;
            ObjHrBal.KeyID = e.CommandArgument.ToString();
            ObjHrBal.SessionUserID = Session["UserId"].ToString();
            Msg = ObjHrBll.DeductionInfModify(ObjHrBal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            common.Clear(this);
            FillDeduction();
        }
    }
}