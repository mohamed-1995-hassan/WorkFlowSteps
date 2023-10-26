using Microsoft.AspNetCore.Mvc;

namespace WebApplication7.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
            var wf = new PrepareStudentWorkflowDefiniation();

            var ss = wf.MoveNext(new Entities.UserTask
            {
                CurrentWorkflowStep = Entities.WfStep.AddNewStudentReview1Step,
                Desicion = Entities.WfDesicion.Approve1,
                AssignTo = "R2"
            });
            //var oldTask = new Entities.UserTask
            //{
            //    CurrentWorkflowStep = Entities.WfStep.AddNewStudentReview2Step,
            //    Desicion = Entities.WfDesicion.Approve2,
            //    AssignTo = "R3"
            //};

            //var nextStep = wf.MoveNext(oldTask);

            //if (nextStep != null)
            //    nextStep.Excute(oldTask);

            return Ok(new
            {
               ss
               //nextStep
            });
        }
    }
}