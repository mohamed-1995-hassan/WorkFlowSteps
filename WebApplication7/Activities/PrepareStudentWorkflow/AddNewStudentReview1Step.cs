using WebApplication7.Entities;

namespace WebApplication7.Activities.PrepareStudentWorkflow
{
    public class AddNewStudentReview1Step : IWorkflowActivity
    {
        public WfStep Step { get => WfStep.AddNewStudentReview1Step; }
        public WfDesicion AvaliableDesicions { get => WfDesicion.Approve1 | WfDesicion.Reject1; }
        public List<IWorkflowActivity> NextSteps { get; set; } = new();
        public WfDesicion InCome { get; set; }
        public List<string> Authors { get => new List<string> { "R2" }; }
        public UserTask Excute(UserTask task)
        {
            return task;
        }
    }
}
