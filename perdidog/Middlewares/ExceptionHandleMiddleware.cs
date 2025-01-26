namespace perdidog.Middlewares
{
    public class ExceptionHandleMiddleware
    {
        private readonly ILogger<ExceptionHandleMiddleware> logger;
        private readonly RequestDelegate next;

        public ExceptionHandleMiddleware(ILogger<ExceptionHandleMiddleware> logger, 
            RequestDelegate next)
        {
            this.logger = logger;
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex) {
                var errorId = Guid.NewGuid();
                logger.LogError(ex,$"{errorId}: {ex.Message}");

                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                httpContext.Response.ContentType = "application/json";

                var error = new
                {
                    id = errorId,
                    message = "Something went wrong",
                };

                await httpContext.Response.WriteAsJsonAsync(error);
            }

        }
    }
}
