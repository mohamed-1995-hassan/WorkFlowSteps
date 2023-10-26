using WebApplication7.Entities;

namespace WebApplication7.Activities.JobApplication
{
    public class SendRecommendedJobs : IWorkflowActivity
    {
        public WfStep Step => WfStep.SendRecommendation;

        public WfDesicion AvaliableDesicions => WfDesicion.Approve3 | WfDesicion.Reject2;

        public List<string> Authors { get => new List<string> { "S2" }; }

        public List<IWorkflowActivity> NextSteps { get; set; } = new();
        public WfDesicion InCome { get; set; }

        public UserTask Excute(UserTask task)
        {
            return task;
        }
    }
}
