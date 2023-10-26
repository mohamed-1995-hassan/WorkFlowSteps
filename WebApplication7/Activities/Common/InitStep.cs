using WebApplication7.Entities;

namespace WebApplication7.Activities.Common
{
    public class InitStep : IWorkflowActivity
    {
        public WfStep Step { get => WfStep.Init; }
        public WfDesicion AvaliableDesicions { get => WfDesicion.Init; }
        public List<IWorkflowActivity> NextSteps { get; set; } = new();
        public WfDesicion InCome { get; set; }
        public List<string> Authors { get => new List<string> { "R1" }; }
        public UserTask Excute(UserTask task)
        {
            return task;
        }
    }
}
