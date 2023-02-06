using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AcaDAL
/// </summary>
public class FacBAL
{
    public FacBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region variable
    private string ID;
    private string Key_Value;
    private string Key_ID;
    private string Common_ID;
   
    private string Full_Name;
    private string Descp;
    private string Value_Type;
    private string Alias_Type;
    private string INSTITUTE_ID;
    private string EMP_ID;
    private string DEP_ID;
    private DateTime FRM_DATE;
    private DateTime TO_DATE;
    private DateTime DATE;
    private string NAME;
    private string CHANGE_STATUS;
    private string TYPE_ID;
    private string VALUE;
    private string XMLVALUE;
    private string Session_User_ID;
    private string CITY_ID;
    private string RTE_NAME;
    private string RATE_DAY;
    private string RTE_DESC;
    private string RATE_SEM;
    private string RTE_ID;
    private string BUS_ID;
    private string BUS_NO;
    private string BUS_TYPE_ID;
    private string CAPICITY;
    private string IS_CHARGE;
    private string SLOT_ID;
    private string REG_DATE_ID;
    private DateTime SRT_DATE;
    private DateTime END_DATE;
    private DateTime REG_SRT_DATE;
    private DateTime REG_END_DATE;
    private DateTime REG_FINE_DATE;
    private string FINE_AMOUNT;
    private string IN_TIME;
    private DateTime IN_DATE;
    private string REMARK;
    private string REG_ID;
    private string REG_ROUTE_ID_XML;
    private string STOPPAGE;
    private string INFO;
    private string APR_ID;
    private string STU_ADM_NO;
    private string TRAN_AMT;
    private string TRAN_REMARK;
    private string BANK_AC_ID;
    private string REG_RTE_ID;
    private string FEE_DEMAND;
    private string DISC_AMT;
    private string PER_TYPE;
    private string AMT;
    private DateTime AMT_DUE_DATE;
    private string APR_BY;
    private DateTime APR_DATE;
    private string MAPP_ID;
    private string PENDING;
    private string FAC_ROOM_CATEGORY_BED_CNT;
    private string GEN_ID;
    private string FAC_CMPLX_ID;
    private string ROOM_FLOOR;
    private string ROOM_ID;
    private DateTime OCCUPIED_DATE;
    private DateTime LEAVING_DATE;
    private string OCCUPIED_ID;
    private string CAT;
    private string SEAT;
    private string Number;
    private string COLOR;
    private string FOR;
    private string BLDGRP;
    private string PH_NO;
    private string ADDRESS;
    private string PICKUP;
    private string NOP;
    private string PURPOSE;
    private string REASON;
    private string TIME;
    private string JTIME;
    private string FORWARD_TO;
    private string STATUS;
    private string TO_TIME;
    private string REQUEST;
    private string EVENT_ID;
    private string ADM_REQ;
    private string frmdt;
    private string TODT;
    private string Sess;

    private string sts;
    #endregion


