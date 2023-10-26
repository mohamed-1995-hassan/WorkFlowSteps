using WebApplication7.Entities;

namespace WebApplication7.Activities.PrepareStudentWorkflow
{
    public class AddNewStudentReview2Step : IWorkflowActivity
    {
        public WfStep Step { get => WfStep.AddNewStudentReview2Step; }
        public WfDesicion AvaliableDesicions { get => WfDesicion.Approve2 | WfDesicion.Reject2; }
        public List<IWorkflowActivity> NextSteps { get; set; } = new();
        public WfDesicion InCome { get; set; }
        public List<string> Authors { get => new List<string> { "R3" }; }
        public UserTask Excute(UserTask task)
        {
            return task;
        }
    }
}
