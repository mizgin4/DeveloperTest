using AdaTestProjesi.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaTestProjesi.Services
{
    public interface IReportService
    {
        IEnumerable<ReportDto> ReturnReport();
    }
}
