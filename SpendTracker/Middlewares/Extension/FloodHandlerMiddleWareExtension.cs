using SpendTracker.Middlewares.Middlewaare;

namespace SpendTracker.Middlewares.Extension
{
    public static class FloodHandlerMiddleWareExtension
    {

        public static IApplicationBuilder UseFloodHandlerMiddleWare(
       this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<FloodHandlerMiddleware>();
        }
    }
}