    #region Definition
    public string SessionUserID
    { get { return Session_User_ID; } set { Session_User_ID = value; } }
    public string Id
    {
        get { return ID; }
        set { ID = value; }
    }
    public string ToTime
    {
        get { return TO_TIME; }
        set { TO_TIME = value; }
    }
    public string XmlValue
    {
        get { return XMLVALUE; }
        set { XMLVALUE = value; }
    }
    public string VehCat
    {
        get { return CAT; }
        set { CAT = value; }
    }
    public string balSession
    {
        get { return Sess; }
        set { Sess = value; }
    }
    public string NoOfPer
    {
        get { return NOP; }
        set { NOP = value; }
    }
    public string Purpose
    {
        get { return PURPOSE; }
        set { PURPOSE = value; }
    }
    public string Reason
    {
        get { return REASON; }
        set { REASON = value; }
    }
    public string Time
    {
        get { return TIME; }
        set { TIME = value; }
    }
    public string JourTime
    {
        get { return JTIME; }
        set { JTIME = value; }
    }
    public string Seat
    {
        get { return SEAT; }
        set { SEAT = value; }
    }
    public string Status
    {
        get { return STATUS; }
        set { STATUS = value; }
    }
    public string No
    {
        get { return Number; }
        set { Number = value; }
    }
    public string Color
    {
        get { return COLOR; }
        set { COLOR = value; }
    }
    public string AuthFor
    {
        get { return FOR; }
        set { FOR = value; }
    }
    public string BldGrp
    {
        get{return BLDGRP;}
        set{BLDGRP = value;}
    }
    public string Forward_To
    {
        get{return FORWARD_TO;}
        set{FORWARD_TO = value;}
    }
    public string PhnNo
    {
        get { return PH_NO; }
        set { PH_NO = value; }
    }
    public string Address
    {
        get { return ADDRESS; }
        set { ADDRESS = value; }
    }
    public string PickUpLocation
    {
        get { return PICKUP; }
        set { PICKUP = value; }
    }
    public DateTime OccDt
    {
        get { return OCCUPIED_DATE; }
        set { OCCUPIED_DATE = value; }
    }
    public DateTime LeavDt
    {
        get { return LEAVING_DATE; }
        set { LEAVING_DATE = value; }
    }
    public string OccId
    {
        get
        { return OCCUPIED_ID; }
        set { OCCUPIED_ID = value; }
    }
    public string Value
    {
        get { return VALUE; }
        set { VALUE = value; }
    }
    public string FullName
    {
        get { return Full_Name; }
        set { Full_Name = value; }
    }
    public string KeyValue
    {
        get { return Key_Value; }
        set { Key_Value = value; }
    }
    public string KeyID
    {
        get { return Key_ID; }
        set { Key_ID = value; }
    }

    public string CommonId
    {
        get { return Common_ID; }
        set { Common_ID = value; }
    }

    public string Description
    {
        get { return Descp; }
        set { Descp = value; }
    }

    public string ValueType
    {
        get { return Value_Type; }
        set { Value_Type = value; }
    }

    public string AliasValue
    {
        get { return Alias_Type; }
        set { Alias_Type = value; }
    }
    public string TypeId
    { get { return TYPE_ID; } set { TYPE_ID = value; } }

    public string ChangeStatus
    {
        get { return CHANGE_STATUS; }
        set { CHANGE_STATUS = value; }
    }
    public string InsId
    {
        get { return INSTITUTE_ID; }
        set { INSTITUTE_ID = value; }
    }
    public string EmpId
    {
        get { return EMP_ID; }
        set { EMP_ID = value; }
    }
    public string DeptId
    {
        get { return DEP_ID; }
        set { DEP_ID = value; }
    }

    public DateTime FromDate
    {
        get { return FRM_DATE; }
        set { FRM_DATE = value; }
    }

    public DateTime ToDate
    {
        get { return TO_DATE; }
        set { TO_DATE = value; }
    }

    public DateTime Date
    { get { return DATE; } set { DATE = value; } }

    public string Name
    { get { return NAME; } set { NAME = value; } }

    public DateTime InDate
    {
        get { return IN_DATE; }
        set { IN_DATE = value; }
    }

    public string CityId
    {
        get { return CITY_ID; }
        set { CITY_ID = value; }
    }
    public string RegstId
    {
        get { return REG_ID; }
        set { REG_ID = value; }
    }
    public string InTime
    {
        get { return IN_TIME; }
        set { IN_TIME = value; }
    }
   
