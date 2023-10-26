using WebApplication7.Activities.Common;
using WebApplication7.Activities.PrepareStudentWorkflow;
using WebApplication7.Activities;
using WebApplication7.Entities;

namespace WebApplication7.WorkFlows
{
    public class PrepareStudentWorkflowDefiniation : IWorkflowDefiniation
    {
        public WfType Type { get => WfType.PrepareStudent; }
        public IWorkflowActivity? InitActivity { get; set; }
        public PrepareStudentWorkflowDefiniation()
        {
            this.StartWith<InitStep>()
                .Then<AddNewStudentReview1Step>()
                    .Branch(WfDesicion.Approve1,
                        (d, fl) =>
                        {
                            fl.Then<AddNewStudentReview2Step>(d)
                              .Branch(WfDesicion.Approve2,
                                (dd, ffl) =>
                                {
                                    ffl.EndWith<FinishedStep>(dd);
                                })
                              .Branch(WfDesicion.Reject2,
                                (dd, ffl) =>
                                {
                                    ffl.EndWith<FinishedStep>(dd);
                                });
                        })
                    .Branch(WfDesicion.Reject1,
                        (d, fl) =>
                        {
                            fl.EndWith<FinishedStep>(d);
                        });
        }

        public IWorkflowActivity MoveNext(UserTask task = null, IWorkflowActivity activity = null, List<IWorkflowActivity> steps = null)
        {
            if (activity?.Step == task.CurrentWorkflowStep)
                return activity;

            if (steps == null)
                steps = InitActivity.NextSteps;

            foreach (var step in steps)
            {
                var found = MoveNext(task, step, step.NextSteps);

                if (found != null)
                {
                    //task.Validate(found.Authors);
                    task.IsClosed = false;
                    var workflowActivity = found.NextSteps.FirstOrDefault(c => c.InCome == task.Desicion);

                    if (workflowActivity is null)
                        return found;

                    return workflowActivity;
                }
            }

            return default;
        }
    }
}
