using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class Academic_Default : System.Web.UI.Page
{
    DatabaseFunctions databadeFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonfunction;
    AcaBAL objbal;
    AcaBLL objbll;
    DataTable dt;

    protected void Page_Load(object sender, EventArgs e)
    {
        initialise();
    }
    void initialise()
    { 
        databadeFunctions=new DatabaseFunctions();
        fillFunctions=new FillFunctions();
        objbal=new AcaBAL();
        objbll=new AcaBLL();
        dt=new DataTable();
        commonfunction = new CommonFunctions();
    
    }
    protected void gvGroupHeads_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            dt = (DataTable)ViewState["dt"];
            ViewState["ID"] = gvregblock.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            DataRow[] dr = dt.Select("stu_main_id=" + ViewState["ID"].ToString());
            txtEnroll.Text = dr[0][1].ToString();
            TXTREMARK.Text= dr[0][3].ToString();
        }
        else if (e.CommandName == "Activate")
        {
            objbal.ChangeStatus = "1";
            objbal.Enroll_No = e.CommandArgument.ToString();
            objbll.changeblockStatus(objbal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Activated Successfully.')", true);
            fillgrid();

        }
        else if (e.CommandName == "Deactivate")
        {
            objbal.ChangeStatus = "0";
            objbal.Enroll_No = e.CommandArgument.ToString();
            objbll.changeblockStatus(objbal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated Successfully.')", true);
            fillgrid();
        }


    }
    protected void btnshow_Click(object sender, EventArgs e)
    {
        string enroll = commonfunction.GetKeyID(txtEnroll);
        Student.ShowStudent(txtEnroll.Text);
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        objbal.Enroll_No = txtEnroll.Text;
        objbal.InsertBy = Session["user_id"].ToString();
        objbal.ChangeStatus = "1";
        objbal.Remark = TXTREMARK.Text;
        objbll.regblockInsert(objbal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Successfully Save')", true);
    }
    

    public void fillgrid()
    {
        objbal.Enroll_No = txtEnroll.Text;
        dt=objbll.regblockSelect(objbal);
        gvregblock.DataSource = dt;
        gvregblock.DataBind();
        foreach (GridViewRow itm in gvregblock.Rows)
        {
            itm.Cells[0].Text = (itm.RowIndex + 1).ToString();
            ImageButton img = (ImageButton)itm.FindControl("imgAct");
            if (dt.Rows[itm.RowIndex]["REG_BLOCK_STS"].ToString() == "True")
            {
                img.ImageUrl = "~/images/activate.gif";
                img.ToolTip = "Deactivate";
                img.CommandName = "Deactivate";
            }
            else
            {
                img.ImageUrl = "~/images/deactivate.gif";
                img.ToolTip = "Activate";
                img.CommandName = "Activate";
                itm.ForeColor = System.Drawing.Color.Red;
                itm.Font.Strikeout = true;
            }
        }

    }
}