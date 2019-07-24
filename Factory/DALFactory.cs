using System;
using System.Reflection;
using WC.IDAL;
using System.Configuration;
/// DALFactory 的摘要说明
/// </summary>
namespace WC.Factory
{
    public class DALFactory
    {
        private static readonly string path = ConfigurationManager.AppSettings["WebDAL"];
        public static IBas_Com CreateBas_ComDAL()
        {
            if (true)
            {
            }
            string typeName = DALFactory.path + ".Bas_ComDAL";

         

            return (IBas_Com)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static ISys_User CreateSys_UserDAL()
        {
            if (true)
            {
            }
            string typeName = DALFactory.path + ".Sys_UserDAL";
            return (ISys_User)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static ISys_Module CreateSys_ModuleDAL()
        {
            string typeName = DALFactory.path + ".Sys_ModuleDAL";
            ISys_Module result = (ISys_Module)Assembly.Load(DALFactory.path).CreateInstance(typeName);
            if (true)
            {
            }
            return result;
        }
        public static ISys_Dep_Module CreateSys_Dep_ModuleDAL()
        {
            string typeName = DALFactory.path + ".Sys_Dep_ModuleDAL";
            ISys_Dep_Module result = (ISys_Dep_Module)Assembly.Load(DALFactory.path).CreateInstance(typeName);
            if (true)
            {
            }
            return result;
        }
        public static ISys_Role_Module CreateSys_Role_ModuleDAL()
        {
            if (true)
            {
            }
            string typeName = DALFactory.path + ".Sys_Role_ModuleDAL";
            return (ISys_Role_Module)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static INews_Type CreateNews_TypeDAL()
        {
            string typeName = DALFactory.path + ".News_TypeDAL";
            return (INews_Type)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static ISys_UserLogin CreateSys_UserLoginDAL()
        {
            string typeName = DALFactory.path + ".Sys_UserLoginDAL";
            return (ISys_UserLogin)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static INews_Article CreateNews_ArticleDAL()
        {
            string typeName = DALFactory.path + ".News_ArticleDAL";
            return (INews_Article)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static IZEX2 CreateZEX2DAL()
        {
            string typeName = DALFactory.path + ".ZEX2DAL";
            return (IZEX2)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static ITips CreateTipsDAL()
        {
            string typeName = DALFactory.path + ".TipsDAL";
            return (ITips)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static ISys_Dep CreateSys_DepDAL()
        {
            string typeName = DALFactory.path + ".Sys_DepDAL";
            return (ISys_Dep)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static ISys_Role CreateSys_RoleDAL()
        {
            string typeName = DALFactory.path + ".Sys_RoleDAL";
            return (ISys_Role)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static IGov_Model CreateGov_ModelDAL()
        {
            string typeName = DALFactory.path + ".Gov_ModelDAL";
            return (IGov_Model)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static IGov CreateGovDAL()
        {
            string typeName = DALFactory.path + ".GovDAL";
            return (IGov)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static IGov_Doc CreateGov_DocDAL()
        {
            string typeName = DALFactory.path + ".Gov_DocDAL";
            return (IGov_Doc)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static IGov_Step CreateGov_StepDAL()
        {
            string typeName = DALFactory.path + ".Gov_StepDAL";
            return (IGov_Step)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static IGov_Recipient CreateGov_RecipientDAL()
        {
            string typeName = DALFactory.path + ".Gov_RecipientDAL";
            return (IGov_Recipient)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static IGov_ModelFile CreateGov_ModelFileDAL()
        {
            string typeName = DALFactory.path + ".Gov_ModelFileDAL";
            return (IGov_ModelFile)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static IGov_ModelStep CreateGov_ModelStepDAL()
        {
            string typeName = DALFactory.path + ".Gov_ModelStepDAL";
            return (IGov_ModelStep)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static IGov_Model_Type CreateGov_Model_TypeDAL()
        {
            string typeName = DALFactory.path + ".Gov_Model_TypeDAL";
            return (IGov_Model_Type)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static ICalendarMemo_Calendars CreateCalendarMemo_CalendarsDAL()
        {
            string typeName = DALFactory.path + ".CalendarsDAL";
            return (ICalendarMemo_Calendars)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static IFlows CreateFlowsDAL()
        {
            string typeName = DALFactory.path + ".FlowsDAL";
            return (IFlows)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static IFlows_Model CreateFlows_ModelDAL()
        {
            string typeName = DALFactory.path + ".Flows_ModelDAL";
            return (IFlows_Model)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static IFlows_Step CreateFlows_StepDAL()
        {
            string typeName = DALFactory.path + ".Flows_StepDAL";
            return (IFlows_Step)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static IFlows_Doc CreateFlows_DocDAL()
        {
            string typeName = DALFactory.path + ".Flows_DocDAL";
            return (IFlows_Doc)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static IFlows_ModelFile CreateFlows_ModelFileDAL()
        {
            string typeName = DALFactory.path + ".Flows_ModelFileDAL";
            return (IFlows_ModelFile)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static IFlows_ModelStep CreateFlows_ModelStepDAL()
        {
            string typeName = DALFactory.path + ".Flows_ModelStepDAL";
            return (IFlows_ModelStep)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static IFlows_Model_Type CreateFlows_Model_TypeDAL()
        {
            string typeName = DALFactory.path + ".Flows_Model_TypeDAL";
            return (IFlows_Model_Type)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static IFlows_StepAction CreateFlows_StepActionDAL()
        {
            string typeName = DALFactory.path + ".Flows_StepActionDAL";
            return (IFlows_StepAction)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static IMails_Detail CreateMails_DetailDAL()
        {
            string typeName = DALFactory.path + ".Mails_DetailDAL";
            return (IMails_Detail)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static IMails CreateMailsDAL()
        {
            string typeName = DALFactory.path + ".MailsDAL";
            return (IMails)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static ISys_Seal CreateSys_SealDAL()
        {
            string typeName = DALFactory.path + ".Sys_SealDAL";
            return (ISys_Seal)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static IMeeting CreateMeetingDAL()
        {
            string typeName = DALFactory.path + ".MeetingDAL";
            return (IMeeting)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static INoteBook CreateNoteBookDAL()
        {
            string typeName = DALFactory.path + ".NoteBookDAL";
            return (INoteBook)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static IPhoneBook CreatePhoneBookDAL()
        {
            string typeName = DALFactory.path + ".PhoneBookDAL";
            return (IPhoneBook)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static IDocs_DocType CreateDocs_DocTypeDAL()
        {
            string typeName = DALFactory.path + ".Docs_DocTypeDAL";
            return (IDocs_DocType)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static IDocs_Doc CreateDocs_DocDAL()
        {
            string typeName = DALFactory.path + ".Docs_DocDAL";
            return (IDocs_Doc)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static IPaperType CreatePaperTypeDAL()
        {
            string typeName = DALFactory.path + ".PaperTypeDAL";
            return (IPaperType)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static IPaper CreatePaperDAL()
        {
            string typeName = DALFactory.path + ".PaperDAL";
            return (IPaper)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static IPaperDownload CreatePaperDownloadDAL()
        {
            string typeName = DALFactory.path + ".PaperDownloadDAL";
            return (IPaperDownload)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static ITasks CreateTasksDAL()
        {
            string typeName = DALFactory.path + ".TasksDAL";
            return (ITasks)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static ITasks_Type CreateTasks_TypeDAL()
        {
            string typeName = DALFactory.path + ".Tasks_TypeDAL";
            return (ITasks_Type)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static ITasks_User CreateTasks_UserDAL()
        {
            string typeName = DALFactory.path + ".Tasks_UserDAL";
            return (ITasks_User)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static IWork_Attend CreateWork_AttendDAL()
        {
            string typeName = DALFactory.path + ".Work_AttendDAL";
            return (IWork_Attend)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static IWork_AttendSet CreateWork_AttendSetDAL()
        {
            string typeName = DALFactory.path + ".Work_AttendSetDAL";
            return (IWork_AttendSet)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static ICRM_Contact CreateCRM_ContactDAL()
        {
            string typeName = DALFactory.path + ".CRM_ContactDAL";
            return (ICRM_Contact)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static ICRM CreateCRMDAL()
        {
            string typeName = DALFactory.path + ".CRMDAL";
            return (ICRM)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static ICRM_Sup CreateCRM_SupDAL()
        {
            string typeName = DALFactory.path + ".CRM_SupDAL";
            return (ICRM_Sup)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static ISms_Data CreateSms_DataDAL()
        {
            string typeName = DALFactory.path + ".Sms_DataDAL";
            return (ISms_Data)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static IVote CreateVoteDAL()
        {
            string typeName = DALFactory.path + ".VoteDAL";
            return (IVote)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static IVoteDetail CreateVoteDetailDAL()
        {
            string typeName = DALFactory.path + ".VoteDetailDAL";
            return (IVoteDetail)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static IWorkLog CreateWorkLogDAL()
        {
            string typeName = DALFactory.path + ".WorkLogDAL";
            return (IWorkLog)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }
        public static IGov_StepAction CreateGov_StepActionDAL()
        {
            string typeName = DALFactory.path + ".Gov_StepActionDAL";
            return (IGov_StepAction)Assembly.Load(DALFactory.path).CreateInstance(typeName);
        }


    }

}