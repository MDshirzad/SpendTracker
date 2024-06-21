 

namespace SpendTracker.Middlewares.Middlewaare
{
    public   class FloodHandlerMiddleware
    {
        private readonly RequestDelegate _next;
       
        public FloodHandlerMiddleware(RequestDelegate next) => _next = next;
         
        public async Task InvokeAsync(HttpContext context)
        {
           
            await _next(context);
        }

    }
}
