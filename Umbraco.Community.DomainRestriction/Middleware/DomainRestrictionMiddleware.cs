namespace Umbraco.Community.DomainRestriction.Middleware;

public class DomainRestrictionMiddleware(
	RequestDelegate next,
	DomainRestrictionConfigService domainRestrictionConfigService
)
{
	public async Task Invoke(HttpContext context)
	{
		var isEnabled = domainRestrictionConfigService.Settings.Enabled;
		var umbracoDomain = domainRestrictionConfigService.Settings.UmbracoDomain;
		var umbracoPath = domainRestrictionConfigService.Settings.UmbracoPath.TrimStart('~');
		var requestedPath = context.Request.Path.ToString();
		var requestedHost = context.Request.Host.ToString();

		if (!isEnabled || string.IsNullOrWhiteSpace(umbracoDomain) || string.IsNullOrWhiteSpace(umbracoPath))
		{
			await next.Invoke(context);
			return;
		}

		if (requestedPath.InvariantContains(umbracoPath) && requestedHost.InvariantContains(umbracoDomain))
		{
			context.Response.StatusCode = (int)HttpStatusCode.NotFound;
			if (!string.IsNullOrWhiteSpace(domainRestrictionConfigService.Settings.RedirectUrl))
			{
				context.Response.Redirect(domainRestrictionConfigService.Settings.RedirectUrl);
			}
		}

		await next.Invoke(context);
	}
}