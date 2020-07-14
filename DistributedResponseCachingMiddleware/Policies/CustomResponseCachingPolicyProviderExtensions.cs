using Microsoft.AspNetCore.ResponseCaching.Internal;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
	/// <summary>
	/// Extension methods for the ResponseCaching Policies.
	/// </summary>
	public static class CustomResponseCachingPolicyProviderExtensions
	{
		/// <summary>
		/// Add policy that allows caching even if it exists an Authorization header.
		/// </summary>
		/// <param name="services">The <see cref="IServiceCollection"/> for adding services.</param>
		/// <returns></returns>
		public static IServiceCollection AddAllowAuthorizationResponseCachingPolicy(this IServiceCollection services)
		{
			if (services == null)
			{
				throw new ArgumentNullException(nameof(services));
			}

            services.Add(ServiceDescriptor.Singleton<IResponseCachingPolicyProvider, AllowAuthorizationResponseCachingPolicyProvider>());
			return services;
		}
    }
}
