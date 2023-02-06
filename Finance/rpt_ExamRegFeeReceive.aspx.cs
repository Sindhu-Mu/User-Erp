using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI.HtmlControls;

public partial class Finance_rpt_ExamRegFeeReceive : System.Web.UI.Page
{
    FillFunctions fillFunction;
    DatabaseFunctions databaseFunctions;
    QueryFunctions queryFunctions;
    CommonFunctions commonFunctions;
    DataTable dt;
    StringBuilder query;
    ExamFunctions.QueryFunctions queryfun;
    ExamFunctions.FillFunctions fillfun;
    void initialise()
    {
        fillFunction = new FillFunctions();
        databaseFunctions = new DatabaseFunctions();
        queryFunctions = new QueryFunctions();
        commonFunctions = new CommonFunctions();
        dt = new DataTable();
        queryfun = new ExamFunctions.QueryFunctions();
        fillfun = new ExamFunctions.FillFunctions();
        query = new StringBuilder();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        initialise();
        if (!IsPostBack)
        {
            fillfun.Fill(ddlExamination, queryfun.GetCommand(ExamFunctions.QueryFunctions.QueryBaseType.Examination), true, ExamFunctions.FillFunctions.FirstItem.All);
            fillFunction.Fill(ddlIns, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.All);
            fillFunction.Fill(ddlSem, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.All);
        }
    }
    protected void ddlIns_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIns.SelectedIndex > 0)
            fillFunction.Fill(ddlPgm, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns, ddlIns.SelectedValue), true, FillFunctions.FirstItem.Select);

    }
    protected void ddlPgm_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPgm.SelectedIndex > 0)
            fillFunction.Fill(ddlBranch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Branch, ddlPgm.SelectedValue), true, FillFunctions.FirstItem.Select);

    }
    private StringBuilder PrepareQuery()
    {
        query.Clear();
        if (ddlReceipt.SelectedValue == "0")
        {
            query.Append("SELECT DISTINCT 'INSTITUTE'=StuView.INS_VALUE,'COURSE'=StuView.PGM_SHORT_NAME,'ENROLL'=StuView.ENROLLMENT_NO ,'NAME'= StuView.STU_FULL_NAME,'RCPT NO'=EXAM_BACK_REG_FEE_INF.RECIEPT_NO,'RCV DATE'=convert(varchar,EXAM_BACK_REG_FEE_INF.BACK_FEE_RCV_DT,103),EMP_NAME as 'RCV BY',DEMAND_AMT AS 'DEMAND',FINE_AMT AS 'FINE',DISCOUNT_AMT AS 'DISCOUNT',RECIEVE_AMT AS 'RECEIVE', (select count (*) from Examination.dbo.EXAM_BACK_REG_SUB_INF where BACK_MAIN_ID=EXAM_BACK_REG_MAIN_INF.BACK_REG_MAIN_ID and BACK_PAPER_STS=2 and BACK_FEE_RCV_ID=EXAM_BACK_REG_FEE_INF.BACK_FEE_RCV_ID) as 'NOP',Examination.dbo.EXAM_BACK_REG_FEE_INF.BACK_FEE_RCV_RMK as 'Remark',case when FEE_TYPE=0 then 'Cleared' else 'Permission' end as 'Type'");
        }
        else
        {
            query.Append("SELECT DISTINCT 'INSTITUTE'=StuView.INS_VALUE,'COURSE'=StuView.PGM_SHORT_NAME,'ENROLL'=StuView.ENROLLMENT_NO ,'NAME'= StuView.STU_FULL_NAME,'REG BY'=StuView.ENROLLMENT_NO,'REG DATE'=EXAM_BACK_REG_TRAN_INF.REG_TRAN_DT,'REG RMK'=EXAM_BACK_REG_TRAN_INF.REG_TRAN_RMK,DEMAND_AMT AS 'DEMAND',FINE_AMT AS 'FINE',DISCOUNT_AMT AS 'DISCOUNT',RECIEVE_AMT AS 'RECEIVE', (select count (*) from Examination.dbo.EXAM_BACK_REG_SUB_INF where BACK_MAIN_ID=EXAM_BACK_REG_MAIN_INF.BACK_REG_MAIN_ID and BACK_PAPER_STS=2) as 'NOP',Examination.dbo.EXAM_BACK_REG_FEE_INF.BACK_FEE_RCV_RMK as 'Remark',case when FEE_TYPE=0 then 'Cleared' else 'Permission' end as 'Type'");
        }
        query.Append(" FROM   StuView INNER JOIN "
                          + " Examination.dbo.EXAM_BACK_REG_MAIN_INF ON StuView.STU_MAIN_ID = Examination.dbo.EXAM_BACK_REG_MAIN_INF.STU_MAIN_ID Inner join "
                          + " Examination.dbo.EXAM_BACK_REG_FEE_INF ON Examination.dbo.EXAM_BACK_REG_MAIN_INF.BACK_REG_MAIN_ID = Examination.dbo.EXAM_BACK_REG_FEE_INF.BACK_REG_MAIN_ID " +
        " inner join Examination.dbo.EXAM_BACK_REG_SUB_INF on " + 
	" EXAM_BACK_REG_SUB_INF.BACK_MAIN_ID = EXAM_BACK_REG_MAIN_INF.BACK_REG_MAIN_ID inner join Examination.dbo.EXAM_MAIN_INF ON "
                          + "  Examination.dbo.EXAM_MAIN_INF.EXAM_MAIN_ID = Examination.dbo.EXAM_BACK_REG_MAIN_INF.EXAM_ID inner join "
                          + " Examination.dbo.EXAM_BACK_REG_TRAN_INF on Examination.dbo.EXAM_BACK_REG_TRAN_INF.REG_ID=EXAM_BACK_REG_MAIN_INF.BACK_REG_MAIN_ID and REG_STS=-1 inner join "
                          + " USerView ON EXAM_BACK_REG_FEE_INF.BACK_FEE_RCV_BY = USerView.USR_ID " +
       " inner join examination.dbo.CRS_REG_TYPE_INF on CRS_REG_TYPE_INF.CRS_REG_TYPE_ID=EXAM_BACK_REG_SUB_INF.EXAM_TYPE ");
        query.Append(" where Examination.dbo.EXAM_BACK_REG_MAIN_INF.EXAM_ID=" + ddlExamination.SelectedValue + "");


        if (ddlIns.SelectedIndex > 0)
        {
            query.Append(" AND (StuView.INS_ID =" + ddlIns.SelectedValue + ")");
        }
        if (ddlPgm.SelectedIndex > 0)
        {
            query.Append(" AND (StuView.INS_PGM_ID =" + ddlPgm.SelectedValue + ")");
        }
        if (ddlBranch.SelectedIndex > 0)
        {
            query.Append(" AND (StuView.PGM_BRN_ID=" + ddlBranch.SelectedValue + ")");
        }
        if (ddlSem.SelectedIndex > 0)
        {
            query.Append(" AND (StuView.ACA_SEC_ID=" + ddlSem.SelectedValue + ")");
        }
        if (ddlType.SelectedIndex > 0)
        {
            query.Append(" AND (EXAM_BACK_REG_FEE_INF.FEE_TYPE=" + ddlType.SelectedValue + ")");
        }

        if (ddlExamination.SelectedIndex > 0)
        {
            query.Append(" AND (EXAM_MAIN_INF.EXAM_MAIN_ID=" + ddlExamination.SelectedValue + ")");
        }
        if (ddlexamtypes.SelectedIndex > 0)
        {
            query.Append(" AND (CRS_REG_TYPE_INF.CRS_REG_TYPE_ID =" + ddlexamtypes.SelectedValue + ")");
        }
        if (txtdate.Text != "")
            query.Append(" AND (convert(varchar,EXAM_BACK_REG_FEE_INF.BACK_FEE_RCV_DT,103) ='" + txtdate.Text + "')");

        if (ddlReceipt.SelectedValue == "0")
            query.Append(" GROUP BY ENROLLMENT_NO,STU_FULL_NAME,INS_VALUE,PGM_SHORT_NAME,EXAM_BACK_REG_MAIN_INF.BACK_REG_MAIN_ID,EXAM_BACK_REG_FEE_INF.RECIEPT_NO,EXAM_BACK_REG_FEE_INF.BACK_FEE_RCV_DT,EXAM_BACK_REG_FEE_INF.BACK_FEE_RCV_ID,EMP_NAME,RECIEVE_AMT,DEMAND_AMT,DISCOUNT_AMT,FINE_AMT,Examination.dbo.EXAM_BACK_REG_FEE_INF.BACK_FEE_RCV_RMK,FEE_TYPE");
        else
            query.Append(" GROUP BY ENROLLMENT_NO,STU_FULL_NAME,INS_VALUE,PGM_SHORT_NAME,EXAM_BACK_REG_MAIN_INF.BACK_REG_MAIN_ID,StuView.ENROLLMENT_NO,REG_TRAN_DT,REG_TRAN_RMK,RECIEVE_AMT,DEMAND_AMT,DISCOUNT_AMT,FINE_AMT,Examination.dbo.EXAM_BACK_REG_FEE_INF.BACK_FEE_RCV_RMK,FEE_TYPE");



        if (ddlReceipt.SelectedValue == "0")

            query.Append(" ORDER BY EXAM_BACK_REG_FEE_INF.RECIEPT_NO");
        else
            query.Append(" ORDER BY ENROLLMENT_NO");


        return query;
    }

    protected void btnView_Click(object sender, EventArgs e)
    {
        try
        {
            SqlCommand command = new SqlCommand(PrepareQuery().ToString());
            command.CommandType = CommandType.Text;
            dt = databaseFunctions.GetDataSet(command).Tables[0];
            gvFeeReport.DataSource = dt;
            gvFeeReport.DataBind();
            double sum = 0, sum1 = 0, sum2 = 0, sum3 = 0;
            foreach (GridViewRow itm in gvFeeReport.Rows)
            {


                sum += Convert.ToDouble(dt.Rows[itm.RowIndex][7].ToString());
                sum1 += Convert.ToDouble(dt.Rows[itm.RowIndex][8].ToString());
                sum2 += Convert.ToDouble(dt.Rows[itm.RowIndex][9].ToString());
                sum3 += Convert.ToDouble(dt.Rows[itm.RowIndex][10].ToString());
            }

            if (dt.Rows.Count > 0)
            {
                gvFeeReport.FooterRow.Cells[8].Text = "Total Amount";
                gvFeeReport.FooterRow.Cells[9].Text = sum.ToString();
                gvFeeReport.FooterRow.Cells[10].Text = sum1.ToString();
                gvFeeReport.FooterRow.Cells[11].Text = sum2.ToString();
                gvFeeReport.FooterRow.Cells[12].Text = sum3.ToString();
            }
        }
        catch
        {

        }

    }
    protected void BtnExport_Click(object sender, EventArgs e)
    {
        gvFeeReport.Columns[0].Visible = false;
        GridViewExportUtil.Export("ExamRegFeeDetail.xls", gvFeeReport);
        gvFeeReport.Columns[0].Visible = true;
    }

    protected void gvFeeReport_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "show")
            {
                if (gvFeeReport.Rows[Convert.ToInt32(e.CommandArgument)].Cells[6].Text.Contains("/"))
                {
                    string receipt_id = GetReceiptId(gvFeeReport.Rows[Convert.ToInt32(e.CommandArgument)].Cells[6].Text);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('prtExamRegFee.aspx?=" + receipt_id + "',alwaysraised='yes')", true);
                }
                else
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Receipt not generated for selected registration.')", true);

            }
        }
        catch
        { }

    }
    private string GetReceiptId(string a)
    {
        ExamFunctions.DatabaseFunctions df = new ExamFunctions.DatabaseFunctions();
        return df.ExecuteScalar(queryfun.GetCommand(ExamFunctions.QueryFunctions.QueryBaseType.Receipt_Id, a)).ToString();


    }

}