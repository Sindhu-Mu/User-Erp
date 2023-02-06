using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class HR_QualificationMain : System.Web.UI.Page
{
    FillFunctions fillfunctions;
    QueryFunctions queryfunctions;
    CommonFunctions common;
    DataTable dt;
    string Msg;
    HRBLL ObjHrBll;
    HRBAL ObjHrBAL;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnSave.Attributes.Add("OnClick", "return validation()");
        if (!IsPostBack)
        {
            FillGrid();
            ViewState["dt"] = dt;
            ViewState["ID"] = "";
        }
    }
    private void Initialize()
    {
        fillfunctions = new FillFunctions();
        queryfunctions = new QueryFunctions();
        common = new CommonFunctions();
        dt = new DataTable();
        ObjHrBll = new HRBLL();
        ObjHrBAL = new HRBAL();
    }

    void FillGrid()
    {
        
        dt = ObjHrBll.getQualificationList().Tables[0];
        ViewState["dt"] = dt; 
        gvShow.DataSource = dt;
        gvShow.DataBind();
    }
    protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            ViewState["ID"] = gvShow.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            dt = (DataTable)ViewState["dt"];
            DataRow[] dr = dt.Select("ACA_CRS_ID=" + ViewState["ID"].ToString());
            if (dr[0]["ACA_CRS_STS"].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
                return;
            }
            txtQualName.Text = dr[0]["ACA_CRS_VALUE"].ToString();
            


        }
        else
        {
            ObjHrBAL.ChangeStatus = e.CommandName;
            ObjHrBAL.KeyID = e.CommandArgument.ToString();
            //ObjHrBAL.SessionUserID = Session["UserId"].ToString();
            Msg = ObjHrBll.QualificationModify(ObjHrBAL);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            FillGrid();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ObjHrBAL.KeyID = ViewState["ID"].ToString();
        ObjHrBAL.KeyValue = txtQualName.Text;
        Msg=ObjHrBll.QualificationInsertUpdate(ObjHrBAL);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        FillGrid();
        txtQualName.Text = "";
    }


}