namespace Umbraco.Community.DomainRestriction.Config;

public class DomainRestrictionConfigService(IOptionsMonitor<DomainRestrictionSettings> settingsOptionsMonitor)
{
	public DomainRestrictionSettings Settings => settingsOptionsMonitor.CurrentValue;
}