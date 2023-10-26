using WebApplication7.Activities;
using WebApplication7.Activities.Common;
using WebApplication7.Activities.JobApplication;
using WebApplication7.Activities.PrepareStudentWorkflow;
using WebApplication7.Entities;

namespace WebApplication7.WorkFlows
{
    public class JobApplicationWorkflowDefiniation : IWorkflowDefiniation
    {
        public WfType Type => WfType.JobApplication;

        public IWorkflowActivity? InitActivity { get; set; }

        public JobApplicationWorkflowDefiniation()
        {
            this.StartWith<InitStep>()
                .Then<ReviewApplication>()
                    .Branch(WfDesicion.Approve1,
                        (d, fl) =>
                        {
                            fl.Then<SendEmail>(d)
                              .Branch(WfDesicion.Approve2,
                                (dd, ffl) =>
                                {
                                    ffl.EndWith<FinishedStep>(dd);
                                })
                              .Branch(WfDesicion.NotResponse,
                                (dd, ffl) =>
                                {
                                    ffl.Then<DeleteUser>()
                                       .EndWith<FinishedStep>(dd);
                                });
                        })
                    .Branch(WfDesicion.Reject1,
                        (d, fl) =>
                        {
                            fl.Then<SendRecommendedJobs>(d)
                              .Branch(WfDesicion.Approve3,
                                (dd, ff) =>
                                {
                                    ff.Then<ApplyRecommendation>()
                                      .EndWith<FinishedStep>(dd);
                                })
                              .Branch(WfDesicion.Reject2,
                                (dd, ff) =>
                                {
                                    ff.Then<KeepTheUserHistory>();
                                    ff.EndWith<FinishedStep>(dd);
                                });
                        });
        }

        public IWorkflowActivity MoveNext(UserTask task, IWorkflowActivity activity = null, List<IWorkflowActivity> steps = null)
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
