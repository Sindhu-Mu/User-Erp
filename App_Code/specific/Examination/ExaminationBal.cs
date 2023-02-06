using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ExaminationBal
/// </summary>
public class ExaminationBal
{
    public ExaminationBal()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region Definition
    public string Semid { get; set; }
    public string SessionUserID { get; set; }
    public string Id { get; set; }
    public string XmlValue { get; set; }
    public string Value { get; set; }
    public string KeyValue { get; set; }
    public string KeyID { get; set; }
    public string Description { get; set; }
    public string ValueType { get; set; }
    public string TypeId { get; set; }


    public string ChangeStatus { get; set; }

    public string InsId { get; set; }

    public string EmpId { get; set; }

    public string DeptId { get; set; }


    public DateTime FromDate { get; set; }

    public DateTime ToDate { get; set; }

    public DateTime Date { get; set; }

    public string Name { get; set; }



    public string View_File { get; set; }



    public string MobileNo { get; set; }


    public string BatchId { get; set; }
    public string ProgramId { get; set; }

    public string BranchId { get; set; }

    public string SectionId { get; set; }

    public string EnrollmentNo { get; set; }
    public string StudentId { get; set; }

    public string Marks { get; set; }

    public string PaperId { get; set; }


    public string Year { get; set; }




    public string ExamId { get; set; }


    public string Remark { get; set; }


    #endregion

}