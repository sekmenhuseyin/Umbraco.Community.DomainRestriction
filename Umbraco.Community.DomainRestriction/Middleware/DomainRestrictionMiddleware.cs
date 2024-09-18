namespace Umbraco.Community.DomainRestriction.Middleware;

public class DomainRestrictionMiddleware(
	RequestDelegate next,
	DomainRestrictionConfigService domainRestrictionConfigService
)
{
	public async Task Invoke(HttpContext context)
	{
		if (!domainRestrictionConfigService.Settings.Enabled)
		{
			await next.Invoke(context);
			return;
		}

		var umbracoPath = domainRestrictionConfigService.Settings.UmbracoPath.TrimStart('~');
		var requestedPath = context.Request.Path.ToString();

		if (requestedPath.InvariantContains(umbracoPath))
		{
			await next.Invoke(context);
			return;
		}

		var umbracoDomain = domainRestrictionConfigService.Settings.UmbracoDomain;
		var host = context.Request.Host.ToString();
		if (host.InvariantContains(umbracoDomain))
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