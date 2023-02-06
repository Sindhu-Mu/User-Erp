using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// Summary description for NewUser
/// </summary>
public class NewUser
{
    DatabaseFunctions databaseFunctions;
    CommonFunctions commonFunctions;
    public NewUser()
    {
        databaseFunctions = new DatabaseFunctions();
        commonFunctions = new CommonFunctions();
    }


    public void SaveNewUser(
        string F_NAME, string M_NAME, string L_NAME, string GEN_ID, string DOB, string DOJ, string CAS_ID, string REL_ID, string NAT_ID, string MOT_TON_ID,
        string BLO_GRP_ID, string EMP_FTH_NAME, string EMP_MTH_NAME, string NEXT_KIN_ID, string NEXT_KIN_NAME, string IS_HAND_ID, string PAN_NO, string MAR_STS_ID, string INI_ID, string JOB_TYPE_ID, string SERV_TYPE_ID,
        string CAT_ID, string DES_ID, string DEPT_ID, string EMP_NEXT_SNR_ID, string ADD_DATA, string PHN_DATA,string MAIL_DATA, string ACA_DATA, string EXP_DATA, string BANK_ID, string CIT_ID, string ACC_NO)
    {
        SqlCommand command = new SqlCommand("SET_USER_NEW_INFORMATION");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@F_NAME", F_NAME);
        command.Parameters.AddWithValue("@M_NAME", commonFunctions.ValidateParameter(M_NAME));
        command.Parameters.AddWithValue("@L_NAME", commonFunctions.ValidateParameter(L_NAME));
        command.Parameters.AddWithValue("@GEN_ID", GEN_ID);
        command.Parameters.AddWithValue("@DOB", DOB);
        command.Parameters.AddWithValue("@DOJ", DOJ);
        command.Parameters.AddWithValue("@CAS_ID", commonFunctions.ValidateParameter(CAS_ID));
        command.Parameters.AddWithValue("@REL_ID", commonFunctions.ValidateParameter(REL_ID));
        command.Parameters.AddWithValue("@NAT_ID", NAT_ID);
        command.Parameters.AddWithValue("@MOT_TON_ID", commonFunctions.ValidateParameter(MOT_TON_ID));
        command.Parameters.AddWithValue("@BLO_GRP_ID", commonFunctions.ValidateParameter(BLO_GRP_ID));
        command.Parameters.AddWithValue("@EMP_FTH_NAME", EMP_FTH_NAME);
        command.Parameters.AddWithValue("@EMP_MTH_NAME", commonFunctions.ValidateParameter(EMP_MTH_NAME));
        if (commonFunctions.ValidateParameter(NEXT_KIN_ID, NEXT_KIN_NAME))
        {
            command.Parameters.AddWithValue("@NEXT_KIN_ID", NEXT_KIN_ID);
            command.Parameters.AddWithValue("@NEXT_KIN_NAME", NEXT_KIN_NAME);
        }
        command.Parameters.AddWithValue("@IS_HAND_ID", commonFunctions.ValidateParameter(IS_HAND_ID));
        command.Parameters.AddWithValue("@PAN_NO", commonFunctions.ValidateParameter(PAN_NO));
        command.Parameters.AddWithValue("@MAR_STS_ID", commonFunctions.ValidateParameter(MAR_STS_ID));
        command.Parameters.AddWithValue("@INI_ID", INI_ID);
        command.Parameters.AddWithValue("@JOB_TYPE_ID", JOB_TYPE_ID);
        command.Parameters.AddWithValue("@SERV_TYPE_ID", SERV_TYPE_ID);
        command.Parameters.AddWithValue("@CAT_ID", CAT_ID);
        command.Parameters.AddWithValue("@DES_ID", DES_ID);
        command.Parameters.AddWithValue("@DEPT_ID", DEPT_ID);
        command.Parameters.AddWithValue("@EMP_NEXT_SNR_ID", commonFunctions.ValidateParameter(EMP_NEXT_SNR_ID));

        command.Parameters.AddWithValue("@ADD_DATA", commonFunctions.ValidateParameter(ADD_DATA));
        command.Parameters.AddWithValue("@PHN_DATA", commonFunctions.ValidateParameter(PHN_DATA));
        command.Parameters.AddWithValue("@MAIL_DATA", commonFunctions.ValidateParameter(MAIL_DATA));
        command.Parameters.AddWithValue("@ACA_DATA", commonFunctions.ValidateParameter(ACA_DATA));
        command.Parameters.AddWithValue("@EXP_DATA", commonFunctions.ValidateParameter(EXP_DATA));

        if (commonFunctions.ValidateParameter(BANK_ID, CIT_ID, ACC_NO))
        {
            command.Parameters.AddWithValue("@BANK_ID", BANK_ID);
            command.Parameters.AddWithValue("@CIT_ID", CIT_ID);
            command.Parameters.AddWithValue("@ACC_NO", ACC_NO);
        }
        databaseFunctions.ExecuteCommand(command);
    }
    
}
