using DataProcessor.Interfaces;
using DataProcessor.Models;
using DataProcessor.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessor.Processors
{
    public class TextDataProcessor
    {
        private IDataChecker dataChecker;
        private IDataParser dataParser;

        public TextDataProcessor(IDataChecker dataChecker, IDataParser dataParser)
        {
            this.dataChecker = dataChecker;
            this.dataParser = dataParser;
        }

        public ProcessResult<TData> Process<TData>(string inputData) where TData : class
        {
            ProcessResult<TData> processResult = new ProcessResult<TData>()
            {
                Success = false,
                CheckResult = DataCheckResult.Undefined
            };

            DataCheckResult checkResult = dataChecker.CheckData(inputData);
            if (checkResult != DataCheckResult.DataAreWellFormed)
            {
                processResult.CheckResult = checkResult;
                return processResult;
            }

            processResult = dataParser.Parse<TData>(inputData);
            return processResult;
        }
    }
}
