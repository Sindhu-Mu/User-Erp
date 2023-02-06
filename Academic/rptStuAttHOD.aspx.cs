using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Academic_rptStuAttHOD : System.Web.UI.Page
{
    FillFunctions fill;
    QueryFunctions queryfunctions;
    CommonFunctions common;
    AcaBLL bll;
    DataTable dt;
    AcaBAL bal;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnView.Attributes.Add("OnClick", "return validation()");
        if (!IsPostBack)
        {
            fill.Fill(ddlSem, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.Select);
            fill.Fill(ddlDept, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.UsrDept, Session["UserId"].ToString()), true, FillFunctions.FirstItem.Select);
        }
    }

    private void Initialize()
    {
        fill = new FillFunctions();
        queryfunctions = new QueryFunctions();
        common = new CommonFunctions();
        dt = new DataTable();
        bll = new AcaBLL();
        bal = new AcaBAL();
    }
    protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDept.SelectedIndex > 0)
        {
            fill.Fill(ddlPgm, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.DeptPgm, ddlDept.SelectedValue), true, FillFunctions.FirstItem.Select);
        }
        else
        {
            ddlPgm.Items.Clear();
        }
    }
    protected void ddlPgm_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPgm.SelectedIndex > 0)
        {
            fill.Fill(ddlBrnch, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.Branch, ddlPgm.SelectedValue), true, FillFunctions.FirstItem.Select);
        }
        else
            ddlBrnch.Items.Clear();
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        bal.DeptId = ddlDept.SelectedValue;
        bal.Pgm_Id = ddlPgm.SelectedValue;
        bal.Brn_Id = ddlBrnch.SelectedValue;
        bal.Semid = ddlSem.SelectedValue;
        fill.Fill(gvClassDetail, bll.getClass(bal).Tables[0]);
    }
    protected void gvClassDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        foreach (GridViewRow row in gvClassDetail.Rows)
        {
            gvClassDetail.Rows[row.RowIndex].BackColor = System.Drawing.Color.White;
        }
        gvClassDetail.Rows[index].BackColor = System.Drawing.Color.Yellow;
        if (e.CommandName == "Select")
        {
            bal.Id = gvClassDetail.DataKeys[index].Values[0].ToString();
            bal.Semid = gvClassDetail.Rows[index].Cells[4].Text;
            bal.DeptId =  gvClassDetail.DataKeys[index].Values[1].ToString();
            bal.Pgm_Id =  gvClassDetail.DataKeys[index].Values[2].ToString();
            bal.Brn_Id = gvClassDetail.DataKeys[index].Values[3].ToString();
            bal.TypeId = "1";
            fill.Fill(gvFaculty, bll.getClassFacStuDetail(bal).Tables[0]);
            trFaculty.Visible = true;
            trStudent.Visible = false;
        }
        else if (e.CommandName == "Student")
        {
            trFaculty.Visible = false;
            trStudent.Visible = true;
            bal.Id = gvClassDetail.DataKeys[index].Values[0].ToString();
            bal.Semid = gvClassDetail.Rows[index].Cells[4].Text;
            bal.DeptId = gvClassDetail.DataKeys[index].Values[1].ToString();
            bal.Pgm_Id = gvClassDetail.DataKeys[index].Values[2].ToString();
            bal.Brn_Id = gvClassDetail.DataKeys[index].Values[3].ToString();
            bal.TypeId = "2";
            DataSet ds = bll.getClassFacStuDetail(bal);

            if (ds.Tables[0].Rows.Count > 0)
            {
                BoundField field;
                foreach (DataColumn column in ds.Tables[0].Columns)
                {
                    if (column.ColumnName != "ENROLLMENT_NO" && column.ColumnName != "SEM_ROLL_NO" && column.ColumnName != "STU_FULL_NAME")
                    {
                        field = new BoundField();

                        field.DataField = column.ColumnName;
                        field.HtmlEncode = false;

                        field.HeaderText = column.ColumnName;
                        field.ItemStyle.HorizontalAlign = HorizontalAlign.Center;

                        gvStudent.Columns.Add(field);
                    }
                }
            }
            fill.Fill(gvStudent, ds.Tables[0]);
        }
    }
}