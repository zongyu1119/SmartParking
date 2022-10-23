using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Share.Contracts
{
    [Serializable]
    public sealed class AppSrvResult
    {
        public bool IsSuccess => ProblemDetails == null;

        public ProblemDetails ProblemDetails { get; set; }

        public AppSrvResult()
        {
        }

        public AppSrvResult(ProblemDetails problemDetails)
        {
            ProblemDetails = problemDetails;
        }

        public static implicit operator AppSrvResult(ProblemDetails problemDetails)
        {
            return new AppSrvResult
            {
                ProblemDetails = problemDetails
            };
        }
    }
    [Serializable]
    public sealed class AppSrvResult<TValue>
    {
        public bool IsSuccess
        {
            get
            {
                if (ProblemDetails == null)
                {
                    return Content != null;
                }

                return false;
            }
        }

        public TValue Content { get; set; }

        public ProblemDetails ProblemDetails { get; set; }

        public AppSrvResult()
        {
        }

        public AppSrvResult(TValue value)
        {
            Content = value;
        }

        public AppSrvResult(ProblemDetails problemDetails)
        {
            ProblemDetails = problemDetails;
        }

        public static implicit operator AppSrvResult<TValue>(AppSrvResult result)
        {
            return new AppSrvResult<TValue>
            {
                Content = default(TValue),
                ProblemDetails = result.ProblemDetails
            };
        }

        public static implicit operator AppSrvResult<TValue>(ProblemDetails problemDetails)
        {
            return new AppSrvResult<TValue>
            {
                Content = default(TValue),
                ProblemDetails = problemDetails
            };
        }

        public static implicit operator AppSrvResult<TValue>(TValue value)
        {
            return new AppSrvResult<TValue>(value);
        }
    }
}
