using AdaTestProjesi.Models.Dto;
using AdaTestProjesi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaTestProjesi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;

        }

        [HttpGet("getreport")]
        public IEnumerable<ReportDto> GetReport()
        {
            IEnumerable<ReportDto> reportDto = _reportService.ReturnReport();

            return reportDto;
        }
        
    }
}
