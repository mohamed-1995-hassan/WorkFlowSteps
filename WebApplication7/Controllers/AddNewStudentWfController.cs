using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication7.Entities;

namespace WebApplication7.Controllers
{
    [Route("api/new-student-wf")]
    [ApiController]
    public class AddNewStudentWfController : ControllerBase
    {
        private readonly MnccContext _context;
        public AddNewStudentWfController(MnccContext context)
        {
            _context = context;
        }

        [HttpGet("init")]
        public IActionResult Init(int id, string name)
        {
            var student = new Student { Id = id, Name = name };
            _context.Students.Add(student);
            var request = new Entities.WorkflowInstance { Id = Guid.NewGuid(), CreationAt = DateTime.Now, Initiator = "hassan", RequestNo = Guid.NewGuid().ToString(), Status = WfStatus.Initiated, StudentId = id, WorkflowType = WfType.PrepareStudent };
            _context.WorkflowInstances.Add(request);
            var task = new Entities.UserTask { Id = Guid.NewGuid(), AssignTo = "R2", RequestId = request.Id, CurrentWorkflowStep = WfStep.AddNewStudentReview1Step, WorkflowType = WfType.PrepareStudent };
            _context.UserTasks.Add(task);
            _context.SaveChanges();

            return Ok(new
            {
                Student = student,
                Request = request,
                Task = task
            });
        }



        [HttpGet("step2/{wfId}/tasks/{taskId}")]
        public IActionResult Step2(Guid wfId, Guid taskId, int desicion)
        {
            var task = _context.UserTasks.FirstOrDefault(c => c.Id == taskId && c.RequestId == wfId && c.CurrentWorkflowStep == WfStep.AddNewStudentReview1Step);
            var request = _context.WorkflowInstances.FirstOrDefault(c => c.Id == wfId);
            var student = _context.Students.FirstOrDefault(c => c.Id == request.StudentId);


            if (task == null)
                return NotFound();

            if (task.IsClosed)
                return Unauthorized();

            task.IsClosed = true;

            if (desicion != 1)
                return Ok(new
                {
                    Student = student
                });

            request.Status = WfStatus.InProgress;
            var approvedTask = new Entities.UserTask { Id = Guid.NewGuid(), AssignTo = "R3", RequestId = request.Id, CurrentWorkflowStep = WfStep.AddNewStudentReview2Step, WorkflowType = WfType.PrepareStudent };
            _context.UserTasks.Add(approvedTask);
            _context.SaveChanges();

            return Ok(new
            {
                ApprovedTask = approvedTask
            });
        }



        [HttpGet("step3/{wfId}/tasks/{taskId}")]
        public IActionResult Step3(Guid wfId, Guid taskId, int desicion)
        {
            var task = _context.UserTasks.FirstOrDefault(c => c.Id == taskId && c.RequestId == wfId && c.CurrentWorkflowStep == WfStep.AddNewStudentReview2Step);
            var request = _context.WorkflowInstances.FirstOrDefault(c => c.Id == wfId);
            var student = _context.Students.FirstOrDefault(c => c.Id == request.StudentId);


            if (task == null)
                return NotFound();

            if (task.IsClosed)
                return Unauthorized();

            task.IsClosed = true;

            if (desicion != 1)
                return Ok(new
                {
                    Student = student
                });

            request.Status = WfStatus.Finshied;
            student.IsActive = true;
            _context.SaveChanges();

            return Ok(new
            {
                Student = student
            });
        }

    }
}
