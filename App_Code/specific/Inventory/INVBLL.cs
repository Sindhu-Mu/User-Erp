using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for PURBLL
/// </summary>
public class INVBLL
{
    INVDAL INVDAL;
    SqlCommand cmd;
    DatabaseFunctions databaseFunctions;
    Messages Msg;
    public INVBLL()
    {
        databaseFunctions = new DatabaseFunctions();
        INVDAL = new INVDAL();
        Msg = new Messages();
    }
    #region store
    public DataSet getStore(INVBAL ObjBal)
    {

        cmd = new SqlCommand("INV_STORE_MASTER_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }

    public string StoreInsertUpdate(INVBAL ObjBal)
    {
        try
        {

            if (ObjBal.KeyId == "")
            {
                INVDAL.SaveNewStore(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                INVDAL.UpdateStore(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            INVDAL = null;
        }
    }
    #endregion

    #region Riju


    public DataSet GetPurOrderDetails(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_GET_PUR_ORDER_DETAILS");
        ObjBal.PurNo = (ObjBal.PurNo == ".") ? "0" : ObjBal.PurNo;
        ObjBal.VenId = (ObjBal.VenId == ".") ? "0" : ObjBal.VenId;
        ObjBal.ItemId = (ObjBal.ItemId == ".") ? "0" : ObjBal.ItemId;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Year", ObjBal.KeyId);
        cmd.Parameters.AddWithValue("@PO_ID", ObjBal.PurNo);
        cmd.Parameters.AddWithValue("@VENDOR_ID", ObjBal.VenId);
        cmd.Parameters.AddWithValue("@ItemId", ObjBal.ItemId);
        cmd.Parameters.AddWithValue("@TO_DT", ObjBal.ToDate);
        cmd.Parameters.AddWithValue("@FROM_DT", ObjBal.Date);
        cmd.Parameters.AddWithValue("@DATE", ObjBal.Identification);
        cmd.Parameters.AddWithValue("@SORT_BY", ObjBal.ID);
        return databaseFunctions.GetDataSet(cmd);
    }


    public DataSet GetSIVDetails(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_GET_SIV_DETAILS_1");
        ObjBal.IndId = (ObjBal.IndId == ".") ? "0" : ObjBal.IndId;
        ObjBal.ItemId = (ObjBal.ItemId == ".") ? "0" : ObjBal.ItemId;
        ObjBal.ItemName = (ObjBal.ItemName == ".") ? "0" : ObjBal.ItemName;
        ObjBal.StoreName = (ObjBal.StoreName == ".") ? "0" : ObjBal.StoreName;
        ObjBal.ActionBy = (ObjBal.ActionBy == ".") ? "0" : ObjBal.ActionBy;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@KeyId", ObjBal.KeyId);
        cmd.Parameters.AddWithValue("@IndId", ObjBal.IndId);
        cmd.Parameters.AddWithValue("@ItemId", ObjBal.ItemId);
        cmd.Parameters.AddWithValue("@ItemName", ObjBal.ItemName);
        cmd.Parameters.AddWithValue("@StoreName", ObjBal.StoreName);
        cmd.Parameters.AddWithValue("@Indentor", ObjBal.ActionBy);
        cmd.Parameters.AddWithValue("@TO_DT", ObjBal.ToDate);
        cmd.Parameters.AddWithValue("@FROM_DT", ObjBal.Date);
        cmd.Parameters.AddWithValue("@DATE", ObjBal.Identification);
        return databaseFunctions.GetDataSet(cmd);
    }


    #endregion


    #region Unit
    public DataSet getUnit()
    {
        cmd = new SqlCommand("INV_ITEM_UNIT_INF_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    public string UnitInsertUpdate(INVBAL ObjBal)
    {

        try
        {
            if (ObjBal.ID == "")
            {
                INVDAL.InsertUnit(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                INVDAL.UpdateUnit(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            INVDAL = null;
        }

    }
    public string UnitModify(INVBAL ObjBal)
    {

        try
        {

            INVDAL.ModifyUnit(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Insert);

        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            INVDAL = null;
        }

    }
    #endregion
    #region Incharge
    public DataSet getStoreInCharge(INVBAL ObjBal)
    {
        ObjBal.ID = (ObjBal.ID == ".") ? "0" : ObjBal.ID;
        cmd = new SqlCommand("INV_STO_INCRG_INF_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STO_ID", ObjBal.ID);
        return databaseFunctions.GetDataSet(cmd);
    }

    public string StoreInchargeInsert(INVBAL ObjBal)
    {
        try
        {

            INVDAL.SaveStoreIncharge(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Insert);

        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            INVDAL = null;
        }
    }
    #endregion

    #region category
    public DataSet getCategory(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_CAT_MASTER_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    public string CategoryInsertUpdate(INVBAL ObjBal)
    {
        try
        {
            if (ObjBal.KeyId == "")
            {
                INVDAL.addNewCategory(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                INVDAL.updateCategory(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            INVDAL = null;
        }
    }


    #endregion

    #region subcategory
    public DataSet getSubCategory(INVBAL ObjBal)
    {
        ObjBal.CatId = (ObjBal.CatId == ".") ? "0" : ObjBal.CatId;
        cmd = new SqlCommand("INV_SUB_CAT_MASTER_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@CAT_ID", ObjBal.CatId);
        return databaseFunctions.GetDataSet(cmd);
    }

    public string SubCategoryInsertUpdate(INVBAL ObjBal)
    {
        try
        {
            if (ObjBal.KeyId == "")
            {
                INVDAL.addNewSubCategory(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                INVDAL.updateSubCategory(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            INVDAL = null;
        }
    }


    #endregion

    #region Store item
    public DataSet getStoreItem(INVBAL ObjBal)
    {
        ObjBal.ID = (ObjBal.ID == ".") ? "0" : ObjBal.ID;
        ObjBal.CatId = (ObjBal.CatId == ".") ? "0" : ObjBal.CatId;
        ObjBal.Typ = (ObjBal.Typ == ".") ? "0" : ObjBal.Typ;
        cmd = new SqlCommand("INV_ITEM_MASTER_SELECT");
        cmd.Parameters.AddWithValue("@STO_ID", ObjBal.ID);
        cmd.Parameters.AddWithValue("@CAT_ID", ObjBal.CatId);
        cmd.Parameters.AddWithValue("@SUB_CAT_ID", ObjBal.Typ);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    public string ItemInsertUpdate(INVBAL ObjBal)
    {
        try
        {
            if (ObjBal.KeyId == "")
            {
                INVDAL.addNewItem(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                INVDAL.UpdateItem(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            INVDAL = null;
        }
    }



    #endregion

    #region vendor
    public string VendorInsertUpdate(INVBAL ObjBal)
    {
        try
        {
            if (ObjBal.VenId == "")
            {
                ObjBal.TurnOver = (ObjBal.TurnOver == "") ? "0" : ObjBal.TurnOver;
                INVDAL.InsertVendor(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {

                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }

    }
    public string InsertVendorShort(INVBAL ObjBal)
    {
        try
        {
            cmd = new SqlCommand("INV_VENDOR_INSERT_SHORT");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@STO_ID", ObjBal.StoreName);
            cmd.Parameters.AddWithValue("@ORG_NAME", ObjBal.OrgName);
            cmd.Parameters.AddWithValue("@ORG_PHN_NO", ObjBal.OrgTelNo);
            cmd.Parameters.AddWithValue("@ORG_MOBILE_NO", ObjBal.OrgMobNo);
            cmd.Parameters.AddWithValue("@ORG_MAIL_VALUE", ObjBal.EmailId);
            if (ObjBal.Address != "")
            {
                cmd.Parameters.AddWithValue("@ORG_DATA", ObjBal.Address);
            }
            databaseFunctions.ExecuteCommand(cmd);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }

    #endregion
    #region Requisition
    public DataSet getPurchaseRequisition(INVBAL ObjBal)
    {

        ObjBal.KeyId = (ObjBal.KeyId == ".") ? "0" : ObjBal.KeyId;
        ObjBal.Date = (ObjBal.Date == ".") ? "1900" : ObjBal.Date;
        ObjBal.PurNo = (ObjBal.PurNo == ".") ? "0" : ObjBal.PurNo;
        ObjBal.Status = (ObjBal.Status == ".") ? "0" : ObjBal.Status;
        cmd = new SqlCommand("GET_PURCHASE_REQUSITION");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STO_ID", ObjBal.KeyId);
        cmd.Parameters.AddWithValue("@FIN_YEAR", ObjBal.Date);
        cmd.Parameters.AddWithValue("@PUR_REQ_NO", ObjBal.PurNo);
        cmd.Parameters.AddWithValue("@PUR_REQ_STS", ObjBal.Status);
        return databaseFunctions.GetDataSet(cmd);
    }
    public string PurchaseRequisitionInsertUpdate(INVBAL ObjBal)
    {
        try
        {
            if (ObjBal.KeyId == "")
            {
                INVDAL.InsertPurReq(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                INVDAL.UpadtePurReq(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            INVDAL = null;
        }

    }
    public SqlDataReader GetFinancialYear()
    {
        cmd = INVDAL.GetFinancialYear();
        cmd.CommandType = CommandType.Text;
        return databaseFunctions.GetReader(cmd);
    }
    #endregion
    #region Requisition Approval
    public DataSet getPurchaseRqsts(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_GET_PUR_REQ");
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.SessionUserId);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet getPurRqstItem(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_ITEM_PUR_REQ_ITEM_DETAIL");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.SessionUserId);
        cmd.Parameters.AddWithValue("@PUR_REQ_ID", ObjBal.ID);
        return databaseFunctions.GetDataSet(cmd);
    }
    public SqlCommand getPurRqstSupplier(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_ITEM_PUR_REQ_SUPPLIER_DETAIL");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PUR_REQ_ID", ObjBal.VenId);
        return cmd;
    }
    public string Update_Qty(INVBAL ObjBal)
    {
        try
        {
            cmd = new SqlCommand("INV_PUR_REQ_DETAIL_UPDATE_QTY");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@REQ_ITEM_QTY", ObjBal.Quantity);
            cmd.Parameters.AddWithValue("@REQ_SUB_ID", ObjBal.ID);
            databaseFunctions.ExecuteCommand(cmd);
            return Msg.GetMessage(Messages.DataMessType.Update);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }
    public string DeleteItem(INVBAL ObjBal)
    {
        try
        {
            cmd = new SqlCommand("INV_PUR_REQ_ITEM_UPDATE");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@REQ_BY", ObjBal.SessionUserId);
            cmd.Parameters.AddWithValue("@REQ_ITEM_NAME", ObjBal.ItemName);
            cmd.Parameters.AddWithValue("@REQ_SUB_ID", ObjBal.ID);
            databaseFunctions.ExecuteCommand(cmd);
            return Msg.GetMessage(Messages.DataMessType.Deleted);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }

    }
    public void PurReqReccomend(INVBAL ObjBal)
    {
        try
        {
            INVDAL.PurReqReccomend(ObjBal);
        }
        catch (Exception e)
        {
            e.Message.ToString();
        }
    }

    public void PurReqApproved(INVBAL ObjBal)
    {
        try
        {
            INVDAL.PurReqApproved(ObjBal);
        }
        catch (Exception e)
        {
            e.Message.ToString();
        }
    }
    public void PurReqCanceled(INVBAL ObjBal)
    {
        try
        {
            INVDAL.PurReqCanceled(ObjBal);
        }
        catch (Exception e)
        {
            e.Message.ToString();
        }
    }
    #endregion
    #region FAN Allocation
    public SqlCommand getFanPurReq(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_GET_FAN_PUR_REQ");
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.SessionUserId);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public SqlCommand getFanPurReqItem(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_GET_FAN_PUR_REQ_ITEM");
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.SessionUserId);
        cmd.Parameters.AddWithValue("@REQ_SUB_ID", ObjBal.ID);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public SqlCommand getFanDetail(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_GET_FAN_DETAILS");
        cmd.Parameters.AddWithValue("@REQ_SUB_ID", ObjBal.ID);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public string UpdateFanQtyRate(INVBAL ObjBal)
    {
        try
        {
            cmd = new SqlCommand("INV_FAN_DETAIL_UPDATE_QTY_RATE");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@REQ_ITEM_QTY", ObjBal.Quantity);
            cmd.Parameters.AddWithValue("@REQ_ITEM_RATE", ObjBal.Rate);
            cmd.Parameters.AddWithValue("@REQ_SUB_ID", ObjBal.ID);
            databaseFunctions.ExecuteCommand(cmd);
            return Msg.GetMessage(Messages.DataMessType.Update);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }

    public void FAN_Allocation(INVBAL ObjBal)
    {
        try
        {
            INVDAL.FAN_Allocation(ObjBal);
        }
        catch (Exception e)
        {
            e.Message.ToString();
        }
    }

    public SqlCommand FANAllotedReport(INVBAL ObjBal)
    {
        ObjBal.ID = (ObjBal.ID == ".") ? "0" : ObjBal.ID;
        ObjBal.Dept = (ObjBal.Dept == ".") ? "0" : ObjBal.Dept;
        ObjBal.ReqNo = (ObjBal.ReqNo == ".") ? "0" : ObjBal.ReqNo;
        ObjBal.ActionBy = (ObjBal.ActionBy == ".") ? "0" : ObjBal.ActionBy;
        ObjBal.Date = (ObjBal.Date == "") ? "" : ObjBal.Date;
        ObjBal.Status = (ObjBal.Status == ".") ? "0" : ObjBal.Status;

        cmd = new SqlCommand("INV_FAN_ALLOTMENT_REPORT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FAN_ID", ObjBal.ID);
        cmd.Parameters.AddWithValue("@DEPT_ID", ObjBal.Dept);
        cmd.Parameters.AddWithValue("@FAN_PUR_ID", ObjBal.ReqNo);
        cmd.Parameters.AddWithValue("@FAN_ASSIGN_BY", ObjBal.ActionBy);
        cmd.Parameters.AddWithValue("@FAN_ASSIGN_DT", ObjBal.Date);
        cmd.Parameters.AddWithValue("@FAN_STATUS", ObjBal.Status);
        return cmd;


    }
    public void PurFanCanceled(INVBAL ObjBal)
    {
        try
        {
            INVDAL.PurFanCanceled(ObjBal);

        }
        catch
        {
            Msg.GetMessage(Messages.DataMessType.Error);
        }
    }
    #endregion

    #region RFQ
    public SqlCommand RFQItemDetails(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_RFQ_ITEM_DETAIL");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@TYPE", ObjBal.Typ);
        cmd.Parameters.AddWithValue("@PUR_REQ_NO", ObjBal.PurNo);
        cmd.Parameters.AddWithValue("@STO_ID", ObjBal.StoreName);
        cmd.Parameters.AddWithValue("@ITEM_ID", ObjBal.ItemId);
        return cmd;
    }


    public SqlCommand RFQSupplierDetails(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_RFQ_SUPPLIER_DETAIL");
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }

    public string RFQMasterInsert(INVBAL ObjBal)
    {
        try
        {
            cmd = new SqlCommand("INV_PUR_RFQ_MASTER_INSERT");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PUR_RFQ_NO", ObjBal.ReqNo);
            cmd.Parameters.AddWithValue("@PUR_RFQ_REF_ID", ObjBal.PurNo);
            cmd.Parameters.AddWithValue("@PUR_RFQ_BY", ObjBal.SessionUserId);
            cmd.Parameters.AddWithValue("@PUR_RFQ_REMARK", ObjBal.Remark);

            return databaseFunctions.GetSingleData(cmd);

        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }

    public string RFQDetailInsert(INVBAL ObjBal)
    {
        try
        {
            cmd = new SqlCommand("INV_PUR_RFQ_DETAIL_INSERT");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PUR_RFQ_VENDOR_ID", ObjBal.VenId);
            cmd.Parameters.AddWithValue("@PUR_RFQ_BY", ObjBal.SessionUserId);
            databaseFunctions.ExecuteCommand(cmd);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }

    public string RFQItemDetailInsert(INVBAL ObjBal)
    {
        try
        {
            cmd = new SqlCommand("INV_PUR_RFQ_ITEM_DETAIL_INSERT");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RFQ_ITEM_ID", ObjBal.ItemId);
            cmd.Parameters.AddWithValue("@RFQ_ITEM_QTY", ObjBal.Quantity);
            databaseFunctions.ExecuteCommand(cmd);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }


    public SqlCommand RFQPrintSupplierDetails(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_PRINT_RFQ_VENDOR_DETAILS");
        cmd.Parameters.AddWithValue("@PUR_RFQ_ID", ObjBal.ID);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }

    public SqlCommand RFQPrintItemDetails(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_PRINT_RFQ_ITEM_DETAILS");
        cmd.Parameters.AddWithValue("@PUR_RFQ_ID", ObjBal.ID);
        //cmd.Parameters.AddWithValue("@PUR_RFQ_VEN_ID", ObjBal.VenId);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public SqlDataReader GetRFQFinancialYear()
    {
        cmd = INVDAL.GetRFQFinancialYear();
        cmd.CommandType = CommandType.Text;
        return databaseFunctions.GetReader(cmd);
    }
    #endregion
    #region RFQ Quotation
    public SqlCommand getQuotationItem(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_QUOTATION_ITEM_DETAILS");
        cmd.Parameters.AddWithValue("@TYP", ObjBal.Typ);
        cmd.Parameters.AddWithValue("@PUR_RFQ_ID", ObjBal.ReqNo);
        cmd.Parameters.AddWithValue("@RFQ_VENDOR_ID", ObjBal.VenId);
        cmd.Parameters.AddWithValue("@ITEM_ID", ObjBal.ItemId);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public string RFQItemUpdate(INVBAL ObjBal)
    {
        try
        {

            int rate = Convert.ToInt32(ObjBal.Rate);
            int qty = Convert.ToInt32(ObjBal.Quantity);
            int dis = Convert.ToInt32(ObjBal.Discount);
            int tax = Convert.ToInt32(ObjBal.Tax);
            int amt, disAmt, taxAmt;
            disAmt = (dis * rate) / 100;
            taxAmt = ((rate - disAmt) * tax) / 100;
            amt = ((rate - disAmt + taxAmt) * qty);
            ObjBal.Amount = amt.ToString();
            INVDAL.RFQItemUpdate(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }

    }

    public SqlCommand getComparison(INVBAL ObjBal)
    {

        if (ObjBal.Typ == "1")
        {
            cmd = INVDAL.getComparison(ObjBal);
        }
        else if (ObjBal.Typ == "2")
        {
            cmd = INVDAL.getComparisonDetails(ObjBal);
        }
        return cmd;
    }
    #endregion

    #region Purchase Order
    public SqlCommand GetPurDeptDate(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_GET_PUR_REQ_DEPT_DATE");
        cmd.Parameters.AddWithValue("@PUR_REQ_ID", ObjBal.PurNo);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }

    public SqlCommand GetFanAmtDate(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_GET_PUR_FAN_AMT_DATE");
        cmd.Parameters.AddWithValue("@FAN_ID", ObjBal.ID);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }

    public DataSet PrintPurOrder(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_PUR_ORDER_PRINT");
        cmd.Parameters.AddWithValue("@PO_ID", ObjBal.ID);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }

    public DataSet ModifyPurOrder(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_PO_MODIFY");
        cmd.Parameters.AddWithValue("@PO_ID", ObjBal.ID);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet PurOrderInsert(INVBAL ObjBal)
    {

        return INVDAL.InsertPurOrder(ObjBal);
    }
    public DataSet UpdatePurOrder(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_PO_UPDATE");
        cmd.Parameters.AddWithValue("@PO_ID", ObjBal.PurNo);
        cmd.Parameters.AddWithValue("@PO_SUPP_CODE", ObjBal.VenId);
        cmd.Parameters.AddWithValue("@PO_REF_NO", ObjBal.ReqNo);
        cmd.Parameters.AddWithValue("@PO_OTHER_CHARGES", ObjBal.Tax);
        cmd.Parameters.AddWithValue("@PO_DISCOUNT", ObjBal.Discount);
        cmd.Parameters.AddWithValue("@PO_AMOUNT", ObjBal.Amount);
        cmd.Parameters.AddWithValue("@PO_REMARK", ObjBal.Remark);
        cmd.Parameters.AddWithValue("@CREATED_BY", ObjBal.SessionUserId);
        cmd.Parameters.AddWithValue("@ORDER_DATA", ObjBal.OrderData);
        cmd.Parameters.AddWithValue("@PAYMENT_DATA", ObjBal.PaymentData);
        cmd.Parameters.AddWithValue("@TERM_DATA", ObjBal.TermData);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }

    public DataSet DeletePurOrderDetail(INVBAL ObjBAl)
    {
        cmd = new SqlCommand("INV_PO_DETAILS_DELETE");
        cmd.Parameters.AddWithValue("@PO_ID", ObjBAl.PurNo);
        cmd.Parameters.AddWithValue("@PO_DET_ID",ObjBAl.TypeId);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }

    public DataSet GetPurOrder(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_GET_PUR_ORDER");
        ObjBal.PurNo = (ObjBal.PurNo == ".") ? "0" : ObjBal.PurNo;
        ObjBal.ID = (ObjBal.ID == ".") ? "0" : ObjBal.ID;
        ObjBal.ReqNo = (ObjBal.ReqNo == ".") ? "0" : ObjBal.ReqNo;
        ObjBal.VenId = (ObjBal.VenId == ".") ? "0" : ObjBal.VenId;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Year", ObjBal.KeyId);
        cmd.Parameters.AddWithValue("@PO_ID", ObjBal.PurNo);
        cmd.Parameters.AddWithValue("@FAN_ID", ObjBal.ID);
        cmd.Parameters.AddWithValue("@PUR_REQ_ID", ObjBal.ReqNo);
        cmd.Parameters.AddWithValue("@VENDOR_ID", ObjBal.VenId);
        cmd.Parameters.AddWithValue("@TO_DT", ObjBal.ToDate);
        cmd.Parameters.AddWithValue("@FROM_DT", ObjBal.Date);
        cmd.Parameters.AddWithValue("@DATE", ObjBal.Identification);
        return databaseFunctions.GetDataSet(cmd);

    }

    #endregion




    #region Purchase Term
    public DataSet GetPurTerm(INVBAL ObjBal)
    {

        cmd = new SqlCommand("INV_GET_PUR_TERM");
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    public string PurTermModify(INVBAL ObjBal)
    {
        try
        {
            ObjBal.Status = (ObjBal.Status == "Deactivate") ? "0" : "1";
            INVDAL.ModifyPurTerm(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Status);

        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }
    public string PurTermInsertUpdate(INVBAL ObjBal)
    {

        try
        {
            if (ObjBal.ID == "")
            {
                INVDAL.InsertPurTerm(ObjBal);

                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                INVDAL.UpdatePurTerm(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            INVDAL = null;
        }

    }
    public SqlDataReader GetPOFinancialYear()
    {

        cmd = INVDAL.GetPOFinancialYear();
        cmd.CommandType = CommandType.Text;
        return databaseFunctions.GetReader(cmd);
    }


    # endregion


    #region GRN
    public DataSet GetGRNDetails(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_GET_PO_DETAILS");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PO_ID", ObjBal.ID);
        return databaseFunctions.GetDataSet(cmd);
    }

    public string InsertGRN(INVBAL ObjBal)
    {
        try
        {

            return INVDAL.InsertGRN(ObjBal);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
            //return INVDAL.InsertGRN(ObjBal);
        }
    }

    public SqlDataReader GetGRNFinancialYear()
    {

        cmd = INVDAL.GetGRNFinancialYear();
        cmd.CommandType = CommandType.Text;
        return databaseFunctions.GetReader(cmd);
    }
    public DataSet GetItemBoundGrnSummary(string ITEM_ID)
    {
        cmd = new SqlCommand("STO_GET_ITEM_BOUND_GRN_SUMMARY");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("ITEM_ID", ITEM_ID);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet GetItemBoundGrnDetail(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_STO_GET_ITEM_BOUND_GRN_DETAILS");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@GRN_ID", ObjBal.ID);
        // command.Parameters.AddWithValue("@ITEM_ID", ObjBal.ItemId);
        return databaseFunctions.GetDataSet(cmd);
    }
    #region mudit

    public DataSet GetGRNDetail(INVBAL objBal)
    {
        cmd = new SqlCommand("INV_GET_GRN_Dteail");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@GRN_NO", objBal.GrnNO);
        return databaseFunctions.GetDataSet(cmd);
    }

    public DataSet Insert_Return_data(INVBAL objBal)
    {
        cmd = new SqlCommand("INV_Insert_Return_Item");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@GRN_NO", objBal.GrnNO);
        cmd.Parameters.AddWithValue("@ITEM_NAME", objBal.ItemName);
        cmd.Parameters.AddWithValue("@QTY", objBal.Quantity);
        cmd.Parameters.AddWithValue("@BALANCE_QTY", objBal.BalQTY);
        cmd.Parameters.AddWithValue("@Rate", objBal.Rate);
        cmd.Parameters.AddWithValue("@TAX", objBal.Tax);
        cmd.Parameters.AddWithValue("@DISCOUNT", objBal.Discount);
        cmd.Parameters.AddWithValue("@ItemToBeRetrnd", objBal.RtnItem);
        cmd.Parameters.AddWithValue("@ITEM_ID", objBal.ItemId);
        cmd.Parameters.AddWithValue("@GRN_ID", objBal.GRNID);

        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #endregion

    #region Indent
    public SqlCommand GetDepartmentLocation(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_STO_GET_DEPT_LOC_ID");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("IND_BY_TYPE_ID", ObjBal.ID);
        cmd.Parameters.AddWithValue("IND_BY", ObjBal.SessionUserId);
        return cmd;
    }

    public SqlCommand GetStore(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_STO_GET_STORE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@TYPE", ObjBal.Typ);
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.SessionUserId);
        return cmd;
    }
    public string NewIndent(INVBAL ObjBal)
    {
        try
        {
            return INVDAL.SaveIndent(ObjBal);
           
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }
    public DataSet GetIndentApprovalList(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_STO_GET_IND_APPROVAL_LIST");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.SessionUserId);
        return databaseFunctions.GetDataSet(cmd);
    }

    public DataSet GetIndentDetails(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_STO_GET_IND_DETAILS");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.SessionUserId);
        cmd.Parameters.AddWithValue("@IND_ID", ObjBal.IndId);
        cmd.Parameters.AddWithValue("@TYPE", ObjBal.Typ);
        return databaseFunctions.GetDataSet(cmd);
    }

    public DataSet GetPreviousDetails(INVBAL ObjBal)
    {
        SqlCommand cmd = new SqlCommand("INV_STO_GET_IND_PREV_DETAILS");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ITEM_ID", ObjBal.ItemId);
        cmd.Parameters.AddWithValue("@IND_ID", ObjBal.IndId);

        return databaseFunctions.GetDataSet(cmd);
    }

    public string IndentApprove(INVBAL ObjBal)
    {
        try
        {

            INVDAL.SaveIndentApproval(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }

    public string IndentCancel(INVBAL ObjBal)
    {
        try
        {
            INVDAL.SaveIndentCancel(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Reject);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }

    public SqlCommand GetIndentProgress(INVBAL ObjBal)
    {
        ObjBal.Status = (ObjBal.Status == ".") ? "0" : ObjBal.Status;
        cmd = new SqlCommand("INV_STO_GET_IND_PROGRESS");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@IND_BY", ObjBal.SessionUserId);
        cmd.Parameters.AddWithValue("@STATUS", ObjBal.Status);
        return cmd;
    }

    public SqlCommand GetUnfinishedIndent(INVBAL ObjBal)
    {
        ObjBal.KeyId = (ObjBal.KeyId == "") ? "0" : ObjBal.KeyId;
        cmd = new SqlCommand("INV_STO_GET_UNFINISHED_INDENT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.SessionUserId);
        cmd.Parameters.AddWithValue("@INDENT_NO", ObjBal.IndId);
        cmd.Parameters.AddWithValue("@INDENTOR", ObjBal.KeyId);
        return cmd;
    }

    public DataSet GetUnfinishedIndentDetails(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_STO_GET_UNFINISHED_INDENT_DETAILS");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@IND_ID", ObjBal.IndId);
        return databaseFunctions.GetDataSet(cmd);
    }

    public DataSet SaveNewStoreIssueVoucher(INVBAL ObjBal)
    {

        cmd = new SqlCommand("INV_STO_SAVE_NEW_SIV");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@IND_ID", ObjBal.IndId);
        cmd.Parameters.AddWithValue("@INS_BY", ObjBal.SessionUserId);
        cmd.Parameters.AddWithValue("@ITEM_DATA_XML", ObjBal.OrderData);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet GetIndentReport(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_STO_IND_REPORT");
        cmd.CommandType = CommandType.StoredProcedure;
        ObjBal.Dept = (ObjBal.Dept == ".") ? "0" : ObjBal.Dept;
        ObjBal.IndId = (ObjBal.IndId == ".") ? "0" : ObjBal.IndId;
        ObjBal.ItemId = (ObjBal.ItemId == ".") ? "0" : ObjBal.ItemId;
        ObjBal.Typ = (ObjBal.Typ == ".") ? "0" : ObjBal.Typ;
        ObjBal.StoreName = (ObjBal.StoreName == ".") ? "0" : ObjBal.StoreName;
        ObjBal.Date = (ObjBal.Date == null) ? "" : ObjBal.Date;
        ObjBal.ToDate = (ObjBal.ToDate == null) ? "" : ObjBal.ToDate;
        ObjBal.Remark = (ObjBal.Remark == ".") ? "0" : ObjBal.Remark;
        cmd.Parameters.AddWithValue("@DEPT_ID", ObjBal.Dept);
        cmd.Parameters.AddWithValue("@IND_ID", ObjBal.IndId);
        cmd.Parameters.AddWithValue("@STO_ID", ObjBal.StoreName);
        cmd.Parameters.AddWithValue("@ITEM_ID", ObjBal.ItemId);
        cmd.Parameters.AddWithValue("@TYP", ObjBal.Typ);
        cmd.Parameters.AddWithValue("@FROM_DT", ObjBal.Date);
        cmd.Parameters.AddWithValue("@TO_DT", ObjBal.ToDate);
        cmd.Parameters.AddWithValue("@SORT", ObjBal.Remark);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet GetIndentItemReport(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_STO_IND_ITEM_REPORT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@IND_ID", ObjBal.IndId);
        return databaseFunctions.GetDataSet(cmd);
    }


    public DataSet GetIndentPrevReport(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_STO_IND_PREV_REPORT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DEPT_ID", ObjBal.Dept);
        cmd.Parameters.AddWithValue("@ITEM_ID", ObjBal.ItemId);
        return databaseFunctions.GetDataSet(cmd);
    }

    public DataSet GetSIVReport(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_STO_SIV_REPORT");
        cmd.CommandType = CommandType.StoredProcedure;
        ObjBal.StoreName = (ObjBal.StoreName == ".") ? "0" : ObjBal.StoreName;
        ObjBal.Typ = (ObjBal.Typ == ".") ? "0" : ObjBal.Typ;
        ObjBal.ID = (ObjBal.ID == ".") ? "0" : ObjBal.ID;
        ObjBal.Dept = (ObjBal.Dept == ".") ? "0" : ObjBal.Dept;
        ObjBal.IndId = (ObjBal.IndId == ".") ? "0" : ObjBal.IndId;
        ObjBal.Date = (ObjBal.Date == null) ? "" : ObjBal.Date;
        ObjBal.ToDate = (ObjBal.ToDate == null) ? "" : ObjBal.ToDate;
        cmd.Parameters.AddWithValue("@STO_ID", ObjBal.StoreName);
        cmd.Parameters.AddWithValue("@TYP", ObjBal.Typ);
        cmd.Parameters.AddWithValue("@INS_ID", ObjBal.ID);
        cmd.Parameters.AddWithValue("@DEPT_ID", ObjBal.Dept);
        cmd.Parameters.AddWithValue("@IND_ID", ObjBal.IndId);
        cmd.Parameters.AddWithValue("@FROM_DT", ObjBal.Date);
        cmd.Parameters.AddWithValue("@TO_DT", ObjBal.ToDate);
        return databaseFunctions.GetDataSet(cmd);
    }


    public DataSet GetStockReport(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_STOCK_REPORT");
        cmd.Parameters.AddWithValue("@TYP", ObjBal.Typ);
        cmd.Parameters.AddWithValue("@STO_ID", ObjBal.StoreName);
        cmd.Parameters.AddWithValue("@CAT_ID", ObjBal.CatId);
        cmd.Parameters.AddWithValue("@SUB_CAT_ID", ObjBal.SubCatId);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }

    public DataSet GetStockGRNSIVReport(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_STO_GRN_SIV_REPORT");
        cmd.Parameters.AddWithValue("@ITEM_ID", ObjBal.ItemId);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }

    public DataSet GetStockGRNReport(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_STO_GRN_PRNT");
        cmd.Parameters.AddWithValue("@TYP", ObjBal.Typ);
        cmd.Parameters.AddWithValue("@ID", ObjBal.ID);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion

    public DataSet GetPurCount(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_GET_PUR_COUNT");
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet GetItemReport(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_STO_ITEM_REPORT");
        cmd.CommandType = CommandType.StoredProcedure;
        ObjBal.StoreName = (ObjBal.StoreName == ".") ? "0" : ObjBal.StoreName;
        ObjBal.CatId = (ObjBal.CatId == ".") ? "0" : ObjBal.CatId;
        ObjBal.SubCatId = (ObjBal.SubCatId == ".") ? "0" : ObjBal.SubCatId;
        ObjBal.ItemName = (ObjBal.ItemName == "") ? "" : ObjBal.ItemName;
        ObjBal.ItemId = (ObjBal.ItemId == "") ? "" : ObjBal.ItemId;
        cmd.Parameters.AddWithValue("@TYP", ObjBal.Typ);
        cmd.Parameters.AddWithValue("@STO_ID", ObjBal.StoreName);
        cmd.Parameters.AddWithValue("@CAT_ID", ObjBal.CatId);
        cmd.Parameters.AddWithValue("@SUB_CAT_ID", ObjBal.SubCatId);
        cmd.Parameters.AddWithValue("@ITEM_NAME", ObjBal.ItemName);
        cmd.Parameters.AddWithValue("@ITEM", ObjBal.ItemId);
        return databaseFunctions.GetDataSet(cmd);
    }

    public DataSet GetStoCount(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_GET_STO_COUNT");
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }

    public string GetIndId(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_GET_IND_ID");
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetSingleData(cmd);

    }
    public DataSet GetSIVDetail(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_GET_DIRECT_SIV_DETAIL");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@IND_ID", ObjBal.IndId);
        return databaseFunctions.GetDataSet(cmd);
    }
    public string DeleteSupp(INVBAL ObjBal)
    {
        try
        {
            cmd = new SqlCommand("INV_DELETE_SUPP");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@REQ_SUB_ID", ObjBal.KeyId);
            databaseFunctions.ExecuteCommand(cmd);
            return Msg.GetMessage(Messages.DataMessType.Deleted);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }

    }
    public string[] BtnSelect(INVBAL ObjBal)
    {
        string[] data = new string[2];
        DataTable dt = INVDAL.BtnSelect(ObjBal);
        string HOI = dt.Rows[0][0].ToString();
        string HOD = dt.Rows[0][1].ToString();
        string INC = dt.Rows[0][2].ToString();
        string INS = dt.Rows[0][3].ToString();
        string DEPT = dt.Rows[0][4].ToString();
        if (ObjBal.Typ == "1")
        {
            data[0] = "2";
            data[1] = "2";
            if (DEPT == "37" || DEPT == "39" || DEPT == "103" || DEPT == "25" || DEPT == "3" || DEPT == "104")
            {
                data[0] = "3";
                data[1] = "2";
            }
            if (ObjBal.SessionUserId == HOD)
            {
               
                data[0] = "3";
                data[1] = "3";
                
            }
           
            if ((ObjBal.SessionUserId == HOI))
            {
                data[0] = "7";
                data[1] = "10";
            }

            if ((ObjBal.SessionUserId != HOD) && (HOD == HOI))
            {
                data[0] = "3";
                data[1] = "3";
            }
            //if ((INS == "10") || (INS == "1"))
            //{
            //    data[0] = "3";
            //    data[1] = "2";
            //}

            if ((ObjBal.SessionUserId == HOD) && ((INS == "10") || (INS == "1")))
            {
                data[0] = "7";
                data[1] = "10";
            }
        }
        else if (ObjBal.Typ == "2")
        {
            data[0] = "3";
            data[1] = "3";
            if (HOD == HOI)
            {
                data[0] = "7";
                data[1] = "10";
            }

        }
        return data;
    }

    #region item return
    public DataSet GetItemRtnDetail(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_GET_STO_ITEM_RTN");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ITEM_ID", ObjBal.ItemId);
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region Issue Tshirt
    public string getStuDetail(INVBAL ObjBal)
    {
        cmd = new SqlCommand("GET_STU_DETAIL");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ENROLLMENT", ObjBal.ID);
        return databaseFunctions.GetSingleData(cmd);
    }
    public string IssueTshirt(INVBAL ObjBal)
    {
        try
        {
            cmd = new SqlCommand("INV_ISSUE_TSHIRT_INSERT");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@STU_MAIN_ID", ObjBal.ID);
            cmd.Parameters.AddWithValue("@ITEM_ID", ObjBal.ItemId);
            cmd.Parameters.AddWithValue("@ISSUE_BY", ObjBal.SessionUserId);
            return databaseFunctions.GetSingleData(cmd);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }

    public string getEnrollment(INVBAL ObjBal)
    {
        cmd = new SqlCommand("GET_STU_ENROLLMENT_BY_FORM_NO");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FORM_NO", ObjBal.KeyId);
        return databaseFunctions.GetSingleData(cmd);
    }

    public DataSet getIssuedDetail(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_ISSUE_TSHIRT_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STU_MAIN_ID", ObjBal.KeyId);
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    public DataSet GetGatePass(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_GET_GATE_PASS_DETAIL");
        ObjBal.PurNo = (ObjBal.PurNo == ".") ? "0" : ObjBal.PurNo;
        ObjBal.ID = (ObjBal.ID == ".") ? "0" : ObjBal.ID;
        ObjBal.ReqNo = (ObjBal.ReqNo == ".") ? "0" : ObjBal.ReqNo;
        ObjBal.VenId = (ObjBal.VenId == ".") ? "0" : ObjBal.VenId;
        ObjBal.Name = (ObjBal.Name == ".") ? "" : ObjBal.Name;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Year", ObjBal.KeyId);
        cmd.Parameters.AddWithValue("@PASS_ID", ObjBal.ID);
        cmd.Parameters.AddWithValue("@CARRY_NAME", ObjBal.Name);
        cmd.Parameters.AddWithValue("@PASS_TYPE", ObjBal.Typ);
        cmd.Parameters.AddWithValue("@VENDOR_ID", ObjBal.VenId);
        cmd.Parameters.AddWithValue("@TO_DT", ObjBal.ToDate);
        cmd.Parameters.AddWithValue("@FROM_DT", ObjBal.Date);
        cmd.Parameters.AddWithValue("@DATE", ObjBal.Identification);
        return databaseFunctions.GetDataSet(cmd);

    }

 public DataSet GatePass(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_GATE_PASS_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PASS_TYPE", ObjBal.TypeId);
        cmd.Parameters.AddWithValue("@EMP_TYPE", ObjBal.ActionBy);
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.KeyId);
        cmd.Parameters.AddWithValue("@NAME", ObjBal.Name);
        cmd.Parameters.AddWithValue("@RECP_TYP", ObjBal.Typ);        
        cmd.Parameters.AddWithValue("@RECIPENT_ID", ObjBal.VenId);
        cmd.Parameters.AddWithValue("@RECP_NAME", ObjBal.OrgName);  
        cmd.Parameters.AddWithValue("@OTHR_DESC", ObjBal.Description);
        cmd.Parameters.AddWithValue("@XML", ObjBal.ItemName);
        cmd.Parameters.AddWithValue("@RTN_DATE", ObjBal.ToDate);
        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserId);
        
        return databaseFunctions.GetDataSet(cmd);
    }
    

    public DataSet PrintGatePass(INVBAL ObjBal)
    {
        cmd = new SqlCommand("GET_GATE_PASS");
        cmd.Parameters.AddWithValue("@GATEPASS_ID", ObjBal.ID);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet GetRtnGatePass(INVBAL ObjBal)
    {
        cmd = new SqlCommand("INV_GET_GATE_PASS_RTN_DTL");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PASS_ID", ObjBal.ID);
        return databaseFunctions.GetDataSet(cmd);
    }
    public string InsertRtnGatePass(INVBAL ObjBal)
    {
        SqlCommand command = new SqlCommand("INV_RTN_GATE_PASS_INSERT");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@RTN_NO", ObjBal.ReqNo);
        command.Parameters.AddWithValue("@PASS_ID", ObjBal.ID);
        if (ObjBal.Description.Length > 0)
            command.Parameters.AddWithValue("@RTN_DET", ObjBal.Description);
        command.Parameters.AddWithValue("@RTN_DATE", ObjBal.Date);
        command.Parameters.AddWithValue("@RCV_BY", ObjBal.ActionBy);
        command.Parameters.AddWithValue("@INS_BY", ObjBal.SessionUserId);
        command.Parameters.AddWithValue("@ITEM_DATA_XML", ObjBal.OrderData);
        command.Parameters.AddWithValue("@CLN_NO", ObjBal.AcNo);
        if (ObjBal.Service_Tax_No.Length > 0)
            command.Parameters.AddWithValue("@BILL_NO", ObjBal.Service_Tax_No);
        return (databaseFunctions.GetSingleData(command));
    }

    public SqlDataReader GetRtnPassFinancialYear()
    {
        cmd = new SqlCommand("SELECT ISNULL(MAX(CONVERT(INT,SUBSTRING(RTN_NO,19,(LEN(RTN_NO)-18)))),01)+1 FROM INV_GATE_PASS_RCV WHERE RTN_NO LIKE  '%" + CommonFunctions.getFinancialYear() + "%'");
        cmd.CommandType = CommandType.Text;
        return databaseFunctions.GetReader(cmd);
    }
}