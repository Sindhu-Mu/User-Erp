using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
/// <summary>
/// Summary description for APPBLL
/// </summary>
public class APPBLL
{
    DatabaseFunctions databaseFunctions = new DatabaseFunctions();
    SqlCommand cmd;
    Messages Msg = new Messages();
    public enum HeaderFeild { PA03_1B, PA03_1A, PA03_2A, PA03_2B, PA03_2C, PA03_2D, PA03_2E, PA03_2F, PA03_3A, PA03_3B, PA03_3C, PA03_3D, PA03_3E, PA03_4A, PA03_5A, PA03_5B, PA03_5C, PA03_5D, PA03_5E, PA03_6A, PA03_6B, PA03_6C, PA03_6D, PA03_7A, PA03_8A };
    public enum LinkFeild { PA03_1, PA03_2, PA03_3, PA03_4, PA03_5, PA03_6, PA03_7, PA03_8, PA03 };
    public enum GridBuildMode { Entry, Report };
    CommonFunctions common = new CommonFunctions();
    public APPBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string GetSemester(int month)
    {
        if (month >= 1 && month <= 6)
            return "1";
        else
            return "0";
    }

    public string GetFacultyStatus(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_FAC_INF_STATUS_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserId);
        cmd.Parameters.AddWithValue("@PA03_FAC_SEM", ObjBal.Sem);
        cmd.Parameters.AddWithValue("@PA03_FAC_YEAR", ObjBal.Year);
        return databaseFunctions.GetSingleData(cmd);
    }
    public string GetFaculty(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_FAC_INF_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserId);
        cmd.Parameters.AddWithValue("@PA03_FAC_SEM", ObjBal.Sem);
        cmd.Parameters.AddWithValue("@PA03_FAC_YEAR", ObjBal.Year);
        return databaseFunctions.GetSingleData(cmd);
    }
    public string SaveFaculty(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_FAC_INF_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserId);
        cmd.Parameters.AddWithValue("@PA03_FAC_SEM", ObjBal.Sem);
        cmd.Parameters.AddWithValue("@PA03_FAC_YEAR", ObjBal.Year);
        return databaseFunctions.GetSingleData(cmd);
    }
    public void FacUpdateStatus(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_FAC_INF_STATUS_UPDATE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public void SetHeader(HeaderFeild headerFeild, Label header, Label description)
    {
        cmd = new SqlCommand("PA03_STEP_INF_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_STEP_ID", headerFeild.ToString().Substring(headerFeild.ToString().IndexOf('_') + 1, 2));
        SqlDataReader reader = databaseFunctions.GetReader(cmd);
        reader.Read();
        header.Text = reader[0].ToString();
        description.Text = reader[1].ToString();
        reader.Close();
    }
    public void SetHeader(LinkFeild linkFeild, Label header, Label description)
    {
        cmd = new SqlCommand("PA03_STEP_HDR_INF_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_STEP_HDR_ID", linkFeild.ToString().Substring(linkFeild.ToString().IndexOf('_') + 1, 1));
        SqlDataReader reader = databaseFunctions.GetReader(cmd);
        reader.Read();
        header.Text = reader[0].ToString();
        description.Text = reader[1].ToString();
        reader.Close();
    }
    public void SetLinks(LinkFeild linkFeild, HyperLink link, string target)
    {
        link.NavigateUrl = linkFeild.ToString() + ".aspx";
        link.Target = target;
    }

    public void BuildGrid(GridView gridView, APPBLL.GridBuildMode buildMode)
    {
        switch (buildMode)
        {
            case APPBLL.GridBuildMode.Entry:
                AddDeleteButton(gridView);
                break;
            case GridBuildMode.Report:
                break;
        }
    }

    public void AddDeleteButton(GridView gridView)
    {
        CommandField feild = new CommandField();
        feild.ButtonType = ButtonType.Button;
        feild.ShowDeleteButton = true;
        feild.HeaderStyle.Width = 50;
        gridView.Columns.Add(feild);
    }

    public DataSet getReviewPeriod(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_GET_REVIEW_PERIOD");
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }

    #region PA03_1A
    public SqlCommand PA03_1A_GetData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_1A_INF_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        return cmd;
    }



    public void PA03_1A_SaveData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_1A_INF_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@PA03_1A_CODE", ObjBal.PaperCode);
        cmd.Parameters.AddWithValue("@PA03_1A_NAME", ObjBal.PaperName);
        cmd.Parameters.AddWithValue("@PA03_1A_COT", ObjBal.Count);
        cmd.Parameters.AddWithValue("@PA03_1A_LAB", ObjBal.Lecture);
        cmd.Parameters.AddWithValue("@PA03_1A_TUT", ObjBal.Tutorail);
        cmd.Parameters.AddWithValue("@PA03_1A_PCT", ObjBal.Practical);
        cmd.Parameters.AddWithValue("@PA03_1A_RMK", ObjBal.Remark);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public void PA03_1A_DeleteData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_1A_INF_DELETE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_1A_ID", ObjBal.KeyId);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion



    #region PA03_1B
    public SqlCommand PA03_1B_GetData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_1B_INF_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        return cmd;
    }

    public void PA03_1B_SaveData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_1B_INF_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@PA03_1B_DET", ObjBal.Detail);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public void PA03_1B_DeleteData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_1B_INF_DELETE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_1B_ID", ObjBal.KeyId);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion


    #region PA03_2A
    public void PA03_2A_SaveData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_2A_INF_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@PA03_2A_DUT", ObjBal.Duty);
        cmd.Parameters.AddWithValue("@PA03_UNIV_LVL_ID", ObjBal.Level);
        cmd.Parameters.AddWithValue("@PA03_2A_FROM_DATE", common.GetDateTime(ObjBal.FromDate));
        cmd.Parameters.AddWithValue("@PA03_2A_TO_DATE", common.GetDateTime(ObjBal.ToDate));
        databaseFunctions.ExecuteCommand(cmd);
    }

    public void PA03_2A_DeleteData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_2A_INF_DELETE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_2A_ID", ObjBal.KeyId);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public SqlCommand PA03_2A_GetData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_2A_INF_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        return cmd;
    }
    #endregion
    #region PA03_2B
    public void PA03_2B_SaveData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_2B_INF_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@PA03_2B_DUT", ObjBal.Duty);
        cmd.Parameters.AddWithValue("@PA03_OPMF_ID", ObjBal.Opmf);
        cmd.Parameters.AddWithValue("@PA03_UNIV_LVL_ID", ObjBal.Level);
        cmd.Parameters.AddWithValue("@PA03_2B_FROM_DATE", common.GetDateTime(ObjBal.FromDate));
        cmd.Parameters.AddWithValue("@PA03_2B_TO_DATE", common.GetDateTime(ObjBal.ToDate));
        databaseFunctions.ExecuteCommand(cmd);
    }
    public void PA03_2B_DeleteData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_2B_INF_DELETE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_2B_ID", ObjBal.KeyId);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public SqlCommand PA03_2B_GetData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_2B_INF_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        return cmd;
    }
    #endregion
    #region PA03_2C
    public void PA03_2C_SaveData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_2C_INF_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@PA03_2C_DUT", ObjBal.Duty);
        cmd.Parameters.AddWithValue("@PA03_OPMF_ID", ObjBal.Opmf);
        cmd.Parameters.AddWithValue("@PA03_UNIV_LVL_ID", ObjBal.Level);
        cmd.Parameters.AddWithValue("@PA03_2C_FROM_DATE", common.GetDateTime(ObjBal.FromDate));
        cmd.Parameters.AddWithValue("@PA03_2C_TO_DATE", common.GetDateTime(ObjBal.ToDate));
        databaseFunctions.ExecuteCommand(cmd);
    }


    public void PA03_2C_DeleteData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_2C_INF_DELETE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_2C_ID", ObjBal.KeyId);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public SqlCommand PA03_2C_GetData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_2C_INF_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        return cmd;
    }
    #endregion

    #region PA03_2D
    public void PA03_2D_SaveData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_2D_INF_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@PA03_2D_DUT", ObjBal.Duty);
        cmd.Parameters.AddWithValue("@PA03_OPMF_ID", ObjBal.Opmf);
        cmd.Parameters.AddWithValue("@PA03_UNIV_LVL_ID", ObjBal.Level);
        cmd.Parameters.AddWithValue("@PA03_2D_FROM_DATE", common.GetDateTime(ObjBal.FromDate));
        cmd.Parameters.AddWithValue("@PA03_2D_TO_DATE", common.GetDateTime(ObjBal.ToDate));
        databaseFunctions.ExecuteCommand(cmd);
    }


    public void PA03_2D_DeleteData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_2D_INF_DELETE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_2D_ID", ObjBal.KeyId);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public SqlCommand PA03_2D_GetData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_2D_INF_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        return cmd;
    }
    #endregion

    #region PA03_2E
    public void PA03_2E_SaveData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_2E_INF_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@PA03_2E_DUT", ObjBal.Duty);
        databaseFunctions.ExecuteCommand(cmd);
    }


    public void PA03_2E_DeleteData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_2E_INF_DELETE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_2E_ID", ObjBal.KeyId);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public SqlCommand PA03_2E_GetData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_2E_INF_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        return cmd;
    }
    #endregion


    #region PA03_2F
    public string PA03_2F_SaveData(APPBAL ObjBal)
    {
        try
        {

            cmd = new SqlCommand("PA03_2F_INF_INSERT_UPDATE");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
            cmd.Parameters.AddWithValue("@PA03_2F_1", ObjBal.Author);
            cmd.Parameters.AddWithValue("@PA03_2F_2", ObjBal.Award);
            cmd.Parameters.AddWithValue("@PA03_2F_3", ObjBal.Count);
            cmd.Parameters.AddWithValue("@PA03_2F_4", ObjBal.Task);
            cmd.Parameters.AddWithValue("@PA03_2F_5", ObjBal.Volume);
            cmd.Parameters.AddWithValue("@PA03_2F_6", ObjBal.Comment);
            cmd.Parameters.AddWithValue("@PA03_2F_7", ObjBal.Conference);
            cmd.Parameters.AddWithValue("@PA03_2F_8", ObjBal.Enrollment);
            cmd.Parameters.AddWithValue("@PA03_2F_STUDENT", ObjBal.Xml);
            databaseFunctions.ExecuteCommand(cmd);
            return Msg.GetMessage(Messages.DataMessType.Insert);

        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }

    }


    public DataSet PA03_2F_GetData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_2F_INF_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion

    #region PA03_3A
    public void PA03_3A_SaveData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_3A_INF_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@PA03_3A_AWD", ObjBal.Award);
        cmd.Parameters.AddWithValue("@PA03_3A_RMK", ObjBal.Remark);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public void PA03_3A_DeleteData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_3A_INF_DELETE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_3A_ID", ObjBal.KeyId);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public SqlCommand PA03_3A_GetData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_3A_INF_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        return cmd;
    }
    #endregion

    #region PA03_3B
    public void PA03_3B_SaveData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_3B_INF_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@PA03_3B_MEM", ObjBal.Membership);
        cmd.Parameters.AddWithValue("@PA03_3B_RMK", ObjBal.Remark);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public void PA03_3B_DeleteData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_3B_INF_DELETE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_3B_ID", ObjBal.KeyId);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public SqlCommand PA03_3B_GetData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_3B_INF_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        return cmd;
    }
    #endregion

    #region PA03_3C
    public void PA03_3C_SaveData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_3C_INF_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@PA03_3C_NAME", ObjBal.Name);
        cmd.Parameters.AddWithValue("@PA03_3C_SPD", ObjBal.Sponsor);
        cmd.Parameters.AddWithValue("@PA03_3C_FROM_DATE", common.GetDateTime(ObjBal.FromDate));
        cmd.Parameters.AddWithValue("@PA03_3C_TO_DATE", common.GetDateTime(ObjBal.ToDate));
        databaseFunctions.ExecuteCommand(cmd);
    }

    public void PA03_3C_DeleteData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_3C_INF_DELETE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_3C_ID", ObjBal.KeyId);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public SqlCommand PA03_3C_GetData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_3C_INF_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        return cmd;
    }
    #endregion

    #region PA03_3D
    public void PA03_3D_SaveData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_3D_INF_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@PA03_3D_INS", ObjBal.Institute);
        cmd.Parameters.AddWithValue("@PA03_3D_PUP", ObjBal.Purpose);
        cmd.Parameters.AddWithValue("@PA03_3D_FROM_DATE", common.GetDateTime(ObjBal.FromDate));
        cmd.Parameters.AddWithValue("@PA03_3D_TO_DATE", common.GetDateTime(ObjBal.ToDate));
        databaseFunctions.ExecuteCommand(cmd);
    }

    public void PA03_3D_DeleteData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_3D_INF_DELETE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_3D_ID", ObjBal.KeyId);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public SqlCommand PA03_3D_GetData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_3D_INF_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        return cmd;
    }
    #endregion

    #region PA03_3E
    public void PA03_3E_SaveData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_3E_INF_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@PA03_3E_NAME", ObjBal.Name);
        cmd.Parameters.AddWithValue("@PA03_3E_PLC", ObjBal.Place);
        cmd.Parameters.AddWithValue("@PA03_3E_SPD", ObjBal.Sponsor);
        cmd.Parameters.AddWithValue("@PA03_3E_FROM_DATE", common.GetDateTime(ObjBal.FromDate));
        cmd.Parameters.AddWithValue("@PA03_3E_TO_DATE", common.GetDateTime(ObjBal.ToDate));
        databaseFunctions.ExecuteCommand(cmd);
    }

    public void PA03_3E_DeleteData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_3E_INF_DELETE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_3E_ID", ObjBal.KeyId);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public SqlCommand PA03_3E_GetData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_3E_INF_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        return cmd;
    }
    #endregion

    #region PA03_4
    public void PA03_4_SaveData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_4A_INF_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@PA03_4A_OTH", ObjBal.Others);
        cmd.Parameters.AddWithValue("@PA03_4A_FROM_DATE", common.GetDateTime(ObjBal.FromDate));
        cmd.Parameters.AddWithValue("@PA03_4A_TO_DATE", common.GetDateTime(ObjBal.ToDate));
        databaseFunctions.ExecuteCommand(cmd);
    }

    public void PA03_4_DeleteData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_4A_INF_DELETE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_4A_ID", ObjBal.KeyId);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public SqlCommand PA03_4_GetData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_4A_INF_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        return cmd;
    }
    #endregion

    #region PA03_5A
    public void PA03_5A_SaveData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_5A_INF_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@PA03_5A_CLS", ObjBal.Class);
        cmd.Parameters.AddWithValue("@PA03_5A_TTL", ObjBal.Title);
        cmd.Parameters.AddWithValue("@PA03_5A_STUS", ObjBal.Name);
        cmd.Parameters.AddWithValue("@PA03_5A_SPR", ObjBal.Supervisor);
        cmd.Parameters.AddWithValue("@PA03_5A_RMK", ObjBal.Remark);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public void PA03_5A_DeleteData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_5A_INF_DELETE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_5A_ID", ObjBal.KeyId);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public SqlCommand PA03_5A_GetData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_5A_INF_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        return cmd;
    }
    #endregion


    #region PA03_5B
    public void PA03_5B_SaveData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_5B_INF_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@PA03_5B_STU_NAME", ObjBal.Name);
        cmd.Parameters.AddWithValue("@PA03_5B_REG", ObjBal.Year);
        cmd.Parameters.AddWithValue("@PA03_5B_TTL", ObjBal.Title);
        cmd.Parameters.AddWithValue("@PA03_5B_SPR", ObjBal.Supervisor);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public void PA03_5B_DeleteData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_5B_INF_DELETE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_5B_ID", ObjBal.KeyId);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public SqlCommand PA03_5B_GetData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_5B_INF_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        return cmd;
    }
    # endregion

    #region PA03_5C
    public void PA03_5C_SaveData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_5C_INF_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@PA03_5C_AUTH", ObjBal.Author);
        cmd.Parameters.AddWithValue("@PA03_5C_TTL", ObjBal.Title);
        cmd.Parameters.AddWithValue("@PA03_5C_JRL", ObjBal.Journal);
        cmd.Parameters.AddWithValue("@PA03_5C_VOL", ObjBal.Volume);
        cmd.Parameters.AddWithValue("@PA03_5C_YEAR", ObjBal.Year);
        cmd.Parameters.AddWithValue("@PA03_5C_PAGE", ObjBal.Page);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public void PA03_5C_DeleteData(APPBAL ObjBal)
    {
        SqlCommand command = new SqlCommand("PA03_5C_INF_DELETE");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@PA03_5C_ID", ObjBal.KeyId);
        databaseFunctions.ExecuteCommand(command);
    }

    public SqlCommand PA03_5C_GetData(APPBAL ObjBal)
    {
        SqlCommand command = new SqlCommand("PA03_5C_INF_SELECT");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        return command;
    }
    # endregion

    #region PA03_5D

    public void PA03_5D_SaveData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_5D_INF_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@PA03_5D_AUTH", ObjBal.Author);
        cmd.Parameters.AddWithValue("@PA03_5D_TTL", ObjBal.Title);
        cmd.Parameters.AddWithValue("@PA03_5D_CNF", ObjBal.Conference);
        cmd.Parameters.AddWithValue("@PA03_5D_PLC", ObjBal.Place);
        cmd.Parameters.AddWithValue("@PA03_5D_YEAR", ObjBal.Year);
        cmd.Parameters.AddWithValue("@PA03_5D_PAGE", ObjBal.Page);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public void PA03_5D_DeleteData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_5D_INF_DELETE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_5D_ID", ObjBal.KeyId);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public SqlCommand PA03_5D_GetData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_5D_INF_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        return cmd;
    }
    #endregion

    #region PA03_5E
    public void PA03_5E_SaveData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_5E_INF_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@PA03_5E_AUTH", ObjBal.Author);
        cmd.Parameters.AddWithValue("@PA03_5E_TTL", ObjBal.Title);
        cmd.Parameters.AddWithValue("@PA03_5E_PUB", ObjBal.Publisher);
        cmd.Parameters.AddWithValue("@PA03_5E_VOL", ObjBal.Volume);
        cmd.Parameters.AddWithValue("@PA03_5E_YEAR", ObjBal.Year);
        cmd.Parameters.AddWithValue("@PA03_5E_PAGE", ObjBal.Page);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public void PA03_5E_DeleteData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_5E_INF_DELETE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_5E_ID", ObjBal.KeyId);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public SqlCommand PA03_5E_GetData(APPBAL ObjBal)
    {
        SqlCommand command = new SqlCommand("PA03_5E_INF_SELECT");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        return command;
    }
    # endregion

    #region PA03_6A
    public void PA03_6A_SaveData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_6A_INF_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@PA03_6A_TTL", ObjBal.Title);
        cmd.Parameters.AddWithValue("@PA03_6A_FUND", ObjBal.Fund);
        cmd.Parameters.AddWithValue("@PA03_6A_FIN", ObjBal.Finance);
        cmd.Parameters.AddWithValue("@PA03_6A_YEAR", ObjBal.Year);
        cmd.Parameters.AddWithValue("@PA03_6A_PRD", ObjBal.Month);
        cmd.Parameters.AddWithValue("@PA03_6A_PI", ObjBal.Name);
        cmd.Parameters.AddWithValue("@PA03_PA_STATUS_ID", ObjBal.Status);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public void PA03_6A_DeleteData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_6A_INF_DELETE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_6A_ID", ObjBal.KeyId);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public SqlCommand PA03_6A_GetData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_6A_INF_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        return cmd;
    }
    # endregion

    #region PA03_6B
    public void PA03_6B_SaveData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_6B_INF_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@PA03_6B_TTL", ObjBal.Title);
        cmd.Parameters.AddWithValue("@PA03_6B_DET", ObjBal.Detail);
        cmd.Parameters.AddWithValue("@PA03_6B_MEM", ObjBal.Membership);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public void PA03_6B_DeleteData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_6B_INF_DELETE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_6B_ID", ObjBal.KeyId);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public SqlCommand PA03_6B_GetData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_6B_INF_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        return cmd;
    }
    # endregion

    #region PA03_6C
    public void PA03_6C_SaveData(APPBAL ObjBal)
    {
        SqlCommand command = new SqlCommand("PA03_6C_INF_INSERT");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        command.Parameters.AddWithValue("@PA03_6C_TTL", ObjBal.Title);
        command.Parameters.AddWithValue("@PA03_6C_DATE", common.GetDateTime(ObjBal.FromDate));
        command.Parameters.AddWithValue("@PA03_6C_PLC", ObjBal.Place);
        command.Parameters.AddWithValue("@PA03_6C_PRG", ObjBal.Program);
        command.Parameters.AddWithValue("@PA03_6C_OTH", ObjBal.Others);
        databaseFunctions.ExecuteCommand(command);
    }

    public void PA03_6C_DeleteData(APPBAL ObjBal)
    {
        SqlCommand command = new SqlCommand("PA03_6C_INF_DELETE");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@PA03_6C_ID", ObjBal.KeyId);
        databaseFunctions.ExecuteCommand(command);
    }

    public SqlCommand PA03_6C_GetData(APPBAL ObjBal)
    {
        SqlCommand command = new SqlCommand("PA03_6C_INF_SELECT");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        return command;
    }
    # endregion

    #region PA03_6D
    public void PA03_6D_SaveData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_6D_INF_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@PA03_6D_TSK", ObjBal.Task);
        cmd.Parameters.AddWithValue("@PA03_6D_DATE", common.GetDateTime(ObjBal.FromDate));
        cmd.Parameters.AddWithValue("@PA03_6D_PLC", ObjBal.Place);
        cmd.Parameters.AddWithValue("@PA03_6D_PRG", ObjBal.Program);
        cmd.Parameters.AddWithValue("@PA03_6D_OTH", ObjBal.Others);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public void PA03_6D_DeleteData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_6D_INF_DELETE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_6D_ID", ObjBal.KeyId);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public SqlCommand PA03_6D_GetData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_6D_INF_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        return cmd;
    }
    # endregion

    #region PA03_7
    public void PA03_7_SaveData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_7A_INF_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@PA03_7A_DET", ObjBal.Detail);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public void PA03_7_DeleteData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_7A_INF_DELETE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_7A_ID", ObjBal.KeyId);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public SqlCommand PA03_7_GetData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_7A_INF_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        return cmd;
    }
    #endregion

    #region PA03_8
    public void PA03_8_SaveData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_8A_INF_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@PA03_8A_DET", ObjBal.Detail);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public void PA03_8_DeleteData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_8A_INF_DELETE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_8A_ID", ObjBal.KeyId);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public SqlCommand PA03_8_GetData(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_8A_INF_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        return cmd;
    }
    # endregion

    public string MarkFinal(APPBAL ObjBal)
    {
        try
        {
            cmd = new SqlCommand("PA03_FAC_FORWARD");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FAC_ID", ObjBal.Id);
            databaseFunctions.ExecuteCommand(cmd);
            return "Appraisal Forwarded Successfully!!!";
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }

    public DataSet GetApprovalList(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_FAC_INF_FOR_APPROVAL_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("USR_ID", ObjBal.SessionUserId);
        return databaseFunctions.GetDataSet(cmd);
    }

    public string ApproveAppraisal(APPBAL ObjBal)
    {
        try
        {
            cmd = new SqlCommand("PA03_FAC_CMT_INF_INSERT");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
            cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserId);
            cmd.Parameters.AddWithValue("@PA03_FAC_DEAN_CMT", ObjBal.Comment);
            return databaseFunctions.GetSingleData(cmd);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }


    #region Report
    public DataSet getFacultyDetails(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_FAC_DETAIL_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet getFacultyLeaveDetail(APPBAL ObjBal)
    {
        cmd = new SqlCommand("EMP_AVERAGE_LEAVE_APPRAISAL");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        return databaseFunctions.GetDataSet(cmd);
    }

    public DataSet AppraisalExamPer(APPBAL ObjBal)
    {
        cmd = new SqlCommand("APPRAISAL_PAPER_PASS_PER_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SESN", ObjBal.KeyId);
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet GetStudentFeedback(APPBAL ObjBal)
    {
        cmd = new SqlCommand("GET_STUDENT_FEEDBACK_APPRAISAL");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet getComment(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA03_FAC_CMT_INF_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        return databaseFunctions.GetDataSet(cmd);
    }

    public DataSet getId(APPBAL ObjBal)
    {
        cmd = new SqlCommand("GET_PA03_ID");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PA03_FAC_ID", ObjBal.Id);
        return databaseFunctions.GetDataSet(cmd);
    }
    public int getInsId(APPBAL ObjBal)
    {
        cmd = new SqlCommand("GET_INS_ID_BY_HOI");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.Id);
        return databaseFunctions.ExecuteScalar(cmd);
    }
    #endregion
    #region PA02_A1_MKS

    public DataSet PA02_A1_GetParameters()
    {
        cmd = new SqlCommand("PA02_E_PARAM_INF_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }



    public string PA02_A1_SaveMarks(APPBAL ObjBal)
    {
        try
        {
            cmd = new SqlCommand("PA02_A1_MKS_INF_INSERT");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DATA", ObjBal.Xml);
            cmd.Parameters.AddWithValue("@ENROLLMENT_NO", ObjBal.Enrollment);
            cmd.Parameters.AddWithValue("@Year", ObjBal.Year);
            cmd.Parameters.AddWithValue("@SEM_ID", ObjBal.Sem);
            return databaseFunctions.GetSingleData(cmd);

        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }
    #endregion

    #region PA02_B1_MKS

    public string Login(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA02_B1_LOGIN");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ENROLLMENT_NO", ObjBal.Enrollment);
        cmd.Parameters.AddWithValue("@YEAR", ObjBal.Year);
        cmd.Parameters.AddWithValue("@SEM", ObjBal.Sem);
        return databaseFunctions.GetSingleData(cmd);
    }

    public DataSet GetParameters()
    {
        cmd = new SqlCommand("PA02_B1_PARAM_INF_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }

    public DataSet PA02_B1_GET_EMP(APPBAL ObjBal)
    {
        cmd = new SqlCommand("PA02_B1_GET_EMP");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ENROLLMENT_NO", ObjBal.Id);
        cmd.Parameters.AddWithValue("@DT_O_BIRTH", ObjBal.FromDate);
        return databaseFunctions.GetDataSet(cmd);
    }

    public string SaveMarks(APPBAL ObjBal)
    {
        try
        {
            cmd = new SqlCommand("PA02_B1_MKS_INF_INSERT_XLS");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DATA", ObjBal.Xml);
            cmd.Parameters.AddWithValue("@USR_ID", ObjBal.Usr_id);
            cmd.Parameters.AddWithValue("@BS_MAPP_CODE", ObjBal.PaperCode);
            cmd.Parameters.AddWithValue("@ENROLLMENT_NO", ObjBal.Enrollment);
            cmd.Parameters.AddWithValue("@TT_PAP_ID", ObjBal.PaperName);
            cmd.Parameters.AddWithValue("@SEM_ID", ObjBal.Sem);
            databaseFunctions.ExecuteCommand(cmd);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }
    #endregion


    #region PA02_B1_RPT

    public DataSet getStuFeedbackRpt(APPBAL ObjBal)
    {
        //Dept_ID = (Dept_ID == "") ? "." : Dept_ID;
        ObjBal.Institute = (ObjBal.Institute == ".") ? "0" : ObjBal.Institute;
        ObjBal.Dept = (ObjBal.Dept == ".") ? "0" : ObjBal.Dept;
        ObjBal.Batch = (ObjBal.Batch == ".") ? "0" : ObjBal.Batch;
        ObjBal.Sem = (ObjBal.Sem == ".") ? "0" : ObjBal.Sem;
        ObjBal.Emp_id = (ObjBal.Emp_id == null) ? "0" : ObjBal.Emp_id;
        cmd = new SqlCommand("PA02_GET_STU_FEEDBACK_RPT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INS_ID", ObjBal.Institute);
        cmd.Parameters.AddWithValue("@DEPT_ID", ObjBal.Dept);
        cmd.Parameters.AddWithValue("@BATCH", ObjBal.Batch);
        cmd.Parameters.AddWithValue("@SEM", ObjBal.Sem);
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.Emp_id);
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    public DataSet getAppraisalRpt(APPBAL ObjBal)
    {
        ObjBal.Institute = (ObjBal.Institute == ".") ? "0" : ObjBal.Institute;
        ObjBal.Dept = (ObjBal.Dept == "." || ObjBal.Dept == " ") ? "0" : ObjBal.Dept;
        ObjBal.Status = (ObjBal.Status == ".") ? "-1" : ObjBal.Status;
        ObjBal.Id = (ObjBal.Id == ".") ? "0" : ObjBal.Id;
        ObjBal.Year = (ObjBal.Year == ".") ? "0" : ObjBal.Year;
        ObjBal.Sem = (ObjBal.Sem == ".") ? "-1" : ObjBal.Sem;
        ObjBal.Emp_id = (ObjBal.Emp_id == "") ? "0" : ObjBal.Emp_id;
        cmd = new SqlCommand("PA03_GET_REPORT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INS_ID", ObjBal.Institute);
        cmd.Parameters.AddWithValue("@DEPT_ID", ObjBal.Dept);
        cmd.Parameters.AddWithValue("@STS", ObjBal.Status);
        cmd.Parameters.AddWithValue("@RS", ObjBal.Id);
        cmd.Parameters.AddWithValue("@RE", ObjBal.KeyId);
        cmd.Parameters.AddWithValue("@RS_START_DATE", ObjBal.StartDate);
        cmd.Parameters.AddWithValue("@RS_END_DATE", ObjBal.EndDate);
        cmd.Parameters.AddWithValue("@RE_START_DATE", ObjBal.FromDate);
        cmd.Parameters.AddWithValue("@RE_END_DATE", ObjBal.ToDate);
        cmd.Parameters.AddWithValue("@YEAR", ObjBal.Year);
        cmd.Parameters.AddWithValue("@SEM", ObjBal.Sem);
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.Emp_id);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet Get_Fac_Feedback(APPBAL objBal)
    {
        cmd = new SqlCommand("PA02_FAC_FEEDBACK_DETAIL");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", objBal.Usr_id);
        cmd.Parameters.AddWithValue("@YEAR", objBal.Year);
        cmd.Parameters.AddWithValue("@SEM", objBal.Sem);
        return databaseFunctions.GetDataSet(cmd);
    }

}