using DataProcessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessor.Utils
{
    public class ProcessResult<TData> where TData : class
    {
        public bool Success { get; set; }
        public DataCheckResult CheckResult { get; set; }
        public string CheckResultAsString
        {
            get
            {
                return Enum.GetName(typeof(DataCheckResult), this.CheckResult);
            }
        }
        public TData Data { get; set; }
    }
}
