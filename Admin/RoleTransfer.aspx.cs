using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

public partial class Admin_RoleTransfer : System.Web.UI.Page
{
    USRBAL ObjUsrBal;
    USRBLL ObjUsrBll;
    CommonFunctions CommonFunction;
 
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            trDetail.Visible = false;
        }
    }
    void Initialize()
    {
        ObjUsrBal = new USRBAL();
        ObjUsrBll = new USRBLL();
        CommonFunction = new CommonFunctions();
    }
    void FillGrid()
    {
        ObjUsrBal.LOGINID = CommonFunction.GetKeyID(txtemp);
        DataTable dt = ObjUsrBll.GetRole(ObjUsrBal).Tables[0];
        gvRole.DataSource = dt;
        gvRole.DataBind();
        if(dt.Rows.Count>0)
            trDetail.Visible = true;

    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        FillGrid();
    }
    protected void btnAssign_Click(object sender, EventArgs e)
    {
        try
        {
            StringBuilder data = new StringBuilder();
            data.AppendFormat("<Role>");
            foreach (GridViewRow row in gvRole.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("chk");
                if (chk.Checked)
                    data.AppendFormat("<Data USR_ROLE_ID=\"" + gvRole.DataKeys[row.RowIndex].Values[0].ToString() + "\" ROLE_ID= \"" + gvRole.DataKeys[row.RowIndex].Values[1].ToString() + "\" USR_TRAN_ID= \"" + gvRole.DataKeys[row.RowIndex].Values[2].ToString() +
                        "\" />");
            }
            data.AppendFormat("</Role>");
            ObjUsrBal.XmlValue = data.ToString();
            ObjUsrBal.FromDt = CommonFunction.GetDateTime(txtDate.Text);
            ObjUsrBal.LOGINID = CommonFunction.GetKeyID(txtNewEmp);
            ObjUsrBal.USRID = Session["UserId"].ToString();
            ObjUsrBll.RoleTransfer(ObjUsrBal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Role transfered successfully.')", true);
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('An error occured.')", true);
            return;
        }
        finally
        {
            Clear();        
        }
    }

    void Clear()
    {
        txtemp.Text = txtNewEmp.Text = txtDate.Text = "";
        CommonFunction.Clear(gvRole);
        trDetail.Visible = false;
    }
}