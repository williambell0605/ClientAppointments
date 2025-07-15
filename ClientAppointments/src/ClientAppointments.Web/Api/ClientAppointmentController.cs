using ClientAppointments.Core.Interfaces;
using ClientAppointments.Core.ProjectAggregate;
using ClientAppointments.Core.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ClientAppointments.Web.Api
{
    public class ClientAppointmentController : BaseApiController
    {
        private readonly IPractitionerSearchService _service;
     
        public ClientAppointmentController(IPractitionerSearchService service)
        {
            _service = service; 
        }

        [HttpGet]
        public async Task<IActionResult> List(string startDate,string endDate)
        {
            var result = await _service.GetAllPractitioners(startDate, endDate);

            if (result.Status == Ardalis.Result.ResultStatus.Ok)
            {
                return Ok(result.Value);
            }
            else
            {
                return BadRequest(result.ValidationErrors);
            }
        }

        [HttpGet("GetAppointments")]
        public async Task<IActionResult> GetAppointments(int id,string startDate,string endDate)
        {
            var result = await _service.GetAppointments(id,startDate, endDate);

            if (result.Status == Ardalis.Result.ResultStatus.Ok)
            {
                return Ok(result.Value);
            }
            else
            {
                return BadRequest(result.ValidationErrors);
            }
        }
    }
}
