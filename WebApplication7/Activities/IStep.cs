﻿using Swashbuckle.AspNetCore.SwaggerGen;
using WebApplication7.Entities;

namespace WebApplication7.Activities
{
    public interface IWorkflowActivity
    {
        WfStep Step { get; }
        WfDesicion AvaliableDesicions { get; }
        public List<string> Authors { get; }
        List<IWorkflowActivity> NextSteps { get; set; }
        WfDesicion InCome { get; set; }
        UserTask Excute(UserTask task);
    }

    public static class StepExtensions
    {
        public static IWorkflowActivity StartWith<T>(this IWorkflowDefiniation wf)
            where T : IWorkflowActivity
        {
            var activity = Activator.CreateInstance<T>();
            activity.InCome = WfDesicion.Init;
            if (activity == null)
                throw new Exception("Init activity is not null.");

            wf.InitActivity = activity;
            return activity;
        }

        public static IWorkflowActivity Then<T>(this IWorkflowActivity currentStep, WfDesicion desicion = WfDesicion.Empty)
            where T : IWorkflowActivity
        {
            var activity = Activator.CreateInstance<T>();
            activity.InCome = desicion;
            currentStep.NextSteps.Add(activity);
            return activity;
        }

        public static void EndWith<T>(this IWorkflowActivity currentStep, WfDesicion desicion = WfDesicion.Empty)
            where T : IWorkflowActivity
        {
            var activity = Activator.CreateInstance<T>();
            activity.InCome = desicion;
            currentStep.NextSteps.Add(activity);
        }

        public static IWorkflowActivity Branch(this IWorkflowActivity wf, WfDesicion desicion, Action<WfDesicion, IWorkflowActivity> branch = null)
        {
            if (branch != null) branch(desicion, wf);
            return wf;
        }
    }
}
