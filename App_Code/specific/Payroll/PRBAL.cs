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
/// Summary description for PRBAL
/// </summary>
public class PRBAL
{
    public PRBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region variables

    private string curEmpCode;
    private string headName;
    private string headShortName;
    private string headType;
    private string inCal;
    private string headId;
    private string tempId;
    private string headValue;
    private string keyId;
    private string empCode;
    private string esId;
    private string payScl;
    private string increment;
    private string edId;
    private string remark;
    private string orderNo;
    private DateTime orderDt;
    private string data;
    private string year;
    private string month;
    private string days;
    private string min;
    private string max;
    private string arngBy;
    private string incType;
    private string incValue;
    private string nod;
    private string instituteValue;
    private string deptValue;
    private string desigValue;
    private string endMonth;
    private string endYear;
    private string amt;
    private string jobtype;
    private string arrearType;
    private string curUserId;



    #endregion


    #region definition
    public string balArrearType
    {
        get { return arrearType; }
        set { arrearType = value; }
    }
    public string balJobType
    {
        get { return jobtype; }
        set { jobtype = value; }
    }
    public string balEndMonth
    {
        get { return endMonth; }
        set { endMonth = value; }
    }
    public string balEndYear
    {
        get { return endYear; }
        set { endYear = value; }

    }
    public string balAmt
    {
        get { return amt; }
        set { amt = value; }
    }
    public string balDesigValue
    {
        get { return desigValue; }
        set { desigValue = value; }
    }
    public string balDeptValue
    {
        get { return deptValue; }
        set { deptValue = value; }
    }
    public string balInstituteValue
    {
        get { return instituteValue; }
        set { instituteValue = value; }
    }
    public string balYear
    {
        get { return year; }
        set { year = value; }
    }

    public string balMonth
    {
        get { return month; }
        set { month = value; }
    }

    public string balData
    {
        get { return data; }
        set { data = value; }
    }
    public string balOrderNo
    {
        get { return orderNo; }
        set { orderNo = value; }
    }
    public DateTime balOrderDt
    {
        get { return orderDt; }
        set { orderDt = value; }
    }
    public string balRemark
    {
        get { return remark; }
        set { remark = value; }
    }
    public string balEdId
    {
        get { return edId; }
        set { edId = value; }
    }
    public string balEsId
    {
        get { return esId; }
        set { esId = value; }
    }
    public string balPayScl
    {
        get { return payScl; }
        set { payScl = value; }
    }
    public string balIncrement
    {
        get { return increment; }
        set { increment = value; }
    }
    public string balkeyId
    {
        get { return keyId; }
        set { keyId = value; }
    }
    public string balEmpCode
    {
        get { return empCode; }
        set { empCode = value; }
    }

    public string balheadValue
    {
        get { return headValue; }
        set { headValue = value; }
    }
    public string balTempId
    {
        get { return tempId; }
        set { tempId = value; }
    }

    public string balHeadId
    {
        get { return headId; }
        set { headId = value; }
    }

    public string balcurUserId
    {
        get { return curUserId; }
        set { curUserId = value; }
    }

    public string balCurEmpCode
    {
        get { return curEmpCode; }
        set { curEmpCode = value; }
    }
    public string balHeadName
    {
        get { return headName; }
        set { headName = value; }
    }
    public string balHeadShortName
    {
        get { return headShortName; }
        set { headShortName = value; }
    }
    public string balHeadType
    {
        get { return headType; }
        set { headType = value; }
    }
    public string balInCal
    {
        get { return inCal; }
        set { inCal = value; }
    }
    public string balDays
    {
        get { return days; }
        set { days = value; }
    }
    public string balMin
    {
        get { return min; }
        set { min = value; }
    }
    public string balMax
    {
        get { return max; }
        set { max = value; }
    }
    public string balArngBy
    {
        get { return arngBy; }
        set { arngBy = value; }
    }
    public string balNod
    {
        get { return nod; }
        set { nod = value; }
    }
    public string balIncType
    {
        get { return incType; }
        set { incType = value; }
    }
    public string balIncValue
    {
        get { return incValue; }
        set { incValue = value; }
    }
    #endregion
}