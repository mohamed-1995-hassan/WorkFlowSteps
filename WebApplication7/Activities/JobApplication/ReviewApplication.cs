using WebApplication7.Entities;

namespace WebApplication7.Activities.JobApplication
{
    public class ReviewApplication : IWorkflowActivity
    {
        public WfStep Step => WfStep.ReviewApplication;

        public WfDesicion AvaliableDesicions => WfDesicion.Approve1 | WfDesicion.Reject1;

        public List<string> Authors { get => new List<string> { "S2" }; }

        public List<IWorkflowActivity> NextSteps { get; set; } = new();
        public WfDesicion InCome { get; set; }

        public UserTask Excute(UserTask task)
        {
            return task;
        }
    }
}
