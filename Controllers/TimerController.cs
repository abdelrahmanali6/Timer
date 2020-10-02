using System;
using Microsoft.AspNetCore.Mvc;
using Timer.Data;
using Timer.Model;
namespace Timer.Controller
{
    [Route("timer")]
    [ApiController]
    public class TimerController : ControllerBase
    {
        private readonly ITimerRecord timer;

        public TimerController(ITimerRecord timer)
        {
            this.timer = timer;
        }

        [HttpGet("/timer/reset/{id}" , Name = "ResetTimer")]
        public ActionResult<TimerModel> ResetTimer(string id)
        {
            TimerModel time = timer.Reset(id);
            if(time !=null)
            {
                return time;
            }
            else
            {
                return NoContent();
            }
        }
        
         [HttpGet("/timer/stop/{id}",Name = "GetTimeByID" )]
        public ActionResult<TimerModel> GetTimeByID(string id)
        {
           TimerModel Time =  timer.endProcess(id);
           if(Time != null)
           {
               return Time;
           }
           else
           {
               return NoContent();
           }
        }

        [HttpGet]
       public TimerModel StartProcess()
       {
            TimerModel ID = timer.startProcess();
            return ID;
       }
    }
}