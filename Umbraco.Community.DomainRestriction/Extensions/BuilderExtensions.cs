namespace Umbraco.Community.DomainRestriction.Extensions;

public static class BuilderExtensions
{
	public static IApplicationBuilder UseDomainRestriction(this IApplicationBuilder builder)
	{
		return builder.UseMiddleware<DomainRestrictionMiddleware>();
	}

	public static IUmbracoBuilder AddDomainRestrictionConfigs(this IUmbracoBuilder builder, Action<DomainRestrictionSettings> defaultOptions = default)
	{
		if (builder.Services.FirstOrDefault(x => x.ServiceType == typeof(DomainRestrictionConfigService)) != null)
		{
			return builder;
		}

		var configSection = builder.Config.GetSection(DomainRestrictionSettings.SectionName);

		var options = builder.Services.AddOptions<DomainRestrictionSettings>()
			.Bind(configSection);

		if (defaultOptions != default)
		{
			options.Configure(defaultOptions);
		}

		options.ValidateDataAnnotations();

		builder.Services.AddSingleton<DomainRestrictionConfigService>();

		return builder;
	}
}