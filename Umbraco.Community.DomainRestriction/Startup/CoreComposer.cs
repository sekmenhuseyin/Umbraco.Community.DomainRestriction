namespace Umbraco.Community.DomainRestriction.Startup;

public class CoreComposer : IComposer
{
	public void Compose(IUmbracoBuilder builder)
	{
		builder.AddDomainRestrictionConfigs();
	}
}