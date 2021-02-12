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

    
    public class TestVerisiOlustur : ControllerBase
    {
        private readonly ITestService _testService;

        public TestVerisiOlustur(ITestService testService)
        {
            _testService = testService;

        }

        
        [HttpPost("veriolustur/{musteriAdeti}/{sepetAdeti}")]
        public void TestVerileriniOlustur(int musteriAdeti,int sepetAdeti)
        {
           
             _testService.TestVerisiOlustur(musteriAdeti, sepetAdeti);
        }
    }
}
