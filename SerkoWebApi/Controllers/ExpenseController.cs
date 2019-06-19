using DataProcessor.Processors;
using DataProcessor.Interfaces;
using DataProcessor.Models;
using DataProcessor.Utils;
using SerkoWebApi.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SerkoWebApi.Controllers
{
    [RoutePrefix("api/Expense")]
    public class ExpenseController : BaseApiController
    {
		[HttpPost]
		[Route("ProcessEmailText")]
        public object ProcessEmailText()
        {
            string inputData = GetObjectFromRequest();
            TextDataProcessor processor = new TextDataProcessor(new XmlDataChecker(), new ExpenseClaimParser());
            ProcessResult<ExpenseClaim> processResult = processor.Process<ExpenseClaim>(inputData);
            return processResult;
        }
    }
}
