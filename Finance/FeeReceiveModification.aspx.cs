using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
using System.Text;

public partial class Finance_FeeReceiveModification : System.Web.UI.Page
{
    FillFunctions fillFunction;
    DatabaseFunctions databaseFunctions;
    QueryFunctions queryFunction;
    CommonFunctions cf;
    SFBAL ObjBal;
    SFBLL Objbll;
    SFDAL ObjDal;
    DataSet ds;
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnShow.Attributes.Add("onClick", "return valid()");
        initialise();
        if (!IsPostBack)
        {
            fillFunction.Fill(ddlSemester, queryFunction.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.Select);
        }
    }
    void initialise()
    {
        fillFunction = new FillFunctions();
        databaseFunctions = new DatabaseFunctions();
        queryFunction = new QueryFunctions();
        cf = new CommonFunctions();
        ObjBal = new SFBAL();
        Objbll = new SFBLL();
        ObjDal = new SFDAL();
        ds = new DataSet();
        dt = new DataTable();
    }
   
    protected void btnShow_Click(object sender, EventArgs e)
    {
        gvFeesHead.DataSource = "";
        gvFeesHead.DataBind();
        gvRcvDetail.DataSource = "";
        gvRcvDetail.DataBind();
        divReceive.Visible = false;
        Student.ShowStudent(txtEnrollment.Text);
        ObjBal.balCommonID = txtEnrollment.Text;
        dt = Objbll.GetStudentDetails(ObjBal).Tables[0];
        if (dt.Rows.Count > 0)
        {

            if (ddlBranch.Items.Count == 0)
            {
                ddlBranch.Items.Clear();
                fillFunction.Fill(ddlBranch, dt, true, FillFunctions.FirstItem.Select);
                ddlBranch.SelectedIndex = 1;
                ddlSemester.SelectedValue = dt.Rows[0][2].ToString();
            }
        }
        if (ddlBranch.Items.Count == 0)
        {
            fillFunction.Fill(ddlBranch, queryFunction.GetCommand(QueryFunctions.QueryBaseType.StuBranch, txtEnrollment.Text), true, FillFunctions.FirstItem.Select);
            ddlBranch.SelectedIndex = 1;
        }
        ObjBal.balStuAdmNo = txtEnrollment.Text;
        ObjBal.balBranchId = ddlBranch.SelectedValue;
        ObjBal.balSem = ddlSemester.SelectedValue;
        ds = Objbll.FeeDemRcvSelect(ObjBal);
        gv.DataSource = ds.Tables[1];
        gv.DataBind();
        gvDetail.DataSource = ds.Tables[0];
        gvDetail.DataBind();

    }
    protected void gvDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ViewState["RECEIPT_NO"] = gvDetail.DataKeys[Convert.ToInt32(e.CommandArgument)].Values[0].ToString();
        ObjBal.balRcptNo = ViewState["RECEIPT_NO"].ToString();
        DataSet ds1 = Objbll.RcvReceiptDetail(ObjBal);
        gvRcvDetail.DataSource = ds1.Tables[0];
        gvRcvDetail.DataBind();

        double TotalAmt = 0;
        foreach (GridViewRow row in gvRcvDetail.Rows)
        {
            TotalAmt += Convert.ToDouble(row.Cells[2].Text);
        }
        if (gvRcvDetail.Rows.Count > 0)
        {
            divReceive.Visible = true;
            gvRcvDetail.FooterRow.Cells[2].Text = TotalAmt.ToString("N2");
            gvRcvDetail.Focus();
            btnModify.Visible = btnCal.Visible = true;
        }

        gvFeesHead.DataSource = ds1.Tables[1];
        gvFeesHead.DataBind();
    }

    protected void btnCal_Click(object sender, EventArgs e)
    {
        double TotalAmt = 0;
        foreach (GridViewRow itm in gvFeesHead.Rows)
        {
            TextBox txt = (TextBox)itm.FindControl("txtPayAmt");
            if (txt.Text != "")
                TotalAmt += Convert.ToDouble(txt.Text);
        }
        if (gvFeesHead.Rows.Count > 0)
        {
            gvFeesHead.FooterRow.Cells[1].Text = TotalAmt.ToString("N2");
            gvFeesHead.Focus();
        }
    }
   
    protected void btnModify_Click(object sender, EventArgs e)
    {
        if (gvRcvDetail.FooterRow.Cells[2].Text == gvFeesHead.FooterRow.Cells[1].Text)
        {
            StringBuilder data = new StringBuilder();
            data.AppendFormat("<DATA>");
            foreach (GridViewRow itm in gvFeesHead.Rows)
            {
                TextBox txt = (TextBox)itm.FindControl("txtPayAmt");
                if (txt.Text != "")
                {
                    data.AppendFormat("<HEAD HEAD_ID=\"" + gvFeesHead.DataKeys[itm.RowIndex].Value.ToString() + "\"  AMT=\"" + txt.Text + "\"/>");
                }
            }
            data.AppendFormat("</DATA>");
            ObjBal.balRcptNo=ViewState["RECEIPT_NO"].ToString();
            ObjBal.balData=data.ToString();
            ObjBal.balInBy = Session["UserId"].ToString();
            Objbll.FeeReceiveTranModify(ObjBal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Received amount modified successfully.')", true);
        }

        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Amounts are not equal.')", true);
        }

        clear();
    }

    void clear()
    {
        gv.DataSource = gvDetail.DataSource = gvFeesHead.DataSource = gvRcvDetail.DataSource = "";
        gv.DataBind(); gvDetail.DataBind(); gvFeesHead.DataBind(); gvRcvDetail.DataBind();
        cf.Clear(txtEnrollment);
        ddlBranch.SelectedIndex = 0;
       
    
    }
   
}