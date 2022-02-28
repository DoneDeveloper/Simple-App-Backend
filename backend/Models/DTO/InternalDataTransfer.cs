using Arx.ElpeChargeGo.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arx.ElpeChargeGo.Core.Models.DTO
{
    public class InternalDataTransfer<T>
    {
        public bool Status { get; set; }
        public T Data { get; set; }
        public IntrnalErrorObject Error { get; set; }

        public InternalDataTransfer()
        {
        }

        public InternalDataTransfer(T data)
        {
            Status = true;
            Data = data;
        }

        public InternalDataTransfer(Exception e)
        {
            Status = false;
            Error = new IntrnalErrorObject(e);
        }

        public InternalDataTransfer(IntrnalErrorObject error)
        {
            Status = false;
            Error = error;

        }
        public InternalDataTransfer(bool status, string description, string details = null)
        {
            Status = status;
            if (!status)
            {
                Error = new IntrnalErrorObject(description, details);
            }
        }


        //ErrorObject
        public class IntrnalErrorObject
        {
            public string Error { get; set; }
            public string Description { get; set; }
            public string Details { get; set; }
            public bool IsExceptionTypeError { get; set; }

            public IntrnalErrorObject()
            {
            }

            public IntrnalErrorObject(Exception e)
            {
                Error = e.Message;
                Description = e.StackTrace;
                IsExceptionTypeError = true;
            }

            public IntrnalErrorObject(Exception e, string description)
            {
                if (description == null)
                {
                    Error = e.Message;
                    Description = e.StackTrace;
                    IsExceptionTypeError = true;
                }
                else
                {
                    Error = $"Message: { e.Message }, StackTrace: { e.StackTrace }";
                    Description = description;
                    IsExceptionTypeError = true;
                }

            }

            public IntrnalErrorObject(string description, string details = null)
            {
                Error = "Error";
                Description = description;
                Details = details;
                IsExceptionTypeError = false;
            }
           

           

            public class TheTypeError<TypeError> where TypeError : Enum
            {
                public TheTypeError()
                {
                }

                public TheTypeError(TypeError typeError)
                {
                    Value = typeError;
                }

                public TypeError Value { get; set; }
            }
        }
    }
}
