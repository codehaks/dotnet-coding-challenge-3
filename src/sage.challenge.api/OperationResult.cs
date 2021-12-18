using System;
using System.Collections.Generic;
using System.Text;

namespace sage.challenge.api
{
    public record OperationResult<TResponse>
    {
        public TResponse Response { get; private set; }

        public bool Success { get; private set; }
        public string? ErrorMessage { get; private set; }
        public Exception? Exception { get; private set; }

        public static OperationResult<TResponse> BuildSuccess(TResponse result)
        {
            return new OperationResult<TResponse> { Success = true, Response = result };

        }

        public static OperationResult<TResponse> BuildFailure(string errorMessage)
        {
            return new OperationResult<TResponse> { Success = false, ErrorMessage = errorMessage };
        }

        public static OperationResult<TResponse> BuildFailureWithResult(TResponse result, string errorMessage)
        {
            return new OperationResult<TResponse> { Success = false, ErrorMessage = errorMessage, Response = result };
        }

        public static OperationResult<TResponse> BuildFailure(Exception ex)
        {
            return new OperationResult<TResponse> { Success = false, Exception = ex };
        }

        public static OperationResult<TResponse> BuildFailure(Exception ex, string errorMessage)
        {
            return new OperationResult<TResponse> { Success = false, Exception = ex, ErrorMessage = errorMessage };
        }

    }
}
