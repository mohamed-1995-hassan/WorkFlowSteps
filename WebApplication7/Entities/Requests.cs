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

        //public static WorkflowInstance InitPrepareStudentWf(string initiator, string requestNo, int studentId)
        //{
        //    var wf = new WorkflowInstance
        //    {
        //        Id = Guid.NewGuid(),
        //        CreationAt = DateTime.Now,
        //        Initiator = initiator,
        //        RequestNo = requestNo,
        //        WorkflowType = WfType.PrepareStudent,
        //        StudentId = studentId
        //    };
        //    var task = new Entities.UserTask { Id = Guid.NewGuid(), AssignTo = "R2", RequestId = wf.Id, WorkflowStep = WfStep.AddNewStudentReview1Step, WorkflowType = WfType.PrepareStudent };
        //    wf.UserTasks.Add(task);
        //    return wf;
        //}

        //public UserTask MoveNext1(UserTask oldTask, int? desicion)
        //{
        //    oldTask.Close(desicion);
        //    if (desicion == 1)
        //    {
        //        Status = WfStatus.InProgress;
        //        var task = new Entities.UserTask { Id = Guid.NewGuid(), AssignTo = "R3", RequestId = Id, WorkflowStep = WfStep.AddNewStudentReview2Step, WorkflowType = WfType.PrepareStudent };
        //        UserTasks.Add(task);
        //        return task;
        //    }
        //    else
        //    {
        //        Status = WfStatus.Finshied;
        //        return null;
        //    }
        //}

        //public void MoveNext2(UserTask oldTask, int? desicion)
        //{
        //    oldTask.Close(desicion);
        //    Status = WfStatus.Finshied;
        //}
    }

    public enum WfType
    {
        PrepareStudent = 1,
        //RecivieStudent
    }

    public enum WfStep
    {
        Init,
        AddNewStudentReview1Step,
        AddNewStudentReview2Step,
        Finished
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
        Reject2 = 16
    }


}
