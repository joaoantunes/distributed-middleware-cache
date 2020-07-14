using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.ResponseCaching.Internal;

/// <summary>
/// Overrides the default behaviour of ResponseCachingPolicyProvider
/// and allows requests with Authorization header to be cached
/// </summary>
public class AllowAuthorizationResponseCachingPolicyProvider : ResponseCachingPolicyProvider
{
    public override bool AttemptResponseCaching(ResponseCachingContext context)
    {
        var request = context.HttpContext.Request;
        if (!HttpMethods.IsGet(request.Method) && !HttpMethods.IsHead(request.Method))
        {
            context.Logger.LogRequestMethodNotCacheable(request.Method);
            return false;
        }
        return true;
    }
}