    public string RteName
    {
        get
        { return RTE_NAME;  }
        set { RTE_NAME = value; }
    }
    public string RateDay
    {
        get { return RATE_DAY; }
        set { RATE_DAY = value; }
    }
    public string RteDesc
    {
        get { return RTE_DESC;  }
        set { RTE_DESC = value; }
    }
    public string RateSem
    {
        get { return RATE_SEM; }
        set { RATE_SEM = value; }
    }
    public string RteId
    {
        get { return RTE_ID; }
        set { RTE_ID = value; }
    }
    public string BusId
    {
        get { return BUS_ID; }
        set { BUS_ID = value; }
    }
    public string BusNo
    {
        get { return BUS_NO; }
        set { BUS_NO = value; }
    }
    public string BusType
    {
        get { return BUS_TYPE_ID; }
        set { BUS_TYPE_ID = value; }
    }
    public string Capicity
    {
        get { return CAPICITY; }
        set { CAPICITY = value; }
    }
    public string IsCharge
    {
        get { return IS_CHARGE; }
        set { IS_CHARGE = value; }
    }
    public string RegId
    {
        get{ return REG_DATE_ID;}
        set{ REG_DATE_ID = value;}
    }
    public DateTime SrtDate
    {
        get { return SRT_DATE; }
        set { SRT_DATE = value; }
    }
    public DateTime EndDate
    {
        get { return END_DATE; }
        set { END_DATE = value; }
    }
    public DateTime RegSrtDate
    {
        get { return REG_SRT_DATE; }
        set { REG_SRT_DATE = value; }
    }
    public DateTime RegEndDate
    {
        get { return REG_END_DATE; }
        set { REG_END_DATE = value; }
    }
    public DateTime RegFineDate
    {
        get { return REG_FINE_DATE;}
        set { REG_FINE_DATE = value; }
    }
    public string FineAmt
    {
        get { return FINE_AMOUNT; }
        set { FINE_AMOUNT = value; }
    }
    public string SlotId
    {
        get { return SLOT_ID; }
        set { SLOT_ID = value; }
    }
    public string Remark
    {
        get { return REMARK; }
        set { REMARK = value; }
    }
    public string RegRteIdXml
    {
        get { return REG_ROUTE_ID_XML; }
        set { REG_ROUTE_ID_XML = value; }
    }
    public string Stoppage
    {
        get { return STOPPAGE; }
        set { STOPPAGE = value; }
    }
    public string Info
    {
        get { return INFO; }
        set { INFO = value; }
    }
    public string AprId
    {
        get { return APR_ID; }
        set { APR_ID = value; }
    }
    public string StuAdmNo
    {
        get { return STU_ADM_NO; }
        set { STU_ADM_NO = value; }
    }
    public string BankAccId
    {
        get { return BANK_AC_ID; }
        set { BANK_AC_ID = value; }
    }
    public string TranAmt
    {
        get { return TRAN_AMT; }
        set { TRAN_AMT = value; }
    }
    public string TranRemark
    {
        get { return TRAN_REMARK; }
        set { TRAN_REMARK = value; }
    }
    public string RegRteId
    {
        get { return REG_RTE_ID; }
        set { REG_RTE_ID = value; }
    }
    public string FeeDemand
    {
        get { return FEE_DEMAND; }
        set { FEE_DEMAND = value; }
    }
    public string DiscAmt
    {
        get { return DISC_AMT; }
        set { DISC_AMT = value; }
    }
    public string PerType
    {
        get { return PER_TYPE; }
        set { PER_TYPE = value; }
    }
    public string Amt
    {
        get { return AMT; }
        set { AMT = value; }
    }
    public DateTime AmtDueDate
    {
        get { return AMT_DUE_DATE; }
        set { AMT_DUE_DATE = value; }
    }
    public string AprBy
    {
        get { return APR_BY; }
        set { APR_BY = value; }
    }
    public DateTime AprDt
    {
        get { return APR_DATE; }
        set { APR_DATE = value; }
    }
    public string MappId
    {
        get { return MAPP_ID; }
        set { MAPP_ID = value; }
    }
    public string Count
    {
        get { return PENDING; }
        set { PENDING = value; }
    }
    public string BedCount
    {
        get { return FAC_ROOM_CATEGORY_BED_CNT; }
        set { FAC_ROOM_CATEGORY_BED_CNT = value; }
    }
    public string GenId
    {
        get { return GEN_ID; }
        set { GEN_ID = value; }
    }
    public string cmpxId
    {
        get { return FAC_CMPLX_ID; }
        set { FAC_CMPLX_ID = value; }
    }
    public string RoomFloor
    {
        get { return ROOM_FLOOR; }
        set { ROOM_FLOOR = value; }
    }
    public string RoomId
    {
        get { return ROOM_ID; }
        set { ROOM_ID = value; }
    }
    public string Request
    {
        get { return REQUEST; }
        set { REQUEST = value; }
    }
    public string EventId
    {
        get { return EVENT_ID; }
        set { EVENT_ID = value; }
    }
    public string AdmReq
    {
        get { return ADM_REQ; }
        set { ADM_REQ = value; }
    }
    public string frdt
    {
        get { return frmdt; }
        set { frmdt = value; }
    }
    public string todt
    {
        get { return TODT; }
        set { TODT = value; }
    }
    public string balsts
    {
        get
        {
            return sts;
        }
        set
        {
            sts = value;
        }


    }
    #endregion
    
}