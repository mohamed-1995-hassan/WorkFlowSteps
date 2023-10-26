using System.Net.NetworkInformation;

namespace WebApplication7.Entities
{
    public class WorkflowInstance
    {
        public Guid Id { get; set; }
        public int StudentId { get; set; }
        public string RequestNo { get; set; }
        public WfType WorkflowType { get; set; }
        public string Initiator { get; set; }
        public DateTime CreationAt { get; set; }
        public WfStatus Status { get; set; }
        public List<UserTask> UserTasks { get; set; } = new();
    }

    public enum WfType
    {
        PrepareStudent = 1,
        JobApplication = 2
        //RecivieStudent
    }

    public enum WfStep
    {
        Init,
        AddNewStudentReview1Step,
        AddNewStudentReview2Step,
        Finished,
        AddBasicInfo,
        ReviewApplication,
        SendEmail,
        DeleteUser,
        SendRecommendation,
        ApplyRecommendation,
        KeepHistory
    }

    public enum WfStatus
    {
        Initiated,
        InProgress,
        Finshied
    }

    [Flags]
    public enum WfDesicion
    {
        Empty = 0,
        Init = 1,
        Approve1 = 2,
        Reject1 = 4,
        Approve2 = 8,
        Reject2 = 16,
        NotResponse = 32,
        Approve3 = 64,

    }


}
