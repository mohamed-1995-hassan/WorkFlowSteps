//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using WebApplication7.Entities;

//namespace WebApplication7.Controllers
//{
//    [Route("api/new-student-wf1")]
//    [ApiController]
//    public class AddNewStudentWf1Controller : ControllerBase
//    {
//        private readonly MnccContext _context;
//        public AddNewStudentWf1Controller(MnccContext context)
//        {
//            _context = context;
//        }

//        [HttpGet("init")]
//        public IActionResult Init(int id, string name)
//        {
//            var student = new Student { Id = id, Name = name };
//            _context.Students.Add(student);

//            var wf = WorkflowInstance.InitPrepareStudentWf("hassan", "fftsikj", id);
//            _context.WorkflowInstances.Add(wf);
//            _context.SaveChanges();

//            return Ok(wf);
//        }



//        [HttpGet("step2/{wfId}/tasks/{taskId}")]
//        public IActionResult Step2(Guid wfId, Guid taskId, int desicion)
//        {
//            var task = _context.UserTasks.FirstOrDefault(c => c.Id == taskId && c.RequestId == wfId && c.WorkflowStep == WfStep.AddNewStudentReview1Step);
//            var wf = _context.WorkflowInstances.FirstOrDefault(c => c.Id == wfId);

//            task.Validate("R2");
//            //do your action, fill student entity
//            //var student = _context.Students.FirstOrDefault(c => c.Id == wf.StudentId);
//            //end region
//            var approvedTask = wf.MoveNext1(task, desicion);

//            _context.SaveChanges();

//            return Ok(new
//            {
//                ApprovedTask = approvedTask
//            });
//        }



//        [HttpGet("step3/{wfId}/tasks/{taskId}")]
//        public IActionResult Step3(Guid wfId, Guid taskId, int desicion)
//        {
//            var task = _context.UserTasks.FirstOrDefault(c => c.Id == taskId && c.RequestId == wfId && c.WorkflowStep == WfStep.AddNewStudentReview2Step);
//            var wf = _context.WorkflowInstances.FirstOrDefault(c => c.Id == wfId);
//            var student = _context.Students.FirstOrDefault(c => c.Id == wf.StudentId);

//            task.Validate("R3");

//            //////////////////////////////////////
//            if (desicion == 1)
//            {
//                student.IsActive = true;
//            }
//            ////////////////////////////////


//            wf.MoveNext2(task, desicion);

//            _context.SaveChanges();

//            return Ok(new
//            {
//                Student = student
//            });
//        }

//    }
//}
