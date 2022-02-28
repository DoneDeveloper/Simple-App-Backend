using Arx.ElpeChargeGo.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class APIResult<TData>
    {
        public bool Status { get; set; }
        public string Description { get; set; } = null;
        public TData Data { get; set; }
        public ErrorApiResult Error { get; set; }

        public class ErrorApiResult
        {
            public ProjectErrorCodes ErrorCode { get; set; }
            public string Description { get; set; }
        }

        public APIResult(ProjectErrorCodes code, string description = null)
        {
            Status = false;
            Error = new ErrorApiResult
            {
                ErrorCode = code,
                Description = description
            };
        }

        public APIResult(TData data, string descr = null)
        {
            Status = true;
            Data = data;
            Description = descr;
            Error = null;
        }
    }
}
