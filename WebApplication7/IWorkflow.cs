using System.Xml.Linq;
using WebApplication7.Activities;
using WebApplication7.Activities.Common;
using WebApplication7.Activities.PrepareStudentWorkflow;
using WebApplication7.Entities;

namespace WebApplication7
{
    public interface IWorkflowDefiniation
    {
        public WfType Type { get; }
        public IWorkflowActivity? InitActivity { get; set; }
        public IWorkflowActivity MoveNext(UserTask task, IWorkflowActivity activity = null, List<IWorkflowActivity> steps = null);
    }

    public class PrepareStudentWorkflowDefiniation1 
    {
        
    }

}
