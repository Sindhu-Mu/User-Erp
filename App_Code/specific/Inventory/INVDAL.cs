using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Class1
/// </summary>
public class INVDAL
{
    DatabaseFunctions databaseFunctions;
    CommonFunctions commonfunction;
    SqlCommand cmd;
    public INVDAL()
    {
        //
        // TODO: Add constructor logic here
        //
        databaseFunctions = new DatabaseFunctions();
        commonfunction = new CommonFunctions();
    }



    #region STORE
   

    public void SaveNewStore(INVBAL ObjBal)
    {

        SqlCommand command = new SqlCommand("INV_STORE_MASTER_INSERT");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@STORE_NAME", ObjBal.StoreName);
        command.Parameters.AddWithValue("@STORE_DESC", ObjBal.Description);    
        command.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserId);
        databaseFunctions.ExecuteCommand(command);
    }
    public void UpdateStore(INVBAL ObjBal)
    {
        SqlCommand command = new SqlCommand("INV_STORE_MASTER_UPDATE");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@STORE_ID", ObjBal.KeyId);
        command.Parameters.AddWithValue("@STORE_NAME", ObjBal.StoreName);
        command.Parameters.AddWithValue("@STORE_DESC", ObjBal.Description);     
        command.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserId);
        databaseFunctions.ExecuteCommand(command);
    }
    #endregion
    public void SaveStoreIncharge(INVBAL ObjBal)
    {

        SqlCommand command = new SqlCommand("INV_STO_INCRG_INF_INSERT");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@STO_ID", ObjBal.ID);
        command.Parameters.AddWithValue("@EMP_ID", ObjBal.KeyId);
        command.Parameters.AddWithValue("@FROM_DT",commonfunction.GetDateTime(ObjBal.Date));
        command.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserId);
        databaseFunctions.ExecuteCommand(command);
    }
    #region category

    public void addNewCategory(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_CAT_MASTER_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@CAT_NAME", ObjBal.CatName);
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserId);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public void updateCategory(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_CAT_MASTER_UPDATE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@CAT_ID", ObjBal.KeyId);
        cmd.Parameters.AddWithValue("@CAT_NAME", ObjBal.CatName);
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserId);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region subcategory
    public void addNewSubCategory(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_SUB_CAT_MASTER_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SUB_CAT_NAME", ObjBal.SubCatName);
        cmd.Parameters.AddWithValue("@CAT_ID", ObjBal.CatId);
        cmd.Parameters.AddWithValue("@SUB_CAT_DESC", ObjBal.Description);
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserId);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public void updateSubCategory(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_SUB_CAT_MASTER_UPDATE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SUB_CAT_NAME", ObjBal.SubCatName);
        cmd.Parameters.AddWithValue("@SUB_CAT_ID", ObjBal.KeyId);
        cmd.Parameters.AddWithValue("@SUB_CAT_DESC", ObjBal.Description);
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserId);
        databaseFunctions.ExecuteCommand(cmd);
    }


    #endregion



    #region item
    public void addNewItem(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_ITEM_MASTER_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ITEM_SUB_CAT_ID", ObjBal.SubCatId);
        cmd.Parameters.AddWithValue("@STO_ID", ObjBal.ID);
        cmd.Parameters.AddWithValue("@ITEM_NAME", ObjBal.ItemName);
        cmd.Parameters.AddWithValue("@RDR_LVL", ObjBal.ReorderLevel);
        cmd.Parameters.AddWithValue("@QTY", ObjBal.Quantity);
        cmd.Parameters.AddWithValue("@UNIT_ID", ObjBal.Unit);
        cmd.Parameters.AddWithValue("@IS_RTN_APP", ObjBal.Typ);
        cmd.Parameters.AddWithValue("@ITEM_DESC", ObjBal.Description);
        cmd.Parameters.AddWithValue("@INSERT_BY", ObjBal.SessionUserId);

        databaseFunctions.ExecuteCommand(cmd);
    }

    public void UpdateItem(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_ITEM_MASTER_UPDATE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ITEM_ID", ObjBal.KeyId);
        cmd.Parameters.AddWithValue("@ITEM_SUB_CAT_ID", ObjBal.SubCatId);
        cmd.Parameters.AddWithValue("@STO_ID", ObjBal.ID);
        cmd.Parameters.AddWithValue("@ITEM_NAME", ObjBal.ItemName);
        cmd.Parameters.AddWithValue("@RDR_LVL", ObjBal.ReorderLevel);
        cmd.Parameters.AddWithValue("@QTY", ObjBal.Quantity);
        cmd.Parameters.AddWithValue("@UNIT_ID", ObjBal.Unit);
        cmd.Parameters.AddWithValue("@IS_RTN_APP", ObjBal.Typ);
        cmd.Parameters.AddWithValue("@ITEM_DESC", ObjBal.Description);
        cmd.Parameters.AddWithValue("@INSERT_BY", ObjBal.SessionUserId);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region vendor


    public void InsertVendor(INVBAL ObjBal)
    {
        ObjBal.ID = (ObjBal.ID == ".") ? "0" : ObjBal.ID;
        ObjBal.KeyId = (ObjBal.KeyId == ".") ? "0" : ObjBal.KeyId;
        ObjBal.Typ = (ObjBal.Typ == "Select") ? "0" : ObjBal.Typ;
        ObjBal.ItemName = (ObjBal.ItemName == "Select") ? "0" : ObjBal.ItemName;
        cmd = new SqlCommand("INV_VENDOR_INF_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ORG_DATA", ObjBal.TypeDescription);
        cmd.Parameters.AddWithValue("@STO_ID", ObjBal.ID);
        cmd.Parameters.AddWithValue("@ORG_NAME", ObjBal.OrgName);
        cmd.Parameters.AddWithValue("@PAN_NO", ObjBal.PanNo);
        cmd.Parameters.AddWithValue("@VAT_NO", ObjBal.VatNo);
        cmd.Parameters.AddWithValue("@TIN_NO", ObjBal.TinNo);
        cmd.Parameters.AddWithValue("@EXCISE_REG_NO", ObjBal.Excise_Reg_No);
        cmd.Parameters.AddWithValue("@SERVICE_TAX_NO", ObjBal.Service_Tax_No);
        cmd.Parameters.AddWithValue("@TURNOVER", ObjBal.TurnOver);
        cmd.Parameters.AddWithValue("@FIN_YEAR", ObjBal.FinYear);
        cmd.Parameters.AddWithValue("@BANK_ID", ObjBal.KeyId);
        cmd.Parameters.AddWithValue("@BANK_AC_NO", ObjBal.AcNo);
        cmd.Parameters.AddWithValue("@BANK_BRANCH", ObjBal.Branch);
        cmd.Parameters.AddWithValue("@BANK_AC_TYPE", ObjBal.Typ);
        cmd.Parameters.AddWithValue("@IFSC_CODE", ObjBal.IfscCode);
        cmd.Parameters.AddWithValue("@RTGS_CODE", ObjBal.RtgsCode);
        cmd.Parameters.AddWithValue("@ADD_XML", ObjBal.Address);
        cmd.Parameters.AddWithValue("@ORG_PHN_NO", ObjBal.OrgTelNo);
        cmd.Parameters.AddWithValue("@ORG_MOBILE_NO", ObjBal.OrgMobNo);
        cmd.Parameters.AddWithValue("@ORG_MAIL_VALUE", ObjBal.OrgMailId);
        cmd.Parameters.AddWithValue("@FULL_NAME", ObjBal.Name);
        cmd.Parameters.AddWithValue("@MOBILE_NO", ObjBal.MobNo);
        cmd.Parameters.AddWithValue("@MAIL_VALUE", ObjBal.EmailId);
        cmd.Parameters.AddWithValue("@DESIG_VALUE", ObjBal.Designation);
        cmd.Parameters.AddWithValue("@CAT_ID", ObjBal.ItemName);
        cmd.Parameters.AddWithValue("@VEN_ITEM_DESC", ObjBal.Description);
        cmd.Parameters.AddWithValue("@DOCUMENT_NAME", ObjBal.DocName);
        cmd.Parameters.AddWithValue("@DOCUMENT_PATH", ObjBal.Path);
        cmd.Parameters.AddWithValue("@VEN_TRAN_BY", ObjBal.SessionUserId);
        databaseFunctions.ExecuteCommand(cmd);


    }


    #endregion
    #region Requisition
   

    public void InsertPurReq(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_PUR_REQ_DETAIL_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;       
        cmd.Parameters.AddWithValue("@REQ_BY", ObjBal.SessionUserId);
        cmd.Parameters.AddWithValue("@PUR_REQ_NO", ObjBal.PurNo);
        cmd.Parameters.AddWithValue("@PUR_STORE_ID", ObjBal.ID);
        cmd.Parameters.AddWithValue("@PUR_REQ_STS", ObjBal.Status);
        cmd.Parameters.AddWithValue("@REQ_REMARK", ObjBal.Remark);     
        cmd.Parameters.AddWithValue("@ORDER_DATA", ObjBal.OrderData);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public SqlCommand GetFinancialYear()
    {

        cmd = new SqlCommand("SELECT ISNULL(MAX(CONVERT(INT,SUBSTRING(PUR_REQ_NO,12,(LEN(PUR_REQ_NO)-11)))),01)+1 FROM INV_PUR_REQ_MASTER WHERE PUR_REQ_NO LIKE '%" + CommonFunctions.getFinancialYear() + "%'");
        cmd.CommandType = CommandType.Text;
        return cmd;
    }
    public void UpadtePurReq(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_PUR_REQ_DETAIL_UPDATE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@REQ_ITEM_ID", ObjBal.ItemId);
        cmd.Parameters.AddWithValue("@REQ_ITEM_QTY", ObjBal.Quantity);
        cmd.Parameters.AddWithValue("@REQ_ITEM_RATE", ObjBal.Rate);
        cmd.Parameters.AddWithValue("@REQ_JUSTIFICATION", ObjBal.Justification);
        cmd.Parameters.AddWithValue("@REQ_SUPP_ID", ObjBal.VenId);
        cmd.Parameters.AddWithValue("@REQ_BY", ObjBal.SessionUserId);
        cmd.Parameters.AddWithValue("@PUR_REQ_NO", ObjBal.PurNo);
        cmd.Parameters.AddWithValue("@PUR_STORE_ID", ObjBal.ID);
        cmd.Parameters.AddWithValue("@PUR_REQ_STS", ObjBal.Status);
        cmd.Parameters.AddWithValue("@PUR_REQ_TRAN_REMARK", ObjBal.Remark);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public void PurReqReccomend(INVBAL ObjaBal)
    {
        cmd = new SqlCommand("INV_PUR_REQ_RECOMMEND");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@REQ_SUB_ID", ObjaBal.ID);
        cmd.Parameters.AddWithValue("@PUR_REQ_ID", ObjaBal.Identification);
        cmd.Parameters.AddWithValue("@REMARK", ObjaBal.Remark);
        cmd.Parameters.AddWithValue("@IN_BY", ObjaBal.SessionUserId);
        cmd.Parameters.AddWithValue("@FORWARD_TO", ObjaBal.ForwardTo);
        cmd.Parameters.AddWithValue("@PROC_TYPE", ObjaBal.Typ);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public void PurReqApproved(INVBAL ObjaBal)
    {
        cmd = new SqlCommand("INV_PUR_REQ_APPROVED");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@REQ_SUB_ID", ObjaBal.ID);
        cmd.Parameters.AddWithValue("@PUR_REQ_ID", ObjaBal.Identification);
        cmd.Parameters.AddWithValue("@REMARK", ObjaBal.Remark);
        cmd.Parameters.AddWithValue("@IN_BY", ObjaBal.SessionUserId);
        cmd.Parameters.AddWithValue("@FORWARD_TO", ObjaBal.ForwardTo);
        cmd.Parameters.AddWithValue("@PROC_TYPE", ObjaBal.Typ);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public void PurReqCanceled(INVBAL ObjaBal)
    {
        cmd = new SqlCommand("INV_PUR_REQ_CANCELED");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@REQ_SUB_ID", ObjaBal.ID);
        cmd.Parameters.AddWithValue("@PUR_REQ_ID", ObjaBal.Identification);
        cmd.Parameters.AddWithValue("@REMARK", ObjaBal.Remark);
        cmd.Parameters.AddWithValue("@IN_BY", ObjaBal.SessionUserId);
        cmd.Parameters.AddWithValue("@PROC_TYPE", ObjaBal.Typ);
        cmd.Parameters.AddWithValue("@STS", ObjaBal.Status);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region FAN Allocation
    public void FAN_Allocation(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_PUR_FAN_MASTER_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FAN_NO", ObjBal.ReqNo);
        cmd.Parameters.AddWithValue("@FAN_AMOUNT", ObjBal.Rate);
        cmd.Parameters.AddWithValue("@FAN_ASSIGN_BY", ObjBal.SessionUserId);
        cmd.Parameters.AddWithValue("@PUR_REQ_TRAN_REMARK", ObjBal.Remark);
        cmd.Parameters.AddWithValue("@REQ_SUB_ID", ObjBal.ID);
        cmd.Parameters.AddWithValue("@STS", ObjBal.Status);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public void PurFanCanceled(INVBAL ObjaBal)
    {
        cmd = new SqlCommand("INV_PUR_REQ_FAN_CANCEL");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PUR_REQ_ID", ObjaBal.Identification);
        cmd.Parameters.AddWithValue("@REMARK", ObjaBal.Remark);
        cmd.Parameters.AddWithValue("@IN_BY", ObjaBal.SessionUserId);
        cmd.Parameters.AddWithValue("@PROC_TYPE", ObjaBal.Typ);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region RFQ
    public SqlCommand GetRFQFinancialYear()
    {

        cmd = new SqlCommand("SELECT ISNULL(MAX(CONVERT(INT,SUBSTRING(PUR_RFQ_NO,13,(LEN(PUR_RFQ_NO)-12)))),01)+1 FROM INV_PUR_RFQ_MASTER WHERE PUR_RFQ_NO LIKE '%" + CommonFunctions.getFinancialYear() + "%'");
        cmd.CommandType = CommandType.Text;
        return cmd;
    }
    public void RFQItemUpdate(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_PUR_RFQ_ITEM_DETAIL_UPDATE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PUR_RFQ_ITEM_ID", ObjBal.ItemId);
        cmd.Parameters.AddWithValue("@PUR_RFQ_VEN_ID", ObjBal.VenId);
        cmd.Parameters.AddWithValue("@RFQ_ITEM_RATE", ObjBal.Rate);
        cmd.Parameters.AddWithValue("@RFQ_ITEM_TAX", ObjBal.Tax);
        cmd.Parameters.AddWithValue("@RFQ_ITEM_DIS", ObjBal.Discount);
        cmd.Parameters.AddWithValue("@RFQ_ITEM_AMOUNT", ObjBal.Amount);
        cmd.Parameters.AddWithValue("@RFQ_ITEM_IN_BY", ObjBal.SessionUserId);
        cmd.Parameters.AddWithValue("@RFQ_ITEM_REASON", ObjBal.Remark);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public SqlCommand getComparison(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_GET_COMPARISON");
        cmd.Parameters.AddWithValue("@PUR_RFQ_ID", ObjBal.ReqNo);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public SqlCommand getComparisonDetails(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_GET_COMPARISON_DETAIL");
        cmd.Parameters.AddWithValue("@PUR_RFQ_ID", ObjBal.ReqNo);
        cmd.Parameters.AddWithValue("@RFQ_ITEM_ID", ObjBal.ItemName);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    #endregion

    #region Purchase Order
    public SqlCommand GetPOFinancialYear()
    {

        cmd = new SqlCommand("SELECT ISNULL(MAX(CONVERT(INT,SUBSTRING(PO_NO,12,(LEN(PO_NO)-11)))),01)+1 FROM INV_PUR_ORDER_MASTER WHERE PO_NO LIKE '%" + CommonFunctions.getFinancialYear() + "%'");
        cmd.CommandType = CommandType.Text;
        return cmd;
    }
    public DataSet InsertPurOrder(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_PURCHASE_ORDER_NEW");
        cmd.CommandType = CommandType.StoredProcedure;

        ObjBal.ReqNo = (ObjBal.ReqNo == "") ? "0" : ObjBal.ReqNo;
        ObjBal.Status = (ObjBal.Status == "") ? "0" : ObjBal.Status;
        //ObjBal.ID = (ObjBal.ID == "") ? "0" : ObjBal.Status;
        cmd.Parameters.AddWithValue("@PO_NO", ObjBal.PurNo);
        cmd.Parameters.AddWithValue("@PO_STORE_ID", ObjBal.StoreName);
        cmd.Parameters.AddWithValue("@PO_SUPP_CODE", ObjBal.SupplierName);
        cmd.Parameters.AddWithValue("@PO_REF_NO", ObjBal.ReqNo);
        cmd.Parameters.AddWithValue("@PO_OTHER_CHARGES", ObjBal.Rate);
        cmd.Parameters.AddWithValue("@PO_DISCOUNT", ObjBal.Discount);
        cmd.Parameters.AddWithValue("@PO_AMOUNT", ObjBal.Amount);
        cmd.Parameters.AddWithValue("@PO_REMARK", ObjBal.Remark);
        cmd.Parameters.AddWithValue("@CREATED_BY", ObjBal.SessionUserId);
        cmd.Parameters.AddWithValue("@ORDER_DATA", ObjBal.OrderData);
        cmd.Parameters.AddWithValue("@PAYMENT_DATA", ObjBal.PaymentData);
        cmd.Parameters.AddWithValue("@TERM_DATA", ObjBal.TermData);
        cmd.Parameters.AddWithValue("@FAN_STATUS", ObjBal.Status);
        cmd.Parameters.AddWithValue("@FAN_ID", ObjBal.ID);
        cmd.Parameters.AddWithValue("@PO_DATE", ObjBal.Date);
        cmd.Parameters.AddWithValue("@DEPT_ID", ObjBal.Dept);
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion

    public DataTable BtnSelect(INVBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "INV_GET_STO_IND_DEPT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@USR_ID", objBal.SessionUserId);
        cmd.Parameters.AddWithValue("@STO_ID", objBal.StoreName);
        cmd.Parameters.AddWithValue("@TYP", objBal.Typ);
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }

    public string InsertGRN(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_STO_GRN_NEW");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@GRN_NO", ObjBal.ReqNo);
        cmd.Parameters.AddWithValue("@PO_ID", ObjBal.ID);
        if (ObjBal.Description.Length > 0)
            cmd.Parameters.AddWithValue("@GRN_DET", ObjBal.Description);
        cmd.Parameters.AddWithValue("@GRN_DATE", ObjBal.Date);
        cmd.Parameters.AddWithValue("@RCV_BY", ObjBal.ActionBy);
        cmd.Parameters.AddWithValue("@EXT_CGS", ObjBal.Rate);
        cmd.Parameters.AddWithValue("@INS_BY", ObjBal.SessionUserId);
        cmd.Parameters.AddWithValue("@ITEM_DATA_XML", ObjBal.OrderData);
        cmd.Parameters.AddWithValue("@CLN_NO", ObjBal.AcNo);
        if (ObjBal.Service_Tax_No.Length > 0)
            cmd.Parameters.AddWithValue("@BILL_NO", ObjBal.Service_Tax_No);
        return (databaseFunctions.GetSingleData(cmd));

    }
    public SqlCommand GetGRNFinancialYear()
    {

        cmd = new SqlCommand("SELECT ISNULL(MAX(CONVERT(INT,SUBSTRING(GRN_NO,13,(LEN(GRN_NO)-12)))),01)+1 FROM INV_STO_GRN_INF WHERE GRN_NO LIKE'%" + CommonFunctions.getFinancialYear() + "%'");
        cmd.CommandType = CommandType.Text;
        return cmd;
    }
    public string SaveIndent(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_STO_SAVE_NEW_INDENT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@IND_BY", ObjBal.SessionUserId);
        cmd.Parameters.AddWithValue("@STO_ID", ObjBal.StoreName);
        cmd.Parameters.AddWithValue("@IND_BY_TYPE_ID", ObjBal.IndId);
        cmd.Parameters.AddWithValue("@DEPT_LOC_ID", ObjBal.ID);
        cmd.Parameters.AddWithValue("@IND_REM", ObjBal.Remark);
        cmd.Parameters.AddWithValue("@ITEM_DATA_XML", ObjBal.OrderData);
        cmd.Parameters.AddWithValue("@IND_STEP_ID", ObjBal.State);
        cmd.Parameters.AddWithValue("@ACTION_TO", ObjBal.Status);
        return databaseFunctions.GetSingleData(cmd);
    }

    public void SaveIndentApproval(INVBAL ObjBal)
    {
        SqlCommand command = new SqlCommand("INV_STO_IND_APPROVE");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@IND_ID", ObjBal.IndId);
        command.Parameters.AddWithValue("@IND_DONE", ObjBal.Status);
        command.Parameters.AddWithValue("@IND_REM", ObjBal.Remark);
        command.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserId);
        command.Parameters.AddWithValue("@TYPE", ObjBal.Typ);
        if (ObjBal.OrderData.Length > 0)
            command.Parameters.AddWithValue("@ITEM_DATA_XML", ObjBal.OrderData);
        databaseFunctions.ExecuteCommand(command);

    }
    public void SaveIndentCancel(INVBAL ObjBal)
    {
        SqlCommand command = new SqlCommand("INV_STO_IND_CANCEL");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@IND_ID", ObjBal.IndId);
        command.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserId);
        command.Parameters.AddWithValue("@IND_REM", ObjBal.Remark);
        databaseFunctions.ExecuteCommand(command);

    }

    public void InsertPurTerm(INVBAL ObjBal)
    {

        cmd = new SqlCommand("INV_PUR_TERM_MASTER_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PUR_TERM", ObjBal.Name);
        cmd.Parameters.AddWithValue("@PUR_TERM_DESC", ObjBal.Description);
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserId);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public void UpdatePurTerm(INVBAL ObjBal)
    {

        cmd = new SqlCommand("INV_PUR_TERM_MASTER_UPDATE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PUR_TERM_ID", ObjBal.ID);
        cmd.Parameters.AddWithValue("@PUR_TERM", ObjBal.Name);
        cmd.Parameters.AddWithValue("@PUR_TERM_DESC", ObjBal.Description);
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserId);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public void ModifyPurTerm(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_PUR_TERM_MASTER_MODIFY");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PUR_TERM_ID", ObjBal.KeyId);
        cmd.Parameters.AddWithValue("@PUR_TERM_STATUS", ObjBal.Status);        
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserId);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public void InsertUnit(INVBAL ObjBal)
    {

        cmd = new SqlCommand("INV_ITEM_UNIT_INF_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@UNIT_NAME", ObjBal.Unit);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public void UpdateUnit(INVBAL ObjBal)
    {

        cmd = new SqlCommand("INV_ITEM_UNIT_INF_UPDATE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@UNIT_ID", ObjBal.ID);
        cmd.Parameters.AddWithValue("@UNIT_NAME", ObjBal.Unit);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public void ModifyUnit(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_ITEM_UNIT_INF_MODIFY");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@UNIT_ID", ObjBal.ID);
        cmd.Parameters.AddWithValue("@UNIT_STS", ObjBal.Status);
        databaseFunctions.ExecuteCommand(cmd);
    }

    
}
