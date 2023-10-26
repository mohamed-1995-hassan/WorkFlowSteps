using WebApplication7.Entities;

namespace WebApplication7.Activities.JobApplication
{
    public class ApplyRecommendation : IWorkflowActivity
    {
        public WfStep Step => WfStep.ApplyRecommendation;

        public WfDesicion AvaliableDesicions => WfDesicion.NotResponse;

        public List<string> Authors { get => new List<string> { "S2" }; }

        public List<IWorkflowActivity> NextSteps { get; set; } = new();
        public WfDesicion InCome { get ; set ; }

        public UserTask Excute(UserTask task)
        {
            return task;
        }
    }
}
