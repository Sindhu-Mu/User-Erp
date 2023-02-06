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
/// Summary description for QueryFunctions
/// </summary>
/// 
namespace ExamFunctions
{
    public class QueryFunctions
    {

        public enum QueryBaseType
        {
            /// <summary>
            ///  No Parameter
            /// </summary>
            MenuHead, MenuSubHead, SemesterType, ExamType, Session, Examination, Exam, SeatComplex,Shift,Receipt_Id,CourseByID,InsPgmBatch,
            /// <summary>
            //  Two  Parameter
            /// </summary>
            PgmBrnBatch,ScheduleRoom,
            /// <summary>
            //  Three  Parameter
            /// </summary>
            Paper
        };
        public QueryFunctions()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public SqlCommand GetCommand(QueryBaseType type)
        {
            SqlCommand command = null;
            switch (type)
            {

                case QueryBaseType.MenuHead:
                    command = new SqlCommand(" SELECT HEAD_VALUE,HEAD_ID FROM PAGE_HEAD_INF WHERE HEAD_STS=1");
                    command.CommandType = CommandType.Text;
                    break;
                case QueryBaseType.ExamType:
                    command = new SqlCommand("SELECT EXAM_TYPE_VALUE,EXAM_TYPE_ID FROM EXAM_TYPE_INF WHERE IS_ACTIVE=1");
                    command.CommandType = CommandType.Text;
                    break;
                case QueryBaseType.SemesterType:
                    command = new SqlCommand("SELECT SEM_TYPE_VALUE,SEM_TYPE_ID FROM EXAM_SEM_TYPE_INF");
                    command.CommandType = CommandType.Text;
                    break;
                case QueryBaseType.Session:
                    command = new SqlCommand("SELECT SESSION_VALUE,SESSION_ID FROM EXAM_SESSION_INF ORDER BY SESSION_ID DESC");
                    command.CommandType = CommandType.Text;
                    break;
                case QueryBaseType.Examination:
                    command = new SqlCommand("SELECT EXAM_NAME,EXAM_MAIN_ID FROM EXAM_MAIN_INF WHERE EXAM_STS=1 ORDER BY EXAM_MAIN_ID DESC");
                    command.CommandType = CommandType.Text;
                    break;
                case QueryBaseType.Exam:
                    command = new SqlCommand("SELECT EXAM_NAME,EXAM_MAIN_ID from EXAM_MAIN_INF WHERE EXAM_STS = 1 ORDER BY EXAM_MAIN_ID DESC");
                    command.CommandType = CommandType.Text;
                    break;
                case QueryBaseType.SeatComplex:
                    command = new SqlCommand("SELECT CMPLX_VALUE,CMPLX_ID FROM SEAT_CMPLX_INF WHERE CMPLX_STS = 1");
                    command.CommandType = CommandType.Text;
                    break;
                case QueryBaseType.Shift:
                    command = new SqlCommand("SELECT  EXAM_SHIFT_VALUE,EXAM_SHIFT_ID FROM EXAM_SHIFT_INF");
                    command.CommandType = CommandType.Text;
                    break;
                default:
                    break;
            }
            return command;
        }
        public SqlCommand GetCommand(QueryBaseType type, string parameter)
        {
            SqlCommand command = null;
            switch (type)
            {


                case QueryBaseType.MenuSubHead:
                    command = new SqlCommand(" SELECT SUB_HEAD_VALUE,SUB_HEAD_ID FROM PAGE_SUB_HEAD_INF WHERE SUB_HEAD_STS=1 AND HEAD_ID = @PARAMETER");
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@PARAMETER", parameter);
                    break;
                case QueryBaseType.Examination:
                    command = new SqlCommand("SELECT EXAM_NAME,EXAM_MAIN_ID FROM EXAM_MAIN_INF WHERE EXAM_STS=1 AND EXAM_TYPE_ID=@PARAMETER ORDER BY EXAM_MAIN_ID DESC");
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@PARAMETER", parameter);
                    break;
                case QueryBaseType.Receipt_Id:
                    command = new SqlCommand(" SELECT BACK_FEE_RCV_ID FROM EXAM_BACK_REG_FEE_INF WHERE RECIEPT_NO=@PARAMETER");
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@PARAMETER", parameter);
                    break;
                default:
                    break;


            }
            return command;
        }
        public SqlCommand GetCommand(QueryBaseType type, string parameter1, string parameter2)
        {
            SqlCommand command = null;
            switch (type)
            {
                case QueryBaseType.CourseByID:
                    command = new SqlCommand(" SELECT '('+CRS_CODE+')'+CRS_NAME,CRS_EXAM_ID FROM EXAM_CRS_MAIN_INF WHERE CRS_EXAM_STS=1 AND PGM_MAPP_ID = @PARAMETER1 AND ACA_SEM_ID=@PARAMETER2 ORDER BY CRS_CODE");
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@PARAMETER1", parameter1);
                    command.Parameters.AddWithValue("@PARAMETER2", parameter2);
                    break;

                case QueryBaseType.InsPgmBatch:
                    command = new SqlCommand(" SELECT MAPP_VALUE,PGM_MAPP_ID FROM PGM_BRN_BATCH_MAPP_INF WHERE PGM_MAPP_STS=1 AND INS_ID = @PARAMETER1 AND ACA_BATCH_ID=@PARAMETER2 ORDER BY ACA_BATCH_ID");
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@PARAMETER1", parameter1);
                    command.Parameters.AddWithValue("@PARAMETER2", parameter2);
                    break;


                case QueryBaseType.PgmBrnBatch:
                    command = new SqlCommand(" SELECT MAPP_VALUE,PGM_MAPP_ID FROM PGM_BRN_BATCH_MAPP_INF WHERE PGM_MAPP_STS=1 AND PGM_BRN_ID = @PARAMETER1 AND ACA_BATCH_ID=@PARAMETER2 ORDER BY ACA_BATCH_ID");
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@PARAMETER1", parameter1);
                    command.Parameters.AddWithValue("@PARAMETER2", parameter2);
                    break;
                case QueryBaseType.ScheduleRoom:
                    command = new SqlCommand("SELECT  DISTINCT    SEAT_ROOM_INF.ROOM_VALUE,SEAT_ROOM_INF.ROOM_ID FROM EXAM_CRS_SCH_INF INNER JOIN "
                                              + " SEATING_PLAN_INF ON EXAM_CRS_SCH_INF.CRS_SCH_ID = SEATING_PLAN_INF.CRS_SCH_ID INNER JOIN "
                                            + " SEAT_ROW_COL_MAPP_INF ON SEATING_PLAN_INF.SEAT_ID = SEAT_ROW_COL_MAPP_INF.SEAT_ID INNER JOIN "
                                          + " SEAT_ROOM_INF ON SEAT_ROW_COL_MAPP_INF.ROOM_ID = SEAT_ROOM_INF.ROOM_ID "
                                          + " WHERE CONVERT(VARCHAR,SCH_DT,103)=@PARAMETER1 AND EXAM_MAIN_ID=@PARAMETER2");
                    command.Parameters.AddWithValue("@PARAMETER1", parameter1);
                    command.Parameters.AddWithValue("@PARAMETER2", parameter2);
                    break;
                default:
                    break;

            }
            return command;
        }
        public SqlCommand GetCommand(QueryBaseType type, string parameter1, string parameter2, string parameter3)
        {
            SqlCommand command = null;
            switch (type)
            {
                case QueryBaseType.CourseByID:
                    command = new SqlCommand(" SELECT '('+CRS_CODE+')'+CRS_NAME,CRS_EXAM_ID FROM EXAM_CRS_MAIN_INF INNER JOIN PGM_BRN_BATCH_MAPP_INF ON PGM_BRN_BATCH_MAPP_INF.PGM_MAPP_ID=EXAM_CRS_MAIN_INF.PGM_MAPP_ID"
                    + " WHERE CRS_EXAM_STS=1  AND PGM_BRN_ID = @PARAMETER1 AND ACA_SEM_ID=@PARAMETER2 AND ACA_BATCH_ID=@PARAMETER3 ORDER BY CRS_CODE");
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@PARAMETER1", parameter1);
                    command.Parameters.AddWithValue("@PARAMETER2", parameter2);
                    command.Parameters.AddWithValue("@PARAMETER3", parameter3);
                    break;

             


                default:
                    break;

            }
            return command;
        }
    }

}
