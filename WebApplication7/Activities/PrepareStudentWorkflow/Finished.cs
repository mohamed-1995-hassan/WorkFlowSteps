using WebApplication7.Entities;

namespace WebApplication7.Activities.PrepareStudentWorkflow
{
    public class FinishedStep : IWorkflowActivity
    {
        public WfStep Step { get => WfStep.Finished; }
        public WfDesicion AvaliableDesicions { get => WfDesicion.Empty; }
        public List<IWorkflowActivity> NextSteps { get; set; } = new();
        public WfDesicion InCome { get; set; }
        public List<string> Authors { get => new List<string> { "R2", "R3" }; }
        public UserTask Excute(UserTask task)
        {
            return task;
        }
    }
}
